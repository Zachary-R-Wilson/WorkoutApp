using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class TrackingService: ITrackingService
    {
        private readonly ITrackingRepository _TrackingRepository;

        public TrackingService(ITrackingRepository trackingRepository)
        {
            _TrackingRepository = trackingRepository;
        }


        /// <inheritdoc />
        public TrackingModel GetProgress(Guid dayKey)
        {
            return _TrackingRepository.GetProgress(dayKey);
        }

        /// <inheritdoc />
        public void InsertTracking(TrackingModel trackingModel)
        {
            _TrackingRepository.InsertTracking(trackingModel);
        }
    }
}
