--PROBLEM 16 

CREATE DATABASE SoftUni
USE SoftUni
--Towns (Id, Name)
CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY, 
	Name NVARCHAR(30) NOT NULL
)
--Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY, 
	AddressText NVARCHAR(MAX), 
	TownId INT,
	FOREIGN KEY (TownId) REFERENCES Towns(Id)
)
--Departments (Id, Name)
CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY, 
	Name NVARCHAR(30) NOT NULL
)

--Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	MiddleName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	JobTitle NVARCHAR(30), 
	DepartmentId INT, 
	HireDate DATE, 
	Salary DECIMAL(9,2), 
	AddressId INT,
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
	FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)

--PROBLEM 17
USE master
DROP DATABASE SoftUni
--BackUp:
--https://docs.microsoft.com/en-us/sql/relational-databases/backup-restore/create-a-full-database-backup-sql-server?view=sql-server-2017&fbclid=IwAR1lOJd2kAc8nm8aU-ch8qJSgNl-hZD4_tYNqmt_y6X-yOzz9ixvv8DhYvg
--Restore:
--https://stackoverflow.com/questions/20837673/how-to-import-a-bak-file-into-sql-server-express?fbclid=IwAR2zX5K_NitBLQqv0-uktQHN4Nd3VoB8ZmUUUmJ3Dl5n7KupnM5XXJ4Q9AU

--PROBLEM 18
-- Towns: Sofia, Plovdiv, Varna, Burgas
-- Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance

USE SoftUni
INSERT INTO Towns (Name) VALUES
('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO Departments (Name) VALUES 
('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

--Name	Job Title	Department	Hire Date	Salary
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov','.NET Developer', 4,'2013-02-01', 3500.00),
('Petar', 'Petrov', 'Petrov','Senior Engineer', 1,'2004-03-02', 4000.00),
('Maria', 'Petrova', 'Ivanova','Intern', 5,'2016-08-28', 525.25),
('Georgi', 'Teziev', 'Ivanov','CEO', 2,'2007-12-09', 3000.00),
('Peter', 'Pan', 'Pan','Intern', 3,'2016-08-28', 599.88)


--PROBLEM 19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--PROBLEM 20
SELECT * FROM Towns
ORDER BY Name ASC

SELECT * FROM Departments
ORDER BY Name ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--PROBLEM 21
SELECT Name FROM Towns
ORDER BY Name ASC

SELECT Name FROM Departments
ORDER BY Name ASC

SELECT FirstName,LastName,JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--PROBLEM 22
UPDATE Employees
SET Salary *=1.1
SELECT Salary FROM Employees

--PROBLEM 23
USE Hotel
UPDATE Payments
SET TaxRate=1
SELECT TaxRate FROM Payments

UPDATE Payments
SET TaxRate*=0.97
SELECT TaxRate FROM Payments

--PROBLEM 24
TRUNCATE TABLE Occupancies
