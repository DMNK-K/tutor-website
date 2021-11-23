CREATE TABLE [dbo].[User]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [IsTutor] BIT NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Username] NVARCHAR(50) NOT NULL, 
    [PasswordHash] BINARY(32) NOT NULL, 
    [JoinDateTime] DATETIMEOFFSET(4) NOT NULL 
)
