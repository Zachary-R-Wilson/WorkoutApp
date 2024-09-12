using Microsoft.Data.SqlClient;
using System.Data;
using WorkoutApi.Models;

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

            using (SqlCommand command = new SqlCommand("AuthUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 254) { Value = loginModel.Email });
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userKey = reader.GetGuid(reader.GetOrdinal("UserKey"));
                        string passwordHash = reader.GetString(reader.GetOrdinal("PasswordHash"));

                        if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, passwordHash)) return null;
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

            using (SqlCommand command = new SqlCommand("RegisterUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 254) { Value = loginModel.Email });
                command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 75) { Value = BCrypt.Net.BCrypt.HashPassword(loginModel.Password) });

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
