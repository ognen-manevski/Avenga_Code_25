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

