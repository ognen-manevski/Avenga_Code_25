------------- agregate functions ----------------

use SEDC
go

-- count

select count (*) as TotalNumberOfCustomers
from Customers


select count (Id) as TotalNumberOfOrders
from Orders

select count (BusinessEntityId) as TotalNumberOfOrders
from Orders

--if there is a null in the column we are counting by, it will not be counted!

-- sum

select sum (TotalPrice) from Orders as TotalRevenue

-- minmax

select max (TotalPrice) as MaxRevenue from Orders;
select min (TotalPrice) as MinRevenue from Orders; 

select  be.[Name], max (o.TotalPrice) as BiggestOrder, min (o.TotalPrice) as SmallestOrder
from BusinessEntities be
inner join Orders o
on be.Id = o.BusinessEntityId
group by be.[Name];


-- avg

select avg (Quantity) from OrderDetails;

-- duplicates are also counted in avg, but nulls are not counted

select avg (distinct Quantity) from OrderDetails; -- duplicates are not counted in avg, but nulls are not counted

-- string_agg

select string_agg ([Name], ', ' ) as AllCustomers from Customers;

select string_agg ([Id], ', ' ) as AllCustomerIds
from Customers;



------------- Workshop 01 / 02 ----------------


--Calculate the total amount on all orders in the system
select sum (TotalPrice) as TotalRevenue
from Orders

--Calculate the total amount per BusinessEntity on all orders
select sum (TotalPrice) as TotalRevenuePerEntity, be.[Name]
from Orders o
join BusinessEntities be
on be.Id = o.BusinessEntityId
group by be.[Name]


--Calculate the total amount per BusinessEntity from Customers with ID < 20
select sum (TotalPrice) as TotalRevenuePerEntity, be.[Name]
from Orders o
join BusinessEntities be
on be.Id = o.BusinessEntityId
where o.CustomerId < 20
group by be.[Name]


--Find Max Order amount and Avg Order amount per BusinessEntity
select
max (TotalPrice) as MaxOrder,
avg (distinct TotalPrice) as AvgOrder,
be.[Name]
from Orders o
join BusinessEntities be
on be.Id = o.BusinessEntityId
group by be.[Name]


--Suggest your own analytical question from Orders

--shortcut to uncomment? --ctrl + k + c to comment --ctrl + k + u to uncomment

--Calculate total amount per BusinessEntity and filter > 635558
select sum (TotalPrice) as TotalRevenuePerEntity, be.[Name]
from Orders o
join BusinessEntities be
on be.Id = o.BusinessEntityId
group by be.[Name]
having sum (TotalPrice) > 635558

--Calculate total amount per BusinessEntity (CustomerId < 20) and filter < 100000
select sum (TotalPrice) as TotalRevenuePerEntity, be.[Name]
from Orders o
join BusinessEntities be
on be.Id = o.BusinessEntityId
where o.CustomerId < 20
group by be.[Name]
having sum (TotalPrice) < 630000

--Find Max and Avg per BusinessEntity and filter where total > 4x average
select
max (TotalPrice) as MaxOrder,
avg (TotalPrice) as AvgOrder,
be.[Name]
from Orders o
join BusinessEntities be
on be.Id = o.BusinessEntityId
group by be.[Name]
having max (TotalPrice) > 4 * avg (TotalPrice);


------------- Workshop 03 Views ----------------

go

--or alter view if it already exists
CREATE or alter VIEW [Total amount of orders per Business entity] as 
select sum (TotalPrice) as TotalRevenuePerEntity, be.[Name] as BusinessEntityName
from Orders o
join BusinessEntities be
on be.Id = o.BusinessEntityId
group by be.[Name];

go

select * from [Total amount of orders per Business entity];

--drop view [Total amount of orders per Business entity];

insert into Orders (OrderDate, Status, BusinessEntityId, CustomerId, EmployeeId, TotalPrice, Comment)
values (GETDATE(), 1, 1, 1, 1, 43000, 'test');


--Create view vv_CustomerOrders (CustomerId + total orders)
go
create or alter view [vv_CustomerOrders] as
select c.Id as CustomerId, c.Name as CustomerName, sum (TotalPrice) as TotalPrice
from Orders o
join Customers c
on c.Id = o.CustomerId
group by c.Id, c.Name
go

select * from [vv_CustomerOrders]
order by TotalPrice desc

--Change to show Customer Names


--Order by highest total price


--Create view vv_EmployeeOrders (Employee + Product + Quantity)
go
create or alter view [vv_EmployeeOrders] as
select e.FirstName + ' ' + e.LastName as EmployeeName, p.Name as ProductName, sum (Quantity) as TotalQuantity
from Orders o
join Employees e on e.Id = o.EmployeeId
join OrderDetails od on od.OrderId = o.Id
join Products p on p.Id = od.ProductId
join BusinessEntities be on be.Id = o.BusinessEntityId
where be.Region = 'Skopski'
group by e.FirstName, e.LastName, p.Name
go
select * from [vv_EmployeeOrders]
order by EmployeeName

--Filter only region 'Skopski'