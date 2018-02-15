CREATE TABLE [dbo].[Deploiement]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[ComposantId] INT NOT NULL,
	[EnvironnementId] INT NOT NULL,
	[Date] DATETIME NOT NULL,
	[BrancheTag] VARCHAR(MAX) NULL,
	[URLDestination] VARCHAR(100) NULL,
	[PortailGroupe] VARCHAR(100) NULL,
	[PortailDescription] VARCHAR(MAX) NULL,
	[Details] VARCHAR(MAX) NULL,
	[DerniereMAJ] DATETIME NOT NULL,
	[PremierDeploiement] BIT NOT NULL,
	[Web] BIT NOT NULL,
	[BD] BIT NOT NULL,
	[Rapport] BIT NOT NULL,
	[Interface] BIT NOT NULL,
	[Job] BIT NOT NULL,
	CONSTRAINT [PK_Deploiement] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90), 
    CONSTRAINT [FK_Deploiement_Composant] FOREIGN KEY ([ComposantId]) REFERENCES [Composant]([Id]),
	CONSTRAINT [FK_Deploiement_Environnement] FOREIGN KEY ([EnvironnementId]) REFERENCES [Environnement]([Id]),
)

GO

CREATE NONCLUSTERED INDEX [IX_Deploiement_ComposantId] ON [dbo].[Deploiement] ([ComposantId])

GO

CREATE NONCLUSTERED INDEX [IX_Deploiement_EnvironnementId] ON [dbo].[Deploiement] ([EnvironnementId])
