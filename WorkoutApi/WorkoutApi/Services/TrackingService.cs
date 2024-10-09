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
        public TrackingProgressModel GetProgress(Guid dayKey)
        {
            return _trackingRepository.GetProgress(dayKey);
        }

        /// <inheritdoc />
        public void InsertTracking(TrackingModel trackingModel)
        {
            _trackingRepository.InsertTracking(trackingModel);
        }
    }
}
