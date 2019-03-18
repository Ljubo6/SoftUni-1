CREATE DATABASE ReportService
USE ReportService
GO

--SECTION I: DDL
CREATE TABLE Users(
Id INT IDENTITY, 
Username NVARCHAR(30) NOT NULL UNIQUE,
[Password] NVARCHAR(50) NOT NULL,
[Name] NVARCHAR(50), 
Gender CHAR,
BirthDate DATETIME,
Age INT, 
Email NVARCHAR(50) NOT NULL,
CONSTRAINT PK_UserId PRIMARY KEY (Id),
CONSTRAINT CHK_User_Gender CHECK (Gender IN ('M','F'))
)

CREATE TABLE Departments(
Id INT IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
CONSTRAINT PK_DepartmentId PRIMARY KEY (Id)
)

CREATE TABLE Employees(
Id INT IDENTITY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR,
BirthDate DATETIME,
Age INT,
DepartmentId INT NOT NULL,
CONSTRAINT PK_EmployeeId PRIMARY KEY (Id),
CONSTRAINT CHK_Employee_Gender CHECK (Gender IN ('M','F')),
CONSTRAINT FK_Employee_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT IDENTITY, 
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT,
CONSTRAINT PK_CategoryId PRIMARY KEY (Id),
CONSTRAINT FK_Categories_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE [Status](
Id INT IDENTITY,
Label VARCHAR(30) NOT NULL,
CONSTRAINT PK_LabelId PRIMARY KEY (Id)
)

CREATE TABLE Reports(
Id INT IDENTITY,
CategoryId INT NOT NULL,
StatusId INT NOT NULL,
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
[Description] VARCHAR(200),
UserId INT NOT NULL,
EmployeeId INT,
CONSTRAINT PK_ReportId PRIMARY KEY (Id),
CONSTRAINT FK_Report_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
CONSTRAINT FK_Report_StatusId FOREIGN KEY (StatusId) REFERENCES Status(Id),
CONSTRAINT FK_Report_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
CONSTRAINT FK_Report_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
)

--SECTION II : DML

-- INSERT
INSERT INTO Employees (FirstName, LastName, Gender, BirthDate, DepartmentId) VALUES
('Marlo', 'O’Malley', 'M', '9/21/1958', '1'),
('Niki', 'Stanaghan', 'F', '11/26/1969', '4'),
('Ayrton', 'Senna', 'M', '03/21/1960', '9'),
('Ronnie', 'Peterson', 'M', '02/14/1944', '9'),
('Giovanna', 'Amati', 'F', '07/20/1959', '5')

INSERT INTO Reports VALUES
(1, 1, '04/13/2017', NULL, 'Stuck Road on Str.133', '6', '2'),
(6, 3, '09/05/2015', '12/06/2015', 'Charity trail running', '3', '5'),
(14, 2, '09/07/2015', NULL, 'Falling bricks on Str.58', '5', '2'),
(4, 3, '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', '1', '1')

-- UPDATE
UPDATE Reports
SET StatusId = 2
WHERE CategoryId = 4 AND StatusId = 1

-- DELETE
DELETE FROM Reports
WHERE StatusId = 4

-- SECTION III: QUERYING

-- USERS BY AGE
SELECT Username, Age FROM Users
ORDER BY Age ASC, Username DESC

-- UNASSIGNED REPORTS
SELECT Description, OpenDate FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, Description ASC

-- EMPLOYEES AND REPORTS
SELECT e.FirstName, e.LastName, r.Description, FORMAT(r.OpenDate, 'yyyy-MM-dd') AS [OpenDate] FROM Reports AS r
JOIN Employees AS e
ON e.Id = r.EmployeeId
WHERE EmployeeId IS NOT NULL
ORDER BY e.Id ASC, OpenDate ASC, r.Id ASC

-- MOST REPORTED CATEGORY
SELECT c.Name AS [CategoryName], COUNT(*) AS [ReportsNumber] FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC, CategoryName ASC

-- EMPLOYEES IN CATEGORIES
SELECT c.Name, COUNT(*) AS EmployeeCount FROM Employees AS e
JOIN Categories AS c
ON c.DepartmentId = e.DepartmentId
GROUP BY e.DepartmentId, c.Name
ORDER BY c.Name

-- USERS PER EMPLOYEE

SELECT EmployeeId, UserId FROM Reports AS r
LEFT JOIN Employees AS e
ON e.Id = r.EmployeeId


SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name], COUNT(DISTINCT UserId) AS [Users Number] FROM Reports AS r
RIGHT JOIN Employees AS e
ON e.Id = r.EmployeeId
GROUP BY R.EmployeeId,  CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Users Number] DESC ,[Name] ASC

CONCAT(e.FirstName, ' ', e.LastName)


SELECT Counted.CategoryName AS [CategoryName], SUM(Counted.UserCount) AS [Employees Number] FROM (
SELECT c.Name AS [CategoryName], COUNT(DISTINCT UserId) AS UserCount FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
GROUP BY r.EmployeeId, c.Name) AS Counted
GROUP BY Counted.CategoryName
ORDER BY [CategoryName]

-- EMERGENCY PATROL
SELECT OpenDate, Description, U.Email FROM Reports AS r
JOIN Users AS u
ON u.Id = r.UserId
WHERE r.CloseDate IS NULL AND LEN(r.Description) > 20 AND r.Description LIKE '%str%' AND r.CategoryId IN (
SELECT Id FROM Categories
WHERE DepartmentId IN (SELECT Id FROM Departments WHERE [Name] IN ('Infrastructure', 'Emergency', 'Roads Maintenance')))
ORDER BY OpenDate ASC, u.Email ASC, r.Id ASC

-- BIRTHDAY REPORT

SELECT DISTINCT c.Name [Category Name] FROM Reports AS r
JOIN Users AS u
ON u.Id = r.UserId
JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE RIGHT(CAST(r.OpenDate AS DATE), 5) = RIGHT(CAST(u.BirthDate AS date), 5)
ORDER BY [Category Name] ASC


-- NUMBER COINCIDENCE 


-- OPEN CLOSED STATISTICS
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
       CONCAT(ISNULL(closedReports.CountedClosed, 0), '/', ISNULL(openReports.CountedOpen, 0)) AS [Closed Open Reports]
 FROM Employees AS e
LEFT JOIN 
(SELECT EmployeeId, COUNT(*) CountedClosed FROM Reports
WHERE DATEPART(YEAR, OpenDate) <= '2016' AND DATEPART(YEAR, CloseDate) = '2016'
GROUP BY EmployeeId) AS closedReports
ON closedReports.EmployeeId = E.Id
LEFT JOIN
(SELECT EmployeeId, COUNT(*) CountedOpen FROM Reports
WHERE DATEPART(YEAR, OpenDate) = '2016'
GROUP BY EmployeeId) AS openReports
ON openReports.EmployeeId = e.Id
WHERE (closedReports.CountedClosed IS NOT NULL OR openReports.CountedOpen IS NOT NULL) AND (openReports.CountedOpen IS NOT NULL)
ORDER BY [Name] ASC, e.Id


-- AVERAGE CLOSING TIME
-- 01
SELECT result.Name,
		CASE 
		WHEN CAST(totalDays AS varchar(5)) = '0' THEN CAST('no info' AS VARCHAR(6))
		ELSE result.totalDays
		END AS [Average Duration] 
  FROM 
(SELECT dep.Name, AVG(Days) AS totalDays FROM 
(SELECT CategoryId, ISNULL(SUM(DATEDIFF(DAY, OpenDate, CloseDate)), 0) AS [Days] FROM Reports
GROUP BY CategoryId) AS totalDaysPerCategory
JOIN Categories AS cat 
ON cat.Id = totalDaysPerCategory.CategoryId
JOIN Departments AS dep
ON dep.Id = cat.DepartmentId
GROUP BY dep.Name) AS result

--02


SELECT d.Name AS [Deaprtment Name],
       ISNULL(CAST(AVG(DaysTotal) AS varchar), 'no info') AS [Average Duration] 
  FROM (
        SELECT CategoryId, ROUND(AVG(DATEDIFF(DAY, OpenDate, CloseDate)), 0) AS DaysTotal 
		  FROM Reports
         GROUP BY CategoryId) AS TotalDays
LEFT JOIN Categories AS c
    ON C.Id = TotalDays.CategoryId
LEFT JOIN Departments AS d
    ON d.Id = c.DepartmentId
GROUP BY d.Name
ORDER BY d.Name


-- FAV CATEGORIES
SELECT d.Name AS [Department Name],
       c.Name AS [Category Name],
       CAST(ROUND((SELECT repC.ReprtsPerCategory * 100.00 / deptC.AllReportsInDept), 0) AS int) AS [Percentage]
FROM
(
    SELECT C.Id,
           C.DepartmentId,
           COUNT(*) AS ReprtsPerCategory
    FROM Reports AS r
         JOIN Categories AS c ON c.Id = r.CategoryId
    GROUP BY C.Id,
             c.DepartmentId
) AS repC
JOIN
(
    SELECT REPC.DepartmentId,
           SUM(ReprtsPerCategory) AS AllReportsInDept
    FROM Departments AS d
         JOIN
(
    SELECT c.DepartmentId,
           COUNT(*) AS ReprtsPerCategory
    FROM Reports AS r
         JOIN Categories AS c ON c.Id = r.CategoryId
    GROUP BY c.DepartmentId
) AS repC ON RepC.DepartmentId = d.Id
    GROUP BY repC.DepartmentId
) AS deptC ON deptC.DepartmentId = repC.DepartmentId
JOIN Departments AS d ON d.Id = deptC.DepartmentId
JOIN Categories AS c ON c.Id = repC.Id
ORDER BY d.Name ASC,
         C.Name ASC,
         Percentage ASC





















-- SECTION IV
-- EMPLOYEE'S LOAD
GO
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	
	DECLARE @ReportsCount INT = (SELECT COUNT(*) FROM Reports WHERE EmployeeId = @employeeId AND StatusId = @statusId);
	
	RETURN @ReportsCount;
END
GO

-- ASSIGN EMPLOYEE

CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
	BEGIN TRANSACTION

	DECLARE @EmployeeDept INT = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
	DECLARE @ReportDept INT = (SELECT DepartmentId FROM Categories WHERE Id = (SELECT CategoryId FROM Reports WHERE Id = @reportId))

	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id=@reportId
	IF (@EmployeeDept <> @ReportDept)
	BEGIN
		RAISERROR ('Employee doesn''t belong to the appropriate department!', 16, 1);
		ROLLBACK;
	END 
	COMMIT

END

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 2


-- CLOSE REPORTS
GO
CREATE TRIGGER tr_CloseReport ON Reports
AFTER UPDATE
AS
	BEGIN
		UPDATE Reports
		SET StatusId = (SELECT Id FROM Status WHERE Label = 'completed')
		WHERE Id IN (SELECT Id FROM inserted 
				      WHERE Id IN (SELECT Id FROM deleted 
					                WHERE CloseDate IS NULL) AND CloseDate IS NOT NULL)
	END

-- REVISION
SELECT c.Name, [Reports Number] FROM 
(SELECT CategoryId, COUNT(*) AS [Reports Number] FROM Reports
WHERE StatusId IN (SELECT Id FROM Status WHERE Label IN ('waiting', 'in progress'))
GROUP BY CategoryId) AS CatgrReports
JOIN Categories AS c
ON c.Id = CatgrReports.CategoryId


SELECT bbb.CategoryId,bbb.Label, MAX(bbb.NumberOfStatus) FROM 
(SELECT aaa.CategoryId, aaa.Label, COUNT (*) AS NumberOfStatus FROM(
SELECT CategoryId, s.Label, DENSE_RANK () OVER (PARTITION BY r.CategoryId ORDER BY Label) AS Rank FROM Reports AS r
JOIN Status AS s
ON s.Id = r.StatusId
JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE StatusId IN (SELECT Id FROM Status WHERE Label IN ('waiting', 'in progress'))) AS aaa
GROUP BY aaa.CategoryId, aaa.Rank, aaa.Label) bbb
GROUP BY bbb.CategoryId, bbb.Label



SELECT * FROM Departments

SELECT * FROM Users
SELECT * FROM Employees
SELECT * FROM Reports
SELECT * FROM Categories
SELECT * FROM Departments
SELECT * FROM Status