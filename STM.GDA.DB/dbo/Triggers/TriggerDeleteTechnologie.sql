CREATE TRIGGER dbo.TriggerDeleteTechnologie
ON ComposantTechnologie
AFTER DELETE
AS
BEGIN
	IF((SELECT COUNT(*) FROM ComposantTechnologie WHERE ComposantTechnologie.TechnologieId = (SELECT TechnologieId FROM DELETED)) = 0)
		DELETE FROM Technologie WHERE ID = (SELECT TechnologieId FROM DELETED)
END
