CREATE TABLE [dbo].[Ratings]
(
	[GiverUID] INT NOT NULL, 
    [ReceiverUID] INT NOT NULL, 
    [Rating] TINYINT NOT NULL,
    PRIMARY KEY ([GiverUID], [ReceiverUID]), 
    CONSTRAINT [FK_RatingsGiver_User] FOREIGN KEY ([GiverUID]) REFERENCES [User]([ID]),
    CONSTRAINT [FK_RatingsReceiver_User] FOREIGN KEY ([ReceiverUID]) REFERENCES [User]([ID])
)
