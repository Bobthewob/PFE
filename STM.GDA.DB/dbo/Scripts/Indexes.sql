--Création du catalogue
CREATE FULLTEXT CATALOG FullTextCatalog;

GO

--Index pour les attributs d'un composant
CREATE UNIQUE INDEX [IX_UniqueVComposant] ON [dbo].[VComposants_FTS] ([Id]);

CREATE FULLTEXT INDEX ON [dbo].[VComposants_FTS] (
	[Abrevriation], 
	[Nom],
	[Version],
	[Description],
	[NomBD],
	[BC],
	[BW],
	[SourceControlPath],
	[NomClient],
	[NomResponsable],
	[NomTechnologie],
	[NomDependance]) 
KEY INDEX [IX_UniqueVComposant] ON [FullTextCatalog] WITH CHANGE_TRACKING AUTO

GO	
