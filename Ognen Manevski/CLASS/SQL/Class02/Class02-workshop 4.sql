--Set default price in Products table

alter table Products
	add constraint DF_Products_Price default 0 for Price;



--Prevent inserting price > 2x cost
alter table Products
	add constraint CK_Products_Price_Cost check (Price <= 2 * Cost);



--Ensure unique product names

alter table Products with check
	add constraint UC_Product_Name unique ([Name]);

