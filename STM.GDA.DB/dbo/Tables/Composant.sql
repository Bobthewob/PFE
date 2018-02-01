CREATE TABLE [dbo].[Composant]
(
	[Id] INT	IDENTITY (1, 1) NOT NULL,
	[Abreviation] VARCHAR(25) NULL,
	[Nom] VARCHAR(100) NOT NULL,
	[Version] VARCHAR(10) NULL,
	[Description] VARCHAR(MAX) NULL,
	[NomBD] VARCHAR(25) NULL,
	[BC] VARCHAR(MAX) NULL,
	[BW] VARCHAR(MAX) NULL,
	[DerniereMAJ] DATETIME NOT NULL,
	[ComposantTypeId] INT NOT NULL,
	CONSTRAINT [PK_Composant] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90), 
    CONSTRAINT [FK_Composant_ComposantType] FOREIGN KEY ([ComposantTypeId]) REFERENCES [ComposantType]([Id])
)

GO

CREATE NONCLUSTERED INDEX [IX_Composant_FK_Composant_ComposantType] ON [dbo].[Composant] ([ComposantTypeId])
