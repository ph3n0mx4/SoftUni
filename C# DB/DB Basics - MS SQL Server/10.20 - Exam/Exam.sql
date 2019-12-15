CREATE DATABASE [Service]
USE [Service]

--1
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK (Age>=14 AND Age<=110 ),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK (Age>=18 AND Age<=110 ),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description NVARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2

INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId) VALUES
('Marlo','O''Malley', '1958-9-21',1),
('Niki','Stanaghan', '1969-11-26',4),
('Ayrton','Senna', '1960-03-21',9),
('Ronnie','Peterson', '1944-02-14',9),
('Giovanna','Amati', '1959-07-20',5)

INSERT INTO Reports (CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId) VALUES
(1,1,'2017-04-13', NULL, 'Stuck Road on Str.133',6,	2),
(6,3,'2015-09-05', '2015-12-06', 'Charity trail running',3,	5),
(14,2,'2015-09-07', NULL, 'Falling bricks on Str.58',5,	2),
(4,3,'2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11',1,	1)

--3
UPDATE Reports 
SET CloseDate=GETDATE()
WHERE CloseDate IS NULL

--4
SELECT *
FROM Reports AS r
WHERE r.StatusId=4

SELECT *
FROM Status

DELETE FROM Reports
WHERE StatusId=4

--5
SELECT 
	r.Description,
	FORMAT(r.OpenDate,'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate, r.Description

--6
SELECT 
	r.Description,
	c.Name AS CategoryName
FROM Reports AS r
JOIN Categories AS c
ON r.CategoryId=c.Id
ORDER BY r.Description, c.Name

--7
SELECT TOP (5)
	c.Name AS CategoryName,
	COUNT(*) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c
ON r.CategoryId=c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC

--8
SELECT
	u.Username,
	c.Name AS CategoryName
FROM Reports AS r
JOIN Users AS u
ON r.UserId=u.Id
JOIN Categories AS c
ON r.CategoryId=c.Id
WHERE FORMAT(r.OpenDate,'dd-MM')=FORMAT(u.Birthdate,'dd-MM')
ORDER BY u.Username, CategoryName

--9
SELECT
	CONCAT(e.FirstName,' ',e.LastName) AS FullName,
	COUNT(u.Id) AS UsersCount
FROM Reports AS r
RIGHT JOIN Employees AS e
ON r.EmployeeId=e.Id
JOIN Users AS u
ON r.UserId=u.Id
GROUP BY e.FirstName,e.LastName
ORDER BY COUNT(*) DESC,FullName

SELECT*
FROM Employees AS e
LEFT JOIN Reports AS r
ON e.Id=r.EmployeeId
LEFT JOIN Users AS u
ON r.UserId=u.Id

SELECT
	CONCAT(e.FirstName,' ',e.LastName) AS FullName,
	COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r
ON e.Id=r.EmployeeId
LEFT JOIN Users AS u
ON r.UserId=u.Id
GROUP BY e.FirstName,e.LastName
ORDER BY COUNT(u.Id) DESC,FullName
--10

SELECT 
	ISNULL(e.FirstName+' '+e.LastName,'None') AS FullName,
	ISNULL(d.Name,'None') AS Department,
	c.Name AS Category,
	r.Description,
	FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
	s.Label AS Status,
	u.Name AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e
ON r.EmployeeId=e.Id
LEFT JOIN Departments AS d
ON e.DepartmentId=d.Id
LEFT JOIN Categories AS c
ON r.CategoryId=c.Id
JOIN Status AS s
ON r.StatusId=s.Id
LEFT JOIN Users AS u
ON r.UserId=u.Id
ORDER BY e.FirstName DESC, e.LastName DESC,d.Name,c.Name, 
r.Description, r.OpenDate, s.Label,u.Username

--11
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
BEGIN
	DECLARE @r INT
	IF (@StartDate IS NOT NULL)
		BEGIN
			IF (@EndDate IS NOT NULL)
				BEGIN
					SET @r=	DATEDIFF(HOUR,@StartDate,@EndDate)
				END
			ELSE
				BEGIN
					SET @r=0
				END
		END
	ELSE
		BEGIN
			SET @r=0
		END
	RETURN @r
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--12
SELECT 
	d.Name
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentId=d.Id
WHERE e.DepartmentId=@EmployeeId




CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS	
	DECLARE @eDep NVARCHAR(30) =
	(SELECT TOP(1)
			d.Name
		FROM Employees AS e
		JOIN Departments AS d
		ON e.DepartmentId=d.Id
		WHERE e.Id=@EmployeeId
	)
	DECLARE @rDep NVARCHAR(30)=
	(SELECT TOP(1)
			d.Name
		FROM Reports AS r
		JOIN Categories AS c
		ON r.CategoryId=c.Id
		JOIN Departments AS d
		ON c.DepartmentId=d.Id
		WHERE r.Id=@ReportId
	)

	IF(@eDep = @rDep)
		UPDATE Reports 
		SET EmployeeId=@EmployeeId
		WHERE Id= @ReportId

	ELSE 
		BEGIN
		   THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
		END
EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2