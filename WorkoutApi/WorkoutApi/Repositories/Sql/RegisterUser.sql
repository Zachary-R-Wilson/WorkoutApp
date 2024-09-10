IF EXISTS (
    SELECT 1
    FROM Users
    WHERE Email = @Email
)
THROW 500, 'A user key already exists for this email.', 1;

DECLARE @userKey uniqueidentifier = NEWID();

INSERT INTO [Users]
VALUES (@userKey, @Email, @Password);