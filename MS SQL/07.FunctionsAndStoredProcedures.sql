USE SoftUni

--01
CREATE PROC usp_GetEmployeesSalaryAbove35000
         AS (
		   SELECT 
		          FirstName
			   AS [First Name]
				  ,LastName
			   AS [Last Name]
		     FROM Employees
		    WHERE Salary > 35000
			)
--02
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @number DECIMAL(18,4)
			  AS (
				 SELECT
						FirstName
						,LastName
				   FROM Employees
				  WHERE Salary >= @number
				 )

--03
CREATE PROC usp_GetTownsStartingWith @startsWith VARCHAR(50)
         AS (
				SELECT Name
				  FROM Towns
				 WHERE (LOWER(Name) LIKE CONCAT(@startsWith, '%'))
			)

--04
CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(50)
		AS (
				SELECT 
				       FirstName
					   ,LastName
				  FROM Employees
				    AS e
			INNER JOIN Addresses
			        AS a
					ON e.AddressID = a.AddressID
			INNER JOIN Towns
			        AS t
					ON t.TownID = a.TownID
				 WHERE t.Name = @townName
		   )

--05
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
			 AS
		  BEGIN
				DECLARE @salaryLevel VARCHAR(8)
				IF @salary < 30000
				BEGIN
				   SET @salaryLevel = 'Low'
				END
				ELSE IF @salary BETWEEN 30000 AND 50000
				BEGIN
				   SET @salaryLevel = 'Average'
				END
				ELSE IF @salary > 50000
				BEGIN
				   SET @salaryLevel = 'High'
				END --Can do without the Beginnings and Ends
		RETURN @salaryLevel
		END

--06
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(8))
		 AS (
				SELECT FirstName
					   ,LastName
				  FROM Employees
				 WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
			)

--07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
    RETURNS BIT
			 AS 
			 BEGIN
					DECLARE @wordINDEX INT = 1;
					WHILE(@wordINDEX <= LEN(@word))
					BEGIN
							DECLARE @currentChar CHAR = SUBSTRING(@word, @wordIndex, 1)
							IF CHARINDEX(@currentChar,@setOfLetters) = 0
							BEGIN
									RETURN 0;
							END
							SET @wordINDEX += 1;
					  END
					RETURN 1;
			   END

--08
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
		 AS 
		 BEGIN
				DECLARE @employeesToDelete TABLE (ID INT);
				
				INSERT INTO @employeesToDelete
					 SELECT EmployeeID
					   FROM Employees
					  WHERE DepartmentID = @departmentId

				DELETE
				  FROM EmployeesProjects
				 WHERE EmployeeID IN (SELECT * FROM @employeesToDelete)

				 ALTER TABLE Departments
				ALTER COLUMN ManagerID INT

				UPDATE Departments
				   SET ManagerID = NULL
				 WHERE ManagerID IN (SELECT * FROM @employeesToDelete)

				UPDATE Employees
				   SET ManagerID = NULL
				 WHERE ManagerID IN (SELECT * FROM @employeesToDelete)

				DELETE
				  FROM Employees
				 WHERE DepartmentID = @departmentId

				DELETE
				  FROM Departments
				 WHERE DepartmentID = @departmentId

				SELECT COUNT(*)
				  FROM Employees
				 WHERE DepartmentID = @departmentId
		 END

--09
USE Bank

CREATE PROC usp_GetHoldersFullName
		 AS
				SELECT CONCAT(FirstName, ' ', LastName)
					AS [Full Name]
				  FROM AccountHolders

--10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18,4))
			  AS
					SELECT
							FirstName
							,LastName
					  FROM AccountHolders
					    AS ah
				INNER JOIN Accounts
						AS a
						ON a.AccountHolderId = ah.Id
				  GROUP BY ah.FirstName, ah.LastName
					 HAVING SUM(a.Balance) > @number
				  ORDER BY ah.FirstName, ah.LastName

--11
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
			AS
			BEGIN
					RETURN ROUND(@sum * POWER(1 + @yearlyInterestRate, @numberOfYears), 4)
			END

--12
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount(@Id INT, @yearlyInterestRate FLOAT)
		 AS 
			SELECT
				   a.Id
				AS [Account Id]
				   ,ah.FirstName
				   ,ah.LastName
				   ,a.Balance
				AS [Current Balance]
				   ,dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5)
				AS [Balance in 5 years]
			  FROM AccountHolders
			    AS ah
		INNER JOIN Accounts
				AS a
				ON a.AccountHolderId = ah.Id
			 WHERE a.Id = @Id

--13
USE Diablo

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS  TABLE
			AS
			RETURN SELECT 
							SUM(Cash)
						AS SumCash
					  FROM (
								SELECT
										ug.Cash
										,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC)
										AS RowNumber
								  FROM UsersGames
								    AS ug
							INNER JOIN Games
									AS g
									ON g.Id = ug.GameId
								 WHERE g.Name = @gameName
							) AS subq
					 WHERE RowNumber % 2 = 1
			
