CREATE DATABASE School
USE School

CREATE TABLE Students (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK (Age>=5 AND Age<=100 ) NOT NULL,
	[Address] NVARCHAR(50),
	Phone NVARCHAR(10)
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Lessons INT CHECK (Lessons>0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2)  CHECK (Grade>=2 AND Grade<=6 ) NOT NULL
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT NOT NULL,
	ExamId INT NOT NULL,
	Grade DECIMAL(3,2)  CHECK (Grade>=2 AND Grade<=6 ) NOT NULL

	CONSTRAINT PK_StudentsExams
	PRIMARY KEY (StudentId, ExamId),

	CONSTRAINT FK_StudentsExams_Students
	FOREIGN KEY (StudentId) 
	REFERENCES Students(Id),

	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY (ExamId) 
	REFERENCES Exams(Id)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone NVARCHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT NOT NULL,
	TeacherId INT NOT NULL,
	
	CONSTRAINT PK_StudentsTeachers
	PRIMARY KEY (StudentId, TeacherId),

	CONSTRAINT FK_StudentsTeachers_Students
	FOREIGN KEY (StudentId) 
	REFERENCES Students(Id),

	CONSTRAINT FK_StudentsTeachers_Teachers
	FOREIGN KEY (TeacherId) 
	REFERENCES Teachers(Id)
)

--2
				
INSERT INTO Teachers(FirstName,LastName,[Address],Phone,SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction',3105500146,6),
('Gerrard', 'Lowin', '370 Talisman Plaza',3324874824,2),
('Merrile', 'Lambdin', '81 Dahle Plaza',4373065154,5),
('Bert', 'Ivie', '2 Gateway Circle',4409584510,4)

INSERT INTO Subjects(Name,Lessons) VALUES	
('Geometry',12),
('Health',10),
('Drama', 7),
('Sports',9)

--3
UPDATE StudentsSubjects 
SET Grade=6
WHERE (SubjectId BETWEEN 1 AND 2) AND Grade>=5.50

--4
DELETE FROM StudentsTeachers
WHERE TeacherId IN (
	SELECT
		t.Id
	FROM Teachers AS t
	WHERE CHARINDEX('72',t.Phone)>0
	)
DELETE FROM Teachers
WHERE CHARINDEX('72',Phone)>0
				
--5
SELECT
	s.FirstName,
	s.LastName,
	s.Age
FROM Students AS s
WHERE s.Age>=12
ORDER BY s.FirstName, s.LastName	

--6
SELECT
	s.FirstName, 
	s.LastName,
	COUNT(*)
FROM Students AS s
JOIN StudentsTeachers AS st
ON s.Id=st.StudentId
GROUP BY s.FirstName, s.LastName	

--7
SELECT 
	CONCAT(s.FirstName,' ',s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se
ON s.Id=se.StudentId
WHERE se.StudentId IS NULL
ORDER BY [Full Name]
				
--8
SELECT TOP(10)
	s.FirstName,
	s.LastName,
	CONVERT(DECIMAL(10,2),AVG(se.Grade))AS Grade
FROM Students AS s
LEFT JOIN StudentsExams AS se
ON s.Id=se.StudentId
GROUP BY s.FirstName,s.LastName
ORDER BY Grade DESC,s.FirstName,s.LastName

--9
SELECT 
	CASE
		WHEN s.MiddleName IS NULL THEN CONCAT(s.FirstName,' ',s.LastName)
		ELSE CONCAT(s.FirstName,' ',s.MiddleName,' ',s.LastName)
	END AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss
ON s.Id=ss.StudentId
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

--10
SELECT
	s.Name,
	AVG(ss.Grade)
FROM StudentsSubjects AS ss
JOIN Subjects AS s
ON ss.SubjectId=s.Id
GROUP BY s.Name, s.Id
ORDER BY s.Id

--11
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS INT
AS 
BEGIN
	SELECT*
	FROM Students
END

--12
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
	