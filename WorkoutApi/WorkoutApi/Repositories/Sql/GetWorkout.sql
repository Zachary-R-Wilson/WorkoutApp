IF OBJECT_ID('GetWorkout', 'P') IS NOT NULL
    DROP PROCEDURE GetWorkout;
GO
CREATE PROCEDURE GetWorkout
    @WorkoutKey UniqueIdentifier
AS
BEGIN
	SELECT W.Name AS 'Workout', D.Name AS 'Day', E.Name AS Exercise, Reps, [Sets] FROM [Workouts] W
	JOIN [Days] D ON D.WorkoutKey = W.WorkoutKey
	JOIN Exercises E ON E.DayKey = D.DayKey
	WHERE W.WorkoutKey = @WorkoutKey;
END;