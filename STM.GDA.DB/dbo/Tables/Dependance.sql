CREATE TABLE [dbo].[Dependance]
(
	[Id] INT	IDENTITY (1, 1) NOT NULL,
	[Nom] VARCHAR(50) NULL,
	[ComposantId] INT NULL,
	CONSTRAINT [PK_Dependance] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90), 
	CONSTRAINT [FK_Dependance_Composant] FOREIGN KEY ([ComposantId]) REFERENCES [Composant]([Id])
)
GO

CREATE INDEX [IX_Dependance_ComposantId] ON [dbo].[Dependance] ([ComposantId])
