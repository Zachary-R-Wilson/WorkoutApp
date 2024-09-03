using Microsoft.Data.SqlClient;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public class HelloWorldRepository: IHelloWorldRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public HelloWorldRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<HelloWorld> GetHelloWorlds()
        {
            var helloWorldList = new List<HelloWorld>();

            using (SqlConnection connection = _dbConnection.GetConnection())
            {
                string sql = "SELECT * FROM HelloWorld";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            helloWorldList.Add(new HelloWorld
                            {
                                HelloKey = reader.GetGuid(0),
                                HelloString = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return helloWorldList;
        }
    }
}
