--02
Select * FROM Departments

--03
Select Name FROM Departments

--04
Select FirstName, LastName, Salary FROM Employees

--05
Select FirstName, MiddleName, LastName FROM Employees

--06
SELECT CONCAT(FirstName,'.',LastName,'@softuni.bg')
FROM Employees

--07
SELECT DISTINCT Salary FROM Employees

--08
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--09
SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--10
SELECT CONCAT (FirstName, ' ', MiddleName, ' ', LastName) FROM Employees
WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

--11
SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

--12
SELECT FirstName, LastName, Salary FROM Employees 
WHERE Salary > 50000
ORDER BY Salary DESC

--13
SELECT TOP 5  FirstName, LastName FROM Employees
ORDER BY Salary DESC

--14
SELECT FirstName, LastName FROM Employees
WHERE DepartmentID <> 4

--15
SELECT * FROM Employees
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName

--16
CREATE VIEW V_EmployeesSalaries AS
SELECT  FirstName, LastName, Salary FROM Employees

SELECT * FROM V_EmployeesSalaries

--17
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName, ''), ' ', LastName) AS FullName, JobTitle FROM Employees

--18
SELECT DISTINCT JobTitle FROM Employees

--19
SELECT TOP 10 * FROM Projects
ORDER BY StartDate, Name

--20
SELECT TOP 7 FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC

--21
SELECT * FROM Departments

UPDATE Employees
SET Salary += 0.12 * Salary
WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary FROM Employees

--22
SELECT PeakName FROM Peaks
ORDER BY PeakName

--23
SELECT TOP 30 CountryName, Population FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC

SELECT * FROM Continents

--24
SELECT CountryName, CountryCode, CASE CurrencyCode
									WHEN 'EUR' THEN 'Euro'
									ELSE 'Not Euro' END AS Currency
								FROM Countries
ORDER BY CountryName

--25
SELECT Name FROM Characters
ORDER BY Name