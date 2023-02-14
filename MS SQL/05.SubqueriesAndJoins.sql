USE SoftUni;

--01
SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText FROM Employees AS e
JOIN Addresses as a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--02
SELECT TOP 50 e.FirstName, e.LastName, t.Name, a.AddressText FROM Employees AS e
LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--03
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--04
   SELECT 
	TOP 5	e.EmployeeID
			,e.FirstName
			,e.Salary
			,d.Name
     FROM	Employees
	   AS	e
LEFT JOIN	Departments
		AS	d
		ON	e.DepartmentID = d.DepartmentID
	 WHERE	e.Salary > 15000
  ORDER BY	e.DepartmentID

--05
   SELECT
    TOP 3 e.EmployeeID
          ,e.FirstName
     FROM Employees
	   AS e
LEFT JOIN EmployeesProjects
       AS ep
	   ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects
        AS p
	   ON ep.ProjectID = p.ProjectID
    WHERE ep.EmployeeID IS NULL AND ep.ProjectID IS NULL

 --06
    SELECT
           e.FirstName
          ,e.LastName
		  ,e.HireDate
		  ,d.Name AS DepartmentName
     FROM Employees
	   AS e
LEFT JOIN Departments AS d
	   ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-01-01'
	  AND d.Name IN ('Sales', 'Finance')
 ORDER BY e.HireDate

--07
   SELECT
    TOP 5 e.EmployeeID
          ,e.FirstName
		  ,p.Name AS ProjectName
     FROM Employees
	   AS e
LEFT JOIN EmployeesProjects
       AS ep
	   ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects
        AS p
	   ON ep.ProjectID = p.ProjectID
	WHERE ep.EmployeeID IS NOT NULL
	  AND p.StartDate > '20020813'
	  AND p.EndDate IS NULL
 ORDER BY e.EmployeeID

--Better solution
SELECT
    TOP 5 e.EmployeeID
          ,e.FirstName
		  ,p.Name AS ProjectName
     FROM EmployeesProjects
	   AS ep
INNER JOIN Employees
       AS e
	   ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects
        AS p
		ON ep.ProjectID = p.ProjectID
     WHERE p.StartDate > '20020813'
	   AND p.EndDate IS NULL
  ORDER BY e.EmployeeID

--08
   SELECT
           e.EmployeeID
          ,e.FirstName
		  --,p.Name AS ProjectName
		  ,CASE 
		       WHEN p.StartDate < '2005' THEN p.Name
			   ELSE NULL
		    END AS ProjectName
     FROM EmployeesProjects
	   AS ep
INNER JOIN Employees
       AS e
	   ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects
        AS p
		ON ep.ProjectID = p.ProjectID
     WHERE e.EmployeeID = 24

--09
   SELECT 
		  e.EmployeeID
		  ,e.FirstName
		  ,e.ManagerID AS ManagerID
		  ,m.FirstName AS ManagerName
     FROM Employees
       AS e
LEFT JOIN Employees
       AS m
	   ON e.ManagerID = m.EmployeeID
	WHERE e.ManagerID IN (3, 7)
 ORDER BY e.EmployeeID

--10
   SELECT 
   TOP 50 e.EmployeeID
		  ,CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName
		  ,CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName
		  ,d.Name AS DepartmentName
     FROM Employees
       AS e
LEFT JOIN Employees
       AS m
	   ON e.ManagerID = m.EmployeeID
LEFT JOIN Departments
       AS d
	   ON e.DepartmentID = d.DepartmentID
 ORDER BY e.EmployeeID

--11
SELECT Min(a.AverageSalary) FROM (
	SELECT AVG(SALARY) AS AverageSalary FROM Employees AS e
	GROUP BY DepartmentID
) AS a

--12
USE Geography

    SELECT 
           c.CountryCode
           ,m.MountainRange
		   ,p.PeakName
		   ,p.Elevation
      FROM MountainsCountries
        AS mc
INNER JOIN Countries
        AS c
	    ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains
        AS m
		ON mc.MountainId = m.Id
 LEFT JOIN Peaks
        AS p
		ON m.Id = p.MountainId
	 WHERE c.CountryName = 'Bulgaria'
	   AND p.Elevation > 2835
  ORDER BY p.Elevation DESC

--13
    SELECT 
           c.CountryCode
           ,COUNT(mc.MountainID) AS MountainRanges
	  FROM MountainsCountries
	    AS mc
INNER JOIN Countries
        AS c
		ON c.CountryCode = mc.CountryCode
	 WHERE c.CountryCode IN ('BG', 'RU', 'US')
  GROUP BY c.CountryCode

--14
   SELECT
	TOP 5 c.CountryName
          ,r.RiverName
	 FROM Countries
	   AS c
LEFT JOIN CountriesRivers
       AS cr
	   ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers
       AS r
	   ON r.Id = cr.RiverId
LEFT JOIN Continents
	   AS cnts
	   ON c.ContinentCode = cnts.ContinentCode
	WHERE cnts.ContinentName = 'Africa'
 ORDER BY c.CountryName

--15
SELECT ContinentCode
       ,CurrencyCode
	   ,CurrencyUsage
  FROM(
		SELECT *
			   ,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC)
			AS CurrencyRank
		  FROM (
				SELECT 
					   ContinentCode
					   ,CurrencyCode
					   ,COUNT(*) AS CurrencyUsage
				  FROM Countries
			  GROUP BY ContinentCode, CurrencyCode
				HAVING COUNT(*) > 1
				  ) AS subC
		  ) AS subDR
WHERE subDR.CurrencyRank = 1

--16
    SELECT
           COUNT(c.CountryCode)
		AS Count
      FROM Countries
        AS c
LEFT OUTER JOIN MountainsCountries
        AS mc
		ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL

--17
SELECT 
 TOP 5 HighestPeak.CountryName
       ,HighestPeak.HighestPeakElevation
	   ,LongestRiver.LongestRiverLength
      FROM (
		 	 SELECT 
		 		    c.CountryName
		 		    ,MAX(p.Elevation) AS HighestPeakElevation
		 	     FROM Countries
		 		   AS c
		   LEFT JOIN MountainsCountries
		 		   AS mc
				   ON c.CountryCode = mc.CountryCode
		   LEFT JOIN Mountains
		 		   AS m
				   ON m.Id = mc.MountainId
		   LEFT JOIN Peaks
		 		   AS p
				   ON p.MountainId = m.Id
		     GROUP BY c.CountryName
      ) AS HighestPeak
INNER JOIN (
				SELECT
					   c.CountryName
					   ,MAX(r.Length) AS LongestRiverLength
				  FROM Countries
					AS c
			 LEFT JOIN CountriesRivers
					AS cr
			        ON c.CountryCode = cr.CountryCode
		  	 LEFT JOIN Rivers
					AS r
					ON r.Id = cr.RiverId
			 GROUP BY c.CountryName
	  ) AS LongestRiver
	  ON HighestPeak.CountryName = LongestRiver.CountryName
ORDER BY HighestPeak.HighestPeakElevation DESC, LongestRiver.LongestRiverLength DESC, HighestPeak.CountryName

--Better Organized Solution
   SELECT 
    TOP 5 c.CountryName
	      ,MAX(p.Elevation) AS HighestPeakElevation
		  ,MAX(r.Length) AS LongestRiverLength
     FROM Countries
       AS c
LEFT JOIN MountainsCountries
       AS mc
	   ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains
       AS m
	   ON m.Id = mc.MountainId
LEFT JOIN Peaks
       AS p
	   ON p.MountainId = m.Id
LEFT JOIN CountriesRivers
       AS cr
	   ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers
       AS r
	   ON r.Id = cr.RiverId
 GROUP BY c.CountryName
 ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName

--18
  SELECT   
   TOP 5 subQ.CountryName    AS Country
	     ,CASE
		      WHEN PeakName IS NULL THEN '(no highest peak)' 
			  ELSE PeakName
			END
	  AS HighestPeakName
	     ,CASE
		      WHEN Elevation IS NULL THEN 0
			  ELSE Elevation
		   END 
	  AS HighestPeakElevation
	     ,CASE
		      WHEN MountainRange IS NULL THEN '(no mountain)'
			  ELSE MountainRange
		   END 
	  AS Mountain
    FROM (
			   SELECT 
					  c.CountryName
					  ,p.PeakName
					  ,p.Elevation
					  ,m.MountainRange
					  ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC)
				   AS PeakRank
				 FROM Countries
				   AS c
			LEFT JOIN MountainsCountries
				   AS mc
				   ON mc.CountryCode = c.CountryCode
			LEFT JOIN Mountains
				   AS m
				   ON m.Id = mc.MountainId
			LEFT JOIN Peaks
				   AS p
				   ON p.MountainId = m.Id
    ) AS subQ
   WHERE subQ.PeakRank = 1
ORDER BY subQ.CountryName, HighestPeakName