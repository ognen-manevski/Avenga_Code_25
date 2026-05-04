-- error handling

begin try
	select 1/0 as Result -- This will cause a divide by zero error
	print 'Yey, we divided by zero!'
end try
begin catch
	print 'An error occurred: ' + ERROR_MESSAGE() -- in messages (not result)

	select
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_STATE() AS ErrorState,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
end catch
go


-- transactions

--example grouping 2 inserts in a transaction, if one fails, the other will be rolled back

begin transaction;

insert into dbo.Customers (Name, AccountNumber, City, RegionName, CustomerSize, PhoneNumber, IsActive)
values ('Test Customer A', 'ACC123', 'Test City', 'Test Region', 'Medium', '123-456-7890', 1);


insert into dbo.Customers (Name, AccountNumber, City, RegionName, CustomerSize, PhoneNumber, IsActive)
values ('Test Customer B', 'ACC123', 'Test City', 'Test Region', 'Medium', '123-456-7890');

commit;
go

--

use [SEDC-2]
go

create or alter procedure dbo.usp_CreateOrderWithDetails
(
	@CustomerId int,
	@BusinessEntityId int,
	@EmployeeId int,
	@ProductId int,
	@Quantity int,
	@Price decimal(18,2),
	@Comment nvarchar(255) = null
)
as
begin

	begin try
		begin transaction
		--1 create the order
		insert into [dbo].[Orders] (OrderDate, [Status], BusinessEntityId, CustomerId, EmployeeId, TotalPrice, Comment)
		values (getdate(), 0, @BusinessEntityId, @CustomerId, @EmployeeId, 0, @Comment)

		declare @LastOrderId int = SCOPE_IDENTITY(); -- get the last inserted order id

		--2 add tge details

		insert into [dbo].[OrderDetails] (OrderId, ProductId, Quantity, Price)
		values ( @LastOrderId, @ProductId, @Quantity, @Price)

		--3 update total price
		update [dbo].[Orders]
		set TotalPrice = @Quantity * @Price
		where Id = @LastOrderId

		commit; -- if everything is successful, commit the transaction

		print 'Order created successfully.'

	end try
	begin catch
		rollback; -- if any error occurs, roll back the transaction to maintain data integrity
		print 'An error occurred: ' + ERROR_MESSAGE()
	end catch
end
go

execute dbo.usp_CreateOrderWithDetails
@CustomerId = 1,
@BusinessEntityId = 1,
@EmployeeId = 1,
@ProductId = 1,
@Quantity = 10,
@Price = 9.99,
@Comment = 'This will work'

execute dbo.usp_CreateOrderWithDetails
@CustomerId = 1,
@BusinessEntityId = 1,
@EmployeeId = 1,
@ProductId = 999399,
@Quantity = 10,
@Price = 9.99,
@Comment = 'This will NOT work'

select * from dbo.Orders order by Id desc
select * from dbo.OrderDetails order by Id desc



--- backups

