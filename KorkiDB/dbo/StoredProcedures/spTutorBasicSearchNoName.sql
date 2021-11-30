CREATE PROCEDURE [dbo].[spTutorBasicSearchNoName]
	@city nvarchar(70)
AS
BEGIN
	SELECT * FROM dbo.Tutor
	INNER JOIN dbo.City 
	ON dbo.Tutor.CityID = dbo.City.ID

	WHERE
	Operational = 1 AND CityName LIKE CONCAT(@city, '%');
END
