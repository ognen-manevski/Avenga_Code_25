-- Class02

use [SEDC]
go

select * from Employees where FirstName = 'Goran'
go

--what is * and do we need it?
-- * is a wildcard character that represents all columns in a table.
-- When you use SELECT *, it retrieves all columns from the specified table.
-- what if i want to select only specific columns?
-- If you want to select only specific columns, you can replace the * with the names of the columns you want to retrieve.
-- For example, if you only want to select the FirstName and LastName columns

--shortcut for commenting here?
-- Yes, in SQL Server Management Studio (SSMS), you can use the following shortcuts for commenting:
-- To comment a single line, you can use -- at the beginning of the line.
-- To comment multiple lines, you can select the lines you want to comment and press Ctrl + K, then Ctrl + C.
-- This will add -- to the beginning of each selected line.
-- To uncomment multiple lines, you can select the lines you want to uncomment and press Ctrl + K, then Ctrl + U.

--can i format my code in ssms?
-- Select the code you want to format and press Ctrl + K, then Ctrl + D.

--------------- WORKSHOP 01 ---------------------

use [SEDC]
go

select * from Employees where FirstName = 'Goran'
go

select * from Employees where LastName like 'S%'
go

select * from Employees where DateOfBirth > '1988-01-01'
go

select * from Employees where Gender = 'M'
go

--Find all employees hired in January/1998
select * from Employees where HireDate between '1998-01-01' and '1998-01-31'

--Find all Employees with LastName starting With ‘A’ hired in January/2019

select * from Employees
	where HireDate between '2019-01-01' and '2019-01-31'
	and LastName like 'A%'


--------------- ORDERBY ---------------------

-------------- WORKSHOP 02 ---------------------

use [SEDC]
go

--Find all Employees with FirstName = Aleksandar ordered by Last Name

select * from Employees
	where FirstName = 'Aleksandar'
	order by LastName;

--List all Employees ordered by FirstName

select * from Employees
	order by FirstName;


--Find all Male employees ordered by HireDate (latest first)

select * from Employees
	where Gender = 'M'
	order by HireDate desc;




------------- Constraints  -----------------

use [SEDC]
go

create table Products_Test(
	[Id] int IDENTITY (1,1) not null,
	[Code] nvarchar (50) null,
	[Name] nvarchar (100) null,
	[Description] nvarchar (max) null,
	[Weight] decimal (18,2) null, 
	[Price] decimal (18,2) not null constraint [DFT_Products_Price] DEFAULT (0),
	[Cost] decimal (18,2) null,
constraint [PK_Product_Test] primary key (Id)
)

insert into Products_Test (Code, Name, Description, Weight, Cost)
values
('P001', 'Product 1', 'Description for Product 1', 1.5,  5.00),
('P002', 'Product 2', 'Description for Product 2', 2.0,  10.00),
('P003', 'Product 3', 'Description for Product 3', 0.5,  2.50) -- Price will default to 0 due to the constraint

select * from Products_Test

alter table Products_Test WITH CHECK
add constraint Products_test_Code_Unique UNIQUE (Code); -- Adding a unique constraint to the Code column

insert into Products_Test (Code, Name, Description, Weight, Cost)
values
('P001', 'Product 1', 'Description for Product 1', 1.5,  5.00);

--default constraint for weight

alter table Products_Test
	add constraint [DF_Products_Test_Weight]
	default (100) for [Weight];

insert into Products_Test (Code, Name, Description, Cost)
values
('P001', 'Product 1', 'Description for Product 1',  5.00);


------------------ Check Constraint + WORKSHOP 04 --------------------------

alter table Products_Test with check
	add constraint ChK_Products_Test_Price
	CHECK (Price >= 0); -- boolean

insert into Products_Test (Code, Name, Description, Weight, Price, Cost)
values
('P001', 'Product 1', 'Description for Product 1', 1.5, -10,  5.00);



alter table Products_Test with nocheck
	add constraint ChK_Products_Test_Name UNIQUE ([Name]);



------------ Constraints in existing tables ------------------

--Set default price in Products table

alter table Products
	add constraint DF_Products_Price default 0 for Price;



--Prevent inserting price > 2x cost
alter table Products
	add constraint CK_Products_Price_Cost check (Price <= 2 * Cost);



--Ensure unique product names

alter table Products with check
	add constraint UC_Product_Name unique ([Name]);


------------ Workshop 03 -----------------


--List all names where we have BusinessEntities and Customers at the same time

select [Name] from BusinessEntities
UNION ALL
select [Name] from Customers
where City in (select City from BusinessEntities);


--List all regions where we have BusinessEntities and Customers at the same time All

select [Region] from BusinessEntities
UNION
select [RegionName] from Customers;


--List all regions where some business entity is based or some customer is based. remove duplicates

select [Region] from BusinessEntities
INTERSECT
--EXCEPT
select [RegionName] from Customers;


------------ HOMEWORK 02 -----------------

------------ Workshop 05 -----------------

--Add foreign key between BusinessEntity and Order
--Analyze behavior with and without keys

use [SEDC]
go

alter table Orders
add constraint [FK_Orders_BusinessEntities] -- constraint required for adding a foreign key
foreign key (BusinessEntityId)
references BusinessEntities (Id);

--FK test:
--trying to insert an order with a non-existing BusinessEntityId
insert into Orders (BusinessEntityId)
values (9999999);

------------ Workshop 06 -----------------

use [SEDC]
go

--List all combinations of Customer and Product
select
	Customers.[Name] as CustomerName,
	Products.[Name] as ProductName
from Customers
cross join Products; --all products x all customers

--List all BusinessEntities with orders
select distinct --no duplicates
	[Name]
from BusinessEntities as be
inner join Orders as o
on be.Id = o.BusinessEntityId; --using the foreign key


--List all entities without orders
select distinct
	be.[Name]
from BusinessEntities as be
left join Orders as o
on be.Id = o.BusinessEntityId
where o.Id is null; --filter


--List Customers without orders (LEFT/RIGHT JOIN)
--left:
select distinct
	c.[Name]
from Customers as c
left join Orders as o
on c.Id = o.CustomerId
where o.Id is null;

--right:
select distinct
	c.[Name]
from Orders as o
right join Customers as c
on o.CustomerId = c.Id
where o.Id is null;

