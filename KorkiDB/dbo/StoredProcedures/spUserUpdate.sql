CREATE PROCEDURE [dbo].[spUserUpdate]
	@ID int,
	@IsTutor bit,
	@Email int,
	@EmailHash char(128),
	@EmailConfirmed bit,
	@Username nvarchar(50),
	@PasswordHash char(128),
	@JoinDateTime datetimeoffset(2),

	@IsDeleted bit,
	@DeletionInfo nvarchar(50),

	@IsSuspended bit,
	@SuspentionInfo nvarchar(50),
	@SuspentionDateTime datetimeoffset(2),
	@SuspentionAutoEnd datetimeoffset(2),

	@IsShowcase bit,
	@AccessFailedCount tinyint
AS
BEGIN
	UPDATE [dbo].[User]
	SET
	IsTutor = @IsTutor,
	Email = @Email,
	EmailHash = @EmailHash,
	EmailConfirmed = @EmailConfirmed,
	Username = @Username,
	PasswordHash = @PasswordHash,
	JoinDateTime = @JoinDateTime,

	IsDeleted = @IsDeleted,
	DeletionInfo = @DeletionInfo,

	IsSuspended = @IsSuspended,
	SuspentionInfo = @SuspentionInfo,
	SuspentionDateTime = @SuspentionDateTime,
	SuspentionAutoEnd = @SuspentionAutoEnd,

	IsShowcase = @IsShowcase,
	AccessFailedCount = @AccessFailedCount
	WHERE ID = @ID;
END
RETURN 0
