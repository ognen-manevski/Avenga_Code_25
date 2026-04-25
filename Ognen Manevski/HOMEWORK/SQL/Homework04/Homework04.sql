use SEDCHome
go

------------ 🧪 WORKSHOP 01 -------------

use SEDC
go

--Declare scalar variable for storing FirstName
declare @FirstName nvarchar(50)

--Assign value 'Aleksandar'
set @FirstName = 'Aleksandar'

--Find all Employees with that FirstName
select * from Employees
where FirstName = @FirstName

--Declare table variable (EmployeeId, DateOfBirth)
declare @EmployeesTable table (
    EmployeeId int,
    DateOfBirth date
)

--Fill with all Female employees
declare @EmployeesTableWithGender table (
    EmployeeId int,
    gender nchar(1),
    DateOfBirth date
)

insert into @EmployeesTableWithGender (EmployeeId, gender, DateOfBirth)
select Id, Gender, DateOfBirth
from Employees
where Gender = 'f'

select * from @EmployeesTableWithGender


--Declare temp table (LastName, HireDate)
declare @TempTable table (
    LastName nvarchar(50),
    HireDate date
)

--Fill with Male employees with FirstName starting with 'A'
insert into @TempTable (LastName, HireDate)
select LastName, HireDate
from Employees e
--where e.FirstName like 'A%'
where substring(e.FirstName, 1, 1) = 'A'

select * from @TempTable
go


--Retrieve employees with LastName length = 7
declare @TempTable table (
    LastName nvarchar(50)
)

insert into @TempTable (LastName)
select LastName
from Employees e
where len(LastName) = 7

select * from @TempTable
go


------------- 🧪 WORKSHOP 02 -------------

use SEDC
go

    --Create scalar function fn_FormatProductName

select * from [Products]


    --Format:
    --    Second & third char from Code
    --    Last 3 chars from Name
    --    Product Price


--editing price to be a string
alter table Products
alter column Price nvarchar(50)

go

create or alter function [fn_FormatProductName] (@code nvarchar(50), @name nvarchar(50), @price nvarchar(10))
returns nvarchar(100)
as
begin
    set @code = substring(@code, 2, 2) --start from 2nd char, take 2 chars
    set @name = substring(@name, len(@name) - 2, 3) --start from 3rd char from end, take 3 chars
    return @code + '-' + @name + '-' + @price
end
go

--in use:
select *, dbo.[fn_FormatProductName](Code, [Name], Price) as FunctionOutput
from Products



------------- Homework -------------

use SEDCHome
go

--    Declare scalar variable FirstName = 'Antonio'
declare @FirstName nvarchar(50) = 'Antonio'

--    Find all Students with that FirstName
select * from dbo.Student
where FirstName = @FirstName

--    Create table variable with StudentId, StudentName, DateOfBirth
declare @StudentsTable table (
    StudentId int,
    StudentName nvarchar(100),
    DateOfBirth date
)


--    Fill with Female students
insert into @StudentsTable (StudentId, StudentName, DateOfBirth)
select ID, FirstName + ' ' + LastName as StudentName, DateOfBirth
from Student
where Gender = 'f'


select * from @StudentsTable;
go


--    Create temp table with LastName and EnrolledDate
declare @TempTable table (
    LastName nvarchar(50),
    EnrolledDate date
)

--    Fill with Male students starting with 'A'
insert into @TempTable (LastName, EnrolledDate)
select LastName, EnrolledDate
from dbo.Student
where Gender = 'm' and 
--FirstName like 'A%'
substring( [FirstName] , 1, 1) = 'A';

select * from @TempTable
go


--    Find students with LastName length = 7
select LastName
from dbo.Student
where len(LastName) = 7


--    Find teachers with FirstName length < 5 and same first 3 letters in First/Last name
select FirstName, lastName
from dbo.Teacher
where len(FirstName) < 5
and substring(FirstName, 1, 3) = substring(LastName, 1, 3)
go