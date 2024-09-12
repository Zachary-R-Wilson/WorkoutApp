IF OBJECT_ID('CreateWorkout', 'P') IS NOT NULL
    DROP PROCEDURE CreateWorkout;
GO
CREATE PROCEDURE CreateWorkout
	@UserKey Uniqueidentifier,
    @WorkoutName NVARCHAR(256)
AS
BEGIN
    DECLARE @WorkoutKey uniqueidentifier = NEWID();

	INSERT INTO [Workouts]
	VALUES (@WorkoutKey, @WorkoutName, @UserKey);

	SELECT @WorkoutKey;
END;