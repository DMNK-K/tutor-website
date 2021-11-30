CREATE TABLE [dbo].[City]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CityName] NVARCHAR(70) NOT NULL, 
    [VoivodeshipAlphaIndex] TINYINT NOT NULL, 
    [Powiat] NVARCHAR(50) NOT NULL, 
    [Gmina] NVARCHAR(50) NOT NULL, 
    [Lat] FLOAT NOT NULL, 
    [Long] FLOAT NOT NULL 
)

GO
