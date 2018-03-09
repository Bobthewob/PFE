CREATE FUNCTION [dbo].[GetComposantResponsables]
(
	@idComposant int
)
RETURNS varchar(MAX) WITH SCHEMABINDING
AS
BEGIN
	Declare @Responsables AS Nvarchar(MAX)
	SELECT @Responsables = COALESCE(@Responsables + ',', '') + r.Nom FROM [dbo].[Responsable] r
		LEFT JOIN [dbo].[ComposantResponsable] cr ON r.Id = cr.ResponsableId
		WHERE cr.ComposantId = @idComposant
	RETURN @Responsables
END