using Moq;
using WorkoutApi.Models;
using WorkoutApi.Repositories;
using WorkoutApi.Services;

namespace WorkoutApi.Tests.ServiceTests
{
    public class TrackingServiceTests
    {
        private readonly TrackingService _service;
        private readonly Mock<ITrackingRepository> _mockRepository;
        private readonly Mock<IJwtHelper> _mockJwtHelper;

        public TrackingServiceTests()
        {
            _mockRepository = new Mock<ITrackingRepository>();
            _mockJwtHelper = new Mock<IJwtHelper>();
            _service = new TrackingService(_mockRepository.Object, _mockJwtHelper.Object);
        }

        #region GetProgress

        [Fact]
        public void GetProgress_ValidToken_ReturnsTrackingProgressModel()
        {
            // Arrange
            var token = "valid-token";
            var userKey = Guid.NewGuid();
            var dayKey = Guid.NewGuid();
            var expectedProgress = new TrackingProgressModel();

            _mockJwtHelper.Setup(j => j.ExtractUserKey(token)).Returns(userKey);
            _mockRepository.Setup(r => r.GetProgress(userKey, dayKey)).Returns(expectedProgress);

            // Act
            var result = _service.GetProgress(token, dayKey);

            // Assert
            Assert.Equal(expectedProgress, result);
            _mockJwtHelper.Verify(j => j.ExtractUserKey(token), Times.Once);
            _mockRepository.Verify(r => r.GetProgress(userKey, dayKey), Times.Once);
        }

        [Fact]
        public void GetProgress_InvalidToken_ThrowsArgumentNullException()
        {
            // Arrange
            var invalidToken = "invalid-token";
            var dayKey = Guid.NewGuid();

            _mockJwtHelper.Setup(j => j.ExtractUserKey(invalidToken)).Returns((Guid?)null);

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _service.GetProgress(invalidToken, dayKey));
            Assert.Equal("Invalid or missing userKey in the token. (Parameter 'token')", exception.Message);
            _mockJwtHelper.Verify(j => j.ExtractUserKey(invalidToken), Times.Once);
            _mockRepository.Verify(r => r.GetProgress(It.IsAny<Guid>(), dayKey), Times.Never);
        }

        #endregion

        #region InsertTracking

        [Fact]
        public void InsertTracking_ValidToken_CallsRepositoryInsertTracking()
        {
            // Arrange
            var token = "valid-token";
            var userKey = Guid.NewGuid();
            var trackingModel = new TrackingModel();

            _mockJwtHelper.Setup(j => j.ExtractUserKey(token)).Returns(userKey);
            _mockRepository.Setup(r => r.InsertTracking(userKey, trackingModel)).Verifiable();

            // Act
            _service.InsertTracking(token, trackingModel);

            // Assert
            _mockJwtHelper.Verify(j => j.ExtractUserKey(token), Times.Once);
            _mockRepository.Verify(r => r.InsertTracking(userKey, trackingModel), Times.Once);
        }

        [Fact]
        public void InsertTracking_InvalidToken_ThrowsArgumentNullException()
        {
            // Arrange
            var invalidToken = "invalid-token";
            var trackingModel = new TrackingModel();

            _mockJwtHelper.Setup(j => j.ExtractUserKey(invalidToken)).Returns((Guid?)null);

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _service.InsertTracking(invalidToken, trackingModel));
            Assert.Equal("Invalid or missing userKey in the token. (Parameter 'token')", exception.Message);
            _mockJwtHelper.Verify(j => j.ExtractUserKey(invalidToken), Times.Once);
            _mockRepository.Verify(r => r.InsertTracking(It.IsAny<Guid>(), trackingModel), Times.Never);
        }

        #endregion
    }
}
