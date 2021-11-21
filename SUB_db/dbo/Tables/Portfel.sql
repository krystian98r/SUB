CREATE TABLE [dbo].[Portfel] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [KodPortfela] NVARCHAR (8)    NOT NULL,
    [Srodki]      MONEY DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

