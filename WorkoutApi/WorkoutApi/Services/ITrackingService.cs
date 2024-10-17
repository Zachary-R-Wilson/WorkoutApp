using WorkoutApi.Models;

namespace WorkoutApi.Services
{
    public interface ITrackingService
    {
        /// <summary>
        /// Gets the latest tracking information from the database.
        /// </summary>
        /// <param name="token">The bearer token.</param>
        /// <param name="dayKey">The day that is being tracked.</param>
        /// <returns>A Tracking model with the tracking information.</returns>
        TrackingProgressModel GetProgress(string token, Guid dayKey);

        /// <summary>
        /// Inserts tracking information into the database.
        /// </summary>
        /// <param name="token">The bearer token.</param>
        /// <param name="trackingModel">The data that is being inserted into the database.</param>
        void InsertTracking(string token, TrackingModel trackingModel);
    }
}
