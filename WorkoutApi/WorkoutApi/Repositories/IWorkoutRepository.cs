using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public interface IWorkoutRepository
    {
        /// <summary>
        /// Writes the workout to the SQL database.
        /// </summary>
        /// <param name="workoutModel">The data stored in the workout.</param>
        void CreateWorkout(WorkoutModel workoutModel);
    }
}
