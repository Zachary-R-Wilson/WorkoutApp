using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /// <inheritdoc />
        public string? AuthenticateUser(LoginModel credentials)
        {
            Guid? userKey = _authRepository.AuthenticateUser(credentials);
            if(userKey != null)
            {
                return GenerateAccessToken(userKey);
            }

            return null;
        }

        /// <inheritdoc />
        public string? RegisterUser(LoginModel credentials)
        {
            Guid? userKey = _authRepository.RegisterUser(credentials);
            if (userKey != null)
            {
                return GenerateAccessToken(userKey);
            }

            return null;
        }

        /// <summary>
        /// Generates a JwtToken so the valid user can access the api
        /// </summary>
        /// <param name="userKey">The Guid that designates which user this is.</param>
        /// <returns>JwtToken</returns>
        private string GenerateAccessToken(Guid? userKey)
        {
            if (userKey == null) throw new ArgumentNullException(nameof(userKey));

            var claims = new List<Claim>
            {
                new Claim("userKey", userKey.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
                audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRETKEY"))),
                    SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
