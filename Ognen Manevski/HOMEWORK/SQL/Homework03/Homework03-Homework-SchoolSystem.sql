
----------------------    Homework 03   --------------------

--USE [SEDCHome]
--GO
---- Delete Data from tables
--------------------
--delete from [dbo].[GradeDetails] where 1=1;
--delete from [dbo].[Grade] where 1=1;
--delete from [dbo].[AchievementType] where 1=1;
--delete from [dbo].[Course] where 1=1;
--delete from [dbo].[Student] where 1=1;
--delete from [dbo].[Teacher] where 1=1;
--GO
---- After running DBCC CHECKIDENT('TableName', RESEED, 0):
---- Newly created tables will start with identity 0
---- Existing tables will continue with identity 1
--------------------
--DBCC CHECKIDENT ('GradeDetails', RESEED, 0)
--DBCC CHECKIDENT ('Grade', RESEED, 0)
--DBCC CHECKIDENT ('AchievementType', RESEED, 0)
--DBCC CHECKIDENT ('Course', RESEED, 0)
--DBCC CHECKIDENT ('Student', RESEED, 0)
--DBCC CHECKIDENT ('Teacher', RESEED, 0)
--GOINSERT [dbo].[Teacher] ([ID], [FirstName], [LastName], [DateOfBirth], [AcademicRank], [HireDate]) VALUES (87, N'Ilinka', N'Ilievska', CAST(N'1980-10-27' AS Date), N'Asistent', CAST(N'2007-08-22' AS Date))
--GO
--INSERT [dbo].[Student] ([ID], [FirstName], [LastName], [DateOfBirth], [EnrolledDate], [Gender], [NationalIDNumber], [StudentCardNumber]) VALUES (483, N'Gordana', N'Taseva', CAST(N'1983-11-17' AS Date), CAST(N'2004-06-07' AS Date), N'F', N'367209', N'sc-23716')
--GO
--INSERT [dbo].[GradeDetails] ([ID], [GradeID], [AchievementTypeID], [AchievementPoints], [AchievementMaxPoints], [AchievementDate]) VALUES (95608, 20107, 3, 85, 100, CAST(N'2018-09-25T00:00:00.000' AS DateTime))
--GO
--INSERT [dbo].[Grade] ([ID], [StudentID], [CourseID], [TeacherID], [Grade], [Comment], [CreatedDate]) VALUES (13494, 200, 27, 27, 10, N'Neispolnitelen', CAST(N'2014-12-29T00:00:00.000' AS DateTime))
--GO
--INSERT [dbo].[Course] ([ID], [Name], [Credit], [AcademicYear], [Semester]) VALUES (40, N'Управување со ИКТ проекти', 6, 4, 8)
--GO

----------------------    Preparation for SEDCHome  --------------------

-- rebuilding the database without constraints so the data seeding can run

--------- From Homework 01 ----------------------

USE [master]
GO

DROP DATABASE IF EXISTS SEDCHome;
CREATE DATABASE SEDCHome;
GO

USE [SEDCHome]
GO

CREATE TABLE Student(
	ID int IDENTITY(1,1) NOT NULL,
	FirstName nvarchar(100),
	LastName nvarchar(100), 
	DateOfBirth date,
	EnrolledDate date,
	Gender nchar(1),
	NationalIDNumber nvarchar(20),
	StudentCardNumber nvarchar(20),
	CONSTRAINT PK_Student PRIMARY KEY (ID)
);

CREATE TABLE Teacher(
	ID int IDENTITY(1,1) NOT NULL,
	FirstName nvarchar(100),
	LastName nvarchar(100), 
	DateOfBirth date,
	AcademicRank nvarchar(100),
	HireDate date,
	CONSTRAINT PK_Teacher PRIMARY KEY (ID)
);

CREATE TABLE Course(
	ID int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100),
	Credit smallint,
	AcademicYear nvarchar(9),
	Semester smallint,
	CONSTRAINT PK_Course PRIMARY KEY (ID)
);

CREATE TABLE AchievementType(
	ID int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100),
	[Description] nvarchar(max),
	ParticipationRate decimal(5,2),
	CONSTRAINT PK_AchievementType PRIMARY KEY (ID)
);

CREATE TABLE Grade(
	ID int IDENTITY(1,1) NOT NULL,
	StudentID int,      -- no constraint
	CourseID int,       -- no constraint
	TeacherID int,      -- no constraint
	Grade nvarchar(2),
	Comment nvarchar(max),
	CreatedDate date,
	CONSTRAINT PK_Grade PRIMARY KEY (ID)
);

--altering for easier calculations
ALTER TABLE Grade
ALTER COLUMN Grade tinyint;


CREATE TABLE GradeDetails(
	ID int IDENTITY(1,1) NOT NULL,
	GradeID int,               -- no constraint
	AchievementTypeID int,     -- no constraint
	AchievementPoints smallint,
	AchievementMaxPoints smallint,
	AchievementDate date,
	CONSTRAINT PK_GradeDetails PRIMARY KEY (ID)
);

-- OK

----------------------    School System  --------------------


use [SEDCHome]
go

go
create or alter view [vv_TeacherGrade] as
select
	t.ID as TeacherID,
	t.FirstName + ' ' + t.LastName as TeacherName,
	g.Grade,
	g.Comment,
	g.CreatedDate,
	s.ID as StudentID,
	s.FirstName + ' ' + s.LastName as StudentName
from Grade g
join Teacher t on g.TeacherID = t.ID
join Student s on g.StudentID = s.ID
go

select * from [vv_TeacherGrade]
go

--    Calculate the count of all grades per Teacher in the system​
select TeacherName, count(*) as GradeCount
from [vv_TeacherGrade]
group by TeacherName
go


--    Calculate the count of all grades per Teacher in the system for first 100 Students (ID < 100)​
select TeacherName, count(*) as GradeCount
from [vv_TeacherGrade]
where StudentID < 100
group by TeacherName
go


--    Find the Maximal Grade, and the Average Grade per Student on all grades in the system​
select StudentID, StudentName, max(Grade) as MaxGrade, avg(Grade) as AvgGrade
from [vv_TeacherGrade]
group by StudentID, StudentName
go

--    Calculate the count of all grades per Teacher in the system and filter only grade count greater then 200​
select count(Grade) as GradeCount, TeacherName
from [vv_TeacherGrade]
group by TeacherName
having count(Grade) > 200
go


--    Find the Grade Count, Maximal Grade, and the Average Grade per Student on all grades in the system.
--    Filter only records where Maximal Grade is equal to Average Grade​
create or alter view [vv_StudentGradesAvg] as
select StudentID, count(*) as GradeCount, max(Grade) as MaxGrade, avg(Grade) as AvgGrade
from [vv_TeacherGrade]
group by StudentID
having max(Grade) = avg(Grade)
go

select * from [vv_StudentGradesAvg]
go


--    List Student First Name and Last Name next to the other details from previous query​
create or alter view [vv_StudentGradesAvg] as
select StudentID, StudentName, count(*) as GradeCount, max(Grade) as MaxGrade, avg(Grade) as AvgGrade
from [vv_TeacherGrade]
group by StudentID, StudentName
having max(Grade) = avg(Grade)
go

select * from [vv_StudentGradesAvg]
go


--    Create new view (vv_StudentGrades) that will List all StudentIds and count of Grades per student​
create or alter view [vv_StudentGrades] as
select StudentID, count(*) as GradeCount
from [vv_TeacherGrade]
group by StudentID
go

select * from [vv_StudentGrades]
go


--    Change the view to show Student First and Last Names instead of StudentID​
create or alter view [vv_StudentGrades] as
select StudentName, count(*) as GradeCount
from [vv_TeacherGrade]
group by StudentName
go

select * from [vv_StudentGrades]
go


--    List all rows from view ordered by biggest Grade Count​
select * from [vv_StudentGrades]
order by GradeCount desc
go


