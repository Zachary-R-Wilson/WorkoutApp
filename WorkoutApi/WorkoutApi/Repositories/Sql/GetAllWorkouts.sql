IF OBJECT_ID('GetAllWorkouts', 'P') IS NOT NULL
    DROP PROCEDURE GetAllWorkouts;
GO
CREATE PROCEDURE GetAllWorkouts
    @UserKey UniqueIdentifier
AS
BEGIN
	SELECT W.Name AS 'Workout', D.Name AS 'Day' FROM [Workouts] W
	JOIN [Days] D ON D.WorkoutKey = W.WorkoutKey
	WHERE W.UserKey = @UserKey;
END;