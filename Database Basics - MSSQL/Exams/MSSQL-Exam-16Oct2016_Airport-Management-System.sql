---------------------------------------------------------------------------------------
------------------------------ AIRPORT MANAGEMENT SYSTEM ------------------------------
---------------------------------------------------------------------------------------
CREATE DATABASE AMS
USE AMS
GO

------------------------------- SECTION 01 -------------------------------
CREATE TABLE Towns (
	TownID INT,
	TownName VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY(TownID)
)

CREATE TABLE Airports (
	AirportID INT,
	AirportName VARCHAR(50) NOT NULL,
	TownID INT NOT NULL,
	CONSTRAINT PK_Airports PRIMARY KEY(AirportID),
	CONSTRAINT FK_Airports_Towns FOREIGN KEY(TownID) REFERENCES Towns(TownID)
)

CREATE TABLE Airlines (
	AirlineID INT,
	AirlineName VARCHAR(30) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Rating INT DEFAULT(0),
	CONSTRAINT PK_Airlines PRIMARY KEY(AirlineID)
)

CREATE TABLE Customers (
	CustomerID INT,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Gender VARCHAR(1) NOT NULL CHECK (Gender='M' OR Gender='F'),
	HomeTownID INT NOT NULL,
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
	CONSTRAINT FK_Customers_Towns FOREIGN KEY(HomeTownID) REFERENCES Towns(TownID)
)

CREATE TABLE Flights(
FlightID INT,	
DepartureTime DATETIME NOT NULL,
ArrivalTime	DATETIME NOT NULL,
[Status] VARCHAR(9) DEFAULT ('Cancelled'),
OriginAirportID	INT NOT NULL, 	
DestinationAirportID INT NOT NULL,
AirlineID INT NOT NULL
CONSTRAINT PK_FlightID PRIMARY KEY (FlightID),
CONSTRAINT FK_OriginAirportID FOREIGN KEY (OriginAirportID) REFERENCES Airports(AirportID),
CONSTRAINT FK_DestinationAirportID FOREIGN KEY (DestinationAirportID) REFERENCES Airports(AirportID),
CONSTRAINT CHK_Status CHECK ([Status] IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')))

CREATE TABLE Tickets(
TicketID INT,
Price DECIMAL(8,2) NOT NULL,
Class VARCHAR(6),
Seat VARCHAR(5) NOT NULL,
CustomerID INT NOT NULL,
FlightID INT NOT NULL
CONSTRAINT PK_TicketID PRIMARY KEY (TicketID),
CONSTRAINT CHK_Class CHECK (Class IN ('First', 'Second', 'Third')),
CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
CONSTRAINT FK_FlightID FOREIGN KEY (FlightID) REFERENCES Flights(FlightID))



------------------------------- SECTION 2 -------------------------------
INSERT INTO Towns(TownID, TownName)
VALUES
(1, 'Sofia'),
(2, 'Moscow'),
(3, 'Los Angeles'),
(4, 'Athene'),
(5, 'New York')

INSERT INTO Airports(AirportID, AirportName, TownID)
VALUES
(1, 'Sofia International Airport', 1),
(2, 'New York Airport', 5),
(3, 'Royals Airport', 1),
(4, 'Moscow Central Airport', 2)

INSERT INTO Airlines(AirlineID, AirlineName, Nationality, Rating)
VALUES
(1, 'Royal Airline', 'Bulgarian', 200),
(2, 'Russia Airlines', 'Russian', 150),
(3, 'USA Airlines', 'American', 100),
(4, 'Dubai Airlines', 'Arabian', 149),
(5, 'South African Airlines', 'African', 50),
(6, 'Sofia Air', 'Bulgarian', 199),
(7, 'Bad Airlines', 'Bad', 10)

INSERT INTO Customers(CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
VALUES
(1, 'Cassidy', 'Isacc', '19971020', 'F', 1),
(2, 'Jonathan', 'Half', '19830322', 'M', 2),
(3, 'Zack', 'Cody', '19890808', 'M', 4),
(4, 'Joseph', 'Priboi', '19500101', 'M', 5),
(5, 'Ivy', 'Indigo', '19931231', 'F', 1)

-- TASK 1 --
INSERT INTO Flights VALUES
(1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1, 4, 1),
(2, '2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 1, 3, 2),
(3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 4, 2, 4),
(4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
(5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
(6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
(7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
(8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
(9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
(10,'2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets VALUES
(1, 3000.00, 'First', '233-A', 3, 8),
(2, 1799.90, 'Second', '123-D', 1, 1),
(3, 1200.50, 'Second', '12-Z', 2, 5),
(4, 410.68, 'Third', '45-Q', 2,	8),
(5, 560.00, 'Third', '201-R', 4, 6),
(6, 2100.00, 'Second', '13-T', 1, 9),
(7, 5500.00, 'First', '98-O',2, 7)

-- TASK 2
UPDATE Flights
   SET AirlineID = 1
 WHERE [Status] LIKE 'Arrived'

-- TASK 3
UPDATE t 
   SET t.Price = t.Price * 1.5
  FROM Tickets t
  JOIN Flights f
    ON f.FlightID = t.FlightID
 WHERE AirlineID = 1

-- TASK 4
CREATE TABLE CustomerReviews(
ReviewID INT NOT NULL IDENTITY,
ReviewContent VARCHAR(255),
ReviewGrade INT,
AirlineID INT NOT NULL,
CustomerID INT NOT NULL
CONSTRAINT PK_ReviewID PRIMARY KEY (ReviewID),
CONSTRAINT CHK_ReviewGrade CHECK (ReviewGrade BETWEEN 1 AND 10),
CONSTRAINT FK_AirlineID FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID),
CONSTRAINT FK_ReviewByCustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID))

CREATE TABLE CustomerBankAccounts(
AccountID INT NOT NULL IDENTITY, 
AccountNumber VARCHAR(10) UNIQUE NOT NULL,
Balance DECIMAL(10,2) NOT NULL,
CustomerID INT NOT NULL
CONSTRAINT PK_AccountID PRIMARY KEY (AccountID),
CONSTRAINT FK_BalanceOfCustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID))

-- TASK 5
INSERT INTO CustomerReviews VALUES
('Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
('Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1,	4),
('Meh...',5,	4, 3),
('Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts VALUES
('123456790', 2569.23, 1),
('18ABC23672', 14004568.23, 2),
('F0RG0100N3', 19345.20, 5)

------------------------------- SECTION 2 -------------------------------
-- TASK 1
SELECT TicketID, Price, Class, Seat FROM Tickets
ORDER BY TicketID ASC

-- TASK 2
SELECT CustomerID, CONCAT(FirstName, ' ', LastName) AS [FullName], Gender FROM Customers
ORDER BY FullName ASC, CustomerID ASC

-- TASK 3
SELECT FlightID, DepartureTime, ArrivalTime FROM Flights
WHERE [Status] = 'Delayed'

-- TASK 4
'SELECT TOP 5 A.AirlineID, A.AirlineName, A.Nationality, A.Rating FROM Flights AS f
INNER JOIN Airlines AS A
ON f.AirlineID = a.AirlineID
WHERE a.AirlineID = f.AirlineID
GROUP BY A.AirlineID, A.AirlineName, A.Nationality, A.Rating
ORDER BY Rating DESC'

-- TASK 5
SELECT t.TicketID,
       a.AirportName AS [Destination],
       CONCAT(c.[FirstName], ' ', c.Lastname) AS [CustomerName]
FROM Tickets t
     JOIN Flights f ON f.FlightID = t.FlightID
     JOIN Customers c ON c.CustomerID = t.CustomerID
     JOIN Airports a ON a.AirportID = f.DestinationAirportID
WHERE t.Price < 5000 AND T.Class LIKE 'First'
ORDER BY t.TicketID ASC

-- TASK 6
SELECT c.CustomerID, CONCAT(C.FirstName, ' ', c.LastName) AS [FullName], tn.TownName AS [HomeTown]  FROM Flights AS f
JOIN Tickets AS t
ON t.FlightID = f.FlightID
JOIN Customers AS c
ON c.CustomerID = t.CustomerID
JOIN Airports AS a
ON a.AirportID = f.OriginAirportID
JOIN Towns AS tn
ON tn.TownID = a.TownID
WHERE c.HomeTownID = a.TownID AND f.Status = 'Departing'


-- TASK 7
SELECT DISTINCT t.CustomerID, 
	   CONCAT(c.Firstname, ' ', c.LastName) AS [FullName],
	   (SELECT DATEDIFF(YEAR, CAST((SELECT DATEPART(YEAR, c.DateOfBirth)) AS varchar(4)), '2016')) AS [Age]
  FROM Tickets t
JOIN Flights f
ON f.FlightID = t.FlightID
join Customers c
on c.CustomerID = t.CustomerID
where f.Status = 'departing'
ORDER BY Age ASC, CustomerID ASC

-- TASK 8
SELECT TOP 3 c.CustomerID, CONCAT(c.Firstname, ' ', c.LastName) AS [FullName], t.Price, a.AirportName AS [Destination] 
  FROM Tickets t
JOIN Flights f
  ON f.FlightID = t.FlightID
JOIN Customers c
  ON c.CustomerID = t.CustomerID
JOIN Airports a
  ON a.AirportID = F.DestinationAirportID
WHERE f.Status = 'Delayed'
ORDER BY t.Price DESC, C.CustomerID ASC

-- TASK 9
SELECT TOP 5 FlightID, DepartureTime, ArrivalTime, a.AirportName, aa.AirportName FROM 
(SELECT *, DENSE_RANK () OVER (Order BY DepartureTime DESC) AS RankedTime FROM Flights
WHERE [Status] = 'Departing') AS rankedDepart
JOIN Airports AS a
ON a.AirportID = rankedDepart.OriginAirportID
JOIN Airports AS aa
ON aa.AirportID = rankedDepart.DestinationAirportID
WHERE rankedDepart.RankedTime BETWEEN 1 AND 5
ORDER BY RankedTime DESC, FlightID ASC

-- TASK 10
'SELECT c.CustomerID, 
       CONCAT(C.FirstName, ' ', c.LastName) AS [FullName], 
	   DATEDIFF(YEAR, CAST(DATEPART(YEAR,DateOfBirth) AS varchar), '2016') AS [Age]
	    FROM Tickets AS t
INNER JOIN Customers as c
ON c.CustomerID = t.CustomerID
WHERE DATEDIFF(YEAR, CAST(DATEPART(YEAR,c.DateOfBirth) AS varchar), '2016') < 21  AND T.FlightID = (SELECT F2.FlightID FROM Flights f2
																									  JOIN Tickets AS t2
																									    ON t2.FlightID = f2.FlightID
																									 WHERE F2.Status = 'Arrived' AND t2.CustomerID = c.CustomerID)
ORDER BY c.CustomerID ASC'


-- TASK 11
SELECT AP.AirportID, AP.AirportName, COUNT(ap.TicketID) AS [Passangers] FROM (
SELECT a.AirportID, a.AirportName, T.TicketID
  FROM Flights f
  JOIN Tickets T
    ON T.FlightID = f.FlightID
  JOIN Airports a
    ON a.AirportID = f.OriginAirportID
WHERE [Status] = 'Departing') AS ap
GROUP BY ap.AirportID, ap.AirportName
ORDER BY ap.AirportID ASC

------------------------------- SECTION 4 -------------------------------
--TASK 1
GO
CREATE PROCEDURE usp_SubmitReview (@CustomerID INT, @ReviewContent VARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30))
AS
BEGIN
	
	BEGIN TRANSACTION 
	DECLARE @AirlineId INT = (SELECT AirlineID FROM Airlines WHERE AirlineName = @AirlineName)
		IF (@AirlineId IS NULL)
	BEGIN
		RAISERROR ('Airline does not exist.', 16, 1)
		ROLLBACK;
	END
		IF (@ReviewGrade < 1 OR @ReviewGrade > 10)
		BEGIN
			ROLLBACK
		END
		ELSE 
		BEGIN
			INSERT INTO CustomerReviews (ReviewContent, ReviewContent, AirlineID, CustomerID) VALUES
			(@ReviewContent, @ReviewContent, @AirlineId, @CustomerID)
		END
COMMIT
END


-- TASK 2
GO


select * from CustomerBankAccounts
SELECT * FROM Tickets
SELECT * FROM Flights
SELECT * FROM Customers
SELECT * FROM Towns
SELECT * FROM Airports