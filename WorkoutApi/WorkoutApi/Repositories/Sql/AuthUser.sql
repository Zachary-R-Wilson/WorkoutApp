IF OBJECT_ID('AuthUser', 'P') IS NOT NULL
    DROP PROCEDURE AuthUser;
GO
CREATE PROCEDURE AuthUser
    @Email NVARCHAR(254)
AS
BEGIN
    SELECT TOP 1 UserKey, PasswordHash
	FROM Users
	WHERE Email = @Email
END;