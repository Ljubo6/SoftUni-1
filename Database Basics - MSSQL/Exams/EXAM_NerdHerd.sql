-- EXAM THE NERD HERD
CREATE DATABASE NerdHerd
USE NERDHERD
GO
-- SECTION I : DDL
 CREATE TABLE Credentials(
Id INT PRIMARY KEY IDENTITY,
Email VARCHAR(30),
Password VARCHAR(20)
);

CREATE TABLE Locations(
Id INT PRIMARY KEY IDENTITY,
Latitude FLOAT,
Longitude FLOAT);

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Nickname VARCHAR(25),
Gender CHAR(1),
Age INT,
LocationId INT,
CredentialId INT,
CONSTRAINT FK_Users_Locations FOREIGN KEY(LocationId) REFERENCES Locations(Id),
CONSTRAINT FK_Users_Credentials FOREIGN KEY(CredentialId) REFERENCES Credentials(Id),
CONSTRAINT uk_CredentialId UNIQUE(CredentialId)
);

CREATE TABLE Chats(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(32),
StartDate DATE,
IsActive BIT
);

CREATE TABLE UsersChats(
UserId INT,
ChatId INT,
CONSTRAINT PK_ChatId_UserId PRIMARY KEY(ChatId, UserId),
CONSTRAINT FK_UsersChats_Users FOREIGN KEY(UserId) REFERENCES Users(Id),
CONSTRAINT FK_UsersChats_Chats FOREIGN KEY(ChatId) REFERENCES Chats(Id)
);

CREATE TABLE Messages(
Id INT PRIMARY KEY IDENTITY,
Content VARCHAR(200),
SentOn DATE,
ChatId INT,
UserId INT,
CONSTRAINT FK_Messages_Chats FOREIGN KEY(ChatId) REFERENCES Chats(Id),
CONSTRAINT FK_Messages_Users FOREIGN KEY(UserId) REFERENCES Users(Id)
);

-- INSERT
INSERT INTO Messages 

SELECT CONCAT(Age, '-', Gender, '-', l.Latitude, '-', l.Longitude),
       GETDATE(),
	   CASE
	   WHEN u.Gender = 'F' THEN CEILING(SQRT(u.Age * 2))
	   WHEN u.Gender = 'M' THEN CEILING(POWER((u.Age / 18), 3))  
	   END,
	   u.Id 
  FROM Users AS u
  JOIN Locations AS l
    ON l.Id = u.LocationId
 WHERE u.Id BETWEEN 10 AND 20


-- UPDATE

UPDATE Chats
  SET
      StartDate =
(
    SELECT MIN(m.SentOn)
    FROM Chats AS c
         JOIN Messages AS m ON m.ChatId = c.Id
    WHERE c.Id = Chats.id
)
WHERE chats.id IN(SELECT c.Id
                  FROM Chats AS c
                       JOIN Messages AS m ON m.ChatId = c.Id
                  GROUP BY c.Id,
                           c.StartDate
                  HAVING c.StartDate > MIN(m.SentOn));

--DELETE
SELECT * FROM Locations
DELETE FROM Locations
WHERE Id IN (
			SELECT l.Id FROM Locations AS l
			LEFT JOIN Users AS u
			ON l.Id = u.LocationId
			WHERE u.LocationId IS NULL)

-- AGE RANGE
SELECT Nickname, Gender, Age FROM Users
WHERE Age BETWEEN 22 AND 37

-- MESSAGES
SELECT Content, SentOn FROM Messages
WHERE SentOn > '2014-05-12' AND Content LIKE '%just%'
ORDER BY Id DESC 

-- CHATS
SELECT Title, IsActive FROM Chats
WHERE (IsActive = 0 AND (LEN(Title) < 5)) OR Title LIKE '__tl%'  
ORDER BY Title DESC

-- CHAT MESSAGES
SELECT ch.Id, ch.Title, m.Id FROM Messages AS m
JOIN Chats AS ch
ON ch.Id = m.ChatId
WHERE m.SentOn < '2012-03-26' AND ch.Title LIKE '%x'
ORDER BY ChatId, m.Id

-- MESSAGE COUNT
SELECT TOP 5 ch.Id, COUNT(m.Id) AS TotalMessages FROM Messages AS m
LEFT JOIN Chats AS ch
ON ch.Id = m.ChatId
WHERE m.Id < 90 
GROUP BY ch.Id
ORDER BY TotalMessages DESC, ch.Id ASC

-- CREDENTIALS
SELECT u.Nickname, cr.Email, cr.Password FROM Users AS u
FULL OUTER JOIN Credentials AS cr
ON cr.Id = u.CredentialId
WHERE RIGHT(cr.Email, 5) = 'co.uk'
ORDER BY cr.Email ASC

-- LOCATION
SELECT Id, Nickname, Age FROM Users
WHERE LocationId IS NULL

-- LEFT USERS
SELECT m.id,
       m.ChatId,
       m.UserId
FROM Messages AS m
WHERE m.ChatId = 17
      AND (m.UserId NOT IN
(
    SELECT userId
    FROM UsersChats
    WHERE ChatId = 17
)
           OR m.UserId IS NULL)
ORDER BY m.Id DESC;

-- USERS IN BULGARIA
SELECT u.Nickname, ch.Title, l.Latitude, l.Longitude FROM Users AS u
JOIN Locations AS l
ON l.Id = u.LocationId
JOIN UsersChats AS uch
ON uch.UserId = u.Id
JOIN Chats AS ch
ON ch.Id = uch.ChatId
WHERE (l.Latitude BETWEEN 41.129999 AND 44.139999) AND (l.Longitude BETWEEN 22.209999 AND 28.359999)
ORDER BY ch.Title

-- LAST CHAT
SELECT C.Title,
       M.Content
FROM Messages AS M
     RIGHT JOIN
(    SELECT TOP 1 id,
                 Title
    FROM Chats
    ORDER BY StartDate DESC
) AS C ON C.Id = M.ChatId;

-- RADIANS
GO
CREATE FUNCTION udf_GetRadians (@Degree FLOAT)
RETURNS FLOAT
AS
BEGIN
	DECLARE @Radians FLOAT = (@Degree * PI()) / 180;
	RETURN @Radians
END

-- CHANGE PASSWORD
GO
CREATE PROCEDURE udp_ChangePassword (@Email VARCHAR(30), @Password VARCHAR(20))
AS
BEGIN
	BEGIN TRANSACTION
	IF (@Email NOT IN (SELECT Email FROM Credentials))
	BEGIN
		RAISERROR ('The email does''t exist!', 16, 1);
		ROLLBACK
	END
	UPDATE Credentials
	SET Password = @Password
	WHERE Email = @Email
	COMMIT
END

-- SEND MESSAGE
GO
CREATE PROCEDURE udp_SendMessage (@UserId INT, @ChatId INT, @Content VARCHAR(200))
AS 
BEGIN
	BEGIN TRANSACTION
	DECLARE @ChatsCount INT = (SELECT COUNT(ucH.ChatId) AS CountedChats 
								 FROM UsersChats AS ucH
						         WHERE ucH.UserId = @UserId AND ucH.ChatId = @ChatId
								GROUP BY ucH.UserId)
	IF (@ChatsCount <> 1 OR @ChatId NOT IN (SELECT @ChatId FROM UsersChats)) 
	BEGIN
		RAISERROR ('There is no chat with that user!', 16, 1)
		ROLLBACK
	END
	INSERT INTO Messages VALUES
	(@Content, GETDATE(), @ChatId, @UserId)
	COMMIT
END
-- 
CREATE PROCEDURE udp_SendMessage @UserId  INT, @ChatId  INT, @Content VARCHAR(200)
AS
     BEGIN
         BEGIN TRANSACTION;
         DECLARE @ChatCount INT;
         SET @ChatCount =
(
    SELECT COUNT(*)
    FROM UsersChats
    WHERE ChatId = @ChatId
          AND UserId = @UserId
);
         IF(@ChatCount <> 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('There is no chat with that user!', 16, 1);
             END;
        INSERT INTO Messages VALUES
	(@Content, GETDATE(), @ChatId, @UserId)
	COMMIT
     END;













-- LOG MESSAGES
GO
CREATE TRIGGER tr_LogMessages ON Messages 
AFTER DELETE
AS
BEGIN
	INSERT INTO MessageLogs 
	SELECT * from deleted
END


-- DELETE USERS
GO
CREATE TRIGGER tr_DeleteUser ON Users
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM UsersChats 
	WHERE UserId = (SELECT Id FROM deleted)

	DELETE FROM Messages
	WHERE UserId = (SELECT Id FROM deleted)

	DELETE FROM Users
	WHERE Id = (SELECT Id FROM deleted)
END


DELETE FROM Messages
WHERE UserId = 4

DELETE FROM Users
WHERE Id = 1

SELECT * FROM Users
SELECT * FROM Chats
SELECT ucH.ChatId FROM UsersChats AS ucH
INNER JOIN Users AS u
ON u.Id = ucH.UserId

SELECT * FROM Credentials

