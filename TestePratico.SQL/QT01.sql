IF OBJECT_ID('[dbo].[Owner]', 'U') IS NOT NULL
DROP TABLE [dbo].[Owner]
GO
CREATE TABLE [dbo].[Owner]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    [Name] NVARCHAR(300)    
);
GO

IF OBJECT_ID('[dbo].[Cats]', 'U') IS NOT NULL
DROP TABLE [dbo].[Cats]
GO

CREATE TABLE [dbo].[Cats]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(300),
    [Age] INT NOT NULL,
    [OwnerId] INT NOT NULL FOREIGN KEY (OwnerId) REFERENCES [Owner] (Id)
);
GO

IF OBJECT_ID('[dbo].[Dogs]', 'U') IS NOT NULL
DROP TABLE [dbo].[Dogs]
GO

CREATE TABLE [dbo].[Dogs]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(300),
    [Age] INT NOT NULL,
    [OwnerId] INT NOT NULL FOREIGN KEY (OwnerId) REFERENCES [Owner] (Id)   
);
GO