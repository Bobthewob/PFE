CREATE VIEW [dbo].[VComposants_FTS]
WITH SCHEMABINDING
	AS SELECT 
		c.Id,
		c.Abreviation,
		c.Nom,
		c.Description,
		c.Version,
		c.BC,
		c.BW,
		c.NomBD,
		c.SourceControlPath,
		ctype.Nom as Type,
		[dbo].GetComposantClients(c.Id) AS Clients,
		[dbo].GetComposantResponsables(c.Id) AS Responsables,
		[dbo].GetComposantTechnologies(c.Id) AS Technologies,
		[dbo].GetComposantDependances(c.Id) AS Dependances
	FROM [dbo].[Composant] c
	LEFT JOIN [dbo].[ComposantType] ctype ON c.ComposantTypeId = ctype.Id