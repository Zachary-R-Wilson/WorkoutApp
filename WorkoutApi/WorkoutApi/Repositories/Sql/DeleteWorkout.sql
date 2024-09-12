IF OBJECT_ID('DeleteWorkout', 'P') IS NOT NULL
    DROP PROCEDURE DeleteWorkout;
GO
CREATE PROCEDURE DeleteWorkout
	@WorkoutKey Uniqueidentifier
AS
BEGIN
    Delete FROM Workouts where WorkoutKey = @WorkoutKey;
END;