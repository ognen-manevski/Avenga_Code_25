USE [master]
GO


--IF EXISTS (SELECT name FROM sys.databases WHERE name = 'TestDB')
--	ALTER DATABASE [TestDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
--GO

--USE [master]
--GO

--DROP DATABASE IF EXISTS [TestDB]
--GO

CREATE DATABASE [TestDB]
GO

USE [TestDB]
GO

--CREATE TABLE

CREATE TABLE [Customer]
(
	[Id] int IDENTITY(1,1) NOT NULL, -- Primary Key starts from 1 and increments by 1 for each new record
	[Name] nvarchar(100) NOT NULL, -- Name of the customer, 100 chars long, cannot be null
	[City] nvarchar(50) NULL, -- City of the customer, 50 chars long, can be null
	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC) -- setting Id as primary key for the customer table
)
GO
--IDENTITY(1,1) - auto increment
--CONSTRAINT - limit rule, default - no duplicates
--PRIMARY KEY - unique identifier
--CLUSTERED - ordering of the data // ASC - ascending order


--INSERT

insert into Customer ([Name], [City])
values ('Vero-Skopje', 'Skopje')

insert into Customer ([Name], [City])
values ('Tinex-Skopje', 'Skopje')

insert into Customer ([Name], [City])
values ('Vero-Strumica', 'Strumica')

insert into Customer ([Name], [City])
values ('Vero-Kumanovo', 'Kumanovo'),
('Vero-Tetovo', 'Tetovo'),
('Vero-Ohrid', 'Ohrid')


--SELECT

select * from Customer -- This query retrieves all records from the Customer table, displaying all columns for each customer.

select [Name] from Customer

select Id, City from Customer

select Id, [Name]
from Customer
where City = 'Skopje'

--UPDATE

update Customer set [Name] = 'Vero Taftalidze', City = 'Skopje'
where [Name] = 'Vero-Kumanovo'

--DELETE

delete
from Customer
where [Name] = 'Vero-Skopje'


-- DROP
--drop table Customer --deletes the entire table


--ALTER

alter table Customer
add [Phone] nvarchar(20) NULL


update Customer
set [Phone] = '02/123-456'
where [Name] = 'Vero Taftalidze'
select * from Customer