CREATE DATABASE TripService
GO
USE TripService
GO
-- DDL
CREATE TABLE Cities(
	Id INT IDENTITY,
	[Name] NVARCHAR (20) NOT NULL,
	CountryCode CHAR(2) NOT NULL,
	CONSTRAINT PK_CityId PRIMARY KEY (Id)
)

CREATE TABLE Hotels(
	Id INT IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2),
	CONSTRAINT PK_HotelId PRIMARY KEY (Id),
	CONSTRAINT FK_Hotel_Cities FOREIGN KEY (CityId) REFERENCES Cities(Id)
)

CREATE TABLE Rooms(
	Id INT IDENTITY,
	Price DECIMAL (15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL,
	CONSTRAINT  PK_RoomId PRIMARY KEY (Id),
	CONSTRAINT FK_Room_Hotel FOREIGN KEY (HotelId) REFERENCES Hotels(Id)
)

CREATE TABLE Trips(
	Id INT IDENTITY, 
	RoomId INT NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CONSTRAINT  PK_TripId PRIMARY KEY (Id),
	CONSTRAINT FK_Trip_Room FOREIGN KEY (RoomId) REFERENCES Rooms(Id),
	CONSTRAINT CHK_BookDate CHECK (BookDate < ArrivalDate),
	CONSTRAINT CHK_ArrivalDate CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
	Id INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL,
	CONSTRAINT PK_AccountId PRIMARY KEY (Id),
	CONSTRAINT FK_Account_Cities FOREIGN KEY (CityId) REFERENCES Cities(Id),
	CONSTRAINT UQ_Email UNIQUE (Email)
)

CREATE TABLE AccountsTrips(
	AccountId INT NOT NULL,
	TripId INT NOT NULL,
	Luggage INT NOT NULL,
	CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId, TripId),
	CONSTRAINT FK_AccountTrip_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
	CONSTRAINT FK_AccountTrip_Trip FOREIGN KEY (TripId) REFERENCES Trips(Id),
	CONSTRAINT CHK_Luggage CHECK (Luggage >=0)
)

-- DML
INSERT INTO Accounts VALUES
('John','Smith','Smith',34,'1975-07-21','j_smith@gmail.com'),
('Gosho',NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com'),
('Ivan','Petrovich','Pavlov',59,'1849-09-26','i_pavlov@softuni.bg'),
('Friedrich','Wilhelm','Nietzsche',2,'1844-10-15','f_nietzsche@softuni.bg')
INSERT INTO Trips VALUES
(101,'2015-04-12','2015-04-14','2015-04-20','2015-02-02'),
(102,'2015-07-07','2015-07-15', '2015-07-22', '2015-04-29'),
(103,'2013-07-17','2013-07-23', '2013-07-24', NULL),
(104,'2012-03-17','2012-03-31', '2012-04-01', '2012-01-10'),
(109,'2017-08-07','2017-08-28', '2017-08-29', NULL)

UPDATE Rooms
SET Price = Price * 1.14
WHERE HotelId IN (5, 7, 9)

DELETE FROM AccountsTrips
WHERE AccountId = 47

-- QUERYING

--BG CITIES

SELECT Id, Name FROM Cities
WHERE CountryCode = 'BG'
ORDER BY Name

-- BORN AFTER 1991
SELECT CASE WHEN (MiddleName IS NULL) THEN (CONCAT(FirstName, ' ', LastName)) ELSE CONCAT(FirstName, ' ', MiddleName, ' ', LastName) END AS FullName,
 YEAR(BirthDate) AS [BirthYear] FROM Accounts
WHERE YEAR(BirthDate) > '1991'
ORDER BY BirthYear DESC, FirstName ASC

-- EEE-MAILS
SELECT FirstName, LastName, FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate, c.Name AS HomeTown, Email  FROM Accounts AS a
JOIN Cities AS c
ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name DESC

-- CITY STATISTICS
SELECT c.Name AS City, ISNULL(Hotels, 0) AS Hotels FROM Cities AS c
LEFT JOIN
(SELECT CityId, COUNT(*) AS Hotels FROM Hotels
GROUP BY CityId) AS h
ON h.CityId = c.Id
ORDER BY Hotels DESC, c.Name

-- EXPENSIVE FIRST CLASS ROOMS
SELECT r.Id, r.Price, h.Name, c.Name FROM Rooms AS r
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
WHERE Type = 'First Class'
ORDER BY Price DESC, r.Id

-- LONGEST AND SHORTEST TRIPS
SELECT h.AccountId, CONCAT(H.FirstName, ' ', h.LastName) AS FullName, MAX(TripDays) AS LongestTrip, MIN(TripDays) AS ShortestTrip
FROM (SELECT AccountId, FirstName, LastName, DATEDIFF(DAY, ArrivalDate, ReturnDate) AS TripDays FROM Trips AS t
	JOIN AccountsTrips AS at
	ON at.TripId = t.Id
	JOIN Accounts AS a
	ON a.Id = at.AccountId
	WHERE a.MiddleName IS NULL AND CancelDate IS NULL) AS h
GROUP BY h.AccountId, CONCAT(H.FirstName, ' ', h.LastName)
ORDER BY LongestTrip DESC, AccountId

-- METROPOLIS
SELECT TOP 5 WITH TIES Id, c.Name AS City, CountryCode AS Country, Counted AS Accounts FROM Cities AS c
JOIN
	(SELECT CITYId, COUNT(*) AS Counted FROM Accounts
	GROUP BY CityId) AS AccInCities
ON AccInCities.CityId = c.Id
ORDER BY Counted DESC

-- ROMANTIC GATEWAYS
SELECT a.Id, a.Email, c.Name AS City, COUNT(*) AS Trips FROM AccountsTrips AS [at]
JOIN Accounts AS a
ON a.Id = at.AccountId
JOIN Trips AS t
ON t.Id = at.TripId
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id

-- LUCATIVE DESTINATIONS
SELECT TOP 10 WITH TIES c.Id, C.Name, SUM(h.BaseRate + r.Price) AS [Total Revenue], COUNT(*) AS Trips FROM Trips AS t
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
WHERE YEAR(t.BookDate) = '2016'
GROUP BY c.Id, C.Name
ORDER BY SUM(h.BaseRate + r.Price) DESC, Trips DESC

-- TRIP REVENUES
SELECT t.Id, h.Name AS HotelName, r.Type AS RoomType,
		CASE WHEN CancelDate IS NULL THEN SUM(h.BaseRate  + r.Price) ELSE 0 END AS Revenue
 FROM Trips AS t
LEFT JOIN Rooms AS r
ON r.Id = t.RoomId
LEFT JOIN Hotels AS h
ON h.Id = r.HotelId
GROUP BY t.Id, h.Name, r.Type, t.CancelDate, h.BaseRate, R.Price
ORDER BY r.Type, t.Id


 
SELECT * FROM Trips  AS t
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
WHERE t.Id IN (3, 9)


SELECT * FROM AccountsTrips







-- TOP TRAVELLERS
SELECT * FROM Accounts
SELECT h2.Id, h2.Email, h2.CountryCode, h2.Trips FROM 
	(SELECT *, ROW_NUMBER () OVER (PARTITION BY h.CountryCode ORDER BY Trips DESC) AS Ranked FROM 
		(SELECT a.Id, a.Email, C.CountryCode, COUNT(*) AS Trips FROM Trips AS t
		JOIN AccountsTrips AS at
		ON at.TripId = t.Id
		JOIN Accounts AS a
		ON a.Id = at.AccountId
		JOIN Rooms AS r
		ON r.Id = t.Id
		JOIN Hotels AS h
		ON h.Id = r.HotelId
		JOIN Cities AS c
		ON c.Id = H.CityId
		GROUP BY  a.Id, a.Email, C.CountryCode
		) AS h
	) AS h2
WHERE Ranked = 1
ORDER BY h2.Trips DESC, h2.Id

-- LUGGAGE FEE
SELECT h.TripId, h.Luggage,
		CASE WHEN (h.Luggage > 5) THEN CONCAT('$',(h.Luggage * 5))
		WHEN (h.Luggage <= 5 AND h.Luggage >= 1) THEN '$0' END AS Fee
		 FROM 
	(SELECT TripId, SUM(Luggage) AS Luggage FROM AccountsTrips
	GROUP BY TripId
	HAVING SUM(Luggage) > 0) AS h
ORDER BY H.Luggage DESC

-- GDPR 491, 787
SELECT T.Id, 
		CASE WHEN (a.MiddleName IS NULL) THEN (CONCAT(a.FirstName, ' ', a.LastName)) ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) END AS FullName,
		c2.Name AS [From],
		c1.Name AS [To],
		CASE WHEN (CancelDate IS NULL) THEN CONCAT(CAST(DATEDIFF (DAY, ArrivalDate, ReturnDate) AS varchar(4)), ' days') ELSE 'Canceled' END AS Duration
	FROM Trips AS t
JOIN AccountsTrips AS at
ON at.TripId = t.Id
JOIN Accounts AS a
ON a.Id = at.AccountId
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c1
ON c1.Id = H.CityId
JOIN Cities AS c2
ON c2.Id = a.CityId
ORDER BY CASE WHEN (a.MiddleName IS NULL) THEN (CONCAT(a.FirstName, ' ', a.LastName)) ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) END, t.Id

-- PROGRAMABILITY
SELECT * FROM Rooms as r
LEFT JOIN Trips AS t
ON t.RoomId = r.Id
WHERE T.RoomId IS NULL




GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @Room INT;
	DECLARE @ArrivalDate DATE ;
	SET @ArrivalDate = (SELECT ArrivalDate 
						  FROM Trips 
						 WHERE RoomId IN (SELECT Id FROM Rooms WHERE HotelId = @HotelId)
						 AND CancelDate IS NULL);

	DECLARE @ReturnDate DATE;
	SET @ReturnDate =  (SELECT ReturnDate 
						  FROM Trips 
						 WHERE RoomId IN (SELECT Id FROM Rooms WHERE HotelId = @HotelId)
						 AND CancelDate IS NULL);
	DECLARE @CancelDate DATE;
	SET @CancelDate = (SELECT CancelDate 
	                     FROM Trips 
						WHERE RoomId IN (SELECT Id FROM Rooms WHERE HotelId = @HotelId));

	IF ((@Date BETWEEN @ArrivalDate AND @ReturnDate) OR @CancelDate IS NULL) 
	BEGIN
		RAISERROR ('No Rooms Available', 16, 1);
		END

	ELSE IF (

	DECLARE @TotalPrice DECIMAL(6,2);
	SET @TotalPrice = '(HotelBaseRate + RoomPrice) * PeopleCount';
END

SELECT * FROM Trips



SELECT * FROM Rooms WHERE Id = 8


SELECT * FROM AccountsTrips

SELECT * FROM Trips
WHERE Id = 10

SELECT * FROM Accounts



-- SWITCH ROOMS
GO
CREATE PROCEDURE dbo.usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @CurrentRoom INT;
	SET @CurrentRoom = (SELECT RoomId FROM Trips WHERE Id = @TripId)

	DECLARE @CurrentHotel INT;
	SET @CurrentHotel = (SELECT ID FROM Hotels WHERE Id = (SELECT HotelId FROM Rooms WHERE ID = @CurrentRoom))

	DECLARE @ReqestedHotel INT;
	SET @ReqestedHotel = (SELECT ID FROM Hotels WHERE Id = (SELECT HotelId FROM Rooms WHERE ID = @TargetRoomId))

	DECLARE @CurrentBeds INT;
	SET @CurrentBeds = (SELECT Beds FROM Rooms WHERE Id = @CurrentRoom)

	DECLARE @NewBeds INT;
	SET @NewBeds = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)

BEGIN TRANSACTION

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId

	IF (@CurrentHotel <> @ReqestedHotel)
	BEGIN
		;THROW 50000, 'Target room is in another hotel!', 1
		ROLLBACK
		RETURN
	END

	IF (@CurrentBeds > @NewBeds)
	BEGIN
		;THROW 50000, 'Not enough beds in target room!' , 2
		ROLLBACK
		RETURN
	END
	
			COMMIT TRANSACTION 

END

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

	EXEC usp_SwitchRoom 10, 7

	SELECT * FROM Trips








































SELECT * FROM Trips as t
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId









-- TRIGGER
SELECT * FROM Trips
GO
CREATE TRIGGER tr_DeletedTrips ON Trips
INSTEAD OF DELETE 
AS
	UPDATE Trips
	SET CancelDate = GETDATE()
	WHERE CancelDate IS NULL AND Id IN (SELECT Id FROM deleted)

	DELETE FROM AccountsTrips
	WHERE TripId IN (SELECT Id FROM deleted)

SELECT * FROM AccountsTrips
WHERE TripId IN (48, 49, 50)

SELECT * FROM Trips
WHERE  Id IN (48, 49, 50)