CREATE TABLE [dbo].[ComposantClient]
(
	[ComposantId] INT NOT NULL,
	[ClientId] INT NOT NULL, 
    CONSTRAINT [PK_ComposantClient] PRIMARY KEY ([ComposantId], [ClientId]), 
    CONSTRAINT [FK_ComposantClient_Composant] FOREIGN KEY ([ComposantId]) REFERENCES [Composant]([Id]), 
    CONSTRAINT [FK_ComposantClient_Responsable] FOREIGN KEY ([ClientId]) REFERENCES [Responsable]([Id])

)
