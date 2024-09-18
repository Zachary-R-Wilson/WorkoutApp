using Microsoft.Data.SqlClient;
using System.Data;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly SqlConnection _connection;

        public WorkoutRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <inheritdoc />
        public void CreateWorkout(Guid userKey, WorkoutModel model)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            using (SqlTransaction transaction = _connection.BeginTransaction())
            {
                try
                {
                    Guid? workoutKey = null;

                    using (SqlCommand command = new SqlCommand("CreateWorkout", _connection, transaction))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserKey", SqlDbType.UniqueIdentifier) { Value = userKey });
                        command.Parameters.Add(new SqlParameter("@WorkoutName", SqlDbType.NVarChar, 256) { Value = model.Name });
                        object result = command.ExecuteScalar();

                        workoutKey = (Guid)result;
                    }

                    model.Days.Keys.ToList().ForEach(dayName =>
                    {
                        Guid dayKey = CreateDay(workoutKey, dayName, transaction);
                        model.Days[dayName].ForEach(exercise => CreateExercise(dayKey, exercise, transaction));
                    });

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        /// <inheritdoc />
        public void DeleteWorkout(Guid workoutKey)
        {
            using (SqlCommand command = new SqlCommand("DeleteWorkout", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@WorkoutKey", SqlDbType.UniqueIdentifier) { Value = workoutKey });

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        /// <inheritdoc />
        public WorkoutModel GetWorkout(Guid workoutKey)
        {
            using (SqlCommand command = new SqlCommand("GetWorkout", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@WorkoutKey", SqlDbType.UniqueIdentifier) { Value = workoutKey });
                _connection.Open();

                WorkoutModel workout = null;
                var daysDictionary = new Dictionary<string, List<Exercise>>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (workout == null)
                        {
                            workout = new WorkoutModel
                            {
                                Name = reader.GetString(0),
                                Days = daysDictionary
                            };
                        }

                        string dayName = reader.GetString(1);
                        string exerciseName = reader.GetString(2);
                        string reps = reader.GetString(3);
                        int sets = reader.GetInt32(4);

                        if (!daysDictionary.ContainsKey(dayName))
                        {
                            daysDictionary[dayName] = new List<Exercise>();
                        }

                        daysDictionary[dayName].Add(new Exercise
                        {
                            Name = exerciseName,
                            Reps = reps,
                            Sets = sets
                        });
                    }
                }

                _connection.Close();

                if (workout == null) throw new Exception("Workout Not Found");

                return workout;
            }
        }

        /// <inheritdoc />
        public  WorkoutCollection GetAllWorkouts(Guid userKey) 
        {
            using (SqlCommand command = new SqlCommand("GetAllWorkouts", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserKey", SqlDbType.UniqueIdentifier) { Value = userKey });
                _connection.Open();

                WorkoutCollection workoutCollection = new WorkoutCollection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid workoutKey = reader.GetGuid(0);
                        string workoutName = reader.GetString(1);
                        string dayName = reader.GetString(2);

                        if (!workoutCollection.Workouts.ContainsKey(workoutName))
                        {
                            workoutCollection.Workouts[workoutName] = new WorkoutInfo
                            {
                                WorkoutKey = workoutKey,
                                Days = new List<string>()
                            };
                        }

                        workoutCollection.Workouts[workoutName].Days.Add(dayName);
                    }
                }

                _connection.Close();

                return workoutCollection;
            }
        }

        /// <summary>
        /// Creates a Day in the database
        /// </summary>
        /// <param name="workoutKey">The guid of the linked workout.</param>
        /// <param name="dayName">The name of the day being created.</param>
        /// <param name="transaction">The connection to the sql database.</param>
        /// <returns>The Guid of the day that was created.</returns>
        private Guid CreateDay(Guid? workoutKey, string dayName, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("CreateDay", _connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@WorkoutKey", SqlDbType.UniqueIdentifier) { Value = workoutKey });
                command.Parameters.Add(new SqlParameter("@DayName", SqlDbType.NVarChar, 256) { Value = dayName });
                object result = command.ExecuteScalar();
                return (Guid)result;
            }
        }

        /// <summary>
        /// Creates an exercise in the database.
        /// </summary>
        /// <param name="dayKey">The guid of the linked day.</param>
        /// <param name="exercise">The Exercise data to be added to the database</param>
        /// <param name="transaction">The connection to the sql database.</param>

        private void CreateExercise(Guid dayKey, Exercise exercise, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("CreateExercise", _connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DayKey", SqlDbType.UniqueIdentifier) { Value = dayKey });
                command.Parameters.Add(new SqlParameter("@ExerciseName", SqlDbType.NVarChar, 256) { Value = exercise.Name });
                command.Parameters.Add(new SqlParameter("@ExerciseReps", SqlDbType.NVarChar, 256) { Value = exercise.Reps });
                command.Parameters.Add(new SqlParameter("@ExerciseSets", SqlDbType.Int) { Value = exercise.Sets });

                command.ExecuteNonQuery();
            }
        }
    }
}
