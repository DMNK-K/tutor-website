CREATE PROCEDURE [dbo].[spGetAllWorkingTutors]
AS
BEGIN
	SELECT * FROM dbo.Tutor WHERE Operational=1;
END
