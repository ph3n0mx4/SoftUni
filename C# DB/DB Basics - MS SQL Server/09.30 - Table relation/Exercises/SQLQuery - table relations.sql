--1
CREATE DATABASE [OneToOne]
USE OneToOne

CREATE TABLE Passports(
	PassportID INT NOT NULL IDENTITY (101,1),
	PassportNumber NVARCHAR(20)

	CONSTRAINT PK_PassportID PRIMARY KEY (PassportID)
)

CREATE TABLE Persons (
	PersonID INT NOT NULL IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(9,2) NOT NULL,
	PassportID INT NOT NULL

	CONSTRAINT PK_PersonID PRIMARY KEY (PersonID)
	CONSTRAINT FK_Persons_Passport FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
)

INSERT INTO Passports (PassportNumber) VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons (FirstName,Salary,PassportID) VALUES
('Roberto',43300.00,102),
('Tom',56100.00,103),
('Yana',60200.00,101)

--2

CREATE DATABASE OneToMany
USE OneToMany

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY ,
	Name NVARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY (101,1),
	Name NVARCHAR(30) NOT NULL,
	ManufacturerID INT NOT NULL

	CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
)


INSERT INTO Manufacturers (Name,EstablishedOn) VALUES
('BMW','1916-07-03'),
('Tesla','2003-01-01'),
('Lada','1966-05-01')

INSERT INTO Models (Name,ManufacturerID) VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

SELECT *
FROM Manufactures

SELECT *
FROM Models

DROP TABLE Models
DROP TABLE Manufactures

--3

CREATE DATABASE ManyToMany
USE ManyToMany

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(30)
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(30)
)

CREATE TABLE StudentsExams(
	StudentID INT,
	ExamID INT

	CONSTRAINT PK_StudentsExams
	PRIMARY KEY (StudentID, ExamID),

	CONSTRAINT FK_StudentsExams_Students
	FOREIGN KEY (StudentID) 
	REFERENCES Students(StudentID),

	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY (ExamID) 
	REFERENCES Exams(ExamID)
)
DROP TABLE Exams
INSERT INTO Students ([Name]) 
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams ([Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES 
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

--4

CREATE DATABASE SelfReferencing
USE SelfReferencing

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT

	CONSTRAINT FK_Teachers_Teachers 
	FOREIGN KEY (ManagerID)
	REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers ([Name],ManagerID)
VALUES
('John',NULL),
('Maya',106),
('Silvia',106),
('Ted',105),
('Mark',101),
('Greta',101)

--5

CREATE DATABASE [OnlineStore]
USE [OnlineStore]
GO
CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)


CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT

	CONSTRAINT FK_Customers_Cities
	FOREIGN KEY (CityID)
	REFERENCES Cities (CityID)
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT 

	CONSTRAINT FK_Orders_Customers
	FOREIGN KEY (CustomerID)
	REFERENCES Customers (CustomerID)
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	ItemTypeID INT

	CONSTRAINT FK_Items_ItemTypes
	FOREIGN KEY (ItemTypeID)
	REFERENCES ItemTypes (ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT,
	ItemID INT,

	CONSTRAINT PK_OrderItems
	PRIMARY KEY (OrderID, ItemID),

	CONSTRAINT FK_OrderItems_Items
	FOREIGN KEY (ItemID)
	REFERENCES Items(ItemID),

	CONSTRAINT FK_OrderItems_Orders
	FOREIGN KEY (OrderID)
	REFERENCES Orders(OrderID)
)

--6

CREATE DATABASE UniversityDB
USE UniversityDB

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(10),
	StudentName NVARCHAR(50),
	MajorID INT

	CONSTRAINT FK_Students_Majors
	FOREIGN KEY (MajorID)
	REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount DECIMAL (9,2),
	StudentID INT

	CONSTRAINT FK_Payments_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
)

CREATE TABLE [Subjects](
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(50)
)

CREATE TABLE Agenda(
	StudentID INT,
	SubjectID INT,

	CONSTRAINT PK_Agenda
	PRIMARY KEY (StudentID, SubjectID),

	CONSTRAINT FK_Agenda_Subjects
	FOREIGN KEY (SubjectID)
	REFERENCES [Subjects] (SubjectID),

	CONSTRAINT FK_Agenda_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
)

--9
USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON p.MountainId=m.Id
WHERE m.MountainRange='Rila'
ORDER BY p.Elevation DESC

  -- FROM PRESENTATION
  SELECT m.MountainRange, p.PeakName, p.Elevation 
    FROM Mountains AS m
    JOIN Peaks As p ON p.MountainId = m.Id
   WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
