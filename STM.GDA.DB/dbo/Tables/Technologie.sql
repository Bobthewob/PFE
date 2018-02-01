CREATE TABLE [dbo].[Technologie] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Nom] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Technologie] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90)
)

GO
