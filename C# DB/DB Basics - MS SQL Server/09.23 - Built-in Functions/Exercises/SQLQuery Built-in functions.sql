--1
USE SoftUni

SELECT FirstName,LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--2
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName
FROM Employees
WHERE DepartmentID =3 OR DepartmentID=10
--AND HireDate >='1995/01/01' AND HireDate <='2005/12/31'
AND YEAR(HireDate) BETWEEN 1995 AND 2005

--4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT Name
FROM Towns
WHERE LEN(Name) BETWEEN 5 AND 6
ORDER BY Name

--6
SELECT *
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name

--7
SELECT *
FROM Towns
WHERE Name NOT LIKE '[RBD]%'
ORDER BY Name

--8
GO
CREATE VIEW V_EmployeesHiredAfter2000 
AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate)>2000

GO
SELECT * FROM V_EmployeesHiredAfter2000

--9
SELECT FirstName,LastName
FROM Employees
WHERE LEN(LastName)=5

--10
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11
SELECT *
FROM (
	SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	) AS RankTable
WHERE RankTable.Rank=2
ORDER BY Salary DESC

--12
USE Geography
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--13
SELECT PS.PeakName, RS.RiverName, LOWER(LEFT(PeakName,LEN(PeakName)-1)+RiverName) AS Mix
FROM Peaks AS PS, Rivers AS RS
WHERE RIGHT(PeakName,1) =LEFT(RiverName,1)
ORDER BY Mix

--14
USE Diablo

SELECT TOP(50) Name,FORMAT(Start,'yyyy-MM-dd') AS Start
FROM Games
WHERE YEAR(Start) BETWEEN 2011 AND 2012
ORDER BY Start,Name

--15
SELECT * FROM Users

SELECT Username, RIGHT(Email,(LEN(Email) -CHARINDEX('@',Email,1))) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider], Username

--16
SELECT Username, IpAddress 
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17

SELECT CONVERT(INT,DATENAME(Hour,Start)) AS [EEEE],*
FROM Games


SELECT Name AS Game, 
CASE
	WHEN CONVERT(INT,DATENAME(Hour,Start))>=0 AND CONVERT(INT,DATENAME(Hour,Start))<12 THEN 'Morning'
	WHEN CONVERT(INT,DATENAME(Hour,Start))>=12 AND CONVERT(INT,DATENAME(Hour,Start))<18 THEN 'Afternoon'
	WHEN CONVERT(INT,DATENAME(Hour,Start))>=18 AND CONVERT(INT,DATENAME(Hour,Start))<24 THEN 'Evening'
END AS [Part of the Day],
CASE
	WHEN Duration<=3  THEN 'Extra Short'
	WHEN Duration>=4 AND Duration<=6  THEN 'Short'
	WHEN Duration>6  THEN 'Long'
	ELSE 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY Game,[Duration],[Part of the Day]

--18
USE Orders

SELECT *
FROM Orders

ALTER TABLE Orders
DROP COLUMN [Pay Due] 


ALTER TABLE Orders
DROP COLUMN [Deliver Due]

SELECT ProductName,OrderDate,
DATEADD(DAY,3,OrderDate) AS [Pay Due],
DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
FROM Orders









