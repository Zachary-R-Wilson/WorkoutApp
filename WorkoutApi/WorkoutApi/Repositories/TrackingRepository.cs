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
        public TrackingModel GetProgress(Guid dayKey)
        {
            using (SqlCommand command = new SqlCommand("GetProgress", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DayKey", SqlDbType.UniqueIdentifier) { Value = dayKey });
                _connection.Open();

                TrackingModel trackingModel = new TrackingModel();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string weight = reader.GetString(0);
                        int completedReps = reader.GetInt32(1);
                        int rpe = reader.GetInt32(2);
                        DateTime date = reader.GetDateTime(3);
                        Guid exerciseKey = reader.GetGuid(4);
                        string exerciseName = reader.GetString(5);

                        trackingModel.Exercises[exerciseName] = new TrackingInfo
                        {
                            Date = date,
                            Weight = weight,
                            CompletedReps = completedReps,
                            RPE = rpe,
                            ExerciseKey = exerciseKey
                        };
                    }
                }

                _connection.Close();

                return trackingModel;
            }
        }

        /// <inheritdoc />
        public void InsertTracking(TrackingModel trackingModel)
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
                        InsertInfo(trackingModel.Exercises[exerciseName], transaction);
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
        private void InsertInfo(TrackingInfo info, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("InsertTracking", _connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ExerciseKey", SqlDbType.UniqueIdentifier) { Value = info.ExerciseKey });
                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date) { Value = info.Date });
                command.Parameters.Add(new SqlParameter("@Weight", SqlDbType.NVarChar, 256) { Value = info.Weight});
                command.Parameters.Add(new SqlParameter("@CompletedReps", SqlDbType.Int) { Value = info.CompletedReps});
                command.Parameters.Add(new SqlParameter("@RPE", SqlDbType.Int) { Value = info.RPE });
                object result = command.ExecuteScalar();
            }
        }
    }
}
