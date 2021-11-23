CREATE TABLE [dbo].[Ratings]
(
	[GiverUID] INT NOT NULL PRIMARY KEY, 
    [ReceiverUID] INT NOT NULL, 
    [Rating] TINYINT NOT NULL
)
