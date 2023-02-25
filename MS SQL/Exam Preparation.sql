--01
CREATE DATABASE ColonialJourney
USE ColonialJourney

CREATE TABLE Planets (
			Id INT PRIMARY KEY IDENTITY,
			Name VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports(
			Id INT PRIMARY KEY IDENTITY,
			Name VARCHAR(50) NOT NULL,
			PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id)
)

CREATE TABLE Spaceships(
			Id INT PRIMARY KEY IDENTITY,
			Name VARCHAR(50) NOT NULL,
			Manufacturer VARCHAR(30) NOT NULL,
			LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists(
			Id INT PRIMARY KEY IDENTITY,
			FirstName VARCHAR(20) NOT NULL,
			LastName VARCHAR(20) NOT NULL,
			Ucn VARCHAR(10) UNIQUE NOT NULL,
			BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
			Id INT PRIMARY KEY IDENTITY,
			JourneyStart DATETIME NOT NULL,
			JourneyEnd DATETIME NOT NULL,
			Purpose VARCHAR(11) CONSTRAINT chk_Purpose CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
			DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id),
			SpaceshipId INT NOT NULL FOREIGN KEY REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards(
			Id INT PRIMARY KEY IDENTITY,
			CardNumber CHAR(10) UNIQUE NOT NULL,
			JobDuringJourney VARCHAR(8) CONSTRAINT chk_Job CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
			ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
			JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
)

--02
INSERT INTO Planets
	 VALUES ('Mars')
			,('Earth')
			,('Jupiter')
			,('Saturn')

INSERT INTO Spaceships
	 VALUES ('Golf', 'VW', 3)
			,('WakaWaka', 'Wakanda', 4)
			,('Falcon9', 'SpaceX', 1)
			,('Bed', 'Vidolov', 6)

--03
UPDATE Spaceships
   SET LightSpeedRate += 1
 WHERE Id BETWEEN 8 AND 12

--04
DELETE TravelCards
 WHERE JourneyId <= 3

DELETE Journeys
 WHERE Id <= 3

--05
SELECT Id
	   ,FORMAT(JourneyStart, 'dd/MM/yyyy')
	   ,FORMAT(JourneyEnd, 'dd/MM/yyyy')
  FROM Journeys
 WHERE Purpose = 'Military'
ORDER BY JourneyStart

--06
	 SELECT c.Id
		   ,CONCAT(FirstName, ' ', LastName)
		AS full_name
	  FROM Colonists
	    AS c
INNER JOIN TravelCards
		AS tc
		ON c.Id = tc.ColonistId
	 WHERE tc.JobDuringJourney = 'Pilot'
  ORDER BY c.Id
  
--07
	SELECT COUNT(c.Id)
		AS count
	  FROM Colonists
	    AS c
INNER JOIN TravelCards
		AS tc
		ON c.Id = tc.ColonistId
INNER JOIN Journeys
		AS j
		ON tc.JourneyId = j.Id
	 WHERE j.Purpose = 'technical'

--08
   SELECT s.Name
	      ,s.Manufacturer
     FROM Spaceships
	   AS s
LEFT JOIN Journeys
		AS j
		ON s.Id = j.SpaceshipId
LEFT JOIN TravelCards
	   AS tc
	   ON j.Id = tc.JourneyId
LEFT JOIN Colonists
	   AS c
	   ON c.Id = tc.ColonistId
    WHERE tc.JobDuringJourney = 'pilot'
	  AND DATEDIFF(YEAR, c.BirthDate, '2019-01-01') < 30
 ORDER BY s.Name

--09
  SELECT p.Name
	     ,COUNT(j.id)
	  AS JourneysCount
    FROM Planets
	  AS p
LEFT JOIN Spaceports
	   AS sp
	   ON sp.PlanetId = p.Id
LEFT JOIN Journeys
	   AS j
	   ON j.DestinationSpaceportId = sp.Id
	WHERE j.Id IS NOT NULL
 GROUP BY p.Name
 ORDER BY JourneysCount DESC, p.Name

--10
   SELECT	
		 SubQ.JobDuringJourney
		 ,CONCAT(SubQ.FirstName, ' ', SubQ.LastName)
	  AS FullName
		 ,SubQ.Oldest
	  AS JobRank
	FROM TravelCards
	   AS tc
LEFT JOIN (
				SELECT  c.Id
					   , FirstName
	 				   , LastName
					   ,ROW_NUMBER() OVER (PARTITION BY tc.JobDuringJourney ORDER BY BirthDate)
					AS Oldest
					   ,JobDuringJourney
				  FROM Colonists
				    AS c
			RIGHT JOIN TravelCards
					AS tc
					ON tc.ColonistId = c.Id
				 
		  )
	   AS SubQ
	   ON SubQ.Id = tc.ColonistId
    WHERE SubQ.Oldest = 2

--11
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
	RETURNS INT
			 AS
			 BEGIN
					DECLARE @enhabitants INT;
					SELECT @enhabitants = COUNT(c.Id)
							FROM Colonists
							AS c
					INNER JOIN TravelCards
							AS tc
							ON tc.ColonistId = c.Id
					INNER JOIN Journeys
							AS j
							ON j.Id = tc.JourneyId
					INNER JOIN Spaceports
							AS sp
							ON sp.Id = j.DestinationSpaceportId
					INNER JOIN Planets
							AS p
							ON p.Id = sp.PlanetId
							WHERE p.Name = @PlanetName
				 
		 RETURN @enhabitants
		 END

--12
CREATE OR ALTER PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
		 AS
		 BEGIN
		 BEGIN TRY
				IF NOT EXISTS(SELECT Id FROM Journeys WHERE Id = @JourneyId)
				THROW 50000,'The journey does not exist!',1

				IF @NewPurpose = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)
				THROW 50000, 'You cannot change the purpose!', 1

				UPDATE Journeys
				   SET Purpose = @NewPurpose
				 WHERE Id = @JourneyId
					
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
		END CATCH
		END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'

EXEC usp_ChangeJourneyPurpose 4, 'Educational'