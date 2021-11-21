CREATE TABLE [dbo].[Wydarzenie]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Gospodarz] NVARCHAR(50) NOT NULL, 
    [Gosc] NVARCHAR(50) NOT NULL, 
    [ZwyciestwoGospodarza] FLOAT NULL, 
    [ZwyciestwoGoscia] FLOAT NULL, 
    [Remis] FLOAT NULL, 
    [Data] DATETIME NOT NULL, 
    [KtoWygral] BIT NULL
)
