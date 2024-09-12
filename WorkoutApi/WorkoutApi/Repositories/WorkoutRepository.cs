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
        public void CreateWorkout(WorkoutModel model)
        {
            Guid? workoutKey = null;

            using (SqlCommand command = new SqlCommand("CreateWorkout", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@WorkoutName", SqlDbType.NVarChar, 254) { Value = model.Name });
                _connection.Open();
                object result = command.ExecuteScalar();
                _connection.Close();

                workoutKey = (Guid)result;
            }

            using (SqlTransaction transaction = _connection.BeginTransaction())
            {
                try
                {
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
        
        /// <summary>
        /// Creates a Day in the database
        /// </summary>
        /// <param name="workoutKey">The guid of the linked workout.</param>
        /// <param name="dayName">The name of the day being created.</param>
        /// <param name="transaction">The connection to the sql database.</param>
        /// <returns></returns>
        private Guid CreateDay(Guid? workoutKey, string dayName, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("CreateDay", _connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@WorkoutKey", SqlDbType.UniqueIdentifier) { Value = workoutKey });
                command.Parameters.Add(new SqlParameter("@DayName", SqlDbType.NVarChar, 254) { Value = dayName });
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
                command.Parameters.Add(new SqlParameter("@ExerciseName", SqlDbType.NVarChar, 254) { Value = exercise.Name });
                command.Parameters.Add(new SqlParameter("@ExerciseReps", SqlDbType.NVarChar, 254) { Value = exercise.Reps });
                command.Parameters.Add(new SqlParameter("@ExerciseSets", SqlDbType.Int) { Value = exercise.Sets });

                command.ExecuteNonQuery();
            }
        }
    }
}
