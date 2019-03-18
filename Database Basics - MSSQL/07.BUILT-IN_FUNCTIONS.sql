--================================================--
--------------------- PART 1 -----------------------
--================================================--

USE SoftUni

-------- PROBLEM 1 ---------
SELECT FirstName, LastName 
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

-------- PROBLEM 2 ---------
SELECT FirstName, LastName 
  FROM Employees
 WHERE LastName LIKE '%ei%'

-------- PROBLEM 3 ---------
     SELECT FirstName 
	   FROM Employees
      WHERE DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005 AND DepartmentID IN (3, 10)

-------- PROBLEM 4 ---------
SELECT FirstName, LastName 
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

-------- PROBLEM 5 ---------
   SELECT [Name] 
     FROM Towns
    WHERE LEN ([Name]) IN (5, 6)
 ORDER BY [Name]

-------- PROBLEM 6 ---------
   SELECT TownID, [Name] 
     FROM Towns
    WHERE SUBSTRING ([Name], 1, 1) LIKE '[MKBE]'
 ORDER BY [Name]

-------- PROBLEM 7 ---------
   SELECT TownID, [Name] 
     FROM Towns
    WHERE SUBSTRING ([Name], 1, 1) NOT LIKE '[RBD]'
 ORDER BY [Name]

-------- PROBLEM 8 ---------
GO
CREATE VIEW v_EmployeesHiredAfter2000 AS
     SELECT FirstName, LastName FROM Employees
	  WHERE (DATEPART(YEAR, HireDate) > 2000)
GO
SELECT * FROM v_EmployeesHaredAfter2000

-------- PROBLEM 9 ---------
SELECT FirstName, Lastname FROM Employees
 WHERE LEN(LastName) = 5

--================================================--
--------------------- PART 2 -----------------------
--================================================--

USE Geography

-------- PROBLEM 10 ---------
  SELECT CountryName, IsoCode FROM Countries
   WHERE (LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', ''))) >= 3
ORDER BY IsoCode

-------- PROBLEM 11 ---------
 SELECT p.PeakName, r.RiverName, LOWER( 
        LEFT(p.PeakName,LEN(PeakName) - 1) + r.RiverName)
     AS 'Mix' 
   FROM Peaks p
INNER JOIN Rivers r
      ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix


--================================================--
--------------------- PART 3 -----------------------
--================================================--

USE Diablo

-------- PROBLEM 12 --------- 
SELECT TOP(50) [Name], 
               CONVERT(NVARCHAR(20),CAST([Start] AS DATE), 120) as [Start] 
      FROM Games
     WHERE DATEPART(YEAR, [Start]) IN (2011, 2012) 
  ORDER BY [Start], [Name]

-------- PROBLEM 13 ---------
    SELECT Username, 
	       RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1)) AS 'Email Provider'  
      FROM Users
  ORDER BY [Email Provider], Username

-------- PROBLEM 14 ---------
  SELECT Username, IpAddress FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-------- PROBLEM 15 ---------

SELECT [Name],
       'Part of the Day' =
	   CASE
          WHEN (DATEPART(HOUR,Start)>= 0 AND DATEPART(HOUR,Start)< 12) THEN 'Morning'
	      WHEN (DATEPART(HOUR,Start)>= 12 AND DATEPART(HOUR,Start)< 18) THEN 'Afternoon'
		  WHEN (DATEPART(HOUR,Start)>= 18 AND DATEPART(HOUR,Start)< 24) THEN 'Evening'
		  END,
	   'Duration' =
	   CASE 
	     WHEN (Duration <= 3) THEN 'Extra Short'
		 WHEN (Duration > 3 AND Duration <= 6) THEN 'Short'
		 WHEN (Duration > 6) THEN 'Long'
		 WHEN Duration IS NULL THEN 'Extra Long'
       END
FROM Games
ORDER BY [Name], Duration, [Part of the Day]

-------- PROBLEM 16 ---------

USE Orders

SELECT ProductName, OrderDate, 
CAST(DATEADD(DAY, 3, OrderDate) AS DATE) AS PayDate, 
CAST(DATEADD(MONTH, 1, OrderDate) AS DATE) AS DeliveryDate
     FROM Orders

-------- PROBLEM 17 ---------

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
Birthdate DATETIME NOT NULL
)

INSERT INTO People VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT [Name],
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS 'Age in Years',
	   DATEDIFF(MONTH, Birthdate, GETDATE()) AS 'Age in Months',
	   DATEDIFF(DAY, Birthdate, GETDATE()) AS 'Age in Days',
	   DATEDIFF(MINUTE, Birthdate, GETDATE()) AS 'Age in Minutes'
	   FROM People