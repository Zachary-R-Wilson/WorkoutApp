using Moq;
using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Models;
using WorkoutApi.Repositories;
using WorkoutApi.Services;
using WorkoutApi.Controllers;

namespace WorkoutApi.Tests.ServiceTests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly Mock<IAuthRepository> _mockAuthRepository;
        private readonly Mock<IJwtHelper> _mockJwtHelper;

        public AuthServiceTests()
        {
            _mockAuthRepository = new Mock<IAuthRepository>();
            _mockJwtHelper = new Mock<IJwtHelper>();
            _authService = new AuthService(_mockAuthRepository.Object, _mockJwtHelper.Object);
        }

        #region AuthenticateUser

        [Fact]
        public void AuthenticateUser_ValidCredentials_ReturnsJwt()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "testing@email.com", Password = "password" };
            var userKey = Guid.NewGuid();
            var expectedToken = "valid_token";

            _mockAuthRepository.Setup(x => x.AuthenticateUser(loginModel)).Returns(userKey);

            _mockJwtHelper.Setup(x => x.GenerateAccessToken(userKey)).Returns(expectedToken);

            // Act
            var result = _authService.AuthenticateUser(loginModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedToken, result);
        }

        [Fact]
        public void AuthenticateUser_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "invalid@email.com", Password = "password" };

            _mockAuthRepository.Setup(x => x.AuthenticateUser(loginModel)).Returns((Guid?)null);

            // Act
            var result = _authService.AuthenticateUser(loginModel);

            // Assert
            Assert.Null(result);
        }


        #endregion

        #region RegisterUser


        #endregion
    }
}
