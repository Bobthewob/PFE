CREATE TRIGGER dbo.TriggerDeleteDependance
ON ComposantDependance
AFTER DELETE
AS
BEGIN
	IF((SELECT COUNT(*) FROM ComposantDependance WHERE ComposantDependance.DependanceId = (SELECT DependanceId FROM DELETED)) = 0)
		DELETE FROM Dependance WHERE ID = (SELECT DependanceId FROM DELETED)
END
