using Microsoft.Data.SqlClient;
using System.Data;
using WorkoutApi.Models;
using WorkoutApi.Repositories.Sql;

namespace WorkoutApi.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly SqlConnection _connection;

        public AuthRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <inheritdoc />
        public Guid? AuthenticateUser(LoginModel loginModel)
        {
            Guid? userKey = null;

            using (SqlCommand command = new SqlCommand(LoadSql.LoadSqlQuery("AuthUser.sql"), _connection))
            {
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 254, loginModel.Email));
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userKey = reader.GetGuid(reader.GetOrdinal("UserKey"));
                        string passwordHash = reader.GetString(reader.GetOrdinal("PasswordHash"));

                        if (BCrypt.Net.BCrypt.Verify(loginModel.Password, passwordHash)) return null;
                    }
                }
                _connection.Close();
            }

            return userKey;
        }

        /// <inheritdoc />
        public Guid? RegisterUser(LoginModel loginModel)
        {
            Guid? userKey = null;

            using (SqlCommand command = new SqlCommand(LoadSql.LoadSqlQuery("RegisterUser.sql"), _connection))
            {
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 254, loginModel.Email));
                command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 75, BCrypt.Net.BCrypt.HashPassword(loginModel.Password)));

                _connection.Open();
                object result = command.ExecuteScalar();
                _connection.Close();

                if (result != null && result != DBNull.Value)
                {
                    userKey = (Guid)result;
                }
            }

            return userKey;
        }
    }
}
