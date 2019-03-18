--Part 1 --
USE SoftUni

-- Problem 1
    SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
      FROM Employees AS e
INNER JOIN Addresses as a
        ON a.AddressID = e.AddressID
  ORDER BY e.AddressID ASC

-- PROBLEM 2
    SELECT TOP 50 
	       e.FirstName, 
		   e.LastName, 
		   t.Name AS [Town], 
		   a.AddressText
      FROM Employees AS e
INNER JOIN Addresses as a
        ON a.AddressID = e.AddressID
INNER JOIN Towns AS t
        ON t.TownID = a.TownID
  ORDER BY FirstName ASC, LastName ASC

-- Problem 3
    SELECT e.EmployeeID, 
	       e.FirstName, 
		   e.LastName, 
		   d.Name AS DepartmentName
      FROM Employees AS e
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
	 WHERE d.Name = 'Sales'
  ORDER BY e.EmployeeID

-- PROBLEM 4
    SELECT TOP 5
           e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
      FROM Employees AS e
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
     WHERE Salary > 15000
  ORDER BY e.DepartmentID

-- PROBLEM 5
SELECT TOP 3
            e.EmployeeID, e.FirstName
  FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
        ON ep.EmployeeID = e.EmployeeID
 WHERE ep.ProjectID IS NULL
 ORDER BY e.EmployeeID ASC

-- Problem 6
    SELECT e.FirstName, e.LastName, e.HireDate, 
	       d.Name AS [DeptName]
	  FROM Employees AS e
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
     WHERE d.Name IN ('Sales', 'Finance')
	       AND e.HireDate > '01/01/1999'
  ORDER BY e.HireDate

-- PROBLEM 7
    SELECT TOP 5
           e.EmployeeID, e.FirstName, p.Name AS [ProjectName]
      FROM Employees AS e
RIGHT JOIN EmployeesProjects AS ep
        ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
        ON p.ProjectID = ep.ProjectID
     WHERE p.StartDate > '08/13/2002' AND p.EndDate IS NULL
  ORDER BY e.EmployeeID ASC, ProjectName ASC

-- PROBLEM 8

    SELECT e.EmployeeID, e.FirstName, p.Name AS [ProjectName]
      FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
        ON ep.EmployeeID = e.EmployeeID
 LEFT JOIN (
            SELECT ProjectID, Name, StartDate FROM Projects
			 WHERE DATEPART(YEAR, StartDate) < 2005
		   ) AS p
        ON p.ProjectID = ep.ProjectID
     WHERE e.EmployeeID = 24

-- PROBLEM 9
    SELECT e.EmployeeID, e.FirstName, e.ManagerID, ee.FirstName AS [ManagerName]
      FROM Employees AS e
INNER JOIN Employees AS ee
        ON ee.EmployeeID = e.ManagerID
     WHERE e.ManagerID IN (3,7)
  ORDER BY e.EmployeeID ASC

-- PROBLEM 10
    SELECT TOP 50
	       e.EmployeeID, 
	       e.FirstName + ' ' + e.LastName AS [EmployeeName], 
	       ee.FirstName + ' ' + ee.LastName AS [ManagerName],
		   d.Name AS [DepartmentName]
      FROM Employees AS e
INNER JOIN Employees AS ee
        ON ee.EmployeeID = e.ManagerID
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
  ORDER BY e.EmployeeID ASC

-- PROBLEM 11
  SELECT MIN (AverageSalary) FROM
        (
            SELECT DepartmentID, AVG(Salary) AS AverageSalary
              FROM Employees
          GROUP BY DepartmentID
		 ) AS AverageSalary

-- PROBLEM 12
USE Geography

    SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation  
      FROM Countries AS c
INNER JOIN MountainsCountries AS mc
        ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m
        ON m.Id = mc.MountainId
INNER JOIN Peaks AS p
        ON p.MountainId = m.Id
     WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
  ORDER BY p.Elevation DESC

-- PROBLEM 13
SELECT CountryCODE, COUNT(MountainId) AS [MountainRange]
FROM MountainsCountries
GROUP BY CountryCode
HAVING CountryCode IN ('BG','RU','US')

-- PROBLEM 14
   SELECT TOP 5 
          c.CountryName, r.RiverName
     FROM Countries as c
LEFT JOIN CountriesRivers AS cr
       ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
          ON r.Id = cr.RiverId
    WHERE c.ContinentCode = 'AF'
 ORDER BY c.CountryName

-- PROBLEM 15
  SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM         
		  (
		  SELECT ContinentCode, CurrencyCode, CurrencyUsage,
          DENSE_RANK() OVER (PARTITION BY (ContinentCode)
          ORDER BY CurrencyUsage DESC) AS PeakRank
		  FROM (
                SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS [CurrencyUsage]
                FROM Countries
                GROUP BY ContinentCode, CurrencyCode
			   ) AS currencies
		  ) AS RankedCurrencies
   WHERE PeakRank = 1 AND CurrencyUsage > 1 
ORDER BY ContinentCode
  
-- PROBLEM 16
SELECT COUNT (*) 
  FROM
        (  SELECT mc.CountryCode 
	         FROM Countries AS c
        LEFT JOIN MountainsCountries AS mc
               ON mc.CountryCode = c.CountryCode
            WHERE mc.CountryCode IS NULL) AS [CountryCode]

-- PROBLEM 17

    SELECT TOP 5
           c.CountryName, HighestPeakEvaluation, LongestRiverLength 
      FROM MountainsCountries AS mc
INNER JOIN Countries AS c
        ON mc.CountryCode = c.CountryCode
INNER JOIN (
            SELECT hp.CountryCode, [HighestPeakEvaluation] FROM
			(
			SELECT highestPeak.CountryCode, highestPeak.MountainId, [HighestPeakEvaluation] FROM
		    (
             SELECT mc.CountryCode, p.MountainId, p.Elevation AS [HighestPeakEvaluation], 
             DENSE_RANK() OVER(PARTITION BY(mc.CountryCode)
	         ORDER BY p.Elevation DESC) AS PeakRank
		     FROM Peaks AS p
	    	 JOIN MountainsCountries AS mc
               ON mc.MountainId = p.MountainId
            ) AS highestPeak
			) AS hp
			) AS hpp
        ON hpp.CountryCode = mc.CountryCode
INNER JOIN
           (
           SELECT longestRiver.CountryCode, [LongestRiverLength] FROM
		     (
             SELECT cr.CountryCode, r.[Length] AS [LongestRiverLength], 
             DENSE_RANK() OVER(PARTITION BY(cr.CountryCode)
	         ORDER BY r.Length DESC) AS RiverRank
		     FROM Rivers AS r
	    	 JOIN CountriesRivers AS cr
               ON cr.RiverId = r.Id
             JOIN Countries AS c
               ON c.CountryCode = cr.CountryCode
			 ) AS longestRiver
             ) AS lr
        ON lr.CountryCode = c.CountryCode
WHERE RiverRank = 1 AND hpp.PeakRank = 1
ORDER BY HighestPeakEvaluation DESC, LongestRiverLength DESC, c.CountryName ASC



 SELECT MountainId, MAX(Elevation) AS [HighestPeakEvaluation]
           FROM Peaks 
           GROUP BY MountainId



SELECT hp.MountainId, [HighestPeakEvaluation] FROM
            (
			 SELECT highestPeak.MountainId, [HighestPeakEvaluation] FROM
		    (
             SELECT p.MountainId, p.Elevation AS [HighestPeakEvaluation], 
             DENSE_RANK() OVER(PARTITION BY(p.Elevation)
	         ORDER BY p.Elevation DESC) AS [Rank]
		     FROM Peaks AS p
	    	 JOIN MountainsCountries AS mc
               ON mc.MountainId = p.MountainId
            ) AS highestPeak
            WHERE [Rank] = 1
		    ) AS hp
order by hp.MountainId
        ON hp.MountainID = mc.MountainID



-- PROBLEM 18
SELECT TOP 5 c.CountryName AS Country,
             CASE
                 WHEN highestpeak.PeakName IS NULL
                 THEN '(no highest peak)'
                 ELSE highestpeak.PeakName
             END AS [Highest Peak Name],
             CASE
                 WHEN [Highest Peak Elevation] IS NULL
                 THEN '0'
                 ELSE [Highest Peak Elevation]
             END AS [Highest Peak Elevation],
             CASE
                 WHEN m.MountainRange IS NULL
                 THEN '(no mountain)'
                 ELSE m.MountainRange
             END AS Mountain
       FROM Countries AS c
            LEFT JOIN MountainsCountries AS mc
            ON mc.CountryCode = c.CountryCode
            LEFT JOIN
(
    SELECT allPeaksRanked.CountryCode,
           allPeaksRanked.PeakName,
           allPeaksRanked.MountainId,
           [Highest Peak Elevation]
           FROM
(
    SELECT mc.CountryCode,
           p.PeakName,
           p.MountainId,
           p.Elevation AS [Highest Peak Elevation],
           RANK() OVER(PARTITION BY mc.CountryCode ORDER BY p.Elevation DESC) AS Rank
           FROM Peaks AS p
                FULL OUTER JOIN MountainsCountries AS mc
                ON mc.MountainId = p.MountainId
) AS allPeaksRanked
           WHERE Rank = 1
) AS highestpeak
            ON highestpeak.CountryCode = mc.CountryCode
            LEFT JOIN Mountains AS m
            ON m.Id = highestpeak.MountainId
       GROUP BY c.CountryName,
                highestpeak.PeakName,
                highestpeak.[Highest Peak Elevation],
                m.MountainRange
            ORDER BY c.CountryName;

--------------- 







SELECT * FROM Continents
SELECT * FROM Rivers -- Id
SELECT * FROM CountriesRivers -- RIVERID-COUNTRY CODE
SELECT * FROM Currencies
SELECT * FROM Countries
SELECT * FROM Peaks
SELECT * FROM Mountains
SELECT * FROM MountainsCountries