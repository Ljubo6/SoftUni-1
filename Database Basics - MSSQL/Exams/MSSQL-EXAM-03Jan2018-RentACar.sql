---------------- RENT A CAR ----------------
CREATE DATABASE RentCar
USE RentCar
GO
-- SECTION I

-- 01 CREATE
CREATE TABLE Clients(
Id INT IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Gender CHAR,
Birthdate DATETIME,
CreditCard NVARCHAR(30) NOT NULL,
CardValidity DATETIME,
Email NVARCHAR(50) NOT NULL
CONSTRAINT PK_ClientId PRIMARY KEY (Id),
CONSTRAINT CHK_Client_Gender CHECK (Gender IN ('M', 'F'))
)

CREATE TABLE Towns(
Id INT IDENTITY,
Name NVARCHAR(50) NOT NULL
CONSTRAINT PK_TownId PRIMARY KEY (Id)
)

CREATE TABLE Offices(
Id INT IDENTITY,
Name NVARCHAR(40),
ParkingPlaces INT,
TownId INT NOT NULL
CONSTRAINT PK_OfficeId PRIMARY KEY (Id),
CONSTRAINT FK_Office_Town FOREIGN KEY (TownId) REFERENCES Towns(Id)
)

CREATE TABLE Models(
Id INT IDENTITY,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(50) NOT NULL,
ProductionYear DATETIME,
Seats INT,
Class NVARCHAR(10),
Consumption DECIMAL (14,2)
CONSTRAINT PK_ModelId PRIMARY KEY (Id),
)

CREATE TABLE Vehicles(
Id INT IDENTITY,
ModelId INT NOT NULL,
OfficeId INT NOT NULL,
Mileage INT
CONSTRAINT PK_VehicleId PRIMARY KEY (Id),
CONSTRAINT FK_Vehicle_Model FOREIGN KEY (ModelId) REFERENCES Models(Id),
CONSTRAINT FK_Vehicle_Office FOREIGN KEY (OfficeId) REFERENCES Offices(Id)
)

CREATE TABLE Orders(
Id INT IDENTITY,
ClientId INT NOT NULL,
TownId INT NOT NULL,
VehicleId INT NOT NULL,
CollectionDate DATETIME NOT NULL,
CollectionOfficeId INT NOT NULL,
ReturnDate DATETIME,
ReturnOfficeId INT,
Bill DECIMAL(14,2),
TotalMileage INT
CONSTRAINT PK_OrderId PRIMARY KEY (Id),
CONSTRAINT FK_Order_Client FOREIGN KEY (ClientId) REFERENCES Clients(Id),
CONSTRAINT FK_Order_Town FOREIGN KEY (TownId) REFERENCES Towns(Id),
CONSTRAINT FK_Order_Vehicle FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id),
CONSTRAINT FK_Order_CollectionOffice FOREIGN KEY (CollectionOfficeId) REFERENCES Offices(Id),
CONSTRAINT FK_Order_ReturnOffice FOREIGN KEY (ReturnOfficeId) REFERENCES Offices(Id)
)

-- 02 INSERT
INSERT INTO Models VALUES
('Chevrolet', 'Astro', '2005-07-27 00:00:00.000', 4, 'Economy', 12.60),
('Toyota', 'Solara', '2009-10-15 00:00:00.000', 7, 'Family', 13.80),
('Volvo', 'S40', '2010-10-12 00:00:00.000', 3, 'Average', 11.30),
('Suzuki', 'Swift', '2000-02-03 00:00:00.000', 7, 'Economy', 16.20)

INSERT INTO Orders VALUES
(17, 2, 52, '2017-08-08', 30, '2017-09-04', 42, 2360.00, 7434),
(78, 17, 50, '2017-04-22', 10, '2017-05-09', 12, 2326.00, 7326),
(27, 13, 28, '2017-04-25', 21, '2017-05-09', 34, 597.00, 1880)

-- 03 UPDATE
UPDATE Models
   SET Class = 'Luxury'
 WHERE Consumption > 20

-- 04 DELETE
DELETE FROM Orders
WHERE ReturnDate IS NULL

-- 05 SHOWROOM
SELECT Manufacturer, Model FROM Models
ORDER BY Manufacturer ASC, Id DESC

-- 06 Y GENERATION

SELECT FirstName, LastName FROM Clients
WHERE DATEPART(YEAR, BirthDate) BETWEEN 1977 AND 1994
ORDER BY FirstName ASC, LastName ASC, Id ASC

-- 07 SPACIOUS OFFCE

SELECT T.Name, o.Name, o.ParkingPlaces FROM Offices AS o
JOIN Towns AS t
ON t.Id = o.TownId
WHERE o.ParkingPlaces > 25
ORDER BY t.Name ASC, o.Id ASC

-- 08 AVAILABLE VEHICLES
SELECT m.Model, m.Seats, v.Mileage FROM Vehicles AS v
JOIN Models AS m
ON m.Id = v.ModelId
WHERE v.Id NOT IN (SELECT VehicleId FROM Orders WHERE ReturnDate IS NULL)
ORDER BY v.Mileage ASC, m.Seats DESC, m.Id ASC

-- 09 OFFICES PER TOWN

SELECT T.Name AS [TownName], COUNT(*) AS OfficesNumber FROM Offices AS o
JOIN Towns AS t
ON t.Id = o.TownId
GROUP BY TownId, t.Name
ORDER BY OfficesNumber DESC, [TownName] ASC

-- 10 BUYERS BEST CHOICE
SELECT m.Manufacturer, m.Model , SUM(ISNULL(TimesOrdered, 0)) AS TimesOrdered FROM Vehicles AS v
LEFT JOIN 
(SELECT VEHICLEID, COUNT(*) AS TimesOrdered FROM Orders
GROUP BY VehicleId) AS vehord
ON vehord.VehicleId = v.Id
JOIN Models AS m
ON m.Id = v.ModelId
GROUP BY m.Manufacturer, m.Model
ORDER BY TimesOrdered DESC, M.Manufacturer DESC, m.Model ASC


-- 11 KINDA PERSON

 '  SELECT ClientId, 
          VehicleId 
     FROM Orders
 GROUP BY ClientId

  DENSE_RANK () OVER (PARTITION BY ClientId ORDER BY VehicleId) AS Ranked '







-- 12 AGE GROUP REVENUE
SELECT [AgeGroup], SUM(AgeGroups.Bill) AS [Revenue], AVG(AgeGroups.TotalMileage) AS [AverageMileage] FROM(
SELECT Bill, TotalMileage, 'AgeGroup' =
	   CASE 
		WHEN YEAR(cl.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
		WHEN YEAR(cl.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
		WHEN YEAR(cl.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
		ELSE 'Others'
	   END
  FROM Orders AS o
JOIN Clients AS cl
ON o.ClientId = cl.Id) AS AgeGroups
GROUP BY AgeGroups.[AgeGroup]
ORDER BY AgeGroup ASC

-- 13 CONSUMPTON IN MIND
SELECT Manufacturer,
       AVG(Consumption) AS AverageConsumption
FROM Models
WHERE Consumption BETWEEN 5 AND 15
      AND Id IN
(
    SELECT TOP 7 m.Id
    FROM orders AS o
         JOIN Vehicles AS v ON v.Id = o.VehicleId
         JOIN Models AS m ON m.Id = v.ModelId
    GROUP BY m.Id
    ORDER BY COUNT(o.VehicleId) DESC
)
GROUP BY Manufacturer
ORDER BY Manufacturer, AverageConsumption; 

-- 14 DEBT HUNTER
SELECT CONCAT(cr.FirstName, ' ', cr.LastName) AS [Client Name],
	   cr.Email, 
	   cr.Bill,
	   cr.Name
 FROM
(SELECT o.ClientId, o.TownId, o.VehicleId, ISNULL(o.Bill,0) AS Bill, c.FirstName, c.LastName, c.Email, t.Name,
DENSE_RANK () OVER (PARTITION BY o.TownId ORDER BY o.Bill DESC) AS [ClientsRanked]
  FROM Orders AS o
JOIN Clients AS c
ON c.Id = o.ClientId
JOIN Towns AS t
ON t.Id = o.TownId
WHERE c.CardValidity < o.CollectionDate) AS cr
WHERE cr.ClientsRanked IN (1,2) AND Bill > 0
ORDER BY cr.Name, cr.Bill ASC, cr.ClientId ASC


-- 15 TOWN STATISTICS

SELECT DISTINCT t.Name AS [TownName],  
       males.MalesCount * 100 / total.totalCount AS [MalePercent], 
	   females.FemalesCount * 100 / total.totalCount AS [FemalePercent]
  FROM Orders AS o
JOIN Clients AS c
ON c.Id = o.ClientId
JOIN Towns AS t
ON t.Id = o.TownId
LEFT JOIN
( 
SELECT t.Name, COUNT(*) AS totalCount FROM Orders AS o
JOIN Clients AS c
ON c.Id = o.ClientId
JOIN Towns AS t
ON t.Id = o.TownId
GROUP BY t.Name
) AS total
ON total.Name = t.Name
LEFT JOIN
(
SELECT t.Name, COUNT(gender) AS MalesCount FROM Orders AS o
JOIN Clients AS c
ON c.Id = o.ClientId
JOIN Towns AS t
ON t.Id = o.TownId
WHERE c.Gender = 'M'
GROUP BY t.Name
) AS males
ON males.Name = total.Name
LEFT JOIN 
(
SELECT t.Name, COUNT(gender) AS FemalesCount FROM Orders AS o
JOIN Clients AS c
ON c.Id = o.ClientId
JOIN Towns AS t
ON t.Id = o.TownId
WHERE c.Gender = 'F'
GROUP BY t.Name
) AS females
ON females.Name = t.Name
ORDER BY t.Name ASC

-- HOME SWEET HOME
SELECT CONCAT(m.Manufacturer, ' - ', m.Model) AS [Vehicle],
	   CASE 
		WHEN o.Id IS NULL THEN 'home'
		WHEN o.ReturnDate IS NULL AND o.ReturnOfficeId IS NULL THEN 'on a rent'
		WHEN v.OfficeId <> o.ReturnOfficeId THEN CONCAT (t2.name, ' - ', ofc.Name)
		END AS [Location]
 FROM Vehicles AS v
LEFT JOIN Orders AS o
ON o.VehicleId = v.Id
LEFT JOIN Models AS m
ON m.Id = v.ModelId
LEFT JOIN Towns AS t2
ON t2.Id = o.ReturnOfficeId
LEFT JOIN Offices AS ofc
ON ofc.Id = o.ReturnOfficeId
ORDER BY Vehicle ASC, v.Id

SELECT * FROM Orders
SELECT * FROM Offices
 HOME = ORDER.ID IS NULL

 ON A RENT = ORDER.RETURNDATE IS NULL
 
 WHEN v.OfficeId <> o.ReturnOfficeId THEN CONCAT ('name of the town and the name of the office, it was turned back to')



















SELECT CONCAT(m.Manufacturer, ' - ', m.Model) AS Vehicle,
       'Location' =
	   CASE
			WHEN ord.Id IS NULL THEN 'home'
			WHEN ord.ReturnOfficeId IS NULL THEN 'on a rent'
			WHEN V.OfficeId <> ord.ReturnOfficeId THEN 
			(SELECT CONCAT(t.Name, ' - ', o.Name) WHERE v.Id = ord.VehicleId)
		END
 FROM Offices AS o
JOIN Towns AS t
ON t.Id = o.TownId
JOIN  Orders AS ord
ON ord.ReturnOfficeId = o.Id
JOIN Vehicles AS v
ON v.Id = ord.VehicleId
JOIN Models AS m
ON m.Id = v.ModelId
ORDER BY Vehicle ASC, V.Id ASC


-- FIND MY RIDE
GO
CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @output NVARCHAR(100) = (SELECT TOP(1) CONCAT(o.Name , ' - ', m.Model) FROM  VEHICLES AS v
									JOIN Models AS m
									ON m.Id = v.ModelId
									JOIN Offices AS o
									ON o.Id = V.OfficeId
									JOIN Towns AS t
									ON t.Id = O.TownId
									WHERE m.Seats = @seatsNumber AND t.Name = @townName
									ORDER BY o.Name ASC)

		IF(@output IS NULL)
		BEGIN
			SET @output =  'NO SUCH VEHICLE FOUND'
		END
	RETURN @output
END
GO

SELECT dbo.udf_CheckForVehicle ('La Escondida', 9) 

-- MOVE A VEHICLE
GO
CREATE PROC usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
BEGIN
	DECLARE @OccupiedPlaces INT = (SELECT COUNT(*) AS OccupiedPlaces FROM Vehicles AS v
	    JOIN Offices AS o
		ON o.Id = v.OfficeId
		WHERE o.Id = @officeId
		GROUP BY o.Id, o.ParkingPlaces)
BEGIN TRANSACTION
		UPDATE Vehicles
		SET OfficeId = @officeId
		WHERE Id = @vehicleId

		IF (@OccupiedPlaces >= (SELECT ParkingPlaces FROM Offices WHERE Id = @officeId))
		BEGIN
			RAISERROR ('Not enough room in this office!', 16, 1)
			ROLLBACK;
		END
	COMMIT
END
GO

-- MOVE THE TALLY
CREATE OR ALTER TRIGGER tr_MileageTransfer ON Orders
AFTER UPDATE
AS
BEGIN
	IF ((SELECT TotalMileage FROM deleted) IS NULL)
	BEGIN
	UPDATE Vehicles
	SET Mileage = Mileage + (SELECT totalMileage FROM inserted as i
								JOIN Vehicles AS v
								  ON v.Id = i.VehicleId
								  WHERE i.Id = (SELECT VehicleId FROM inserted)
	END

END

UPDATE Orders
SET
TotalMileage = 100
WHERE Id = 40;


EXEC usp_MoveVehicle 7, 32;
EXEC usp_MoveVehicle 7, 32;
SELECT OfficeId FROM Vehicles WHERE Id = 7








SELECT * FROM Clients
SELECT * FROM Offices
SELECT * FROM Orders
SELECT * FROM Models

SELECT * FROM VEHICLES AS v
JOIN Models AS m
ON m.Id = v.ModelId
JOIN Offices AS o
ON o.Id = V.OfficeId
JOIN Towns AS t
ON t.Id = O.TownId