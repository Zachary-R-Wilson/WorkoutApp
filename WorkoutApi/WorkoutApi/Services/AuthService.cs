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
                return JwtHelper.GenerateAccessToken(userKey);
            }

            return null;
        }

        /// <inheritdoc />
        public string? RegisterUser(LoginModel credentials)
        {
            Guid? userKey = _authRepository.RegisterUser(credentials);
            if (userKey != null)
            {
                return JwtHelper.GenerateAccessToken(userKey);
            }

            return null;
        }
    }
}
