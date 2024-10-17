using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public class TrackingRepository: ITrackingRepository
    {
        private readonly SqlConnection _connection;

        public TrackingRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <inheritdoc />
        public TrackingProgressModel GetProgress(Guid userKey, Guid dayKey)
        {
            using (SqlCommand command = new SqlCommand("GetProgress", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DayKey", SqlDbType.UniqueIdentifier) { Value = dayKey });
                command.Parameters.Add(new SqlParameter("@UserKey", SqlDbType.UniqueIdentifier) { Value = userKey });
                _connection.Open();

                TrackingProgressModel trackingProgressModel = new TrackingProgressModel();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string dayName = reader.GetString(reader.GetOrdinal("DayName"));
                        Guid exerciseKey = reader.GetGuid(reader.GetOrdinal("ExerciseKey"));
                        string exerciseName = reader.GetString(reader.GetOrdinal("ExerciseName"));
                        string reps = reader.GetString(reader.GetOrdinal("Reps"));
                        int sets = reader.GetInt32(reader.GetOrdinal("Sets"));
                        string? weight = reader.IsDBNull(reader.GetOrdinal("Weight")) ? null : reader.GetString(reader.GetOrdinal("Weight"));
                        int? completedReps = reader.IsDBNull(reader.GetOrdinal("CompletedReps")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CompletedReps"));
                        int? rpe = reader.IsDBNull(reader.GetOrdinal("RPE")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("RPE"));
                        DateTime? date = reader.IsDBNull(reader.GetOrdinal("LastWorkout")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastWorkout"));

                        trackingProgressModel.Exercises[exerciseName] = new TrackingProgress
                        {
                            DayKey = dayKey,
                            DayName = dayName,
                            ExerciseKey = exerciseKey,
                            ExerciseName = exerciseName,
                            Reps = reps,
                            Sets = sets,
                            Weight = weight,
                            CompletedReps = completedReps,
                            RPE = rpe,
                            Date = date
                        };
                    }
                }

                _connection.Close();

                return trackingProgressModel;
            }
        }

        /// <inheritdoc />
        public void InsertTracking(Guid userKey, TrackingModel trackingModel)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            using (SqlTransaction transaction = _connection.BeginTransaction())
            {
                try
                {
                    trackingModel.Exercises.Keys.ToList().ForEach(exerciseName =>
                    {
                        InsertInfo(trackingModel.Exercises[exerciseName], userKey, transaction);
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
        /// Inserts Tracking info into the database
        /// </summary>
        /// <param name="info">The tracking data to be stored.</param>
        /// <param name="transaction">The connection to the sql database.</param>
        private void InsertInfo(TrackingInfo info, Guid userKey, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("InsertTracking", _connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ExerciseKey", SqlDbType.UniqueIdentifier) { Value = info.ExerciseKey });
                command.Parameters.Add(new SqlParameter("@UserKey", SqlDbType.UniqueIdentifier) { Value = userKey });
                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date) { Value = info.Date });
                command.Parameters.Add(new SqlParameter("@Weight", SqlDbType.NVarChar, 256) { Value = info.Weight});
                command.Parameters.Add(new SqlParameter("@CompletedReps", SqlDbType.Int) { Value = info.CompletedReps});
                command.Parameters.Add(new SqlParameter("@RPE", SqlDbType.Int) { Value = info.RPE });
                object result = command.ExecuteScalar();
            }
        }
    }
}
