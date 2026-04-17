--workshop 01 - Class02

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

