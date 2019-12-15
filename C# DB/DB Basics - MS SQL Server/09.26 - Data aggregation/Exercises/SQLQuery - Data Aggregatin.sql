--1
USE Gringotts

SELECT COUNT(w.Id) AS [Count]
FROM WizzardDeposits AS w

--2
SELECT MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS w

--3
SELECT 
	w.DepositGroup, 
	MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits w
GROUP BY w.DepositGroup
--ORDER BY LongestMagicWand

--4
SELECT TOP 2 
	w.DepositGroup
FROM WizzardDeposits w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize)

--5
SELECT
	w.DepositGroup,
	SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits w
GROUP BY w.DepositGroup



--6
SELECT
	w.DepositGroup,
	SUM (w.DepositAmount) AS TotalSum
FROM WizzardDeposits w
WHERE w.MagicWandCreator= 'Ollivander family'
GROUP BY w.DepositGroup

--7
SELECT
	w.DepositGroup,
	SUM (w.DepositAmount) AS TotalSum
FROM WizzardDeposits w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM (w.DepositAmount) <150000
ORDER BY TotalSum DESC

--8
SELECT 
	w.DepositGroup,
	w.MagicWandCreator,
	MIN(w.DepositCharge) AS MinDepositCharge
FROM WizzardDeposits w
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup

--9


SELECT
CASE
	WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END AS AgeGroup,
COUNT(*)
FROM WizzardDeposits w
GROUP BY 
CASE
	WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END

--10
SELECT SUBSTRING(w.FirstName,1,1) AS FirstLetter
FROM WizzardDeposits w
WHERE w.DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(w.FirstName,1,1)
ORDER BY SUBSTRING(w.FirstName,1,1)

--11
SELECT 
	w.DepositGroup,
	w.IsDepositExpired,
	AVG (w.DepositInterest) AS AverageInterest
FROM WizzardDeposits w
WHERE w.DepositStartDate BETWEEN CAST('1985-01-01' AS DATE)AND GETDATE()
GROUP BY w.DepositGroup, w.IsDepositExpired
ORDER BY w.DepositGroup DESC, w.IsDepositExpired

--12


--13
USE SoftUni

SELECT 
	e.DepartmentID,
	SUM (e.Salary)
FROM Employees e
GROUP BY e.DepartmentID

--14
SELECT 
	e.DepartmentID,
	MIN (e.Salary)
FROM Employees e
WHERE e.HireDate >'2000-01-01'
GROUP BY e.DepartmentID
HAVING e.DepartmentID IN (2,5,7)
USE SoftUni
--15
SELECT *
INTO EmployeesNew 
FROM Employees e
WHERE e.Salary>30000

DELETE 
FROM EmployeesNew
WHERE ManagerID =42

UPDATE EmployeesNew 
SET Salary+=5000
WHERE DepartmentID=1

SELECT 
	en.DepartmentID,
	AVG(en.Salary) AS AverageSalary
FROM EmployeesNew en
GROUP BY en.DepartmentID

--16

SELECT 
	e.DepartmentID,
	MAX(e.Salary) AS MaxSalary
FROM Employees e
GROUP BY e.DepartmentID
HAVING MAX(e.Salary) NOT BETWEEN 30000 AND 70000

--17

SELECT 
	COUNT(*) AS Count
FROM Employees e
WHERE e.ManagerID IS NULL

