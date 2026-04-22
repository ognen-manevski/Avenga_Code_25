-- Built in and Scalar functions 👘 ---

use sedc
go

--len()
select FirstName, LEN (LastName) as LastNameLength
from Employees;

--substring()
select Code, SUBSTRING (Code, 1, 3) as ShortCode -- 1 based
from Products;


--replace()
select FirstName, LastName, REPLACE (Gender, 'M', 'Male') as Gender
from Employees;

--with both
SELECT FirstName, LastName,
       CASE Gender
           WHEN 'M' THEN 'Male'
           WHEN 'F' THEN 'Female'
           ELSE Gender
       END AS Gender
FROM Employees;

select GETDATE();

select UPPER(FirstName) as FirstNameUpper, LOWER(LastName) as LastNameLower
from Employees;

------------ 🧪 WORKSHOP 01 -------------

--Declare scalar variable for storing FirstName

--Assign value 'Aleksandar'

--Find all Employees with that FirstName

--Declare table variable (EmployeeId, DateOfBirth)

--Fill with all Female employees

--Declare temp table (LastName, HireDate)

--Fill with Male employees with FirstName starting with 'A'

--Retrieve employees with LastName length = 7


-------- Programming Concepts and Scalar Functions ----------

DECLARE
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50)

set @FirstName = 'Martin'
set @LastName = 'Smith'

select @FirstName as FirstName, @LastName as LastName

--

declare @FullName nvarchar(100)

set @FullName = @FirstName + ' ' + @LastName

select @FullName as FullName

--

select @FirstName = 'Aleksandar', @LastName = 'Sjoanovski'

select * from Employees
where FirstName = @FirstName and
       LastName = @LastName
--

select @FirstName = 'Filip'

if (len (@FirstName) > 3)
    select 'Correct Name'
else
    select 'Name too short!'



------------- SCALAR FUNCTIONS  -------------

go

create function fn_EmployeeFullName (@EmployeeId int)
returns nvarchar(100) as
begin

   declare @Result nvarchar(100)
   
   select @Result = FirstName + ' ' + LastName
   from Employees
   where Id = @EmployeeId

   return @Result

end

go

select dbo.fn_EmployeeFullName(10) as EmployeeFullName



