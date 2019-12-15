CREATE DATABASE Bitbucket
USE Bitbucket

--1
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT,
	ContributorId INT,

	CONSTRAINT PK_RepositoriesContributors
	PRIMARY KEY (RepositoryID, ContributorID),

	CONSTRAINT FK_RepositoriesContributors_Users
	FOREIGN KEY (ContributorId) 
	REFERENCES Users(Id),

	CONSTRAINT FK_RepositoriesContributors_Repositories
	FOREIGN KEY (RepositoryId) 
	REFERENCES Repositories(Id)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(255) NOT NULL,
	IssueStatus NVARCHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Size DECIMAL(20,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

--2
INSERT INTO Files([Name],Size,ParentId,CommitId) VALUES
('Trade.idk', 2598.0, 1,1),
('menu.net', 9238.31, 2,2),
('Administrate.soshy', 1246.93, 3,3),	
('Controller.php', 7353.15, 4,4),	
('Find.java', 9957.86, 5,5),	
('Controller.json', 14034.87, 3,6),
('Operate.xix', 7662.92, 7,7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId,AssigneeId) VALUES
('Critical Problem with HomeController.cs file','open',1,4),
('Typo fix in Judge.html','open',4,3),
('Implement documentation for UsersService.cs','closed',8,2),
('Unreachable code in Index.cs','open',9,8)

--3
UPDATE Issues 
SET IssueStatus='closed'
WHERE Id =6

--4
DELETE FROM Issues
WHERE RepositoryId IN (
	SELECT 
		r.Id
	FROM Repositories AS r
	WHERE r.Name= 'Softuni-Teamwork'
	)

DELETE FROM RepositoriesContributors
WHERE RepositoryId IN (
	SELECT 
		r.Id
	FROM Repositories AS r
	WHERE r.Name= 'Softuni-Teamwork'
	)



DELETE FROM Files
WHERE CommitId IN(
	SELECT
		c.Id
	FROM Commits AS c
	WHERE RepositoryId IN (
	SELECT 
		r.Id
	FROM Repositories AS r
	WHERE r.Name= 'Softuni-Teamwork'
		)
	)

DELETE FROM Commits
WHERE RepositoryId IN (
	SELECT 
		r.Id
	FROM Repositories AS r
	WHERE r.Name= 'Softuni-Teamwork'
	)

DELETE FROM Repositories
WHERE Name= 'Softuni-Teamwork'

--5
SELECT
	c.Id,
	c.Message,
	c.RepositoryId,
	c.ContributorId
FROM Commits AS c
ORDER BY c.Id, c.Message, c.RepositoryId, c.ContributorId

--6
SELECT 
	f.Id,
	f.Name,
	f.Size
FROM Files AS f
WHERE f.Size>1000 AND CHARINDEX('html',f.Name)>0
ORDER BY f.Size DESC, f.Id, f.Name

--7
SELECT
	i.Id,
	u.Username + ' : ' + i.Title
FROM Issues AS i
LEFT JOIN Users AS u
ON i.AssigneeId=u.Id
ORDER BY i.Id DESC,i.AssigneeId

--8
SELECT 
	f.Id,
	f.Name,
	CAST((f.Size) AS VARCHAR) +'KB' AS Size
FROM Files AS f
WHERE f.Id IN(
			SELECT 
				f.Id
			FROM Files AS f
			LEFT JOIN Files AS f2
			ON f2.ParentId =f.Id
			WHERE f2.Id IS NULL)
ORDER BY f.Id, f.Name,f.Size DESC

--9
SELECT TOP(5)
	r.Id,
	r.Name,
	COUNT(*) AS Contributors
FROM RepositoriesContributors AS rc
JOIN Repositories AS r
ON rc.RepositoryId=r.Id
JOIN Commits AS c
ON r.Id=c.RepositoryId
GROUP BY r.[Name],r.Id
ORDER BY Contributors DESC, r.Id,r.Name

--10

SELECT 
	u.Username,
	AVG(f.Size)
FROM Files AS f
JOIN Commits AS c
ON f.CommitId=c.Id
JOIN Users AS u
ON c.ContributorId=u.Id
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC,u.Username

--11
CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30))
RETURNS INT
AS 
BEGIN
	RETURN(
		SELECT
			COUNT(*)
		FROM Users AS u
		JOIN Commits AS c
		ON u.Id=c.ContributorId
		WHERE u.Username=@username
	)
END

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

--12
CREATE PROC usp_FindByExtension(@extension NVARCHAR(30))
AS	
	SELECT 
		f.Id,
		f.Name,
		CONCAT(f.Size,'KB') AS [Size]
	FROM Files AS f
	WHERE CHARINDEX(@extension,f.Name)>0