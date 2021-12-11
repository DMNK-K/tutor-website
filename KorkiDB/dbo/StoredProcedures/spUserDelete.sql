CREATE PROCEDURE [dbo].[spUserDelete]
	@ID int,
	@DeletionInfo nvarchar(50)
AS
	UPDATE [dbo].[User]
	SET IsDeleted = 1,
	DeletionInfo = @DeletionInfo
	WHERE ID = @ID
RETURN 0
