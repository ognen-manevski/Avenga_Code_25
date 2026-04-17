------------ Workshop 03 -----------------


--List all names where we have BusinessEntities and Customers at the same time

select [Name] from BusinessEntities
UNION ALL
select [Name] from Customers
where City in (select City from BusinessEntities);


--List all regions where we have BusinessEntities and Customers at the same time All

select [Region] from BusinessEntities
UNION
select [RegionName] from Customers;


--List all regions where some business entity is based or some customer is based. remove duplicates

select [Region] from BusinessEntities
INTERSECT
--EXCEPT
select [RegionName] from Customers;


