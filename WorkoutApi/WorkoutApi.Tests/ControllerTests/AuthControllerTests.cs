using Moq;
using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Models;
using WorkoutApi.Controllers;
using WorkoutApi.Services;

namespace WorkoutApi.Tests.ControllerTests
{
    public class AuthControllerTests
    {
        private readonly AuthController _authController;
        private readonly Mock<IAuthService> _mockAuthService;

        public AuthControllerTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _authController = new AuthController(_mockAuthService.Object);
        }

        #region LoginTests

        [Fact]
        public void Login_ValidCredentials_ReturnsOkResult()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "testing@email.com", Password = "password" };
            _mockAuthService.Setup(x => x.AuthenticateUser(loginModel)).Returns("valid_token");

            // Act
            var result = _authController.Login(loginModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = okResult.Value as dynamic;
            Assert.Equal("{ AccessToken = valid_token }", response?.ToString());
        }

        [Fact]
        public void Login_InvalidCredentials_ReturnsUnauthorizedResult()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "invalid@email.com", Password = "invalidPassword" };
            _mockAuthService.Setup(x => x.AuthenticateUser(loginModel)).Returns((string)null);

            // Act
            var result = _authController.Login(loginModel);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public void Login_ThrowsSqlException_ReturnsInternalServerError()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "testing@email.com", Password = "password" };
            _mockAuthService.Setup(x => x.AuthenticateUser(loginModel)).Throws(SqlExceptionHelper.MakeSqlException());

            // Act
            var result = _authController.Login(loginModel);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        #endregion

        #region RegisterTests

        [Fact]
        public void Register_ValidCredentials_ReturnsOkResult()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "newTesting@email.com", Password = "password" };
            _mockAuthService.Setup(x => x.RegisterUser(loginModel)).Returns("valid_token");

            // Act
            var result = _authController.Register(loginModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = okResult.Value as dynamic;
            Assert.Equal("{ AccessToken = valid_token }", response?.ToString());
        }

        [Fact]
        public void Register_InvalidCredentials_ReturnsUnauthorizedResult()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "newInvalid@email.com", Password = "invalidPassword" };
            _mockAuthService.Setup(x => x.RegisterUser(loginModel)).Returns((string)null);

            // Act
            var result = _authController.Register(loginModel);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public void Register_ThrowsSqlException_ReturnsInternalServerError()
        {
            // Arrange
            var loginModel = new LoginModel { Email = "testing@email.com", Password = "password" };
            _mockAuthService.Setup(x => x.RegisterUser(loginModel)).Throws(SqlExceptionHelper.MakeSqlException());

            // Act
            var result = _authController.Register(loginModel);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        #endregion
    }
}
