-- PART I : DIABLO DB
USE Diablo
GO
--PROBLEM 1
SELECT [Email Provider], 
       COUNT([Email Provider]) AS [Number Of Users] 
  FROM (SELECT RIGHT(EMAIL, (LEN(Email) - CHARINDEX('@', Email, 1))) AS [Email Provider] 
		  FROM Users ) AS result
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC, [Email Provider] ASC

-- PROBLEM 2

SELECT g.Name AS Game,
       gt.Name AS GameType,
	   u.Username, 
	   ug.Level,
	   ug.Cash, 
	   ch.Name AS [Character]
 FROM UsersGames AS ug
JOIN Users AS u
ON u.Id = ug.UserId
JOIN Games AS g
ON g.Id = ug.GameId
JOIN GameTypes AS gt
ON gt.Id = g.GameTypeId
JOIN Characters AS ch
ON ch.Id = ug.CharacterId
order by ug.Level DESC, u.Username, g.Name

-- PROBLEM 3
'SELECT help.Username, help.Name, SUM(NumberOfItems) AS [Items Count], SUM(ItemsPrice) AS [Items Price] 
FROM 
(SELECT u.Username, g.Name, NumberOfItems, SUM(ItemsPerGame * i.Price) AS ItemsPrice   
   FROM
       (SELECT UserGameId, COUNT(*) AS NumberOfItems FROM UserGameItems GROUP BY UserGameId) AS ugi
          JOIN UsersGames AS ug
          ON ugi.UserGameId = ug.Id
          JOIN UserGameItems AS ugi2
          ON ugi2.UserGameId = ug.Id
          JOIN Users AS u
          ON u.Id = ug.UserId
          JOIN Games AS g
          ON g.Id = ug.GameId
          JOIN Items AS i
          ON i.Id = ugi2.ItemId
          JOIN
          (SELECT ItemId, COUNT(*) AS ItemsPerGame FROM UserGameItems GROUP BY ItemId) ugi3
           ON ugi3.ItemId = i.Id
		   GROUP BY u.Username, g.Name, NumberOfItems) AS help
GROUP BY help.Username, help.Name
HAVING SUM(NumberOfItems) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, help.Username ASC'



SELECT * FROM Users
SELECT * FROM UsersGames
SELECT * FROM Games
SELECT * FROM Characters
SELECT * FROM [Statistics]
SELECT * FROM Items
SELECT * FROM UserGameItems

CHARACTER 

SELECT l2.[Username], l2.Game, SUM([Items Count]), l2.[Items Price] FROM
(
	SELECT level1.[Username], level1.Game, COUNT(level1.ItemId)  AS [Items Count], SUM(Price) AS [Items Price] FROM
	(
		SELECT u.Username AS [Username], g.[Name] AS Game, ugt.ItemId
		  FROM Users u
	INNER JOIN UsersGames ug
	        ON ug.UserId = u.Id
	INNER JOIN Games g
	        ON g.Id = ug.GameId
	INNER JOIN UserGameItems ugt
	       ON ugt.UserGameId = ug.GameId
	) AS level1
INNER JOIN Items i
		ON i.Id = level1.ItemId
GROUP BY level1.[Username], level1.Game) as l2
GROUP BY l2.Username, l2.Game, l2.[Items Price], [Items Count]
HAVING SUM([Items Count]) >= 10
ORDER BY  l2.Username ASC	
[Items Count] DESC, [Items Price] DESC,

SELECT GameId, UserId FROM UsersGames
WHERE GameId = 181 
SELECT * FROM UserGameItems WHERE UserGameId = 181
SELECT * FROM Games WHERE Name = 'WASHINGTON D.C.'
SELECT * FROM Users WHERE Id=50

-- PART II : GEOGRAPHY
USE Geography
--PROBLEM 8
SELECT P.PeakName, M.MountainRange AS [Mountain], P.Elevation FROM Peaks P
JOIN Mountains M
ON M.Id = P.MountainId
ORDER BY P.Elevation DESC, P.PeakName

-- PROBLEM 9
SELECT P.PeakName,
       M.MountainRange AS Mountain,
       c.CountryName,
       cn.ContinentName
       FROM Peaks P
            JOIN Mountains M
            ON M.Id = P.MountainId
            JOIN MountainsCountries mc
            ON mc.MountainId = M.Id
            JOIN Countries c
            ON c.CountryCode = mc.CountryCode
            JOIN Continents cn
            ON cn.ContinentCode = c.ContinentCode
ORDER BY P.PeakName;

-- PROBLEM 10

SELECT * FROM Rivers

SELECT c.CountryName,
       cn.ContinentName,
       COUNT(RiverId) AS RiversCount,
	   CASE 
	   WHEN (SUM(Length)) IS NULL THEN '0'
	   ELSE SUM(Length)
	   END AS TotalLength
       FROM CountriesRivers cr
            FULL OUTER JOIN Countries c
            ON c.CountryCode = cr.CountryCode
            FULL OUTER JOIN Continents cn
            ON cn.ContinentCode = c.ContinentCode
            FULL OUTER JOIN Rivers r
            ON r.Id = cr.RiverId
       GROUP BY cr.CountryCode,
                c.CountryName,
                cn.ContinentName
ORDER BY RiversCount DESC,
         TotalLength DESC,
         c.CountryName;


-- PROBLEM 11
SELECT c.CurrencyCode, c.Description, ISNULL(cc.CurrencyCount, 0) AS [NumberOfCountries] FROM Currencies AS c
LEFT JOIN
(SELECT CurrencyCode, COUNT(*) AS CurrencyCount FROM Countries
GROUP BY CurrencyCode) AS cc
ON cc.CurrencyCode = c.CurrencyCode
ORDER BY NumberOfCountries DESC, c.Description

-- PROBLEM 12

SELECT cn.ContinentName, 
       SUM(CAST((C.AreaInSqKm) AS decimal(20))) AS [CountriesArea],
       SUM(CAST((C.Population) AS decimal(20))) AS [CountriesPopulation]  FROM Countries c
JOIN Continents cn
ON cn.ContinentCode = c.ContinentCode
GROUP BY cn.ContinentName
ORDER BY CountriesPopulation DESC

-- PROBLEM 13
CREATE TABLE Monasteries(
Id INT IDENTITY NOT NULL, 
[Name] NVARCHAR(100), 
CountryCode VARCHAR(2)
CONSTRAINT PK_MonasteriesId PRIMARY KEY (Id),
CONSTRAINT FK_CountryCode FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode) )

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

-- MONASTERIES BY COUNTRY
SELECT * FROM Monasteries




ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT '0'

GO
CREATE TRIGGER tr_MoreThan3Rivers ON Countries
INSTEAD OF DELETE
AS
BEGIN 
	UPDATE c 
	SET c.IsDeleted = 1
	FROM Countries AS c
	JOIN deleted d
	  ON d.CountryCode = c.CountryCode
	WHERE c.IsDeleted = 0
END

GO
CREATE PROC dbo.udp_DeleteCountires 
AS
BEGIN
DELETE FROM Countries
WHERE CountryCode IN (SELECT A.CountryCode FROM (
												SELECT C.CountryCode, COUNT(RiverId) AS 'RiversCount' FROM CountriesRivers CR
												JOIN Countries C ON C.CountryCode =  CR.CountryCode
												GROUP BY CR.CountryCode, C.CountryCode
												) AS A
												WHERE RiversCount > 3)
END

EXEC dbo.udp_DeleteCountires

SELECT m.[Name] AS [Monastery],
       c.CountryName AS [Country]
FROM Monasteries m
     JOIN Countries c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted <> 1
ORDER BY m.Name;

SELECT CountryCode FROM(
SELECT CountryCode, COUNT(*) AS RiverCount FROM CountriesRivers
GROUP BY CountryCode) AS h
WHERE RiverCount > 3

SELECT * FROM Countries