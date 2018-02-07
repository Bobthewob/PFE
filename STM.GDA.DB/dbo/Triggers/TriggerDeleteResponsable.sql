CREATE TRIGGER dbo.TriggerDeleteResponsable
ON ComposantResponsable
AFTER DELETE
AS
BEGIN
	IF((SELECT COUNT(*) FROM ComposantResponsable WHERE ComposantResponsable.ResponsableId = (SELECT ResponsableId FROM DELETED)) = 0)
		DELETE FROM Responsable WHERE ID = (SELECT ResponsableId FROM DELETED)
END