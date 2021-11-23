CREATE TABLE [dbo].[Tutor]
(
	[ID] INT NOT NULL PRIMARY KEY, 
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
    [City] NVARCHAR(50) NULL, 
    [ServiceRange] TINYINT NOT NULL DEFAULT 0
)
