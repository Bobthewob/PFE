CREATE TABLE [dbo].[ComposantEnvironnement]
(
	[ComposantId] INT NOT NULL,
	[EnvironnementId] INT NOT NULL,
	[Ordre] INT NOT NULL, 
    CONSTRAINT [PK_ComposantEnvironnement] PRIMARY KEY ([ComposantId], [EnvironnementId]), 
    CONSTRAINT [FK_ComposantEnvironnement_Composant] FOREIGN KEY ([ComposantId]) REFERENCES [Composant]([Id]), 
    CONSTRAINT [FK_ComposantEnvironnement_Environnement] FOREIGN KEY ([EnvironnementId]) REFERENCES [Environnement]([Id])


)
