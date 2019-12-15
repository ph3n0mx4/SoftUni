USE SoftUni

--1
SELECT TOP 5
	e.EmployeeID,
	e.JobTitle,
	a.AddressID,
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID=a.AddressID
ORDER BY a.AddressID 

--2
SELECT TOP 50 
	e.FirstName,
	e.LastName,
	t.[Name],
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID=a.AddressID
JOIN Towns AS t
ON a.TownID=t.TownID
ORDER BY e.FirstName, e.LastName

--3
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID=d.DepartmentID
WHERE d.Name='Sales'
ORDER BY e.EmployeeID

--4
SELECT TOP 5 
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID=d.DepartmentID 
AND e.Salary> 15000
ORDER BY e.DepartmentID

--5
SELECT TOP 3
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID=ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

--6
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID=d.DepartmentID
WHERE e.HireDate > '1999-1-1 00:00:00.000'
AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

--7
SELECT TOP 5
	e.EmployeeID,
	e.FirstName,
	p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID=ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID=p.ProjectID
WHERE p.StartDate > ('2002-8-13')
AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8
SELECT 
	e.EmployeeID,
	e.FirstName,
	p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID=ep.EmployeeID
LEFT JOIN Projects AS p 
ON ep.ProjectID=p.ProjectID
AND p.StartDate <'2005-1-1'
WHERE e.EmployeeID=24

--9
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName
FROM Employees AS e
JOIN Employees AS m
ON m.EmployeeID=e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

--10
SELECT TOP 50
	e.EmployeeID,
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID=m.EmployeeID
JOIN Departments AS d
ON d.DepartmentID=e.DepartmentID
ORDER BY e.EmployeeID

--11
SELECT TOP 1
	AVG(e.Salary) AS MinAverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY AVG (e.Salary)


USE Geography

--12
SELECT 
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON p.MountainId = m.Id
JOIN MountainsCountries AS c
ON p.MountainId=c.MountainId
WHERE c.CountryCode='BG'
AND p.Elevation>2835
ORDER BY p.Elevation DESC

--13
SELECT 
	c.CountryCode,
	COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS c
JOIN Mountains AS m
ON m.Id=c.MountainId
GROUP BY  c.CountryCode
HAVING c.CountryCode IN ('US', 'BG', 'RU')

--14
SELECT TOP 5
	c.CountryName,
	r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId=r.Id
WHERE c.ContinentCode='AF'
ORDER BY c.CountryName

--15
SELECT 
	a.ContinentCode,
	a.CurrencyCode,
	a.CurrencyUsage
FROM (
	SELECT 
		c.ContinentCode,
		c.CurrencyCode,
		COUNT(c.CurrencyCode) AS CurrencyUsage,
		DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS r
	FROM Countries AS c
	GROUP BY c.ContinentCode, c.CurrencyCode
	HAVING COUNT(c.CurrencyCode)>1) AS a
WHERE a.r=1
ORDER BY a.ContinentCode

--16
SELECT *
FROM Countries,MountainsCountries

SELECT 
	COUNT (*) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS m
ON c.CountryCode=m.CountryCode
WHERE m.MountainId IS NULL
GROUP BY m.MountainId

--17

SELECT TOP 5
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS m
ON c.CountryCode=m.CountryCode
LEFT JOIN Peaks AS p
ON m.MountainId=p.MountainId
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId=r.Id
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC,MAX(r.Length) DESC, c.CountryName

--18

SELECT TOP 5
	a.CountryName AS Country,
	CASE
		WHEN a.PeakName IS NULL THEN '(no highest peak)'
		ELSE a.PeakName
	END AS [Highest Peak Name],
	CASE
		WHEN a.ElevationPeak IS NULL THEN '0'
		ELSE a.ElevationPeak
	END AS [Highest Peak Elevation],
	CASE
		WHEN a.MountainRange IS NULL THEN '(no mountain)'
		ELSE a.MountainRange
	END AS Mountain
FROM (
	SELECT
		c.CountryName,
		m.MountainRange,
		p.PeakName,
		MAX(p.Elevation) as ElevationPeak,
		DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS r
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode=mc.CountryCode
	LEFT JOIN Mountains AS m
	ON mc.MountainId=m.Id
	LEFT JOIN Peaks AS p
	ON m.Id=p.MountainId
	GROUP BY c.CountryName, m.MountainRange, p.PeakName
	--ORDER BY c.CountryName
) AS a
WHERE a.r=1
ORDER BY a.CountryName,a.PeakName

