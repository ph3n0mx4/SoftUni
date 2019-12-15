USE SoftUni
GO
--1
CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
	SELECT 
		e.FirstName,
		e.LastName
	FROM Employees AS e
	WHERE e.Salary>35000
GO
EXEC dbo.usp_GetEmployeesSalaryAbove35000

--2
GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(18,4))
AS
	SELECT 
		e.FirstName,
		e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @number
GO

--3
CREATE PROC usp_GetTownsStartingWith (@param NVARCHAR(20))
AS
	SELECT 
		t.[Name] AS Town
	FROM Towns AS t
	WHERE SUBSTRING(t.[Name],1,LEN(@param))=@param

EXEC usp_GetTownsStartingWith 'b'
GO
--4
CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(20))
AS
	SELECT 
		e.FirstName,
		e.LastName
	FROM Employees AS e
	JOIN Addresses AS a
	ON e.AddressID=a.AddressID
	JOIN Towns AS t
	ON a.TownID=t.TownID
	WHERE t.[Name]=@townName
GO

--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(7)
AS
BEGIN
	DECLARE @level NVARCHAR(7)
	SET @level=
		CASE
			WHEN @salary > 50000 THEN 'High'
			WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
			ELSE 'Low'
		END
	RETURN @level
END

GO
SELECT
	dbo.ufn_GetSalaryLevel(e.Salary)
FROM Employees AS e
GO

--6
CREATE PROC usp_EmployeesBySalaryLevel (@level NVARCHAR(7))
AS
	SELECT
		e.FirstName,
		e.LastName
	FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary)=@level

GO
--7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @result INT =1;
	DECLARE @index INT =1;
	WHILE @index<=LEN(@word)
	BEGIN
		IF(CHARINDEX(SUBSTRING (@word,@index,1),@setOfLetters,1)=0)
			BEGIN
				SET @result=0
			END
		SET @index+=1
	END
	RETURN @result
END
GO
--8
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	DELETE 
	FROM EmployeesProjects
	WHERE EmployeeID IN (
	SELECT EmployeeID
	FROM Employees
	WHERE DepartmentID=@departmentId
	)

	UPDATE Employees
	SET ManagerID=NULL
	WHERE ManagerID IN (
	SELECT EmployeeID
	FROM Employees
	WHERE DepartmentID=@departmentId
	)

	--set column ManagerId(Departments) to be nullable
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	--set ManagerID to NULL for all departments whose manager was deleted
	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID=@departmentId

	--as employees doesn`t have any more relations we can safely delete all employees in wanted department
	DELETE FROM Employees
	WHERE DepartmentID=@departmentId

	--as department doesn`t have any more relations we can safely delete the whole department
	DELETE FROM Departments
	WHERE DepartmentID=@departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID=@departmentId
END

SELECT *
FROM Employees
GO
USE Bank

--9
GO
CREATE PROC usp_GetHoldersFullName 
AS
	SELECT 
		a.FirstName + ' ' + a.LastName AS FullName
	FROM AccountHolders AS a

GO
--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18,4))
AS
	SELECT 
		ah1.FirstName,
		ah1.LastName
	FROM AccountHolders AS ah1
	WHERE ah1.Id IN (
		SELECT
			ah.Id
		FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON a.AccountHolderId=ah.Id
		GROUP BY ah.Id
		HAVING SUM(a.Balance) >@number)
	ORDER BY ah1.FirstName, ah1.LastName

--11
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @rate FLOAT, @years INT )
RETURNS DECIMAL (18,4)
AS 
BEGIN
	DECLARE @result DECIMAL (18,4);
	SET @result = @sum*(POWER(1+@rate,@years))
	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000,0.1,5)

--12
CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @YearlyInterestRate FLOAT)
AS
	SELECT 
		ah.Id AS [Account Id],
		ah.FirstName [First Name],
		ah.LastName [Last Name],
		a.Balance [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance,@YearlyInterestRate,5) AS ['Balance in 5 years']
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON a.AccountHolderId=ah.Id
	WHERE a.Id=@AccountId


--13
GO
USE Diablo
GO

SELECT 
	ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS r
FROM UsersGames AS ug
JOIN Games AS g
ON ug.GameId=g.Id
WHERE CAST(r AS INT)%2=1

CREATE FUNCTION ufn_CashInUsersGames (@param NVARCHAR(30))
RETURNS TABLE AS
RETURN
(
	SELECT 
		--a.Name,
		--a.r,
		SUM(a.Cash) AS SumCash
	FROM
	(
		SELECT
			g.Name,
			ug.Cash,
			ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS r
		FROM UsersGames AS ug
		INNER JOIN Games AS g
		ON g.Id=ug.GameId
		WHERE g.Name=@param
		
	)AS a
	WHERE a.r % 2  =1
)

SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist')

SELECT *
FROM dbo.ufn_CashInUsersGames1('Love in a mist')

SELECT *
FROM Games
SELECT 
	*,
	ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS r
FROM UsersGames 

 CREATE FUNCTION ufn_CashInUsersGames1 (@GameName NVARCHAR(50))
   RETURNS TABLE
    RETURN (SELECT SUM(k.Cash) AS SumCash
              FROM (
		       SELECT ug.Cash,
			      ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
	                 FROM UsersGames ug
		   INNER JOIN Games g
			   ON g.Id = ug.GameId
	 	        WHERE g.Name = @GameName) AS k
             WHERE k.RowNumber % 2 = 1)


