CREATE TABLE [dbo].[Client] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Nom] VARCHAR (100)     NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90)
);
