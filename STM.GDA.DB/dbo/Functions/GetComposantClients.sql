CREATE FUNCTION [dbo].[GetComposantClients]
(
	@idComposant int
)
RETURNS varchar(MAX) WITH SCHEMABINDING
AS
BEGIN
	Declare @Clients AS Nvarchar(MAX)
	SELECT @Clients = COALESCE(@Clients + ',', '') + c.Nom FROM [dbo].[Client] c
		LEFT JOIN [dbo].[ComposantClient] cc ON c.Id = cc.ClientId
		WHERE cc.ComposantId = @idComposant
	RETURN @Clients
END