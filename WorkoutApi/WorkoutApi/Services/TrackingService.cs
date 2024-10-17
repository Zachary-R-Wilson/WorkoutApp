using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class TrackingService: ITrackingService
    {
        private readonly ITrackingRepository _trackingRepository;

        public TrackingService(ITrackingRepository trackingRepository)
        {
            _trackingRepository = trackingRepository;
        }


        /// <inheritdoc />
        public TrackingProgressModel GetProgress(string token, Guid dayKey)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            return _trackingRepository.GetProgress(userKey, dayKey);
        }

        /// <inheritdoc />
        public void InsertTracking(string token, TrackingModel trackingModel)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            _trackingRepository.InsertTracking(userKey, trackingModel);
        }
    }
}
