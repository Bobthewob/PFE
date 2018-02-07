CREATE TRIGGER dbo.TriggerDeleteClient
ON ComposantClient
AFTER DELETE
AS
BEGIN
	IF((SELECT COUNT(*) FROM ComposantClient WHERE ComposantClient.ClientId = (SELECT ClientId FROM DELETED)) = 0)
		DELETE FROM Client WHERE ID = (SELECT ClientId FROM DELETED)
END