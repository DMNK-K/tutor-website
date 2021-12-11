CREATE PROCEDURE [dbo].[spTutorAdvSearch]
	@nameStr nvarchar(50),
	@nameFirst nvarchar(50),
	@nameLast nvarchar(50),
	@city nvarchar(70),
	@minRating int,
	@skipNonRated bit,
	@minRatingCount int,
	@tutoringPlace int,
	@requirePriceInfo bit
AS
BEGIN
	SELECT [dbo].[Tutor].[ID], [dbo].[Tutor].[UserID], [dbo].[Tutor].[NameFirst], [dbo].[Tutor].[NameLast], [dbo].[Tutor].[NameFormal], [dbo].[Tutor].[UsesFormalName], [dbo].[Tutor].[GoesToClient], [dbo].[Tutor].[Description], [dbo].[Tutor].[RatingCount], [dbo].[Tutor].[RatingSum], [dbo].[Tutor].[InfoPrice], [dbo].[Tutor].[InfoBonus], [dbo].[Tutor].[CityID], [dbo].[Tutor].[ServiceRange], [dbo].[Tutor].[Timetable], [dbo].[Tutor].[Operational], [dbo].[Tutor].[SubjectsStr], [dbo].[City].[ID], [dbo].[City].[CityName], [dbo].[City].[VoivodeshipAlphaIndex], [dbo].[City].[Powiat], [dbo].[City].[Gmina]
	FROM dbo.Tutor
	INNER JOIN dbo.City 
	ON dbo.Tutor.CityID = dbo.City.ID

	--CONTAINS would work better for this, but it requires adding fulltext catalog
	--which can't be done through Visual Studio
	WHERE
	Operational = 1 AND
	(
		@requirePriceInfo = 0 OR
		(InfoPrice IS NOT NULL AND InfoPrice != '')
	) AND
	(
		(RatingCount < @minRatingCount AND @skipNonRated = 0) OR
		(RatingCount >= @minRatingCount AND (RatingSum / RatingCount) >= @minRating)
	) AND
	(
		(@tutoringPlace = 0) OR
		(@tutoringPlace = 1 AND GoesToClient = 1) OR
		(@tutoringPlace = 2 AND GoesToClient = 0)
	) AND
	CityName LIKE CONCAT(@city, '%') AND
	(
		(UsesFormalName = 1 AND NameFormal LIKE CONCAT('%', @nameStr, '%')) OR
		NameFirst = @nameFirst OR
		NameLast LIKE CONCAT('%', @nameLast, '%') OR
		SubjectsStr LIKE CONCAT('%', @nameStr, '%')
	);
END