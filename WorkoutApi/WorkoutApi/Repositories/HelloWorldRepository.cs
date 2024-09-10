using Microsoft.Data.SqlClient;
using WorkoutApi.Models;
using WorkoutApi.Repositories.Sql;

namespace WorkoutApi.Repositories
{
    public class HelloWorldRepository : IHelloWorldRepository
    {
        private readonly SqlConnection _connection;

        public HelloWorldRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<HelloWorld> GetHelloWorlds()
        {
            var helloWorldList = new List<HelloWorld>();

            using (SqlCommand command = new SqlCommand(LoadSql.LoadSqlQuery("HelloWorld.sql"), _connection))
            {
                _connection.Open();
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
                _connection.Close();
            }

            return helloWorldList;
        }
    }

}
