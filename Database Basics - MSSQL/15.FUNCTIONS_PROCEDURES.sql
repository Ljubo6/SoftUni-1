--================================================--
 -------------- PART I : SOFTUNI DB ---------------
--================================================--

USE SoftUni
GO

-------- PROBLEM 1 ---------
CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
     SELECT FirstName,
            LastName
       FROM Employees
      WHERE Salary > 35000;
-- NOT TO BE SUBMITTED INTO JUDGE
EXEC dbo.usp_GetEmployeesSalaryAbove35000;

-------- PROBLEM 2 ---------
GO
CREATE PROC dbo.usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18, 4)  = 0)
AS
     SELECT FirstName,
            LastName
       FROM Employees
      WHERE Salary >= @minSalary;
-- NOT TO BE SUBMITTED INTO JUDGE
EXEC dbo.usp_GetEmployeesSalaryAboveNumber  48100;

-------- PROBLEM 3 ---------
GO
CREATE PROC dbo.usp_GetTownsStartingWith @firstLetters VARCHAR(10) 
AS
SELECT [Name] FROM Towns
WHERE LEFT(Name, LEN(@firstLetters)) = @firstLetters
-- NOT TO BE SUBMITTED INTO JUDGE
EXEC dbo.usp_GetTownsStartingWith b

-------- PROBLEM 4 ---------
GO
CREATE PROC dbo.usp_GetEmployeesFromTown @townSearch VARCHAR(20)
AS
SELECT FirstName, 
       LastName 
  FROM Employees e
  JOIN Addresses a
    ON a.AddressID = e.AddressID
  JOIN Towns t
    ON t.TownID = a.TownID
 WHERE t.Name = @townSearch
-- NOT TO BE SUBMITTED INTO JUDGE
EXEC dbo.usp_GetEmployeesFromTown Sofia

-------- PROBLEM 5 ---------
GO
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))  
RETURNS NVARCHAR(10)
AS 
BEGIN 
	DECLARE @salaryLevel VARCHAR(10)
	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE 
	BEGIN
		SET @SalaryLevel = 'High'
	END
RETURN @SalaryLevel
END
-- NOT TO BE SUBMITTED INTO JUDGE
GO
SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [SalaryLevel] FROM Employees

-------- PROBLEM 6 ---------
GO
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
AS
SELECT FirstName, LastName 
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel 
-- NOT TO BE SUBMITTED INTO JUDGE
EXEC dbo.usp_EmployeesBySalaryLevel average

-------- PROBLEM 7 ---------
GO
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
	BEGIN
		DECLARE @counterIndex INT = 1;
		DECLARE @currentLetter CHAR;
		WHILE (@counterIndex <= LEN(@word))
		BEGIN
			SET @currentLetter = SUBSTRING(@word, @counterIndex, 1)
			DECLARE @macthingLetter INT = CHARINDEX(@currentLetter, @setOfLetters)
			IF (@macthingLetter = 0)
			BEGIN
				RETURN 0;
			END;

			'SET @setOfLetters = REPLACE(@setOfLetters, @currentLetter, '')' --> VYARNO RESHENIE
			SET @counterIndex = @counterIndex + 1;
		END;
		RETURN 1
	END;

-------- PROBLEM 8 ---------
GO
CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN
	ALTER TABLE Departments ALTER COLUMN ManagerId INT NULL

	ALTER TABLE Employees DROP CONSTRAINT FK_Employees_Departments
	ALTER TABLE EmployeesProjects DROP CONSTRAINT FK_EmployeesProjects_Employees
	ALTER TABLE Departments DROP CONSTRAINT FK_Departments_Employees
	
	DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId

	DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId
END

EXEC dbo.usp_DeleteEmployeesFromDepartment 2

SELECT * FROM Employees
--================================================--
 --------------- PART II : BANK DB ----------------
--================================================--
USE Bank
GO

-------- PROBLEM 9 ---------
CREATE PROC dbo.usp_GetHoldersFullName 
AS 
SELECT FirstName + ' ' + LastName AS [FullName] 
  FROM AccountHolders
-- NOT TO BE SUBMITTED INTO JUDGE
GO
exec dbo.usp_GetHoldersFullName

-------- PROBLEM 10 ---------
GO
CREATE PROC dbo.usp_GetHoldersWithBalanceHigherThan (@suppliedNumber DECIMAL(18,4))
AS
    SELECT ah.FirstName, ah.LastName 
	  FROM Accounts AS a
INNER JOIN AccountHolders AS ah
        ON a.AccountHolderId = ah.Id
  GROUP BY ah.FirstName, ah.LastName
    HAVING SUM(a.Balance) > @suppliedNumber 
-- NOT TO BE SUBMITTED INTO JUDGE
EXEC dbo.usp_GetHoldersWithBalanceHigherThan 10000.00

-------- PROBLEM 11 ---------
GO

CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(20,4), @interestRate FLOAT, @years INT)
RETURNS DECIMAL(20,4)
AS 
	BEGIN
	DECLARE @numberOfYears INT = 1;
	WHILE (@numberOfYears <= @years)
		BEGIN
			SET @initialSum = @initialSum * (1 + @interestRate);
			SET @numberOfYears = @numberOfYears + 1;
		END
	RETURN @initialSum;
	END
-------- PROBLEM 12 ---------
GO

CREATE PROC dbo.usp_CalculateFutureValueForAccount (@AccountID INT, @interestRate FLOAT)
AS
	BEGIN
    SELECT a.Id AS [Account Id],
	       ah.FirstName AS [First Name], 
		   ah.LastName AS [Last Name],
		   a.Balance AS [Current Balance], 
		   dbo.ufn_CalculateFutureValue (a.Balance, @interestRate, 5) AS [Balance in 5 years]
	  FROM Accounts AS a
INNER JOIN AccountHolders AS ah
        ON a.AccountHolderId = ah.Id
     WHERE @AccountID = ah.Id 
	 END

-- NOT TO BE SUBMITTED INTO JUDGE
EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1