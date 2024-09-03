using Microsoft.Data.SqlClient;

namespace WorkoutApi.Repositories
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(DatabaseConnectionSettings settings)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = settings.DataSource,
                InitialCatalog = settings.InitialCatalog,
                UserID = settings.UserID,
                Password = settings.Password,
                IntegratedSecurity = false,
                TrustServerCertificate = true,
            };

            _connectionString = builder.ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

    public class DatabaseConnectionSettings
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
