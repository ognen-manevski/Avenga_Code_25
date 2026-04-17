------------- Constraints -----------------

use [SEDC]
go

create table Products_Test(
	[Id] int IDENTITY (1,1) not null,
	[Code] nvarchar (50) null,
	[Name] nvarchar (100) null,
	[Description] nvarchar (max) null,
	[Weight] decimal (18,2) null, 
	[Price] decimal (18,2) not null constraint [DFT_Products_Price] DEFAULT (0),
	[Cost] decimal (18,2) null,
constraint [PK_Product_Test] primary key (Id)
)

insert into Products_Test (Code, Name, Description, Weight, Cost)
values
('P001', 'Product 1', 'Description for Product 1', 1.5,  5.00),
('P002', 'Product 2', 'Description for Product 2', 2.0,  10.00),
('P003', 'Product 3', 'Description for Product 3', 0.5,  2.50) -- Price will default to 0 due to the constraint

select * from Products_Test

alter table Products_Test WITH CHECK
add constraint Products_test_Code_Unique UNIQUE (Code); -- Adding a unique constraint to the Code column

insert into Products_Test (Code, Name, Description, Weight, Cost)
values
('P001', 'Product 1', 'Description for Product 1', 1.5,  5.00);

--default constraint for weight

alter table Products_Test
	add constraint [DF_Products_Test_Weight]
	default (100) for [Weight];

insert into Products_Test (Code, Name, Description, Cost)
values
('P001', 'Product 1', 'Description for Product 1',  5.00);