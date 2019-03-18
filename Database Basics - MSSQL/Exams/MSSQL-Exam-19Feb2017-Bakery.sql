CREATE DATABASE Bakery
USE Bakery

-- TASK 1
CREATE TABLE Products(
Id INT IDENTITY,
[Name] NVARCHAR(25) UNIQUE,
[Description] NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price MONEY,
CONSTRAINT PK_ProductId PRIMARY KEY (Id),
CONSTRAINT CHK_ProductPrice CHECK (Price > 0)
)

CREATE TABLE Countries(
Id INT IDENTITY,
[Name] NVARCHAR(50) UNIQUE,
CONSTRAINT PK_CountryId PRIMARY KEY (Id)
)

CREATE TABLE Distributors(
Id INT IDENTITY,
[Name] NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30), 
Summary NVARCHAR(200), 
CountryId INT NOT NULL
CONSTRAINT PK_DistributorId PRIMARY KEY (Id),
CONSTRAINT FK_DistributorId FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Ingredients(
Id INT IDENTITY,
[Name] NVARCHAR(30),
Description NVARCHAR(200),
OriginCountryId INT NOT NULL,
DistributorId INT NOT NULL
CONSTRAINT PK_IngredientId PRIMARY KEY (Id),
CONSTRAINT FK_DistributorIngredientId FOREIGN KEY (DistributorId) REFERENCES Distributors(Id),
CONSTRAINT FK_OriginCountry FOREIGN KEY (OriginCountryId) REFERENCES Countries(Id)
)

CREATE TABLE ProductsIngredients(
ProductId INT,
IngredientId INT
CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId,IngredientId)
CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES Products(Id),
CONSTRAINT FK_IngredientId FOREIGN KEY (IngredientId) REFERENCES Ingredients(Id)
)

CREATE TABLE Customers(
Id INT NOT NULL IDENTITY, 
FirstName NVARCHAR(25),
LastName NVARCHAR(25), 
Gender CHAR NOT NULL,
Age INT, 
PhoneNumber VARCHAR(10),
CountryId INT NOT NULL
CONSTRAINT PK_CustomerId PRIMARY KEY (Id),
CONSTRAINT FK_CountryId FOREIGN KEY (CountryId) REFERENCES Countries(Id),
CONSTRAINT CHK_Gender CHECK (Gender IN ('M', 'F')),
CONSTRAINT CHK_PhoneNumber CHECK (LEN(PhoneNumber) = 10)
)

CREATE TABLE Feedbacks(
Id INT NOT NULL IDENTITY,
[Description] NVARCHAR(255),
Rate DECIMAL(4,2),
ProductId INT NOT NULL,
CustomerId INT NOT NULL
CONSTRAINT PK_FeedbackId PRIMARY KEY (Id),
CONSTRAINT FK_FeedbackProductId FOREIGN KEY (ProductId) REFERENCES Products(Id),
CONSTRAINT FK_FeedbackCustomerId FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
CONSTRAINT CHK_Rate CHECK (Rate BETWEEN 0 AND 10)
)

-- TASK 5
SELECT Name,ROUND(Price,2), Description FROM Products
ORDER BY Price DESC, Name ASC

-- TASK 6
SELECT Name,Description,OriginCountryId FROM Ingredients
WHERE OriginCountryId IN (1,10,20)
ORDER BY Id ASC

--TASK 7
SELECT TOP 15 i.Name, i.Description, c.Name FROM Ingredients i
JOIN Countries c
ON c.Id = i.OriginCountryId
WHERE c.Name IN ('Bulgaria', 'Greece')	
ORDER BY i.Name ASC, c.Name ASC

-- TASK 8
SELECT TOP(10) p.Name, p.Description, AverageRate, FeedbackAmount FROM Products AS p
LEFT JOIN 
(SELECT ProductId, AVG(Rate) AS AverageRate, COUNT(*) AS FeedbackAmount FROM Feedbacks
GROUP BY ProductId) allRatedProducts
ON p.Id = allRatedProducts.ProductId
ORDER BY AverageRate DESC, FeedbackAmount DESC

-- TASK 9
select f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender from Feedbacks AS f
JOIN Customers AS c 
ON c.Id = f.CustomerId 
where f.Rate < 5.0
ORDER BY f.ProductId DESC, f.Rate ASC

-- TASK 10

SELECT CONCAT(FirstName, ' ' ,LastName) AS CustomerName,
		PhoneNumber,
		Gender
  FROM Customers  
WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)
ORDER BY Id
    
-- TASK 11
SELECT f.ProductId, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, f.Description AS [FeedbackDescription] FROM Feedbacks AS f
JOIN Customers AS c
ON c.Id = F.CustomerId
WHERE CustomerId IN (SELECT CustomerId FROM
(SELECT CustomerId, COUNT(*) AS FeedbacksPerCustomer FROM Feedbacks
GROUP BY CustomerId
HAVING COUNT(*) >= 3)AS a)
ORDER BY f.ProductId, CustomerName, F.Id

-- TASK 12

SELECT FirstName, Age, PhoneNumber FROM Customers
WHERE (Age >= 21 AND FirstName LIKE '%an%') OR (RIGHT(PhoneNumber,2) = '38' AND CountryId <> 31) 
ORDER BY FirstName ASC, Age DESC

-- TASK 13
SELECT d.Name, i.Name, p.Name, AverageRate.AvgRate  FROM Distributors AS d
JOIN Ingredients AS i
ON i.DistributorId = d.Id
JOIN ProductsIngredients AS pi
ON pi.IngredientId = i.Id
JOIN Products AS p
ON p.Id = PI.ProductId
JOIN
(SELECT * FROM (
SELECT ProductID, AVG(Rate) AS AvgRate FROM Feedbacks
GROUP BY ProductId) AvgRate
WHERE AvgRate.AvgRate BETWEEN 5 AND 8) AS AverageRate
ON AverageRate.ProductId = p.Id
ORDER BY d.Name, i.Name, p.Name

-- TASK 14
SELECT TOP 1 WITH TIES cn.Name AS CountryName,
       AVG(Rate) AS FeedbackRate
FROM Feedbacks AS f
     JOIN Customers AS c ON c.Id = f.CustomerId
     JOIN Countries AS cn ON cn.Id = c.CountryId
GROUP BY cn.Name
ORDER BY FeedbackRate DESC;


-- TASK 15
SELECT c1.Name, d1.Name FROM 
(SELECT c.Id, NoIngrd.DistributorId,  DENSE_RANK () OVER (PARTITION BY CountryId ORDER BY NumberOfIngredients DESC) AS DistrRanked FROM
(SELECT DistributorId, COUNT(*) AS NumberOfIngredients FROM Ingredients
GROUP BY DistributorId) AS NoIngrd
JOIN Distributors AS d
ON d.Id = NoIngrd.DistributorId
JOIN Countries AS c
ON c.Id = d.CountryId) AS CntrRanked
JOIN Distributors AS d1
ON d1.Id = CntrRanked.DistributorId 
JOIN Countries AS c1
ON c1.Id = CntrRanked.Id
WHERE CntrRanked.DistrRanked = 1
ORDER BY c1.Name ASC, d1.Name ASC


-- 16 CUSTOMERS WITH COUNTRIES 
GO
CREATE VIEW v_UserWithCountries 
AS
	SELECT CONCAT(cstm.FirstName, ' ', cstm.LastName) AS CustomerName,
	       Age, 
		   Gender,
		   cntr.Name 
      FROM Customers AS cstm
	  JOIN Countries cntr
	    ON cntr.Id = cstm.CountryId
GO
SELECT TOP 5 * FROM v_UserWithCountries ORDER BY Age

-- 17 FEEDBACK BY PRODUCT NAME
GO
CREATE FUNCTION udf_GetRating (@ProductName VARCHAR(25)) RETURNS VARCHAR(9)
AS
BEGIN
	DECLARE @ProductId INT = (SELECT ID FROM Products WHERE [Name] = @ProductName)
	DECLARE @RateRange VARCHAR(9) = ''
	DECLARE @ProductRate FLOAT = (SELECT avgRate FROM (SELECT P.Id, AVG(ISNULL(Rate, 0)) AS avgRate 
	                                                   FROM Products AS p
                                                  LEFT JOIN Feedbacks AS f
                                                         ON f.ProductId = p.Id
                                                   GROUP BY p.Id) AS rated
                                                      WHERE rated.Id = @ProductId)
	IF (@ProductRate > 8)
	BEGIN
		SET @RateRange = 'Good'
	END
    IF (@ProductRate < 5)
	BEGIN
		SET @RateRange = 'Bad'
	END
	IF (@ProductRate BETWEEN 5 AND 8)
	BEGIN
		SET @RateRange = 'Average'
	END 
	IF (@ProductRate = 0)
	BEGIN
		SET @RateRange = 'No rating'
	END                                               

RETURN @RateRange
END
GO
SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name) FROM Products ORDER BY Id


-- 18 SEND FEEDBACK
GO
CREATE PROCEDURE usp_SendFeedback (@CustomerId INT, @ProductId INT, @Rate DECIMAL(4, 2), @Description NVARCHAR(255))
AS
BEGIN
	BEGIN TRANSACTION
	DECLARE @FeedbackCount INT 
            SET @FeedbackCount = (SELECT Count(Rate)
								    FROM Feedbacks
								   WHERE CustomerId = @CustomerId AND ProductId = @ProductId)
	IF (@FeedbackCount = 3) 
	BEGIN
    	ROLLBACK
		RAISERROR ('You are limited to only 3 feedbacks per product!', 16, 1)
	END
    ELSE 
		BEGIN
		INSERT INTO Feedbacks (Description, Rate, ProductId, CustomerId) VALUES
		(@Description, @Rate, @ProductId, @CustomerId)
	END
	COMMIT
END 

-- DELETE PRODUCTS 
GO
CREATE TRIGGER tr_DeleteProduct ON Products
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM ProductsIngredients WHERE ProductId = (SELECT Id FROM deleted)
	DELETE FROM Feedbacks WHERE ProductId = (SELECT Id FROM deleted)
	DELETE FROM Products WHERE Id = (SELECT Id FROM deleted)
END
GO

-- PRODUCTS BY ONE DISTRIBUTOR
SELECT p.Name, prdRate.ProductAverageRate, d.Name, c.Name  FROM
  (SELECT distinct p.id
    FROM Products AS p
         JOIN ProductsIngredients AS pi ON pi.ProductId = p.id
         JOIN Ingredients AS i ON i.Id = pi.IngredientId 
         JOIN Distributors AS d ON d.Id = i.DistributorId
GROUP BY p.Id
  HAVING COUNT(DISTINCT d.id) = 1) AS prdsId
JOIN Products AS p
ON p.Id = prdsId.Id
JOIN 
(SELECT ProductId, AVG(Rate) AS ProductAverageRate FROM Feedbacks 
GROUP BY ProductId) AS prdRate
ON prdRate.ProductId = p.Id
JOIN ProductsIngredients AS pi
ON pi.ProductId = p.Id
JOIN Ingredients AS i 
ON i.Id = PI.IngredientId
JOIN Distributors AS d
ON d.Id = i.DistributorId
JOIN Countries AS c
ON c.Id = d.CountryId
ORDER BY p.Id





ORDER BY C.Name, d.Name

select * from Products

select * from Feedbacks

SELECT * FROM Customers

SELECT * FROM Countries

SELECT * FROM Distributors

SELECT * FROM ProductsIngredients

SELECT * FROM Ingredients