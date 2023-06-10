INSERT INTO Deelnemers
(Voornaam, Familienaam, Email,Geboortedatum, Geslacht, Straatnaam, Huisnummer, Gemeente, Postcode, Ziekenfonds, Monitor, Hoofdmonitor, Admin) 
VALUES
('Emma', 'Maes', 'Emma@email.com','2003-03-08', 'V', 'Kerkstraat', '12', 'Antwerpen', '2000', 1, 0, 0, 1),
('Liam', 'Peeters', 'Liam@email.com','2002-06-25', 'M', 'Stationsstraat', '45', 'Gent', '9000', 0, 0, 1, 0),
('Olivia', 'Jacobs', 'Olivia@email.com','2004-09-14', 'V', 'Leuvensesteenweg', '32', 'Brussel', '1000', 1, 0, 0, 0),
('Noah', 'Dubois', 'Noah@email.com','2003-12-18', 'M', 'Avenue des Arts', '78', 'Brugge', '8000', 0, 1, 0, 0),
('Amélie', 'Martin', 'Amélie@email.com','2005-04-22', 'V', 'Rue Royale', '25', 'Luik', '4000', 1, 0, 0, 0),
('Lucas', 'Lambert', 'Lucas@email.com','2004-01-05', 'M', 'Chaussée de Louvain', '56', 'Namen', '5000', 0, 0, 1, 0),
('Elise', 'Simon', 'Elise@email.com','2002-08-30', 'V', 'Rue de la Loi', '64', 'Brussel', '1000', 1, 0, 0, 0),
('Arthur', 'Dubois', 'Arthur@email.com','2004-11-12', 'M', 'Rue du Marché', '10', 'Luik', '4000', 0, 1, 0, 0),
('Juliette', 'Dupont', 'Juliette@email.com','2003-07-17', 'V', 'Place Sainte-Catherine', '22', 'Brussel', '1000', 1, 0, 0, 0),
('Victor', 'Leroy', 'Victor@email.com','2005-02-19', 'M', 'Avenue Louise', '88', 'Brussel', '1050', 0, 0, 1, 0),
('Louise', 'Garcia', 'Louise@email.com','2002-09-11', 'V', 'Rue de la Bourse', '14', 'Antwerpen', '2000', 1, 0, 0, 0),
('Maxime', 'Renard', 'Maxime@email.com','2004-06-03', 'M', 'Place des Palais', '5', 'Brussel', '1000', 0, 1, 0, 0),
('Camille', 'Dubois', 'Camille@email.com','2003-03-25', 'V', 'Rue des Fripiers', '30', 'Brussel', '1000', 1, 0, 0, 0),
('Sophie', 'Leclercq', 'Sophie@email.com','2003-09-21', 'V', 'Rue de la Station', '9', 'Namen', '5000', 1, 0, 0, 0),
('Thomas', 'Lemaire', 'Thomas@email.com','2002-12-05', 'M', 'Rue des Augustins', '16', 'Luik', '4000', 0, 1, 0, 0),
('Charlotte', 'Dubois', 'Charlotte@email.com','2004-05-11', 'V', 'Rue du Marché aux Herbes', '32', 'Brussel', '1000', 1, 0, 0, 0),
('Théo', 'Moreau', 'Théo@email.com','2003-02-14', 'M', 'Chaussée de Wavre', '124', 'Brussel', '1000', 0, 0, 1, 0),
('Léa', 'Rousseau', 'Léa@email.com','2005-07-28', 'V', 'Rue des Dominicains', '8', 'Brugge', '8000', 1, 0, 0, 0),
('Lou', 'Bertrand', 'Lou@email.com','2002-04-16', 'V', 'Rue de Flandre', '52', 'Gent', '9000', 1, 0, 0, 0);

INSERT INTO Medische 
(DeelnemerId,Omschrijving, Medicatie, Behandeling)
VALUES 
(1,'Hoge bloeddruk', 'Lisinopril', 'Leefstijlaanpassingen'),
(2,'Diabetes mellitus type 2', 'Metformine', 'Leefstijlaanpassingen en medicatie'),
(3,'Depressie', 'SSRI', 'Verwijzing naar psycholoog'),
(4,'Chronische rugpijn', 'NSAID', 'Verwijzing naar fysiotherapeut'),
(5,'Gebroken been', 'Pijnstillers', 'Operatie en revalidatie'),
(6,'Obesitas', 'Orlistat', 'Verwijzing naar diëtist en leefstijlaanpassingen'),
(7,'Stemstoornis', 'Geen medicatie', 'Verwijzing naar logopedist'),
(8,'Hartritmestoornissen', 'Bètablokker', 'Verwijzing naar cardioloog'),
(9,'Acne', 'Retinoïden', 'Verwijzing naar dermatoloog');


INSERT INTO Rolen
(Naam)
VALUES
('deelnemer'),
('monitor'),
('hoofdmonitor');

INSERT INTO Leeftijdscategorieen
(Naam)
VALUES
('Kinderen: 0-12 jaar'),
('Tieners: 13-19 jaar'),
('Jongvolwassenen: 18-25 jaar'),
('Volwassenen: 26-59 jaar'),
('Ouderen: 60 jaar en ouder');

INSERT INTO Bestemmingen
(Naam, Straatnaam, Huisnummer, Gemeente, Postcode, Land)
VALUES 
('Het Heijderbos', 'Hommersumseweg', '43', 'Heijen', '6598 MC', 'Nederland'),
('Sunparks Kempense Meren', 'Postelsesteenweg', '100', 'Mol', '2400', 'België'),
('Center Parcs De Eemhof', 'Slingerweg', '1', 'Zeewolde', '3896 LD', 'Nederland'),
('Landal Mooi Zutendaal', 'Gijzenveldstraat', '86', 'Zutendaal', '3690', 'België'),
('Roompot Beach Resort', 'Mariapolderseweg', '1', 'Kamperland', '4493 PH', 'Nederland'),
('Domaine de la Sapinière', 'Rue Abbé Dossogne', '27', 'Bouillon', '6830', 'België'),
('Center Parcs Les Ardennes', 'Rue de la Grotte', '12', 'Vielsalm', '6690', 'België'),
('Landal Landgoed ''t Loo', 'Tepelenburgerweg', '85', 'Ermelo', '3852 NB', 'Nederland'),
('Center Parcs De Kempervennen', 'Kempervennendreef', '8', 'Westerhoven', '5563 VB', 'Nederland'),
('Park Molenheide', 'Molenheidestraat', '7', 'Houthalen-Helchteren', '3530', 'België'),
('Landal De Lommerbergen', 'Lommerbergen', '1', 'America', '5966 PJ', 'Nederland'),
('Sunparks De Haan', 'Wenduinesteenweg', '150', 'De Haan', '8420', 'België'),
('Center Parcs Port Zélande', 'Port Zélande', '2', 'Ouddorp', '3253 MG', 'Nederland'),
('Vakantiepark Hengelhoef', 'Tulpenstraat', '141', 'Houthalen-Helchteren', '3530', 'België'),
('Roompot Vakantiepark Weerterbergen', 'Trancheeweg', '7', 'Weert', '6002 ST', 'Nederland'),
('Landal De Vers', 'Grubbenvorsterweg', '18', 'Lottum', '5973 NB', 'Nederland'),
('Sunparks Oostduinkerke aan Zee', 'Polderstraat', '158', 'Koksijde', '8670', 'België'),
('Center Parcs Park Zandvoort', 'Vondellaan', '60', 'Zandvoort', '2041 BE', 'Nederland'),
('Landal Het Vennenbos', 'Schouwberg', '7', 'Hapert', '5527 JH', 'Nederland'),
('Bungalowpark Les Doyards', 'Rue des Peupliers', '10', 'Malmedy', '4960', 'België');

INSERT INTO Themas
(Naam)
VALUES
('Avontuurlijk'),
('Cultuur'),
('Strand'),
('Outdoor'),
('Ski'),
('Voetbal'),
('Paarden'),
('Surf'),
('Taal'),
('Themapark');

INSERT INTO Opleidingen
(Beschrijving, Datum, MaxAantalDeelnemers) 
VALUES 
('Monitor', '2023-06-12', 10),
('Monitor', '2023-06-15', 10),
('Hoofdmonitor', '2023-06-18', 5),
('Monitor', '2023-06-21', 10),
('Monitor', '2023-06-24', 10),
('Monitor', '2023-06-27', 10),
('Monitor', '2023-06-30', 10),
('Hoofdmonitor', '2023-07-03', 5),
('Hoofdmonitor', '2023-07-06', 5),
('Hoofdmonitor', '2023-07-09', 5),
('Hoofdmonitor', '2023-07-12', 5),
('Hoofdmonitor', '2023-07-15', 5),
('Monitor', '2023-07-18', 10),
('Monitor', '2023-07-21', 10),
('Hoofdmonitor', '2023-07-24', 5),
('Monitor', '2023-07-27', 10),
('Hoofdmonitor', '2023-07-30', 5),
('Hoofdmonitor', '2023-08-02', 5),
('Monitor', '2023-08-05', 10),
('Hoofdmonitor', '2023-08-08', 5);

INSERT INTO DeelnemerOpleidingen
(DeelnemerId, OpleidingId)
VALUES
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(2,2),
(2,3),
(2,4),
(2,5),
(2,6),
(3,2),
(3,3),
(3,4),
(3,5),
(3,6),
(4,2),
(4,3),
(4,4),
(4,5),
(5,4);

INSERT INTO OpleidingBestemmingen
(OpleidingId, BestemmingId)
VALUES
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,1),
(7,2),
(8,3),
(9,4),
(10,5),
(11,1),
(12,2),
(13,3),
(14,4),
(15,5),
(16,1),
(17,2),
(18,3),
(19,4),
(20,5);

INSERT INTO Groepsreisen
(BestemmingId, ThemaId, LeeftijdscategorieId, Prijs, Startdatum, Einddatum, MaxAantalDeelnemers)
VALUES 
(1, 1, 1, 425.50,'2023-06-01', '2023-06-30', 10),
(2, 2, 2, 210.00,'2023-06-20', '2023-07-10', 20),
(3, 3, 3, 550.25,'2023-07-01', '2023-07-30', 10),
(4, 4, 4, 350.75,'2023-08-01', '2023-08-30', 15),
(5, 5, 5, 450.00,'2023-08-01', '2023-09-01', 10),
(1, 2, 1, 500.00,'2023-05-30', '2023-06-20', 20),
(2, 3, 2, 300.50,'2023-07-01', '2023-08-30', 15),
(3, 4, 3, 425.00,'2023-10-01', '2023-10-30', 12),
(4, 5, 4, 280.25,'2023-10-20', '2023-10-30', 13),
(5, 1, 5, 550.00,'2023-11-01', '2023-11-30', 15),
(1, 3, 1, 600.00,'2023-12-01', '2023-12-30', 10),
(2, 4, 2, 200.75,'2023-05-01', '2023-05-30', 20),
(3, 5, 3, 475.50,'2023-06-01', '2023-06-30', 30),
(4, 1, 4, 325.00,'2023-07-01', '2023-07-14', 8),
(5, 2, 5, 475.25,'2023-08-01', '2023-08-14', 10),
(1, 4, 1, 300.00,'2023-09-01', '2023-09-10', 10),
(2, 5, 2, 525.50,'2023-05-01', '2023-06-30', 20),
(3, 1, 3, 400.75,'2023-12-1', '2023-12-10', 15),
(4, 2, 4, 225.00,'2023-07-1', '2023-08-30', 12),
(5, 3, 5, 375.25,'2023-06-1', '2023-06-30', 16);

INSERT INTO DeelnemerGroepsreisen (DeelnemerId, GroepsreisId, RolId, Betaald)
VALUES 
(1, 1, 3, 'true'),
(2, 1, 2, 'true'),
(3, 1, 1, 'False'),
(4, 1, 1, 'False'),
(5, 1, 1, 'true'),
(6, 2, 2, 'False'),
(7, 2, 1, 'False'),
(8, 2, 1, 'true'),
(9, 3, 3, 'False'),
(10, 3, 1, 'true'),
(11, 3, 1, 'true'),
(12, 3, 1, 'False'),
(13, 4, 2, 'true'),
(14, 4, 1, 'False'),
(15, 4, 1, 'False'),
(16, 5, 1, 'true'),
(17, 5, 1, 'False'),
(18, 5, 1, 'true'),
(19, 5, 2, 'False');