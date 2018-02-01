CREATE TABLE [dbo].[ComposantResponsable]
(
	[ComposantId] INT NOT NULL,
	[ResponsableId] INT NOT NULL, 
    CONSTRAINT [PK_ComposantResponsable] PRIMARY KEY ([ComposantId], [ResponsableId]), 
    CONSTRAINT [FK_ComposantResponsable_Composant] FOREIGN KEY ([ComposantId]) REFERENCES [Composant]([Id]), 
    CONSTRAINT [FK_ComposantResponsable_Responsable] FOREIGN KEY ([ResponsableId]) REFERENCES [Responsable]([Id])

)
