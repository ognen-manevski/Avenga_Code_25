use [SEDC-2]
go

---------------------------------------
-- Recap - scalar functions
---------------------------------------

select * from dbo.Employees
go

select [dbo].[fn_EmployeeFullName](1)
select [dbo].[fn_EmployeeFullName](3) as 'Full Name'

USE [SEDC-2]
GO

--alster the fn to return the uppercased full name
CREATE OR ALTER function [dbo].[fn_EmployeeFullName] (@EmployeeId int)
	returns nvarchar(100) as
begin
   declare @Result nvarchar(100)
   select @Result = upper(FirstName + ' ' + LastName)
   from Employees
   where Id = @EmployeeId

   return @Result

end
GO

select [dbo].[fn_EmployeeFullName](2)
go


--asign the return value to a variable

declare @EmployeeFullName nvarchar(100) = [dbo].[fn_EmployeeFullName](4)

select @EmployeeFullName as 'First Employee'
go

--

declare @EmployeeFullName nvarchar(100)
set @EmployeeFullName = [dbo].[fn_EmployeeFullName](5)
select @EmployeeFullName as 'Fifth Employee'
go

-- write a fn to insert a new employee


CREATE OR ALTER function [dbo].[fn_InsertIntoEmployees]
(
    @FirstName nvarchar(100),
    @LastName nvarchar(100),
    @DateOfBirth date,
    @Gender nchar(1),
    @HireDate date,
    @NationalIdNumber nvarchar(20)
)
returns int
begin
    INSERT INTO [dbo].[Employees] ([FirstName], [LastName], [DateOfBirth], [Gender], [HireDate], [NationalIdNumber])
    values (@FirstName, @LastName, @DateOfBirth, @Gender, @HireDate, @NationalIdNumber)

    return SCOPE_IDENTITY() --the id of the last inserted record in the current scope
end
GO

--wont run
--we cant insert data or make any changes to the db using a function

--

INSERT INTO [dbo].[Employees] ([FirstName], [LastName], [DateOfBirth], [Gender], [HireDate], [NationalIdNumber])
values ('Bob', 'Bobsky', GETUTCDATE(), 'M', GETUTCDATE(), '12345678910')
go
select SCOPE_IDENTITY() as 'Last Added Item ID'
go


------- stored procedures -------------------

use [SEDC-2]
go

-- ex: return all employees

select * from dbo.Employees
go

create or alter procedure [dbo].[usp_GetAllEmployees] --usp -> user stored procedure
as
begin
    select * from dbo.Employees
end
go

execute [dbo].[usp_GetAllEmployees] --calling the stored procedure
go

--- with params
-- employee by id

create or alter procedure [dbo].[usp_GetEmployeeById]
(@EmployeeId int)
as
begin
    select * from dbo.Employees e
    where e.Id = @EmployeeId
end
go

execute [dbo].[usp_GetEmployeeById] @EmployeeId = 3
execute [dbo].[usp_GetEmployeeById] 10
go

--insert employee using stored procedure

create or alter procedure [dbo].[usp_InsertIntoEmployees]
(
    @FirstName nvarchar(100),
    @LastName nvarchar(100),
    @DateOfBirth date,
    @Gender nchar(1),
    @HireDate date,
    @NationalIdNumber nvarchar(20)
)
as
begin
    INSERT INTO [dbo].[Employees] ([FirstName], [LastName], [DateOfBirth], [Gender], [HireDate], [NationalIdNumber])
    values (@FirstName, @LastName, @DateOfBirth, @Gender, @HireDate, @NationalIdNumber)
end
go


execute [dbo].[usp_InsertIntoEmployees]
    @FirstName = 'Jane',
    @LastName = 'Doe',
    @NationalIdNumber = '10987654321',
    @Gender = 'F',
    @HireDate = '2020-12-15',
    @DateOfBirth = '1990-01-01'
go

select * from dbo.Employees
order by Id desc
go


--alter the procedure to return the id of the newly inserted employee

create or alter procedure [dbo].[usp_InsertIntoEmployees]
(
    @FirstName nvarchar(100),
    @LastName nvarchar(100),
    @DateOfBirth date,
    @Gender nchar(1),
    @HireDate date,
    @NationalIdNumber nvarchar(20),
    @NewEmployeeId int output --output/out parametars are used to return values from the stored procedure
                              --we can have many output params
)
as
begin
    INSERT INTO [dbo].[Employees] ([FirstName], [LastName], [DateOfBirth], [Gender], [HireDate], [NationalIdNumber])
    values (@FirstName, @LastName, @DateOfBirth, @Gender, @HireDate, @NationalIdNumber)

    select * from dbo.Employees
    order by Id desc

    set @NewEmployeeId = SCOPE_IDENTITY() --assign the output

    select @NewEmployeeId as 'New Employee ID' --we can also return the value by selecting it, but we need to assign it to the output param first

end
go

declare @NewEmployeeIdResult int
execute [dbo].[usp_InsertIntoEmployees]
    @FirstName = 'Jessica',
    @LastName = 'Smith',
    @NationalIdNumber = '11223344556',
    @Gender = 'M',
    @HireDate = '2021-01-10',
    @DateOfBirth = '1985-05-20',
    @NewEmployeeId = @NewEmployeeIdResult output --save value here


select @NewEmployeeIdResult as 'New Employee ID'
go
