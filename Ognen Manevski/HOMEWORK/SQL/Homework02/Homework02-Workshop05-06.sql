
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

