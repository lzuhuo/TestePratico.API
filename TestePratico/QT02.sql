INSERT INTO [dbo].[Owner]
([Name])
VALUES
('Adam Smith'),('Scott Johnson'),('Kimberly Parker ')
GO

INSERT INTO [dbo].[Cats]
([Name],[Age],[OwnerId])
VALUES
('Lily',5,1),('Chloe',2,3),('Charlie',3,2)
GO

INSERT INTO [dbo].[Dogs]
([Name],[Age],[OwnerId])
VALUES
('Maggie',1,2),('Duke',7,1),('Buddy',4,2)
GO