CREATE TABLE [dbo].[City]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CityName] NCHAR(10) NOT NULL, 
    [VoivodeshipAlphaIndex] NCHAR(10) NOT NULL, 
    [Powiat] NCHAR(10) NULL, 
    [Gmina] NCHAR(10) NULL
)
