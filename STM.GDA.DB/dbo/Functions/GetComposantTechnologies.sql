CREATE FUNCTION [dbo].[GetComposantTechnologies]
(
	@idComposant int
)
RETURNS varchar(MAX) WITH SCHEMABINDING
AS
BEGIN
	Declare @Technologies AS Nvarchar(MAX)
	SELECT @Technologies = COALESCE(@Technologies + ',', '') + t.Nom FROM [dbo].[Technologie] t
		LEFT JOIN [dbo].[ComposantTechnologie] ctechno ON t.Id = ctechno.TechnologieId
		WHERE ctechno.ComposantId = @idComposant
	RETURN @Technologies
END