﻿IF OBJECT_ID('UpdateMaxes', 'P') IS NOT NULL
    DROP PROCEDURE UpdateMaxes;
GO
CREATE PROCEDURE UpdateMaxes
    @UserKey UNIQUEIDENTIFIER,
	@Squat INTEGER,
	@Deadlift INTEGER,
	@Benchpress INTEGER
AS
BEGIN
	UPDATE [Maxes] SET Squat=@Squat, Deadlift=@Deadlift, Benchpress=@Benchpress where userKey=@UserKey
	IF @@ROWCOUNT=0
		INSERT INTO [Maxes] (Squat, Deadlift, Benchpress, userKey) values(@Squat, @Deadlift, @Benchpress, @UserKey);
END;