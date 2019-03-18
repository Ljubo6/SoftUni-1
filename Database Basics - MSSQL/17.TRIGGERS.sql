use Bank
-- PROBLEM 1--
CREATE TABLE Logs(
LogId INT NOT NULL IDENTITY, 
AccountId INT NOT NULL, 
OldSum MONEY NOT NULL, 
NewSum MONEY NOT NULL
CONSTRAINT PK_LogId PRIMARY KEY(LogId),
CONSTRAINT FK_AccountId FOREIGN KEY(AccountId) REFERENCES Accounts(Id)
)
GO
CREATE TRIGGER tr_SumUpdate 
    ON Accounts 
 AFTER UPDATE
AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum) VALUES
	((SELECT Id FROM deleted), (SELECT Balance FROM deleted), (SELECT Balance FROM inserted))
	RETURN
END

-- PROBLEM 2 --
CREATE TABLE NotificationEmails(
Id INT NOT NULL IDENTITY, 
Recipient INT NOT NULL, 
[Subject] NVARCHAR(100), 
Body NVARCHAR(100)
CONSTRAINT PK_NotificationId PRIMARY KEY(Id),
)
GO

CREATE TRIGGER tr_NotificationEmails
    ON Logs
 AFTER INSERT
AS
BEGIN 
	INSERT INTO NotificationEmails VALUES
	((SELECT AccountId FROM inserted), 
	 CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted)),
	 CONCAT('On ', CONVERT(VARCHAR(20), GETDATE(), 100), ' your balance was changed from ', (SELECT oldSum from Logs), ' to ', (SELECT NewSum from Logs), '.'))
	 RETURN
END 

-- PROBLEM 3 --
GO
CREATE PROC dbo.usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	IF (@MoneyAmount < 0)
	BEGIN
		RAISERROR ('Negative amount of money transfered into account!', 16, 1)
	END
	ELSE 
	BEGIN 
		IF (@AccountId IS NULL OR @MoneyAmount IS NULL)
		BEGIN
			RAISERROR ('Error! Account or sum not entered!', 16, 2)
		END
	END
BEGIN TRANSACTION 
	UPDATE Accounts 
	   SET Balance = Balance + @moneyAmount
	 WHERE @AccountId = Accounts.Id
	    IF (@@ROWCOUNT <> 1)
		BEGIN 
			ROLLBACK;
			RAISERROR ('Error!', 16, 3)
		END
	COMMIT
END

-- PROBLEM 4
GO
CREATE PROC dbo.usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	IF (@MoneyAmount < 0)
	BEGIN
		RAISERROR ('Negative amount of money withdrawn from account!', 16, 1)
	END
	ELSE 
	BEGIN 
		IF (@AccountId IS NULL OR @MoneyAmount IS NULL)
		BEGIN
			RAISERROR ('Error! Account or sum not entered!', 16, 2)
		END
	END
BEGIN TRANSACTION 
	UPDATE Accounts 
	   SET Balance = Balance - @moneyAmount
	 WHERE @AccountId = Accounts.Id
	    IF (@@ROWCOUNT <> 1)
		BEGIN 
			ROLLBACK;
			RAISERROR ('Error!', 16, 3)
		END
	COMMIT
END

-- PROBLEM 5
GO
CREATE PROC dbo.usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN
	IF (@Amount < 0)
	BEGIN
		RAISERROR ('Negative amount of money withdrawn from account!', 16, 1)
	END;

	BEGIN TRANSACTION 
		IF(@Amount >= (SELECT Balance FROM Accounts WHERE @SenderId = Accounts.Id))
		BEGIN
			ROLLBACK
			RAISERROR ('Insufficient Funds in account!', 16, 2)
		END;
		IF (@SenderId IS NULL OR @ReceiverId IS NULL OR @Amount IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR ('Wrong information entered!', 16, 3)
		END

	UPDATE Accounts
	SET Balance = Balance + @Amount
	WHERE @ReceiverId = Accounts.Id

	UPDATE Accounts
	SET Balance = Balance - @Amount
	WHERE @SenderId = Accounts.Id
	COMMIT
END

EXEC dbo.usp_TransferMoney 5, 1, 5000

SELECT Id, AccountHolderId, Balance FROM Accounts
where Id IN (1, 5)

-- PROBLEM 7 
USE Diablo

SELECT * FROM Items

select * from users

where username = 'stamat'

select * from games
where name = 'Safflower'

select * from usersgames
where userid = 9 and gameid=87

SELECT SUM(CountItems) FROM
(
select * from items
where minlevel in (11, 12, 19, 20, 21)
) as Sum

select * from usergameitems
where usergameid = 110
@@ROWCOUNT
GO
CREATE PROC dbo.udp_BuyingItems
AS
BEGIN TRANSACTION
-- BUYING ITEMS ONE BY ONE
DECLARE @numberOfAttemptsToBuy INT = (SELECT SUM(CountItems) FROM
																(
																SELECT COUNT(ID) AS [CountItems] from items
																WHERE MinLevel in (11, 12, 19, 20, 21)
																GROUP BY MINLEVEL
																) as TotalItemsFromAllLeves)
DECLARE @AttemptCounter INT = 1
WHILE (@AttemptCounter <= @numberOfAttemptsToBuy)
	BEGIN
		
	END

select * FROM (
               select *,
               RANK () OVER ( PARTITION BY minlevel ORDER BY ID ) AS [Rank]
               from Items AS i
                where Minlevel in (11, 12, 19, 20, 21)
			  ) as listofitems
WHERE [Rank] = 1

-- PROBLEM 8
USE SoftUni
GO
CREATE PROC dbo.usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN 
	IF(@emloyeeId IS NULL OR @projectID IS NULL)
	BEGIN
		RAISERROR ('Missing data', 16, 1)
	END

	BEGIN TRANSACTION 
	IF ((SELECT COUNT(ep.ProjectID) FROM EmployeesProjects ep
		 WHERE ep.EmployeeId = @emloyeeId
		 GROUP BY ep.EmployeeId) > 2)
		BEGIN
			RAISERROR ('The employee has too many projects!', 16, 1)
			ROLLBACK;
		END
	
	INSERT INTO EmployeesProjects VALUES 
	(@emloyeeId, @projectID)

	COMMIT
END

EXEC dbo.usp_AssignProject 2, 5

-- PROBLEM 9
GO
CREATE TRIGGER tr_DeletedEmployees ON Employees
AFTER DELETE 
AS
BEGIN
	INSERT INTO Deleted_Employees 
	SELECT FirstName,  LastName,  MiddleName,  JobTitle, departmentID,  Salary 
	   FROM deleted
END


















CREATE TRIGGER tr_DeletedEmployeesSaver ON Employees
AFTER DELETE
AS
 BEGIN
	INSERT INTO Deleted_Employees
                SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary
                FROM deleted;
     END

	Deleted_Employees(EmployeeId PK, FirstName, LastName, MiddleName, JobTitle,
DepartmentId, Salary)
END

SELECT * FROM EMPLOYEES






