USE Gringotts

-------- PROBLEM 1 ---------
SELECT COUNT(Id) AS [Count]
  FROM wizzarddeposits 

-------- PROBLEM 2 ---------
    SELECT MAX(MagicWandSize) AS [LongestMagicWand]
      FROM wizzarddeposits

-------- PROBLEM 3 ---------
    SELECT DepositGroup, 
	       MAX(MagicWandSize) AS [LongestMagicWand]
      FROM wizzarddeposits 
  GROUP BY DepositGroup 

-------- PROBLEM 4 ---------
    SELECT TOP (2) DepositGroup 
	      FROM wizzarddeposits
	  GROUP BY DepositGroup 
	  ORDER BY AVG(MagicWandSize)  

-------- PROBLEM 5 ---------
   SELECT DepositGroup, 
	       SUM(DepositAmount) AS [TotalSum]
      FROM wizzarddeposits 
  GROUP BY DepositGroup
  
-------- PROBLEM 6 ---------
    SELECT DepositGroup, 
	       SUM(DepositAmount) AS [TotalSum]
      FROM wizzarddeposits 
	  WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup

-------- PROBLEM 7 ---------
    SELECT DepositGroup, 
	       SUM(DepositAmount) AS [TotalSum]
      FROM wizzarddeposits 
	 WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup
    HAVING SUM(DepositAmount) < 150000  
  ORDER BY TotalSum DESC  

-------- PROBLEM 8 ---------
  SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) 
      AS [MinDepositCharge] 
	FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-------- PROBLEM 9 ---------
   SELECT 
          'AgeGroup' = 
		  CASE 
		     WHEN (Age BETWEEN 0 AND 10) THEN '[0-10]'
			 WHEN (Age BETWEEN 11 AND 20) THEN '[11-20]'
			 WHEN (Age BETWEEN 21 AND 30) THEN '[21-30]'
			 WHEN (Age BETWEEN 31 AND 40) THEN '[31-40]'
			 WHEN (Age BETWEEN 41 AND 50) THEN '[41-50]'
			 WHEN (Age BETWEEN 51 AND 60) THEN '[51-60]'
			 ELSE '[61+]'
		  END,
		  COUNT (*) AS WizardCount
          FROM WizzardDeposits
	GROUP BY 
		  CASE 
		     WHEN (Age BETWEEN 0 AND 10) THEN '[0-10]'
			 WHEN (Age BETWEEN 11 AND 20) THEN '[11-20]'
			 WHEN (Age BETWEEN 21 AND 30) THEN '[21-30]'
			 WHEN (Age BETWEEN 31 AND 40) THEN '[31-40]'
			 WHEN (Age BETWEEN 41 AND 50) THEN '[41-50]'
			 WHEN (Age BETWEEN 51 AND 60) THEN '[51-60]'
			 ELSE '[61+]'
		  END
 
-------- PROBLEM 10 ---------
SELECT LEFT(FirstName, 1)
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY LEFT(FirstName, 1)

-------- PROBLEM 11 ---------
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC


-------- PROBLEM 12 ---------
SELECT SUM ([DIFFERENCE]) FROM
(SELECT
       (DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC)) 
	   AS [Difference] 
	   FROM WizzardDeposits) AS [SumDifference]

-------- PROBLEM 13 ---------
USE SoftUni

SELECT DepartmentID, SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-------- PROBLEM 14 ---------
SELECT Departmentid, MIN(Salary) AS [MinimumSalary]
  FROM Employees
  WHERE HireDate > '2000-01-01'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)

-------- PROBLEM 15 ---------
CREATE TABLE EmployeesSalaryAbove30000
(Id           INT
 PRIMARY KEY NOT NULL,
 FirstName    NVARCHAR(50) NOT NULL,
 LastName     NVARCHAR(50) NOT NULL,
 MiddleName   NVARCHAR(50),
 JobTitle     NVARCHAR(50) NOT NULL,
 DepartmentID INT,
 ManagerID    INT,
 HireDate     DATETIME NOT NULL,
 Salary       MONEY,
 AddressID    INT
)

INSERT INTO EmployeesSalaryAbove30000
       SELECT *
       FROM Employees
       WHERE Salary > 30000;

DELETE FROM EmployeesSalaryAbove30000
WHERE MANAGERID = 42;

UPDATE EmployeesSalaryAbove30000
  SET
      Salary+=5000
WHERE DepartmentID = 1;

SELECT DepartmentID,
       AVG(Salary) AS [AverageSalary]
FROM EmployeesSalaryAbove30000
GROUP BY DepartmentID

-------- PROBLEM 16 ---------

SELECT DepartmentID, MAX(Salary) 
  FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT  DepartmentID, MAX(Salary) 
  FROM Employees
  WHERE DepartmentID = 2
GROUP BY DepartmentID

-------- PROBLEM 17 ---------
SELECT COUNT(Salary)
FROM Employees
WHERE ManagerID IS NULL

-------- PROBLEM 18 ---------
SELECT DepartmentID, Salary FROM
(
  SELECT DepartmentID, MAX(Salary) AS Salary, 
       DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
    FROM Employees
GROUP BY DepartmentID, Salary
) AS ThirdPart
WHERE Rank = 3

-------- PROBLEM 19 ---------
SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID 
  FROM Employees e 
 WHERE e.Salary >  
       (
          SELECT AVG(Salary) 
		    FROM Employees e1
		   WHERE DepartmentID = e.DepartmentID
        GROUP BY e1.DepartmentID) 
ORDER BY DepartmentID