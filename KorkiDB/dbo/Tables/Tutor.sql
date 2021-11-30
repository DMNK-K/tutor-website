CREATE TABLE [dbo].[Tutor]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [NameFirst] NVARCHAR(50) NOT NULL, 
    [NameLast] NVARCHAR(50) NOT NULL, 
    [NameFormal] NVARCHAR(50) NULL, 
    [UsesFormalName] BIT NOT NULL DEFAULT 0, 
    [GoesToClient] BIT NOT NULL DEFAULT 1, 
    [Description] NVARCHAR(1250) NULL, 
    [RatingCount] INT NOT NULL DEFAULT 0, 
    [RatingSum] INT NOT NULL DEFAULT 0, 
    [InfoPrice] NVARCHAR(250) NULL, 
    [InfoBonus] NVARCHAR(500) NULL, 
    [CityID] INT NOT NULL, 
    [ServiceRange] TINYINT NOT NULL DEFAULT 0, 
    [Timetable] NVARCHAR(1000) NULL, 
    [Operational] BIT NOT NULL DEFAULT 1, 
    [SubjectsStr] NVARCHAR(200) NULL, 
    [IsShowcase] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Tutor_User] FOREIGN KEY ([UserID]) REFERENCES [User]([ID]), 
    CONSTRAINT [FK_Tutor_City] FOREIGN KEY ([CityID]) REFERENCES [City]([ID]) 
)
