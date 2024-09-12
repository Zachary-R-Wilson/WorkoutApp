IF OBJECT_ID('CreateExercise', 'P') IS NOT NULL
    DROP PROCEDURE CreateExercise;
GO
CREATE PROCEDURE CreateExercise
	@DayKey Uniqueidentifier,
    @ExerciseName NVARCHAR(256),
	@ExerciseReps NVARCHAR(256),
	@ExerciseSets INTEGER
AS
BEGIN
    DECLARE @ExerciseKey uniqueidentifier = NEWID();

	INSERT INTO [Exercises]
	VALUES (@ExerciseKey, @ExerciseName, @ExerciseReps, @ExerciseSets, @DayKey);

	SELECT @DayKey;
END;