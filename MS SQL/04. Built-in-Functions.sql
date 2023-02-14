--01
SELECT FirstName
       ,LastName
  FROM Employees
 WHERE LEFT(FirstName,2) = 'Sa'

 --02
 SELECT FirstName
       ,LastName
  FROM Employees
 WHERE LastName LIKE '%ei%'

 --03
 SELECT FirstName
   FROM Employees
  WHERE DepartmentID IN (3,10)
    AND YEAR(HireDate) BETWEEN 1995 AND 2005

--04
SELECT FirstName
	   ,LastName
  FROM Employees
 WHERE CHARINDEX('engineer', JobTitle) = 0

 --05
  SELECT Name
    FROM Towns
   WHERE LEN(Name) IN (5,6)
ORDER BY Name

--06
  SELECT TownID, Name
    FROM Towns
   WHERE Left(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name

--07
  SELECT TownID, Name
    FROM Towns
   WHERE Name NOT LIKE ('[RBD]%')
ORDER BY Name

--08
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName
       ,LastName
  FROM Employees
 WHERE YEAR(HireDate) > 2000

 --09
SELECT FirstName
       ,LastName
  FROM Employees
 WHERE LEN(LastName) = 5

--10
  SELECT EmployeeID
         ,FirstName
  	   ,LastName
  	   ,Salary
  	   ,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID)
  	   AS [RANK]
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11
SELECT *
  FROM (
    SELECT EmployeeID
         ,FirstName
  	   ,LastName
  	   ,Salary
  	   ,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID)
  	   AS [RANK]
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
  ) AS Ranked
WHERE Rank = 2
ORDER BY Salary DESC

--12
Use Geography

  SELECT CountryName
         ,IsoCode
    FROM Countries
   WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode

--13
   SELECT p.PeakName
          ,r.RiverName
   	      ,CONCAT(SUBSTRING(LOWER(p.PeakName), 1, LEN(p.PeakName) - 1), LOWER(r.Rivername))
   	   AS Mix
     FROM Peaks
       AS p,
   	      Rivers
       AS r
   WHERE RIGHT(LOWER(p.PeakName),1 ) = LEFT(LOWER(r.RiverName),1)
ORDER BY Mix

--14
SELECT TOP (50) Name
           ,FORMAT(Start, 'yyyy-MM-dd')
      FROM Games
	  WHERE YEAR(Start) BETWEEN 2011 AND 2012
   ORDER BY FORMAT(Start, 'yyyy-MM-dd'), Name

--15
use Diablo

  SELECT Username
         ,SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', email))
      AS EmailProvider
    FROM Users
ORDER BY EmailProvider, Username

--16
  SELECT Username
         ,[IpAddress]
    FROM Users
   WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY Username

--17
  SELECT [Name]
      AS Game,
         CASE 
			WHEN DATEPART(HOUR, Start) >= 0 AND DATEPART(HOUR, Start) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR, Start) >= 12 AND DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
			ELSE 'Evening'
		 END
	  AS [Part of the Day],
	     CASE
		    WHEN Duration <= 3 THEN 'Extra Short'
			WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
			WHEN Duration > 6 THEN 'Long'
			ELSE 'Extra Long'
		 END
	  AS Duration
    FROM Games
	  AS [g]
ORDER BY [Game]
         ,[Duration]
		 ,[Part of the Day]

--18
USE Orders

SELECT ProductName
       ,OrderDate
	   ,DATEADD(DAY, 3, OrderDate) AS [Pay Due]
	   ,DATEADD(MONTH, 1, OrderDate) AS [DeliveryDue]
  FROM Orders

--19
Use SoftUni

CREATE TABLE People(
	ID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	Birthdate DATETIME NOT NULL
)
GO

INSERT INTO People ([Name], Birthdate)
VALUES
	('Victor','2000-12-07 00:00:00.000')
	,('Steven','1992-09-10 00:00:00.000')
	,('Stephen','1910-09-19 00:00:00.000')
	,('John','2010-01-06 00:00:00.000')

SELECT [Name]
       ,DATEDIFF(HOUR,Birthdate,GETDATE()) / 8766 AS [Age in Years]
	   ,DATEDIFF(HOUR,Birthdate,GETDATE()) / 730 AS [Age in Months]
	   ,DATEDIFF(HOUR,Birthdate,GETDATE()) / 24 AS [Age in Days]
	   ,DATEDIFF(HOUR,Birthdate,GETDATE()) * 60 AS [Age in Minutes]
  FROM People