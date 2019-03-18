--+++++++++++++++++++++++++++++++++++++++++++++++--
-- EXAM DB 24 APR 2017 - Washing Machine Service --
--+++++++++++++++++++++++++++++++++++++++++++++++--
DROP DATABASE WMS
CREATE DATABASE WMS
USE WMS
GO

--++ SECTION 1: DDL ++--
CREATE TABLE Clients(
ClientID INT IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Phone VARCHAR(12) NOT NULL,
CONSTRAINT PK_ClientID PRIMARY KEY (ClientID),
CONSTRAINT CHK_PhoneLen CHECK (LEN(Phone) = 12)
)

CREATE TABLE Mechanics(
MechanicID INT IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Address VARCHAR(255) NOT NULL,
CONSTRAINT PK_MechanicID PRIMARY KEY (MechanicID)
)

CREATE TABLE Models(
ModelId INT IDENTITY,
[Name] VARCHAR(50) NOT NULL,
CONSTRAINT PK_ModelID PRIMARY KEY (ModelID),
CONSTRAINT UC_Name UNIQUE ([Name])
)

CREATE TABLE Jobs(
JobId INT IDENTITY,
ModelId INT NOT NULL,
[Status] VARCHAR(11) NOT NULL DEFAULT 'Pendind',
ClientId INT NOT NULL,
MechanicId INT NULL,
IssueDate DATE NOT NULL,
FinishDate DATE NULL,
CONSTRAINT PK_JobsId PRIMARY KEY (JobID),
CONSTRAINT FK_ModelId FOREIGN KEY (ModelId) REFERENCES Models(ModelId),
CONSTRAINT FK_MechanicID FOREIGN KEY (MechanicID) REFERENCES Mechanics(MechanicID),
CONSTRAINT FK_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),
CONSTRAINT CHK_Status CHECK ([Status] IN ('Pending', 'In Progress', 'Finished'))
)

CREATE TABLE Vendors(
VendorId INT IDENTITY,
[Name] VARCHAR(50) NOT NULL,
CONSTRAINT PK_VendorId PRIMARY KEY (VendorId),
CONSTRAINT UC_VendorName UNIQUE ([Name])
)

CREATE TABLE Orders(
OrderId INT NOT NULL IDENTITY,
JobId INT NOT NULL,
IssueDate DATE, 
Delivered BIT NOT NULL DEFAULT 0,
CONSTRAINT PK_OrderId PRIMARY KEY (OrderID),
CONSTRAINT FK_JobId FOREIGN KEY (JobId) REFERENCES Jobs(JobId)
)

CREATE TABLE Parts(
PartId INT IDENTITY,
SerialNumber VARCHAR(50) UNIQUE NOT NULL,
[Description] VARCHAR(255) NULL,
Price DECIMAL (6,2) NOT NULL,
VendorId INT NOT NULL,
StockQty INT DEFAULT '0',
CONSTRAINT PK_PartID PRIMARY KEY (PartId),
CONSTRAINT CHK_Price CHECK (Price > 0 AND Price <= 9999.99),
CONSTRAINT FK_VendorId FOREIGN KEY (VendorId) REFERENCES Vendors(VendorId),
CONSTRAINT CHK_StockQty CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts(
OrderId INT NOT NULL,
PartId INT NOT NULL,
Quantity INT NOT NULL DEFAULT '1',
CONSTRAINT PK_OrderParts PRIMARY KEY(OrderId, PartId),
CONSTRAINT FK_OrderParts_OrderId FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
CONSTRAINT FK_OrderParts_PartId FOREIGN KEY (PartId) REFERENCES Parts(PartId),
CONSTRAINT CHK_Quantity CHECK (Quantity > 0)
)

CREATE TABLE PartsNeeded(
PartsNeededId INT IDENTITY,
JobId INT NOT NULL,
PartId INT NOT NULL,
Quantity INT NOT NULL DEFAULT '1',
CONSTRAINT PK_PartsNeeded PRIMARY KEY(JobId, PartId),
CONSTRAINT FK_Partsneeded_JobId FOREIGN KEY (JobId) REFERENCES Jobs(JobId),
CONSTRAINT FK_Partsneeded_PartId FOREIGN KEY (PartId) REFERENCES Parts(PartId),
CONSTRAINT CHK_Partsneeded_Quantity CHECK (Quantity > 0)
)

--++ SECTION 1: DML ++--

-- TASK 2 --
INSERT INTO Clients VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2, 0), 
('W10780048', 'Suspension Rod', 42.81, 1, 0), 
('W10841140', 'Silicone Adhesive', 6.77, 4, 0), 
('WPY055980', 'High Temperature Adhesive', 13.94, 3, 0)

-- TASK 3
UPDATE Jobs
SET MechanicId = 3, Status = 'In Progress'
WHERE Status = 'Pending'

-- TASK 4 DELETE
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

-- TASK 5

SELECT FirstName, LastName, Phone FROM Clients
ORDER BY LastName, ClientID
-- TASK 6
SELECT Status, IssueDate FROM Jobs
WHERE Status <> 'Finished'
ORDER BY IssueDate, JobId

-- TASK 7
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic],
       j.Status,
	   j.IssueDate
  FROM Jobs j
JOIN Mechanics m
ON m.MechanicID = j.MechanicId
ORDER BY m.MechanicID, j.IssueDate, j.JobId

-- TASK 8

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [Client],
       DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	   j.Status
  FROM Jobs AS j
JOIN Clients AS c
ON c.ClientID = j.ClientId
WHERE j.Status <> 'Finished'
ORDER BY [Days going] DESC, j.ClientId

-- TASK 9
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic],
       AVG(DATEDIFF(DAY, IssueDate,FinishDate)) AS [Average Days] FROM Jobs AS j
JOIN Mechanics AS m
ON m.MechanicID = J.MechanicId
WHERE FinishDate IS NOT NULL
GROUP BY j.MechanicId, CONCAT(m.FirstName, ' ', m.LastName)

-- TASK 10

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic], 
	   COUNT(JobId) AS Jobs 
  FROM Jobs AS j
  JOIN Mechanics AS m
    ON m.MechanicId = j.MechanicId
 WHERE Status <> 'Finished'
 GROUP BY J.MechanicId, CONCAT(m.FirstName, ' ', m.LastName)
 HAVING COUNT(JobId) > 1
 ORDER BY Jobs DESC

 -- TASK 11
SELECT CONCAT(FirstName, ' ', LastName) AS [Availabe] FROM Mechanics
WHERE MechanicID NOT IN (SELECT MechanicId FROM Jobs
WHERE Status <> 'Finished')

-- TASK 12
SELECT ISNULL(SUM(p.Price * op.Quantity),0) AS [Parts Total] FROM Orders AS o
JOIN OrderParts AS op
ON op.OrderId = o.OrderId
JOIN Parts AS p
ON p.PartId = op.PartId
WHERE o.IssueDate > (DATEADD(WEEK, -3 , '2017-04-24'))

-- TASK 13

SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity),0) AS [Total] FROM Jobs AS j
LEFT JOIN Orders AS o
  ON o.JobId = j.JobId
  LEFT JOIN OrderParts AS op
ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p
ON p.PartId = op.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC

-- TASK 14
SELECT j.ModelId, m.Name, CONCAT(AVG(DATEDIFF(DAY,IssueDate, FinishDate)), ' days') AS [Average Service Time] FROM Jobs AS j
JOIN Models AS m
ON m.ModelId = j.ModelId
WHERE FinishDate IS NOT NULL
GROUP BY J.ModelId, m.Name
ORDER BY AVG(DATEDIFF(DAY,IssueDate, FinishDate)) ASC

-- TASK 15

SELECT TOP (1) WITH TIES m.Name, MAX(CountedFaults.Counting) AS [Times Serviced],
       ISNULL(SUM(p.Price * op.Quantity),0) AS [Parts Total]
  FROM (
        SELECT ModelId, COUNT(ModelId) AS Counting 
		  FROM Jobs
      GROUP BY ModelId) AS CountedFaults
JOIN Jobs AS j
ON j.ModelId = CountedFaults.ModelId
JOIN Orders AS o
ON o.JobId = j.JobId
JOIN OrderParts AS op
 ON op.OrderId = o.OrderId
 JOIN Parts AS p
 ON p.PartId = op.PartId
JOIN Models AS m
ON m.ModelId = CountedFaults.ModelId
WHERE o.JobId IN (SELECT JobId FROM Jobs WHERE ModelId = CountedFaults.ModelId)
GROUP BY m.Name
ORDER BY [Times Serviced] DESC

-- TASK 16
SELECT p.PartId, p.[Description], pn.Quantity AS [Required], p.StockQty AS [In Stock], ISNULL(op.Quantity,0) AS Ordered FROM Jobs AS j
LEFT JOIN PartsNeeded AS pn
ON pn.JobId = j.JobId
LEFT JOIN Parts AS p
ON p.PartId = pn.PartId
LEFT JOIN Orders AS o
ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op
ON op.OrderId = o.OrderId
WHERE [Status] <> 'Finished' AND (ISNULL(p.StockQty,0) + ISNULL(op.Quantity, 0)) < pn.Quantity
ORDER BY p.PartId ASC
-- PROBLEM 17
GO
CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(6,2)
AS
BEGIN
	DECLARE @TotalCost DECIMAL(6,2)

	SET @TotalCost = (SELECT (ISNULL(SUM(p.Price * op.Quantity),0))
	  FROM Orders AS o
		JOIN OrderParts AS op 
		  ON op.OrderId = o.OrderId
		JOIN Parts AS p 
		  ON p.PartId = op.PartId
		WHERE o.JobId = @JobId)

		 IF @TotalCost IS NULL

             RETURN 0;

RETURN @TotalCost
END

GO
SELECT dbo.udf_GetCost(1)
-- TASK 18
GO
CREATE PROC dbo.usp_PlaceOrder @JobId INT, @SerialNumber VARCHAR(50), @Quantity INT
AS
BEGIN
	DECLARE @JobStatus VARCHAR(30) = (SELECT [Status] FROM Jobs WHERE JobId = @JobId)
	DECLARE @JobsIdinDB INT = (SELECT JobId FROM Jobs WHERE JobId = @JobId AND Status <> 'Finished')
	DECLARE @PartOrdered INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
	DECLARE @OrderId INT = (SELECT TOP 1 OrderId FROM Orders WHERE JobId = @JobId)
	
	BEGIN TRANSACTION	
	IF (@JobId NOT IN (SELECT JobId FROM Jobs)) --WHERE Status <> 'Finished'))
	BEGIN
		INSERT INTO Orders VALUES
		(@JobId, NULL, 0) 
		DECLARE @NewOrderId INT = (SELECT TOP 1 OrderId FROM Orders WHERE JobId = @JobId)
		INSERT INTO OrderParts VALUES
		(@NewOrderId, @PartOrdered, @Quantity)
	END
	IF (@JobId = @JobsIdinDB AND @PartOrdered = (SELECT PartId FROM OrderParts WHERE OrderId = @OrderId))
	
	--(@PartOrdered = (SELECT PartId FROM OrderParts WHERE OrderId = @OrderId) AND (SELECT OrderId FROM Orders WHERE JobId = @JobId) = @PartOrdered)
		BEGIN
			UPDATE OrderParts
			SET Quantity = Quantity + @Quantity
			WHERE OrderId = @OrderId AND PartId = @PartOrdered
		END

	ELSE IF (@JobId = @JobsIdinDB AND (SELECT TOP 1 IssueDate FROM Orders WHERE JobId = @JobId) IS NULL)
	BEGIN
		BEGIN
			INSERT INTO OrderParts VALUES
			(@OrderId, @PartOrdered, @Quantity)
		END
	END
	IF (@Quantity <= 0)
	BEGIN
		RAISERROR ('Part quantity must be more than zero!', 16, 2)
		ROLLBACK;
	END

	IF (@JobStatus = 'Finished')
	BEGIN
		RAISERROR ('This job is not active!', 16, 1)
		ROLLBACK;
	END
	
	IF (@JobsIdinDB IS NULL)
	BEGIN
		RAISERROR ('Job not found!', 16, 3)
		ROLLBACK;
	END
	IF (@PartOrdered IS NULL)
	BEGIN
		RAISERROR ('Part not found!', 16, 4)
		ROLLBACK;
	END
COMMIT
END

@JobId IN (SELECT JobId FROM Orders) AND

-- TASK 19
GO
CREATE TRIGGER tr_OrderDelivered ON Orders
AFTER UPDATE
AS
BEGIN
	UPDATE Parts
	SET StockQty = StockQty + (SELECT Quantity FROM OrderParts WHERE OrderId = (SELECT OrderId FROM inserted AS i
																					JOIN deleted AS d 
																					ON d.OrderId = i.OrderId WHERE d.Delivered <> i.Delivered) 
										AND PartId = 
END


SELECT * FROM Orders
SELECT * FROM Parts

SELECT * FROM OrderParts





	INSERT INTO Orders VALUES
	SELECT 
END



SELECT * FROM Orders
SELECT * FROM OrderParts
SELECT * FROM Parts
SELECT * FROM Models
SELECT * FROM Jobs

