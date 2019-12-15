CREATE DATABASE Airport
--USE Airport

CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin NVARCHAR(50) NOT NULL,
	Destination	NVARCHAR(50) NOT NULL,
	PlaneId	INT

	CONSTRAINT FK_Flights_Planes
	FOREIGN KEY (PlaneId)
	REFERENCES Planes (Id)
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId NVARCHAR(11) NOT NULL,
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT NOT NULL,
	FlightId INT NOT NULL,
	LuggageId INT NOT NULL,
	Price DECIMAL (18,2),

	CONSTRAINT FK_Tickets_Passengers
	FOREIGN KEY (PassengerId)
	REFERENCES Passengers (Id),

	CONSTRAINT FK_Tickets_Flights
	FOREIGN KEY (FlightId)
	REFERENCES Flights (Id),

	CONSTRAINT FK_Tickets_Luggages
	FOREIGN KEY (LuggageId)
	REFERENCES Luggages (Id)
)

--2
INSERT INTO Planes([Name],Seats,[Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),		
('Stelt 297', 254, 2143),		
('Boeing 338', 165, 5111),		
('Airbus 558', 387, 1342),		
('Boeing 128', 345, 5541)	

INSERT INTO LuggageTypes (Type) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3
UPDATE Tickets 
SET Price*=1.13
WHERE FlightId IN (
	SELECT 
		f.Id
	FROM Flights AS f
	WHERE f.Destination='Carlsbad'
)

--4
DELETE FROM Tickets
WHERE FlightId IN (
	SELECT 
		f.Id
	FROM Flights AS f
	WHERE f.Destination= 'Ayn Halagim'
	)

DELETE FROM Flights
WHERE Destination= 'Ayn Halagim'

--5
SELECT *
FROM Planes AS p
WHERE CHARINDEX('tr',p.Name)>0
ORDER BY p.Id,p.Name, p.Seats, p.Range

--6
SELECT 
	t.FlightId,
	SUM(t.Price) AS Price
FROM Tickets AS t
GROUP BY t.FlightId
ORDER BY SUM(t.Price) DESC,FlightId

--7
SELECT 
	p.FirstName + ' ' + p.LastName AS [Full Name],
	f.Origin,
	f.Destination
FROM Passengers AS p
JOIN Tickets AS t
ON p.Id=t.PassengerId
JOIN Flights AS f
ON t.FlightId=f.Id
ORDER BY [Full Name],f.Origin,f.Destination

--8
SELECT 
	p.FirstName,
	p.LastName,
	p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t
ON p.Id=t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC,p.FirstName, p.LastName

--9
SELECT 
	p.FirstName + ' ' + p.LastName AS [Full Name],
	pl.Name AS [Plane Name],
	f.Origin + ' - ' + f.Destination AS Trip,
	l.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t
ON p.Id=t.PassengerId
JOIN Flights AS f
ON t.FlightId=f.Id
JOIN Planes AS pl
ON f.PlaneId=pl.Id
JOIN Luggages AS lu
ON t.LuggageId=lu.Id
JOIN LuggageTypes AS l
ON lu.LuggageTypeId=l.Id
ORDER BY [Full Name],[Plane Name],f.Origin,f.Destination,[Luggage Type] 

--10

SELECT 
	p.Name,
	p.Seats,
	COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f
ON p.Id=f.PlaneId
LEFT JOIN Tickets AS t
ON f.Id=t.FlightId
GROUP BY p.Name, p.Seats
ORDER BY [Passengers Count] DESC,p.Name, p.Seats


USE Airport
--11
--udf_CalculateTickets(@origin, @destination, @peopleCount) 
CREATE FUNCTION udf_CalculateTickets (@origin NVARCHAR(100), @destination NVARCHAR(100), @peopleCount INT )
RETURNS NVARCHAR(100)
AS 
BEGIN
	DECLARE @result NVARCHAR(100);
	DECLARE @price DECIMAL(18,2)
	IF @peopleCount > 0
    BEGIN
		SET @price = 
			(SELECT
				t.Price
			FROM Tickets AS t
			JOIN Flights AS f
			ON t.FlightId=f.Id
			WHERE f.Origin= @origin AND f.Destination=@destination)

		
		IF @price IS NOT NULL
		BEGIN
			SET @price *=@peopleCount;
			SET @result ='Total price ' + CAST(@price AS NVARCHAR);
		END
		ELSE
		BEGIN
			SET @result = 'Invalid flight!';
		END
    END
    ELSE
    BEGIN
        SET @result = 'Invalid people count!';
    END
	--SET @result = @sum*(POWER(1+@rate,@years))
	RETURN @result
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang',33)

--12
--usp_CancelFlights
CREATE PROC usp_CancelFlights
AS
	UPDATE Flights 
	SET DepartureTime=NULL,
	ArrivalTime = NULL
	WHERE DepartureTime<ArrivalTime

