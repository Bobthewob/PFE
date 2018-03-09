CREATE FUNCTION [dbo].[GetComposantDependances]
(
	@idComposant int
)
RETURNS varchar(MAX) WITH SCHEMABINDING
AS
BEGIN
	Declare @Dependances AS Nvarchar(MAX)
	SELECT @Dependances = COALESCE(@Dependances + ',', '') + d.Nom FROM [dbo].[Dependance] d
		LEFT JOIN [dbo].[ComposantDependance] cd ON d.Id = cd.DependanceId
		WHERE cd.ComposantId = @idComposant
	RETURN @Dependances
END