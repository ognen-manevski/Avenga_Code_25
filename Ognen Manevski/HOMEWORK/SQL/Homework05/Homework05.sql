---------------  Class05 Workshop – Database Design: Pizza Ordering App 🍕 ----------------

--Design a Pizza Ordering Application Database

--👤 User Requirements

--A user can have multiple orders
--Information:

--    First Name
--    Last Name
--    Address
--    Phone

--🍕 Pizza Requirements

--A pizza can:

--    Have multiple toppings
--    Have one size
--    Belong to one order

--Information:

--    Name
--    Price (for this pizza)
--    Size*
--    Order*

--📦 Order Requirements

--An order can:

--    Have only one user
--    Have multiple pizzas

--Information:

--    Is Delivered
--    Price (delivery price)
--    User*

--🧀 Topping Requirements

--A topping can:

--    Be used in multiple pizzas

--Information:

--    Name
--    Price

--📏 Pizza Size Requirements

--A pizza size can:

--    Be used in multiple pizzas

--Information:

--    Name

--⚙️ Extra Requirements

--    Create a function that concatenates First and Last Name of a user
--    Create a view for all undelivered pizzas with user full names
--    Create a view:
--        Pizzas ordered by popularity (most ordered first)
--    Create a view:
--        Toppings ordered by popularity
--    Create a view:
--        Users and total pizzas they ordered

--Deliverables
--Database schema (tables + relationships)
--SQL scripts
--Implemented extra requirements

use [master]
go


alter database [PizzaOrdering]
set single_user
with rollback immediate
go


drop database if exists PizzaOrdering

create database [PizzaOrdering]
go

use [PizzaOrdering]
go

-----------------------------------
--drop tables if they exist
-----------------------------------

drop table if exists Users
drop table if exists Pizzas
drop table if exists PizzaSizes
drop table if exists Toppings
drop table if exists Orders
drop table if exists OrderDetails
drop table if exists PizzaToppings
drop table if exists OrderDetailToppings

-----------------------------------
--create tables
-----------------------------------

create table Users (
	Id int identity(1,1) primary key,
	FirstName nvarchar(100) not null,
	LastName nvarchar(100) not null,
	[Address] nvarchar(150) not null,
	Phone nvarchar(30) not null
)

create table Pizzas(
	Id int identity(1,1) primary key,
	[Name] nvarchar(100) not null,
	[Price] decimal(10,2) not null,
	Description nvarchar(max) null,
	SizeId int not null
)

create table PizzaSizes(
	Id int identity(1,1) primary key,
	[Name] nvarchar(50) not null
)

create table Toppings(
	Id int identity(1,1) primary key,
	[Name] nvarchar(100) not null,
	[Price] decimal(4,2) not null
)

create table Orders(
	Id int identity(1,1) primary key,
	UserId int not null,
	IsDelivered bit not null default 0,
	TotalPrice decimal(10,2) not null
)

create table OrderDetails(
	Id int identity(1,1) primary key,
	PizzaId int not null,
	OrderId int not null,
	Quantity int not null,
	Price decimal(10,2) not null --unit price
)

create table PizzaToppings(
	Id int identity(1,1) primary key,
	PizzaId int not null,
	ToppingId int not null
)

create table OrderDetailToppings(
	Id int identity(1,1) primary key,
	OrderDetailId int not null,
	ToppingId int not null
)

-----------------------------------
--FK Constraints
-----------------------------------


alter table Pizzas
add constraint FK_Pizzas_PizzaSizes
foreign key (SizeId) references PizzaSizes(Id)

alter table PizzaToppings
add constraint FK_PizzaToppings_Pizzas
foreign key (PizzaId) references Pizzas(Id)

alter table PizzaToppings
add constraint FK_PizzaToppings_Toppings
foreign key (ToppingId) references Toppings(Id)

alter table Orders
add constraint FK_Orders_Users
foreign key (UserId) references Users(Id)

alter table OrderDetails
add constraint FK_OrderDetails_Pizzas
foreign key (PizzaId) references Pizzas(Id)

alter table OrderDetails
add constraint FK_OrderDetails_Orders
foreign key (OrderId) references Orders(Id)

alter table OrderDetailToppings
add constraint FK_OrderDetailToppings_OrderDetails
foreign key (OrderDetailId) references OrderDetails(Id)

alter table OrderDetailToppings
add constraint FK_OrderDetailToppings_Toppings
foreign key (ToppingId) references Toppings(Id)


-----------------------------------
--FN to concatenate first and last name
-----------------------------------
go

create or alter function dbo.GetUserFullName
(
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
)
returns nvarchar(101) as
begin
	return concat(@FirstName, ' ', @LastName)
end
go


-----------------------------------
--VW Undelivered pizzas with user full names
-----------------------------------

create or alter view dbo.vw_UndeliveredPizzas as
select 
	o.Id as OrderId,
	dbo.GetUserFullName(u.FirstName, u.LastName) as UserFullName,
	p.[Name] as PizzaName,
	od.Quantity,
	od.Price as SingleItemPrice,
	od.Quantity * od.Price as TotalPrice
from Orders o
join Users u on o.UserId = u.Id
join OrderDetails od on o.Id = od.OrderId
join Pizzas p on od.PizzaId = p.Id
where o.IsDelivered = 0
go

select * from dbo.vw_UndeliveredPizzas
go


-----------------------------------
--VW Pizzas ordered by popularity
-----------------------------------

create or alter view dbo.vw_PizzasByPopularity as
select 
	p.Id as PizzaId,
	p.[Name] as PizzaName,
	sum(od.Quantity) as TotalOrdered
from OrderDetails od
join Pizzas p on od.PizzaId = p.Id
group by p.[Name], p.Id
having sum(od.Quantity) > 0
go

select * from dbo.vw_PizzasByPopularity
order by TotalOrdered desc
go


-----------------------------------
--Create a view:
--Toppings ordered by popularity
-----------------------------------
create or alter view dbo.vw_ToppingsByPopularity as
select 
	t.Id as ToppingId,
	t.[Name] as ToppingName,
	sum(od.Quantity) as TotalOrdered
from OrderDetailToppings odt
join Toppings t on odt.ToppingId = t.Id
join OrderDetails od on odt.OrderDetailId = od.Id
join Orders o on od.OrderId = o.Id
where o.IsDelivered = 1
group by t.[Name], t.Id
go

select * from dbo.vw_ToppingsByPopularity
order by TotalOrdered desc
go




-----------------------------------
--Create a view:
--Users and total pizzas they ordered
-----------------------------------
create or alter view dbo.vw_UsersTotalPizzasOrdered as
select u.Id as UserId,
	dbo.GetUserFullName(u.FirstName, u.LastName) as UserFullName,
	sum(od.Quantity) as TotalPizzasOrdered
from Users u
join Orders o on u.Id = o.UserId
join OrderDetails od on o.Id = od.OrderId
group by u.Id, u.FirstName, u.LastName
go

select * from dbo.vw_UsersTotalPizzasOrdered
order by TotalPizzasOrdered desc
go


