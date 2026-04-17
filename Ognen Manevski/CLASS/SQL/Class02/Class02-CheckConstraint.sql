alter table Products_Test with check
	add constraint ChK_Products_Test_Price
	CHECK (Price >= 0); -- boolean

insert into Products_Test (Code, Name, Description, Weight, Price, Cost)
values
('P001', 'Product 1', 'Description for Product 1', 1.5, -10,  5.00);



alter table Products_Test with nocheck
	add constraint ChK_Products_Test_Name UNIQUE ([Name]);
