CREATE PROCEDURE [dbo].[spUserTutorCreate]
	@Email nvarchar(100),
	@Username nvarchar(50),
	@PasswordHash char(64),
	@JoinDateTime datetimeoffset(2),
	@IsShowcase bit = 0,
	@NameFirst nvarchar(50),
	@NameLast nvarchar(50),
	@CityID int
AS
DECLARE @LastUserID int;

BEGIN
	INSERT INTO [dbo].[User] (IsTutor, Email, Username, PasswordHash, JoinDateTime, IsShowcase)
	VALUES (1, @Email, @Username, @PasswordHash, @JoinDateTime, @IsShowcase);

	SET @LastUserID = SCOPE_IDENTITY();
END

BEGIN
	INSERT INTO [dbo].[Tutor] (UserID, NameFirst, NameLast, CityID, IsShowcase)
	VALUES (@LastUserID, @NameFirst, @NameLast, @CityID, @IsShowcase);
END
RETURN 0
