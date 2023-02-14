--01.
create database Minions

--02.
create table Minions (
	Id int NOT Null
	,[Name] nvarchar(50)
	,Age int
	,TownId int
);

Alter table Minions
Add Primary Key (Id);

create table Towns (
	Id int Not null Primary Key
	,[Name] nvarchar(50)
);

--03.
ALTER TABLE Minions
ADD CONSTRAINT FK_TownId
FOREIGN KEY (TownId) REFERENCES Towns(Id);

ALTER Table Minions
ALTER COLUMN TownId int;

--04.
Insert Towns (Id, [Name])
Values 
	(1, 'Sofia')
	,(2, 'Plovdiv')
	,(3, 'Varna')

Insert Minions(Id, [Name], Age, TownId)
Values
	(1, 'Kevin', 22, 1)
	,(2, 'Bob', 15, 3)
	,(3, 'Steward', Null, 2);

--05
Delete From Minions

Select Id, [Name], Age, TownId
From Minions

--06
Drop Table dbo.Minions
Drop Table dbo.Towns
;

--07
Create Table People (
	Id int NOT Null PRIMARY Key IDENTITY,
	[Name] nvarchar(200) Not Null,
	Picture VARBINARY(MAX), -- limit to 2000000
	Height float(2),
	[Weight] float(2),
	Gender char(1) CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATE Not Null,
	Biography nvarchar(MAX)
);

Insert People ([Name], Gender, Birthdate)
Values
	('Pesho', 'm', '1996-04-05')
	,('Gosho', 'm', '1996-04-29')
	,('Lily', 'f', '1997-07-31')
	,('Maria', 'f', '2001-08-26')
	,('Emo', 'm', '1004-02-28')

Select * from Users

--08.
Create Table Users(
	Id BIGINT Primary Key IDENTITY,
	Username varchar(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
);
Go

Insert Users (Username, [Password])
Values
	('Pesho', 'lkhbasd')
	,('Gosho', '98h12en')
	,('Lily', '98h12n')
	,('Maria', '981n2')
	,('Emo', 'ubasd1')

--09.
ALTER TABLE USERS
DROP PK__Users__3214EC07EEDF36A1;

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)

--10.
ALTER TABLE Users
ADD CONSTRAINT [PasswordLength] CHECK (DATALENGTH(Password) >= 5)

--11
UPDATE Users
Set LastLoginTime = NULL

--12
ALTER TABLE Users
DROP PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id);

ALTER TABLE Users
ADD CONSTRAINT [UsernameLength] CHECK (DATALENGTH(Username) >= 3)

--13
CREATE DATABASE Movies

CREATE TABLE Directors(
	Id int Primary KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
	Id int Primary KEY IDENTITY,
	GenreNames NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Categories(
	Id int Primary KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Movies(
	Id int Primary KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId int NOT NULL FOREIGN Key REFERENCES Directors(Id),
	CopyrightYear DATE NOT NULL,
	Length int NOT NULL, --minutes
	GenreID int NOT NULL FOREIGN KEY REFERENCES Genres(Id),
	CategoryID int NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	Rating FLOAT(2),
	Notes NVARCHAR(MAX)
);

INSERT Directors (DirectorName)
Values
	('James Cameron')
	,('Steven Spielberg')
	,('George Lucas')
	,('Clint Eastwood')
	,('Christopher Nolan')

INSERT Genres (GenreNames)
VALUES
	('Romance')
	,('Comedy')
	,('Action')
	,('Sci Fi')
	,('Fantasy')

INSERT Categories (CategoryName)
VALUES
	('Reality')
	,('TV Show')
	,('Motion Picture')
	,('Documentary')
	,('Adventure')

INSERT Movies (Title, DirectorId, CopyrightYear, Length, GenreID, CategoryID)
VALUES
	('Avatar', 1, '2023-01-15', 150, 4, 3)
	,('Openheimer', 5, '2023-07-21', 150, 3, 4)
	,('Star Wars', 3, '2005-05-25', 138, 4, 3)
	,('A Westside Story', 2, '2023-01-15', 160, 1, 3)
	,('Untitled Movie', 4, '2023-05-26', 123, 2, 1)

Select * FROM Movies

--14
CREATE DATABASE CarRental

CREATE TABLE Categories(
	Id int Primary KEY IDENTITY,
	CategoryName NVARCHAR(50),
	DailyRate DECIMAL NOT NULL,
	WeeklyRate DECIMAL,
	MonthlyRate DECIMAL NOT NULL,
	WeekendRate DECIMAL NOT NULL
);

CREATE TABLE Cars(
	Id int Primary KEY IDENTITY,
	PlateNumber CHAR(10) NOT NULL CHECK (DATALENGTH(PlateNumber) = 10),
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId int FOREIGN KEY REFERENCES Categories(Id),
	Doors int CHECK (Doors >= 2 OR Doors <=5) NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(4) CHECK (Condition = 'good' OR Condition = 'bad') NOT NULL,
	Available BIT NOT NULL
);

CREATE TABLE Employees(
	Id int Primary KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Customers(
	Id int Primary KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	Address NVARCHAR(150),
	City NVARCHAR(20),
	ZIPCode INT,
	Notes NVARCHAR(MAX)
);

CREATE TABLE RentalOrders(
	Id int Primary KEY IDENTITY,
	EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(Id),
	CustomerId int NOT NULL FOREIGN KEY REFERENCES Customers(Id),
	CarId int NOT NULL FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(day, StartDate, EndDate),
	RateApplied NVARCHAR(20) NOT NULL CHECK (RateApplied = 'Daily rate' OR RateApplied = 'Weekly rate' OR RateApplied = 'Monthly rate' OR RateApplied = 'Weekend rate'),
	TaxRate DECIMAL,
	OrderStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT Categories
VALUES
	('Sedan', 50, 320, 1500, 180)
	,('Truck', 80, 540, 2580, 230)
	,('SUV', 65, 400, 2000, 225)

INSERT Cars
VALUES
	('BP 9282 CR', 'Mercedes-Benz', 'S Class', '2018-07-26', 1, 4, null, 'good', 1)
	,('BP 9852 ML', 'BMW', 'M7', '2017-08-26', 1, 5, null, 'good', 0)
	,('CR 1358 BP', 'Opel', 'Corsa', '2005-07-26', 1, 2, null, 'good', 1)

INSERT Employees
VALUES
	('Dave', 'Mongomary', 'Sales Representative', null)
	,('Steve', 'Max', 'Sr. Sales Representative', null)
	,('Clint', 'Goodman', 'Manager Representative', null)

INSERT Customers
VALUES
	(4567891, 'Carl Buyers', null, null, null, null)
	,(9784615, 'Mark Twain', null, null, null, null)
	,(56719, 'Tod Gear', null, null, null, null)

INSERT RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, RateApplied, TaxRate, OrderStatus)
VALUES
	(3, 2, 1, 100, 12000, 15000, 300000, '2023-01-15', '2023-01-25', 'Daily rate', 0.2, 1)
	,(1, 2, 2, 70, 1500, 7500, 300000, '2023-02-23', '2023-03-02', 'Daily rate', 0.2, 1)
	,(3, 3, 3, 100, 25000, 27000, 300000, '2023-01-25', '2023-01-27', 'Weekend rate', 0.2, 1)


--15
CREATE DATABASE Hotel

CREATE TABLE Employees(
	Id int Primary KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Customers(
	AccountNumber INT Primary KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber INT,
	EmergencyName NVARCHAR(50),
	EmergencyNumber INT,
	Notes NVARCHAR(MAX)
);

CREATE TABLE RoomStatus(
	RoomStatus Bit NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
);

CREATE TABLE RoomTypes(
	RoomType INT PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
);

CREATE TABLE BedTypes(
	BedType INT PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY IDENTITY(101,1),
	RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType INT FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL,
	RoomStatus BIT,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Payments(
	Id int Primary KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(day, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL NOT NULL,
	TaxRate DECIMAL NOT NULL,
	TaxAmount DECIMAL NOT NULL,
	PaymentTotal DECIMAL NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Occupancies(
	Id int Primary KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE,
	AccountNumber INT,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied NVARCHAR(30),
	PhoneCharge DECIMAL,
	Notes NVARCHAR(MAX)
);

INSERT Employees
VALUES
	('Dave', 'Mongomary', 'Host', null)
	,('Steve', 'Max', 'Sr. Host', null)
	,('Clint', 'Goodman', 'VP Host', null)

INSERT Customers
VALUES
	('Carl', 'Buyers', 3651, null, null, null)
	,('David', 'Renner', 3652, null, null, null)
	,('Ben', 'Solo', 3653, null, null, null)

INSERT RoomStatus
VALUES
	(1, 'busy')
	,(0, 'vacant')
	,(0, 'vacant')

INSERT RoomTypes
VALUES
	 (1, 'big')
	,(2, 'medium')
	,(3, 'small')

INSERT BedTypes
VALUES
	 (1, 'big')
	,(2, 'medium')
	,(3, 'small')

INSERT Rooms
VALUES
	(1, 2, 32, 0, null)
	,(2, 1, 38, 0, null)
	,(3, 2, 22, 0, null)

INSERT Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
	(1, '2023-05-15', 123, '2023-01-16', '2023-01-22', 0, 20, 0.2, 500, null)
	,(2, '2023-03-12', 123, '2023-03-07', '2023-03-12', 0, 50, 0.2, 550, null)
	,(3, '2023-04-08', 123, '2023-04-03', '2023-04-23', 0, 35, 0.2, 520, null)

INSERT Occupancies
VALUES
	(1, '2023-01-16', 123, 101, 0.2, 0.35, 'order 1')
	,(3, '2023-03-07', 123, 101, 0.2, 0.35, 'order 2')
	,(2, '2023-04-03', 123, 101, 0.2, 0.35, 'order 3')

--16
CREATE DATABASE SoftUni

CREATE TABLE Towns (
	Id int Primary Key IDENTITY
	,[Name] nvarchar(50)
);

CREATE TABLE Addresses(
	Id int Primary Key IDENTITY,
	AddressText NVARCHAR(MAX),
	TownId INT FOREIGN KEY REFERENCES Towns(Id),
);

CREATE TABLE Departments(
	Id INT Primary Key IDENTITY,
	Names NVARCHAR(50)
);

CREATE TABLE Employees(
	Id INT Primary KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
);

--17
DROP DATABASE SoftUni --Did with GUI

--18
Insert Towns ([Name])
Values 
	('Sofia')
	,('Plovdiv')
	,('Varna')
	,('Burgas')

INSERT Departments
VALUES
	('Engineering')
	,('Sales')
	,('Marketing')
	,('Software Development')
	,('Quality Assurance')

INSERT Employees
VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, null)
	,('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, null)
	,('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, null)
	,('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, null)
	,('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, null)

UPDATE Employees
Set Salary = 599.88
Where LastName = 'Pan'

--19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20
SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

--21
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--22
UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

--23
UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate From Payments

--24
TRUNCATE TABLE Occupancies

Select * FROM Occupancies