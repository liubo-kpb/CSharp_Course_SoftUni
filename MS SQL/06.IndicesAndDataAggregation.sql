USE Gringotts
Select * FROM WizzardDeposits

--01
SELECT COUNT(*)
  FROM WizzardDeposits

--02
SELECT MAX(MagicWandSize)
    AS LongestMagicWand
  FROM WizzardDeposits

--03
  SELECT 
          DepositGroup
         ,MAX(MagicWandSize)
      AS LongestMagicWand
    FROM WizzardDeposits
GROUP BY DepositGroup

--04
SELECT
 TOP 2 subq.DepositGroup
  FROM (
			SELECT
			  DepositGroup
			       ,AVG(MagicWandSize)
				AS AvGWandSize
			  FROM WizzardDeposits
		  GROUP BY DepositGroup
       )
	AS subq
		  ORDER BY subq.AvGWandSize

--05
  SELECT DepositGroup
         ,SUM(DepositAmount)
    FROM WizzardDeposits
GROUP BY DepositGroup

--06
  SELECT DepositGroup
         ,SUM(DepositAmount)
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--07
  SELECT DepositGroup
         ,SUM(DepositAmount)
	  AS TotalDepositAmount
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
ORDER BY TotalDepositAmount DESC

--08
  SELECT 
         DepositGroup
         ,MagicWandCreator
		 ,MIN(DepositCharge)
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--09
    SELECT
           ag.AgeGroup
	       ,COUNT(ag.AgeGroup)
	  FROM (
        SELECT  
				 CASE 
					 WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
					 WHEN Age > 10 AND Age <= 20 THEN '[11-20]'
					 WHEN Age > 20 AND Age <= 30 THEN '[21-30]'
					 WHEN Age > 30 AND Age <= 40 THEN '[31-40]'
					 WHEN Age > 40 AND Age <= 50 THEN '[41-50]'
					 WHEN Age > 50 AND Age <= 60 THEN '[51-60]'
					 WHEN Age > 60 THEN '[61+]'
				  END
		   AS AgeGroup
		 FROM WizzardDeposits
          )
	  AS ag
GROUP BY ag.AgeGroup

--10
  SELECT 
		  subq.FirstLetter
    FROM (
			  SELECT 
					 SUBSTRING(FirstName,1,1)
				  AS FirstLetter
				FROM WizzardDeposits
			   WHERE DepositGroup = 'Troll Chest'
         )
      AS subq
GROUP BY subq.FirstLetter
ORDER BY subq.FirstLetter

--11
  SELECT 
		 DepositGroup
		 ,IsDepositExpired
		 ,AVG(DepositInterest)
	  AS AverageInterest
	FROM WizzardDeposits
   WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--12
SELECT SUM(subq.Difference)
  FROM (
		  SELECT FirstName
			  AS [Host Wizzard]
				 ,DepositAmount
			  AS [Host Wizzard Deposit]
				 ,LEAD(FirstName) OVER (ORDER BY Id)
			  AS [Guest Wizzard]
				 ,LEAD(DepositAmount) OVER (ORDER BY Id)
			  AS [Guest Wizzard Deposit]
				 ,DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id)
			  AS Difference
			FROM WizzardDeposits
	  ) subq

--13
USE SoftUni

  SELECT
         DepartmentID
		 ,SUM(Salary)
    FROM Employees
GROUP BY DepartmentID

--14
  SELECT DepartmentID
         ,MIN(Salary)
	  AS MinimumSalary
    FROM Employees
   WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

--15
SELECT *
  INTO EmployeesWithSalaryOver30000
  FROM Employees
 WHERE Salary > 30000

DELETE
  FROM EmployeesWithSalaryOver30000
 WHERE ManagerID = 42

UPDATE EmployeesWithSalaryOver30000
   SET Salary += 5000
 WHERE DepartmentID = 1

  SELECT 
	     DepartmentID
	     ,AVG(Salary)
	  AS AverageSalary
    FROM EmployeesWithSalaryOver30000
GROUP BY DepartmentID

--16
  SELECT   DepartmentID
         ,MAX(Salary)
    FROM Employees
GROUP BY DepartmentID
  HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

--17
SELECT COUNT(*)
 FROM Employees
WHERE ManagerID IS NULL

--18
  SELECT 
DISTINCT DepartmentID
		 ,Salary
	  AS ThirdHighestSalary
    FROM (
			SELECT DepartmentID
				   ,Salary
				   ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC)
				AS SalaryRank
			  FROM Employees
	     )
	  AS subq
   WHERE SalaryRank = 3

--19
    SELECT
    TOP 10  FirstName
	       ,LastName
	       ,e.DepartmentID
      FROM Employees
        AS e
INNER JOIN
		(
			SELECT 
				   DepartmentID
				   ,AVG(Salary)
				AS AverageDepartmentSalary
			  FROM Employees
		  GROUP BY DepartmentID
       )
	AS subq
	ON e.DepartmentID = subq.DepartmentID
 WHERE e.Salary > subq.AverageDepartmentSalary