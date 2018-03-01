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
		client.Nom AS NomClient,
		responsable.Nom AS NomResponsable,
		technologie.Nom AS NomTechnologie,
		dependance.Nom AS NomDependance
	FROM [dbo].[Composant] c
	INNER JOIN [dbo].[ComposantType] ctype ON c.ComposantTypeId = ctype.Id
	INNER JOIN [dbo].[ComposantTechnologie] ctechno ON c.Id = ctechno.ComposantId
	INNER JOIN [dbo].[Technologie] technologie ON ctechno.TechnologieId = technologie.Id
	INNER JOIN [dbo].[ComposantClient] cclient ON c.Id = cclient.ComposantId
	INNER JOIN [dbo].[Client] client ON client.Id = cclient.ClientId
	INNER JOIN [dbo].[ComposantResponsable] cresponsable ON c.Id = cresponsable.ComposantId
	INNER JOIN [dbo].[Responsable] responsable ON responsable.Id = cresponsable.ResponsableId
	INNER JOIN [dbo].[ComposantDependance] cdependance ON c.Id = cdependance.ComposantId
	INNER JOIN [dbo].[Dependance] dependance ON dependance.Id = cdependance.DependanceId
