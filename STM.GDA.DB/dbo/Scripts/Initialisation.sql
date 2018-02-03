--Insertion des types de composants de base
SET IDENTITY_INSERT [dbo].[ComposantType] ON;

INSERT INTO ComposantType (Id, Nom) VALUES (1, 'Application');

INSERT INTO ComposantType (Id, Nom) VALUES (2, 'Service');

SET IDENTITY_INSERT [dbo].[ComposantType] OFF;

--Insertion des dependances de base
SET IDENTITY_INSERT [dbo].[DependanceType] ON;

INSERT INTO DependanceType (Id, Nom) VALUES (1, 'Web');

INSERT INTO DependanceType (Id, Nom) VALUES (2, 'Bd');

INSERT INTO DependanceType (Id, Nom) VALUES (3, 'Interface');

INSERT INTO DependanceType (Id, Nom) VALUES (4, 'Job');

INSERT INTO DependanceType (Id, Nom) VALUES (5, 'Externe');

SET IDENTITY_INSERT [dbo].[DependanceType] OFF;

--Insertion des environnements de base
SET IDENTITY_INSERT [dbo].[Environnement] ON;

INSERT INTO Environnement (Id, Nom, Ordre, EstDefault) VALUES (1, 'Développement', 2, 1);

INSERT INTO Environnement (Id, Nom, Ordre, EstDefault) VALUES (2, 'QA', 3, 1);

INSERT INTO Environnement (Id, Nom, Ordre, EstDefault) VALUES (3, 'Pré-Production', 4, 1);

INSERT INTO Environnement (Id, Nom, Ordre, EstDefault) VALUES (4, 'Production', 1, 1);

SET IDENTITY_INSERT [dbo].[Environnement] OFF;

--Création de dépendances
SET IDENTITY_INSERT [dbo].[Dependance] ON;

INSERT INTO Dependance (Id, DependanceTypeId, Nom) VALUES (1, 1, 'Serveur Web');

INSERT INTO Dependance (Id, DependanceTypeId, Nom) VALUES (2, 2, 'Serveur BD');

INSERT INTO Dependance (Id, DependanceTypeId, Nom) VALUES (3, 3, 'Interface');

INSERT INTO Dependance (Id, DependanceTypeId, Nom) VALUES (4, 4, 'Job');

INSERT INTO Dependance (Id, DependanceTypeId, Nom) VALUES (5, 5, 'Externe');

SET IDENTITY_INSERT [dbo].[Dependance] OFF;

--Création de technologies
SET IDENTITY_INSERT [dbo].[Technologie] ON;

INSERT INTO Technologie (Id, Nom) VALUES (1, 'C# 4.6');

INSERT INTO Technologie (Id, Nom) VALUES (2, 'Telerik 7.0');

INSERT INTO Technologie (Id, Nom) VALUES (3, 'jQuery');

SET IDENTITY_INSERT [dbo].[Technologie] OFF;

SET IDENTITY_INSERT [dbo].[Composant] ON;

--Création composant 1
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 1', 'App1', 'Description application 1', '1.0', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

--Création du composant 2
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 2', 'App2', 'Description application 2', '2.0', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (2, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (2, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (2, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (2, 4, 1);

INSERT INTO ComposantDependance VALUES (2, 4, 1);
INSERT INTO ComposantDependance VALUES (2, 4, 4);

INSERT INTO ComposantTechnologie VAlUES (2, 1);
INSERT INTO ComposantTechnologie VAlUES (2, 2);

--Création du composant 3
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 3', 'App3', 'Description application 3', '3.0', 2, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (3, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (3, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (3, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (3, 4, 1);

INSERT INTO ComposantDependance VALUES (3, 4, 3);
INSERT INTO ComposantDependance VALUES (3, 4, 5);

INSERT INTO ComposantTechnologie VAlUES (3, 1);
INSERT INTO ComposantTechnologie VAlUES (3, 3);

--Création composant 4
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 4', 'App4', 'Description application 4', '1.0', 4, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

--Création composant 5
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 5', 'App5', 'Description application 5', '1.0', 5, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

--Création composant 6
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 6', 'App6', 'Description application 6', '1.0', 6, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

--Création composant 7
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 7', 'App7', 'Description application 7', '1.0', 7, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

--Création composant 8
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 8', 'App8', 'Description application 8', '1.0', 8, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

--Création composant 9
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 9', 'App9', 'Description application 9', '1.0', 9, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

--Création composant 10
INSERT INTO Composant (Nom, Abreviation, Description, Version, ComposantTypeId, DateCreation, DerniereMAJ) VALUES
('Application 10', 'App10', 'Description application 9', '1.0', 10, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO ComposantEnvironnement VALUES (1, 1, 2);
INSERT INTO ComposantEnvironnement VALUES (1, 2, 3);
INSERT INTO ComposantEnvironnement VALUES (1, 3, 4);
INSERT INTO ComposantEnvironnement VALUES (1, 4, 1);

INSERT INTO ComposantDependance VALUES (1, 4, 1);
INSERT INTO ComposantDependance VALUES (1, 4, 2);

INSERT INTO ComposantTechnologie VAlUES (1, 1);
INSERT INTO ComposantTechnologie VAlUES (1, 2);

SET IDENTITY_INSERT [dbo].[Composant] OFF;