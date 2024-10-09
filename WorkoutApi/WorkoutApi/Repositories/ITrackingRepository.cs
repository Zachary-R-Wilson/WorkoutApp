using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public interface ITrackingRepository
    {
        /// <summary>
        /// Gets the latest tracking information from the database.
        /// </summary>
        /// <param name="dayKey">The day that is being tracked.</param>
        /// <returns>A Tracking Progress Model with the tracking information.</returns>
        TrackingProgressModel GetProgress(Guid dayKey);

        /// <summary>
        /// Inserts tracking information into the database.
        /// </summary>
        /// <param name="trackingModel">The data that is being inserted into the database.</param>
        void InsertTracking(TrackingModel trackingModel);
    }
}
