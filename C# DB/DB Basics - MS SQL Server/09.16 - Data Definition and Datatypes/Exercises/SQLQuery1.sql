CREATE DATABASE Minions

GO

USE Minions

GO
DROP TABLE Minions
DROP TABLE Towns

CREATE TABLE Minions (
	Id INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT NOT NULL
)

CREATE TABLE Towns (
	Id INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId
PRIMARY KEY (Id)

ALTER TABLE Minions
ADD TownId INT 

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionsTownId
FOREIGN KEY (TownId) REFERENCES Towns (Id)

INSERT INTO Towns (Id,[Name])
VALUES (1,'Sofia'), (2,'Plovdiv'), (3,'Varna')

SELECT * FROM Towns

ALTER TABLE Minions
DROP COLUMN Age

ALTER TABLE Minions
ADD Age INT

INSERT INTO Minions (Id, [Name], Age, TownId)
VALUES (1,'Kevin', 22, 1), (2,'Bob', 15, 3), (3,'Steward', NULL, 2)

SELECT [Id], [Name], [Age], [TownId] FROM Minions

GO 
TRUNCATE TABLE Minions

SELECT * FROM Towns

DROP TABLE Minions
DROP TABLE Towns

--PROBLEM 7

USE Minions
--DROP TABLE People 
TRUNCATE TABLE People
CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) <=2097152),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) CHECK (Gender ='m' OR Gender ='f'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Asen', NULL, 1.65, 100.52, 'm', '2000-08-01', NULL),
('Ivan', NULL, 2.65, 104.52, 'm', '2020-08-01', NULL),
('Gosho', NULL, 1.652, 100.22, 'm', '2010-08-01', NULL),
('PP', NULL, 1.55, 99.52, 'm', '2002-08-01', NULL),
('Asn', NULL, 1.95, 10.52, 'm', '2008-08-01', NULL)

SELECT * FROM People

--PROBLEM 8
CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR (30) UNIQUE NOT NULL,
	[Password] VARCHAR (26) NOT NULL,
	ProfilPicture VARBINARY (MAX) CHECK (DATALENGTH(ProfilPicture) <=921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT NOT NULL
)
--DROP TABLE Users

INSERT INTO Users (Username, [Password], ProfilPicture, LastLoginTime, IsDeleted) VALUES
('Ivan', '00000', NULL, NULL, 0),
('Ivan2', '00002', NULL, NULL, 0),
('Ivan3', '00003', NULL, NULL, 0),
('Ivan4', '00004', NULL, NULL, 1),
('Ivan5', '00005', NULL, NULL, 0)

USE Minions

--PROBLEM 9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC076F84D4D1

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUser
PRIMARY KEY (Id,Username)
--PROBLEM 10
ALTER TABLE Users
ADD CONSTRAINT PassLeast5Symbols
CHECK (LEN (Password) >=5)
--SELECT LEN (Password) FROM Users

--PROBLEM 11
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users (Username, [Password], ProfilPicture, IsDeleted) VALUES
('Gosho1', '000000', NULL, 0)

SELECT * FROM Users

--PROBLEM 12
ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUser

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (ID)

ALTER TABLE Users
ADD UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CheckUsernameLeast3Symbbols
CHECK (LEN (Username)>=3)

--PROBLEM 13

CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR (30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes) VALUES
('GOSHO',NULL),('GOSHO2',NULL),('GOSHO3',NULL),('GOSHO4',NULL),('GOSHO5',NULL)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR (30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres(GenreName,Notes) VALUES
('Comedy', NULL),('Comedy2', NULL),('Comedy3', NULL),('Comedy4', NULL),('Comedy5', NULL)


CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR (30) NOT NULL,
	Notes NVARCHAR (MAX)
)

INSERT INTO Categories (CategoryName, Notes) VALUES
('Category1', NULL),('Category2', NULL),('Category3', NULL),('Category4', NULL),('Category5', NULL)

--Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(30) NOT NULL,
	DirectorId INT,
	CopyrightYear DATE,
	[Length] TIME,
	GenreId INT,
	CategoryId INT, 
	Rating DECIMAL(4,2), 
	Notes NVARCHAR (MAX)
)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('PACUL', 1, '2008-11-03','19:30:10',1,1, 10.00, NULL),
('PACUL2', 1, '2008-11-03','19:30:10',1,1, 10.00, NULL),
('PACUL3', 1, '2008-11-03','19:30:10',1,1, 10.00, NULL),
('PACUL4', 1, '2008-11-03','19:30:10',1,1, 10.00, NULL),
('PACUL5', 1, '2008-11-03','19:30:10',1,1, 10.00, NULL)


--PROBLEM 14
CREATE DATABASE CarRental
USE CarRental
--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY, 
	CategoryName NVARCHAR(30) NOT NULL, 
	DailyRate DECIMAL(9,2), 
	WeeklyRate DECIMAL(9,2), 
	MonthlyRate DECIMAL(9,2), 
	WeekendRate DECIMAL(9,2)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Category1', 10.22, NULL, NULL, NULL),
('Category2', 1.22, NULL, NULL, NULL),
('Category3', NULL, NULL, 1.22, NULL)

--Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber VARCHAR(10) NOT NULL, 
	Manufacturer NVARCHAR(30) NOT NULL, 
	Model NVARCHAR(30) NOT NULL, 
	CarYear DATE, 
	CategoryId INT , 
	Doors INT, 
	Picture VARBINARY(MAX), 
	Condition NVARCHAR(MAX), 
	Available BIT,
	FOREIGN KEY(CategoryId) REFERENCES Categories (Id)
)
INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('A1111AA', 'FORD', 'KA', NULL, NULL, 2, NULL, NULL, 0),
('A1112AA', 'AUDI', 'A', NULL, NULL, 2, NULL, NULL, 0),
('A1113AA', 'BMW', 'K', NULL, NULL, 2, NULL, NULL, 1)

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(30), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES 
('PETYR', 'PETROV', NULL, NULL),
('IVAN', 'PETROV', NULL, NULL),
('OP', 'PETROV', NULL, NULL)

--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber INT NOT NULL, 
	FullName NVARCHAR(60) NOT NULL, 
	Address NVARCHAR(60), 
	City NVARCHAR(30), 
	ZIPCode INT, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
(12321, 'A', NULL, NULL, 111, NULL),
(12421, 'A', NULL, NULL, 121, NULL),
(12521, 'A', NULL, NULL, 113, NULL)

--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	CustomerId INT NOT NULL, 
	CarId INT NOT NULL, 
	TankLevel INT, 
	KilometrageStart DECIMAL(7,1), 
	KilometrageEnd DECIMAL (7,1), 
	TotalKilometrage INT, 
	StartDate DATE, 
	EndDate DATE, 
	TotalDays INT, 
	RateApplied DECIMAL(4,2), 
	TaxRate DECIMAL(6,2), 
	OrderStatus NVARCHAR(30) , 
	Notes NVARCHAR(MAX),
	FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
	FOREIGN KEY (CustomerId) REFERENCES Customers (Id),
	FOREIGN KEY (CarId) REFERENCES Cars (Id),
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1,1,1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2,2,2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3,3,3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)


--USE master
--DROP DATABASE CarRental

--PROBLEM 15 
DROP DATABASE Hotel
CREATE DATABASE Hotel
USE Hotel

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(50), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES 
('GOSHO','GOSHEV', NULL, NULL),
('GOSHO1','GOSHEV1', NULL, NULL),
('GOSHO2','GOSHEV2', NULL, NULL)

--Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY NOT NULL, 
	FirstName NVARCHAR(30), 
	LastName NVARCHAR(30), 
	PhoneNumber VARCHAR(30), 
	EmergencyName NVARCHAR(30), 
	EmergencyNumber VARCHAR(30), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(123, NULL, NULL, NULL, NULL, NULL, NULL),
(1213, NULL, NULL, NULL, NULL, NULL, NULL),
(1223, NULL, NULL, NULL, NULL, NULL, NULL)

--RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(30)
)

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES 
('Clean', NULL),
('Dirty', NULL),
('Clean1', NULL)
--DROP TABLE RoomStatus
--RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes(
	RoomType NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(30)
	CONSTRAINT PK_RoomTypes
       PRIMARY KEY (RoomType)
)

INSERT INTO RoomTypes (RoomType, Notes) VALUES 
('Small', NULL),
('Large', NULL),
('Medium', NULL)

--BedTypes (BedType, Notes)
CREATE TABLE BedTypes(
	BedType NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(30),
	CONSTRAINT PK_BedTypes
       PRIMARY KEY (BedType)
)

INSERT INTO BedTypes (BedType, Notes) VALUES 
('Normal', NULL),
('Comfort', NULL),
('Normal1', NULL)

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY NOT NULL, 
	RoomType NVARCHAR(30), 
	BedType NVARCHAR(30), 
	Rate DECIMAL(4,2), 
	RoomStatus NVARCHAR(30), 
	Notes NVARCHAR(MAX),
	FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
	FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
	FOREIGN KEY (RoomStatus) REFERENCES RoomStatus
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(102, NULL, NULL, NULL, NULL, NULL),
(202, NULL, NULL, NULL, NULL, NULL),
(302, NULL, NULL, NULL, NULL, NULL)

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT, 
	PaymentDate DATE, 
	AccountNumber INT, 
	FirstDateOccupied DATE, 
	LastDateOccupied DATE, 
	TotalDays INT, 
	AmountCharged DECIMAL(6,2), 
	TaxRate DECIMAL(6,2), 
	TaxAmount DECIMAL(6,2), 
	PaymentTotal DECIMAL(6,2), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, '2001-01-11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, '2001-01-21', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, '2001-01-01', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT, 
	DateOccupied DATE, 
	AccountNumber INT, 
	RoomNumber INT , 
	RateApplied DECIMAL(6,2), 
	PhoneCharge DECIMAL(6,2), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(NULL,NULL,NULL,NULL,NULL,NULL,NULL)

--PROBLEM 23
UPDATE Payments
SET TaxRate*=0.97
SELECT * FROM Payments