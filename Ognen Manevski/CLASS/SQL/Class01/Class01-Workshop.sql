use [master]
go

drop database if exists [SEDC]
go

create database [SEDC]

use [SEDC]
go

-- make sure no tables exist before we start

drop table if exists [dbo].[OrderDetails]
drop table if exists [dbo].[Orders]
drop table if exists [dbo].[Customers]
drop table if exists [dbo].[Employees]
drop table if exists [dbo].[BusinessEntities]
drop table if exists [dbo].[Products]


create table Customers (
	[Id] int IDENTITY (1,1) not null, --we can write primary key here, but we cant name it explicitly
	[Name] nvarchar (100) not null,
	[AccountNumber] nvarchar (100) null,
	[City] nvarchar (100) null,
	[RegionName] nvarchar (100) null,
	[CustomerSize] nvarchar (10) null,
	[PhoneNumber] nvarchar (20) null,
	[IsActive] bit not null, --boolean value, 1 for active, 0 for inactive
constraint [PK_Customer] primary key (Id) --setting the primary key for the table
)

create table Employees (
	[Id] int IDENTITY (1,1) not null,
	[FirstName] nvarchar (100) not null,
	[LastName] nvarchar (100) not null,
	[DateOfBirth] date null,
	[Gender] nchar (1) null,
	[HireDate] date null,
	[NationalIdNumber] nvarchar(20) null,
constraint [PK_Employee] primary key (Id)
)

create table Products(
	[Id] int IDENTITY (1,1) not null,
	[Code] nvarchar (50) null,
	[Name] nvarchar (100) null,
	[Description] nvarchar (max) null,
	[Weight] decimal (18,2) null, --decimal with 18 digits in total and 2 digits after the decimal point
	[Price] decimal (18,2) null,
	[Cost] decimal (18,2) null,
constraint [PK_Product] primary key (Id)
)

create table Orders (
	[Id] bigint IDENTITY (1,1) not null, --bigint for larger number of orders
	[OrderDate] date null,
	[Status] smallint null, --smallint for status codes up to 32767
	[BusinessEntityId] int null, --reference to another table 
	[CustomerId] int null, --foreign key to Customers table (must match data type [int])
	[EmployeeId] int null, --foreign key to Employees table
	[TotalPrice] decimal (18,2) null,
	[Comment] nvarchar (max) null,
constraint [PK_Order] primary key (Id)
)

create table OrderDetails (
	[Id] int IDENTITY (1,1) not null,
	[OrderId] bigint null, --foreign key to Orders table
	[ProductId] int null, --foreign key to Products table
	[Quantity] int null,
	[Price] decimal (18,2) null,
constraint [PK_OrderDetail] primary key (Id)
)

--what is identity in the tables and what is primary key/constraint?
--Identity is a property of a column that automatically generates a unique value for each new row inserted into the table.
--It is often used for primary key columns to ensure that each record has a unique identifier.
--The syntax for defining an identity column is: [ColumnName] int IDENTITY (seed, increment),
--where seed is the starting value and increment is the value added to the previous value for each new row.

--Primary key is a constraint that uniquely identifies each record in a table.
--It ensures that no two rows can have the same value in the primary key column(s).
--A primary key can consist of one or more columns, and it is often used to establish relationships between tables.
--When a primary key is defined, SQL Server automatically creates a unique index on the primary key column(s) to enforce uniqueness and improve query performance.

--what is the difference between primary key and constraint?
--A primary key is a specific type of constraint that uniquely identifies each record in a table.
--A constraint is a rule that limits the type of data that can be inserted into a table, and it can be used to enforce data integrity and consistency.
--in my example, I have defined primary keys for each table using the CONSTRAINT keyword, which is a way to explicitly name the primary key constraint.
-- is it possible to have a primary key without using the CONSTRAINT keyword?
--Yes, it is possible to define a primary key without using the CONSTRAINT keyword.
--You can simply specify the primary key column(s) directly in the column definition. For example:
--[Id] int IDENTITY (1,1) PRIMARY KEY
--However, using the CONSTRAINT keyword allows you to give the primary key constraint a specific name,
--which can be helpful for clarity and maintenance purposes.


create table BusinessEntities (
	[Id] int IDENTITY (1,1) not null,
	[Name] nvarchar (100) null,
	[Region] nvarchar (1000) null,
	[Zipcode] nvarchar (10) null,
	[Size] nvarchar (10) null,
constraint [PK_BusinessEntity] primary key (Id)
)

GO