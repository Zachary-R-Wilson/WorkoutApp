using Microsoft.Data.SqlClient;
using System.Data;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public class MaxesRepository : IMaxesRepository
    {
        private readonly SqlConnection _connection;

        public MaxesRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <inheritdoc />
        public MaxModel GetMaxes(Guid userKey)
        {
            using (SqlCommand command = new SqlCommand("GetMaxes", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserKey", SqlDbType.UniqueIdentifier) { Value = userKey });
                _connection.Open();

                MaxModel? maxModel = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int squat = reader.GetInt32(0);
                        int deadlift = reader.GetInt32(1);
                        int benchpress = reader.GetInt32(2);

                        maxModel = new MaxModel
                        { 
                            Squat = squat,
                            Deadlift = deadlift,
                            Benchpress = benchpress
                        };
                    }
                }

                _connection.Close();

                if (maxModel == null) throw new Exception("No Maxes Found");

                return maxModel;
            }
        }

        /// <inheritdoc />
        public void UpdateMaxes(Guid userKey, MaxModel maxModel)
        {
            using (SqlCommand command = new SqlCommand("UpdateMaxes", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserKey", SqlDbType.UniqueIdentifier) { Value = userKey });
                command.Parameters.Add(new SqlParameter("@Squat", SqlDbType.Int) { Value = maxModel.Squat });
                command.Parameters.Add(new SqlParameter("@Deadlift", SqlDbType.Int) { Value = maxModel.Deadlift});
                command.Parameters.Add(new SqlParameter("@Benchpress", SqlDbType.Int) { Value = maxModel.Benchpress });

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
