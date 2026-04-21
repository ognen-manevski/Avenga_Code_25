
----------------------    Homework 03   --------------------

use SEDC
go

----------------------    Workshop 01  --------------------

--Calculate the total amount on all orders in the system
select sum (TotalPrice) as TotalRevenue from Orders;


--Calculate the total amount per BusinessEntity on all orders
select sum (TotalPrice) as TotalRevenue, be.[Name] as BusinessEntityName
from Orders o
inner join BusinessEntities be
on o.BusinessEntityId = be.Id
group by be.[Name];


--Calculate the total amount per BusinessEntity from Customers with ID < 20
select sum (TotalPrice) as TotalRevenue, be.[Name] as BusinessEntityName
from Orders o
join Customers c on o.CustomerId = c.Id
join BusinessEntities be on o.BusinessEntityId = be.Id
where c.Id < 20
group by be.[Name];

--Find Max Order amount and Avg Order amount per BusinessEntity
select max (TotalPrice) as MaxRevenue, avg (TotalPrice) as AvgRevenue, be.[Name] as BusinessEntityName
from Orders o
inner join BusinessEntities be
on o.BusinessEntityId = be.Id
group by be.[Name];


--Suggest your own analytical question from Orders

--which employee has the highest total order count?
select max (TotalOrders) as MaxTotalOrders
from (
	select count (EmployeeId) as TotalOrders, e.FirstName, e.LastName
	from Orders o
	join Employees e
	on o.EmployeeId = e.Id
	group by e.FirstName, e.LastName
) as EmployeeOrders;

--list the total number of orders per employee
select count (EmployeeId) as TotalOrders, e.FirstName, e.LastName
from Orders o
join Employees e
on o.EmployeeId = e.Id
group by e.FirstName, e.LastName
order by TotalOrders desc;


--which date has the highest total revenue amount?
select max (TotalRevenue) as MaxTotalRevenue
from (
	select sum (TotalPrice) as TotalRevenue, OrderDate
	from Orders o
	group by OrderDate
) as RevenuePerDate;

--list the total revenue per date
select sum (TotalPrice) as TotalRevenue, OrderDate
from Orders o
group by OrderDate
order by TotalRevenue desc;

select * from Orders


----------------------    Workshop 02  --------------------

 --   Calculate total amount per BusinessEntity and filter > 635558
select sum (TotalPrice) as TotalRevenue, be.[Name] as BusinessEntityName
from Orders o
join BusinessEntities be
on o.BusinessEntityId = be.Id
group by be.[Name]
having sum (TotalPrice) > 635558;

 --   Calculate total amount per BusinessEntity (CustomerId < 20) and filter < 100000
select sum (TotalPrice) as TotalRevenue, be.[Name] as BusinessEntityName
from Orders o
join Customers c on o.CustomerId = c.Id
join BusinessEntities be on o.BusinessEntityId = be.Id
where o.CustomerId < 20
group by be.[name]
having sum(TotalPrice) < 100000;


 --   Find Max and Avg per BusinessEntity and filter where total > 4x average
select
max (TotalPrice) as MaxRevenue,
avg (TotalPrice) as AvgRevenue,
be.[Name] as BusinessEntityName
from Orders o
join BusinessEntities be
on o.BusinessEntityId = be.Id
group by be.[Name]
having max (TotalPrice)  > 4 * avg (TotalPrice); --cant use alias in having
