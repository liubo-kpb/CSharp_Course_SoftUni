-- 01
CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY(101,1),
	PassportNumber VARCHAR(8)
)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE -- Judge ���� � ��� UNIQUE :D. �������� �� :D
)


INSERT INTO Passports(PassportNumber)
VALUES
	('N34FG21B')
	,('K65LO4R7')
	,('ZE657QP2')

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES
	 ('Roberto', 43300.00, 102)
	,('Tom', 56100.00, 103)
	,('Yana', 60200.00, 101)

--02
CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
	EstablishedOn DATE NOT NULL,
)

CREATE TABLE Models (
	ModelID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(Name, EstablishedOn)
VALUES
			('BMW', '07/03/1916'),
			('Tesla', '01/01/2003'),
			('Lada', '01/05/1966')

INSERT INTO Models(Name, ManufacturerID)
VALUES
			 ('X1', 1)
			,('i6', 1)
			,('Mdel S', 2)
			,('Model X', 2)
			,('Model 3', 2)
			,('Nova', 3)


--03
CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY (101, 1),
	Name VARCHAR(20) NOT NULL,
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
)

CREATE TABLE StudentsExams (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students (Name)
VALUES
		('Mila')
		,('Toni')
		,('Ron')

INSERT INTO Exams (Name)
VALUES
		('SpringMVC')
		,('Neo4j')
		,('Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
		(1, 101)
		,(1, 102)
		,(2, 101)
		,(3, 103)
		,(2, 102)
		,(2, 103)

--04
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY (101, 1),
	Name VARCHAR(20) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(Name, ManagerID)
VALUES
		('John', NULL)
		,('Maya', 106)
		,('Silvia', 106)
		,('Ted', 105)
		,('Mark', 101)
		,('Greta', 101)

--05
CREATE DATABASE New1
USE New1

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20),
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	PRIMARY KEY (OrderID, ItemID)
)

--06
CREATE DATABASE New2
Use New2

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(20) NOT NULL,
)

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(20) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL (8,2),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
	PRIMARY KEY (StudentID, SubjectID)
)

--09
USE Geography

   SELECT m.MountainRange,
          p.PeakName,
		  p.Elevation
     FROM Peaks
       AS [p]
LEFT JOIN [Mountains]
       AS [m]
	   ON [p].MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
 ORDER BY p.Elevation DESC