--------- Homework 01 ----------------------

--Create a database called SEDCACADEMYDB.

--Create the following tables:
--    Student
--    Teacher
--    Grade
--    Course
--    AchievementType
--    GradeDetails

use [master] go

drop database if exists SEDCACADEMYDB;

if not exists (select * from sys.databases where name = 'SEDCACADEMYDB') --copilot suggested this
create database SEDCACADEMYDB;

use [SEDCACADEMYDB] go

create table Student(
	ID int identity (1,1) not null,
	FirstName nvarchar (100),
	LastName nvarchar (100), 
	DateOfBirth date,
	EnrolledDate date,
	Gender nchar (1),
	NationalIDNumber nvarchar (20), -- usually 9 to 13 digits
	StudentCardNumber nvarchar (20),
constraint PK_Student primary key (ID)
);

create table Teacher(
	ID int identity (1,1) not null,
	FirstName nvarchar (100),
	LastName nvarchar (100), 
	DateOfBirth date,
	AcademicRank nvarchar (100),
	HireDate date,
constraint PK_Teacher primary key (ID)
);

create table Course(
	ID int identity (1,1) not null,
	[Name] nvarchar (100),
	Credit smallint,
	AcademicYear nvarchar(9), -- 2025/2026
	semester smallint, -- 1 or 2
constraint PK_Course primary key (ID)
);


create table AchievementType(
	ID int identity (1,1) not null,
	[Name] nvarchar (100),
	[Description] nvarchar (max),
	ParticipationRate decimal (5,2), -- 0.00 to 100.00
constraint PK_AchievementType primary key (ID)
);

create table Grade(
	ID int identity (1,1) not null,
	StudentID int, --fk to Student
	CourseID int, --fk to Course
	TeacherID int, --fk to Teacher
	Grade nvarchar (2), -- A / A+
	Comment nvarchar (max),
	CreatedDate date,
constraint PK_Grade primary key (ID),
--constraint FK_Grade_Student foreign key (StudentID) references Student(ID),
--constraint FK_Grade_Course foreign key (CourseID) references Course(ID),
--constraint FK_Grade_Teacher foreign key (TeacherID) references Teacher(ID),
);

create table GradeDetails(
	ID int identity (1,1) not null,
	GradeID int, --fk to Grade
	AchievementTypeID int, --fk to AchievementType
	AchievementPoints smallint,
	AchievementMaxPoints smallint,
	AchievementDate date,
constraint PK_GradeDetails primary key (ID)
);


---- Optional: Add constraints ----

alter table Grade
	add
	--foreign keys:
	constraint FK_Grade_Student	foreign key (StudentID)	references Student(ID),
	constraint FK_Grade_Course foreign key (CourseID) references Course(ID),
	constraint FK_Grade_Teacher foreign key (TeacherID) references Teacher(ID),
	--grade check constraint:
	constraint CHK_Grade_ValidValues check (Grade in ('A', 'A+', 'B', 'B+', 'C', 'C+', 'D', 'D+', 'F'));

-- FK columns cant be null. Cant have grades without students, courses or teachers.
alter table Grade alter	column StudentID int not null;
alter table Grade alter	column CourseID int not null;
alter table Grade alter	column TeacherID int not null;

alter table GradeDetails
	add
	--foreign keys:
	constraint FK_GradeDetails_Grade foreign key (GradeID) references Grade(ID),
	constraint FK_GradeDetails_AchievementType foreign key (AchievementTypeID) references AchievementType(ID),
	--points check constraint:
	--Points cannot be more than MaxPoints
	constraint CHK_AchievementPoints check (AchievementPoints <= AchievementMaxPoints);

--FK not null
alter table GradeDetails alter column GradeID int not null;
alter table GradeDetails alter column AchievementTypeID int not null;

alter table Teacher
	add	constraint CHK_AcademicRank_ValidValues
	check (AcademicRank in ('Assistant Professor', 'Associate Professor', 'Professor'));

alter table Course
	add
	constraint CHK_Semester_ValidValues	check (semester in (1, 2)),
	constraint CHK_Credit_Range check (Credit >= 3 and Credit <= 30), --ects? 3 to 12 for modules, 15 to 30 for bachelor/master thesis
	constraint CHK_AcademicYear_Format check (AcademicYear like '%/%');

alter table AchievementType
	add constraint CHK_ParticipationRate_Range
	check (ParticipationRate >= 0 and ParticipationRate <= 100);

alter table Student
	add
	constraint UQ_Student_NationalIDNumber unique (NationalIDNumber),
	constraint UQ_Student_StudentCardNumber unique (StudentCardNumber);


---- Optional: Add Defaults ----

alter table Grade
	-- set default date to current date
	add constraint DFT_Grade_CreatedDate default (getdate()) for CreatedDate;

-- default credit to 6
alter table Course	add	constraint DFT_Course_Credit default (6) for Credit;



