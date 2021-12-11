CREATE TABLE [dbo].[User]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IsTutor] BIT NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL,
    [EmailHash] BINARY(32) NOT NULL,
    [EmailConfirmed] BIT NOT NULL DEFAULT 0, 
    [Username] NVARCHAR(50) NOT NULL, 
    [PasswordHash] CHAR(64) NOT NULL, 
    [JoinDateTime] DATETIMEOFFSET(3) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [DeletionInfo] NVARCHAR(50) NULL, 
    [IsSuspended] BIT NOT NULL DEFAULT 0, 
    [SuspentionInfo] NVARCHAR(50) NULL, 
    [SuspentionDateTime] DATETIMEOFFSET(2) NULL, 
    [SuspentionAutoEnd] DATETIMEOFFSET(2) NULL, 
    [IsShowcase] BIT NOT NULL DEFAULT 0, 
    [AccessFailedCount] TINYINT NOT NULL DEFAULT 0
)
