IF OBJECT_ID('GetMaxes', 'P') IS NOT NULL
    DROP PROCEDURE GetMaxes;
GO
CREATE PROCEDURE GetMaxes
    @UserKey UniqueIdentifier
AS
BEGIN
	SELECT M.Squat, M.Deadlift, M.Benchpress FROM [Maxes] M
	WHERE M.UserKey = @UserKey;
END;