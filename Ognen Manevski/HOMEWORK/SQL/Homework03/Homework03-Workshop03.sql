
----------------------    Homework 03   --------------------

use SEDC
go

----------------------    Workshop 03  --------------------


--Create view vv_CustomerOrders (CustomerId + total orders)
create or alter view [vv_CustomerOrders] as
select o.CustomerId, count(*) as TotalOrders -- count(*) - entire row
from Orders o
join Customers c
on o.CustomerId = c.Id
group by CustomerId
go

select * from [vv_CustomerOrders]
go


--Change to show Customer Names
create or alter view [vv_CustomerOrders] as
select o.CustomerId, c.[Name] as CustomerName, count(*) as TotalOrders
from Orders o
join Customers c
on o.CustomerId = c.Id
group by o.CustomerId, c.Name
go

select * from [vv_CustomerOrders]
go


--Order by highest total price
select * from [vv_CustomerOrders]
order by TotalOrders desc
go


--Create view vv_EmployeeOrders (Employee + Product + Quantity)
create or alter view [vv_EmployeeOrders] as
select e.FirstName + ' ' + e.LastName as EmployeeName, p.[Name], sum(Quantity) as TotalQuantity
from Orders o
join Employees e on e.Id = o.EmployeeId
join OrderDetails od on od.OrderId = o.Id
join Products p on p.Id = od.ProductId
group by e.FirstName, e.LastName, p.[Name]
go

select * from [vv_EmployeeOrders]
order by EmployeeName
go



--Filter only region 'Skopski'
create or alter view [vv_EmployeeOrders] as
select e.FirstName + ' ' + e.LastName as EmployeeName, p.[Name], sum(Quantity) as TotalQuantity
from Orders o
join Employees e on e.Id = o.EmployeeId
join OrderDetails od on od.OrderId = o.Id
join Products p on p.Id = od.ProductId
join BusinessEntities be on be.Id = o.BusinessEntityId
where be.Region = 'Skopski'
group by e.FirstName, e.LastName, p.[Name]
go

--select * from BusinessEntities
--go

select * from [vv_EmployeeOrders]
order by EmployeeName
go