/*
create a new procedure called CreateOrder
Pridecure should create only Order info (Table Order) (not Order details)
Procedure should return the total no of orders in the system for the Customer from the new
order (regardless the BusinessEntity)
Procedure should return the second resultset with the total amount of all orders for the customer
and business entity on input  (regardless the business entity)
*/

use [SEDC-2]
go

select * from [dbo].[Orders]
go

create or alter procedure [dbo].[usp_CreateOrder]
(
@CustomerId int,
@BusinessEntityId int,
@EmployeeId int,

@CustomerOrders int output,
@CustomerBeOrders int output
)
as
begin

	insert into [dbo].[Orders] ([OrderDate], [Status], [BusinessEntityId], [CustomerId], [EmployeeId])
	values (getdate(), 0, @BusinessEntityId, @CustomerId, @EmployeeId)

	--get total number of orders for the customer
	set @CustomerOrders = (
	select count (*) as TotalOrdersCustomer
	from [dbo].[Orders] o
	where o.CustomerId = @CustomerId
	)

	--get total amount of all orders for the customer and business entity
	set @CustomerBeOrders = (
	select count (*) as TotalOrdersCustomerBE
	from [dbo].[Orders] o
	where o.CustomerId = @CustomerId
	and o.BusinessEntityId = @BusinessEntityId
	)	
end
go

declare @CustomerOrders int,
@CustomerBeOrders int

execute [dbo].[usp_CreateOrder]
@BusinessEntityId = 2,
@CustomerId = 4,
@EmployeeId = 1,
@CustomerOrders = @CustomerOrders output,
@CustomerBeOrders = @CustomerBeOrders output


select @CustomerOrders as 'Total Orders for Customer'
select @CustomerBeOrders as 'Total Orders for Customer and Business Entity'