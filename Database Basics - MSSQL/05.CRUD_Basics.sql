--================================================--
--------------------- PART 1 -----------------------
--================================================--

USE SoftUni

-------- PROBLEM 2 ---------
SELECT * FROM Departments

-------- PROBLEM 3 ---------
SELECT [NAME] FROM Departments

-------- PROBLEM 4 ---------
SELECT FirstName, LastName, Salary FROM Employees

-------- PROBLEM 5 ---------
SELECT FirstName, MiddleName, LastName FROM Employees

-------- PROBLEM 6 ---------
SELECT FirstName+'.'+LastName+'@softuni.bg' AS [Full Email Address]
FROM Employees;

-------- PROBLEM 7 ---------
SELECT DISTINCT Salary 
FROM Employees

-------- PROBLEM 8 ---------
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

-------- PROBLEM 9 ---------
SELECT FirstName,
       LastName,
       JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000;

-------- PROBLEM 10 ---------
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

-------- PROBLEM 11 ---------
SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

-------- PROBLEM 12 ---------
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary >= 50000
ORDER BY Salary DESC

-------- PROBLEM 13 ---------
SELECT TOP (5) FirstName, LastName
FROM Employees
ORDER BY Salary DESC

-------- PROBLEM 14 ---------
SELECT FirstName, LastName
FROM Employees
WHERE DepartmentID != 4

-------- PROBLEM 15 ---------
SELECT * FROM Employees
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName DESC

-------- PROBLEM 16 ---------
GO
CREATE VIEW v_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
FROM Employees
GO 
SELECT * FROM v_EmployeesSalaries

-------- PROBLEM 17 ---------
GO
CREATE VIEW v_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName,'') + ' ' + LastName AS [Full Name],
       JobTitle
FROM Employees
GO
SELECT * FROM v_EmployeeNameJobTitle

-------- PROBLEM 18 ---------
SELECT DISTINCT JobTitle
FROM Employees

-------- PROBLEM 19 ---------
SELECT TOP(10) * FROM Projects
ORDER BY StartDate, [NAME]

-------- PROBLEM 20 ---------
SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC

-------- PROBLEM 21 ---------
UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN (1, 2, 4, 11)
SELECT Salary FROM Employees

--================================================--
--------------------- PART 2 -----------------------
--================================================--

USE Geography

-------- PROBLEM 22 ---------
SELECT PeakName FROM Peaks
ORDER BY PeakName

-------- PROBLEM 23 ---------
SELECT TOP(30) CountryName, [Population] FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName

-------- PROBLEM 24 ---------
GO
   SELECT CountryName, CountryCode, Currency =
     CASE CurrencyCode
          WHEN 'EUR' THEN 'Euro'
	      ELSE 'Not Euro'
	  END
     FROM Countries
 ORDER BY CountryName

--================================================--
--------------------- PART 3 -----------------------
--================================================--

USE Diablo

SELECT [Name] FROM Characters
ORDER BY [Name]