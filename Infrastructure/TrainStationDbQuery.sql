CREATE DATABASE TrainStationDb;
GO

USE TrainStationDb;
GO

CREATE TABLE City 
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE Ticket
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	DepartureDate DATETIME NOT NULL,
	ArrivalDate DATETIME NOT NULL,
	FromId INT FOREIGN KEY REFERENCES City(ID) NOT NULL,
	ToId INT FOREIGN KEY REFERENCES City(ID) NOT NULL,
	Price SMALLMONEY NOT NULL
)
GO

INSERT INTO City VALUES ('Kyiv')
INSERT INTO City VALUES ('Lviv')
INSERT INTO City VALUES ('Khmelnitskiy')
INSERT INTO City VALUES ('Rivne')
GO

INSERT INTO Ticket VALUES('2023-12-5 12:00', '2023-12-6 01:00', 1, 2, 800)
INSERT INTO Ticket VALUES('2023-12-6 12:00', '2023-12-6 21:00', 2, 3, 600)
INSERT INTO Ticket VALUES('2023-12-7 09:00', '2023-12-7 15:00', 3, 4, 400)
INSERT INTO Ticket VALUES('2023-12-8 03:00', '2023-12-8 18:00', 4, 1, 900)
GO
