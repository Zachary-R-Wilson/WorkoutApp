﻿using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository) 
        {
            _workoutRepository = workoutRepository;
        }

        /// <inheritdoc />
        public void CreateWorkout(string token, WorkoutModel workoutModel)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            _workoutRepository.CreateWorkout(userKey, workoutModel);
        }

        /// <inheritdoc />
        public void DeleteWorkout(string token, Guid workoutKey)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            _workoutRepository.DeleteWorkout(userKey, workoutKey);
        }

        /// <inheritdoc />
        public WorkoutModel GetWorkout(string token, Guid WorkoutKey)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            return _workoutRepository.GetWorkout(userKey, WorkoutKey);
        }

        /// <inheritdoc />
        public WorkoutCollection GetAllWorkouts(string token) 
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            return _workoutRepository.GetAllWorkouts(userKey);
        }
    }
}
