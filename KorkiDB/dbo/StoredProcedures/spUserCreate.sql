CREATE PROCEDURE [dbo].[spUserCreate]
	@Email nvarchar(100),
	@Username nvarchar(50),
	@PasswordHash char(64),
	@JoinDateTime datetimeoffset(2),
	@IsShowcase bit = 0
AS
BEGIN
	INSERT INTO [dbo].[User] (IsTutor, Email, Username, PasswordHash, JoinDateTime, IsShowcase)
	VALUES (0, @Email, @Username, HASHBYTES('SHA2_256', @PasswordHash), @JoinDateTime, @IsShowcase);
END
RETURN 0
