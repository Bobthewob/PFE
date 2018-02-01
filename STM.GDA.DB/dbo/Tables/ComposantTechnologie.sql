CREATE TABLE [dbo].[ComposantTechnologie]
(
	[ComposantId] INT NOT NULL,
	[TechnologieId] INT NOT NULL, 
    CONSTRAINT [PK_ComposantTechnologie] PRIMARY KEY ([ComposantId], [TechnologieId]), 
    CONSTRAINT [FK_ComposantTechnologie_Composant] FOREIGN KEY ([ComposantId]) REFERENCES [Composant]([Id]), 
    CONSTRAINT [FK_ComposantTechnologie_Technologie] FOREIGN KEY ([TechnologieId]) REFERENCES [Technologie]([Id])
)
