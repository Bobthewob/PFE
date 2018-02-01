CREATE TABLE [dbo].[ComposantDependance]
(
	[ComposantId] INT NOT NULL,
	[EnvironnementId] INT NOT NULL,
	[DependanceId] INT NOT NULL, 
    CONSTRAINT [PK_ComposantDependance] PRIMARY KEY ([ComposantId], [EnvironnementId], [DependanceId]), 
    CONSTRAINT [FK_ComposantDependance_Composant] FOREIGN KEY ([ComposantId]) REFERENCES [Composant]([Id]), 
    CONSTRAINT [FK_ComposantDependance_Environnement] FOREIGN KEY ([EnvironnementId]) REFERENCES [Environnement]([Id]), 
    CONSTRAINT [FK_ComposantDependance_Dependance] FOREIGN KEY ([DependanceId]) REFERENCES [Dependance]([Id]),
)
