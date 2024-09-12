using WorkoutApi.Models;

namespace WorkoutApi.Services
{
    public interface IWorkoutService
    {
        /// <summary>
        /// Creates the workout.
        /// </summary>
        /// <param name="workoutModel">The data stored in the workout.</param>
        void CreateWorkout(Guid userKey, WorkoutModel workoutModel);

        /// <summary>
        /// Deletes a workout.
        /// </summary>
        /// <param name="workoutKey">The guid of the workout being deleted.</param>
        void DeleteWorkout(Guid workoutKey);
    }
}
