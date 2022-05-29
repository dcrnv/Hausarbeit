USE master;
GO

IF DB_ID('Baufirma') IS NULL
  CREATE DATABASE Baufirma;
GO

USE Baufirma;
GO 

IF OBJECT_ID('Material') IS NOT NULL
  DROP TABLE Material;
GO

IF OBJECT_ID('Mitarbeiter') IS NOT NULL
  DROP TABLE Mitarbeiter;
GO

IF OBJECT_ID('Arbeitsplan') IS NOT NULL
  DROP TABLE Arbeitsplan;
GO


CREATE TABLE Material (
  ID_Material int NOT NULL IDENTITY PRIMARY KEY, 
  Name nvarchar(100),
  Anzahl INT,
  Listenpreis decimal,
  Hersteller nvarchar(50),
  Gewicht_in_KG INT
);


CREATE TABLE Mitarbeiter (
  ID_Mitarbeiter int NOT NULL IDENTITY PRIMARY KEY, 
  Name nvarchar(20),
  Vorname nvarchar(20),
  Straﬂe nvarchar(50),
  Hausnummer int,
  Postleitzahl INT,
  Telefonnummer decimal,
  Geburtstag DATE,
  Ort nvarchar(30),
  Rolle nvarchar(30)
);


CREATE TABLE Arbeitsplan (
  ID_Arbeitsplan int IDENTITY NOT NULL PRIMARY KEY,
  Baustelle nvarchar(100),
  Datum DATE,
  ID_Material int,
  ID_Mitarbeiter int,
  CONSTRAINT FK_ID_Material FOREIGN KEY (ID_Material) REFERENCES Material(ID_Material),
  CONSTRAINT FK_ID_Mitarbeiter FOREIGN KEY (ID_Mitarbeiter) REFERENCES Mitarbeiter (ID_Mitarbeiter)
  );

INSERT INTO Material (Name, Anzahl, Listenpreis, Hersteller, Gewicht_in_KG) VALUES
  ('Schaltwerk', 20, 39.99, 'BOSCH', 10),
  ('Griffe', 30, 24.99, 'BOSCH', 10),
  ('Kassette', 30, 79.99, 'BOSCH', 10),
  ('Nille', 15, 84.99, 'BOSCH', 10);

INSERT INTO Mitarbeiter (Name, Vorname, Straﬂe, Hausnummer, Postleitzahl, Telefonnummer, Geburtstag, Ort, Rolle) VALUES
 ('Cernoveri', 'Drilon', 'Steinbachstraﬂe', 10, 66424, 017622565204, '20001027' , 'Homburg', 'Chef');

 INSERT INTO Arbeitsplan (Baustelle, Datum) VALUES
 ('Homburg-Erbach Lidl', GETDATE());