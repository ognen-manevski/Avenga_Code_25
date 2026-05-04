use [SEDC-2]
go

-- example 1 : get employees by gender and their count

select * from [dbo].[Employees]
go


CREATE OR ALTER procedure [dbo].[usp_GetEmployeesByGender]
(
    @Gender nchar(1) = 'M', --default
    @GenderCount int output
)
as
begin
    select @GenderCount = count(Id)
    from [dbo].[employees] e
    where e.Gender = @Gender
end
go

declare @GenderCountResult int

execute [dbo].[usp_GetEmployeesByGender] @Gender = 'F', @GenderCount = @GenderCountResult output

select @GenderCountResult 
go

-- ex2: find product details for specific product (by name)
-- return the product price and total quantity of the ordered items for the product

select * from [dbo].[Products]
select * from [dbo].[OrderDetails]
go

create or alter procedure [dbo].[usp_GetProductDetailsByName]
(
    @ProductName nvarchar(100),
    @ProductPrice decimal(18,2) output,
    @TotalQuantity int output
)
as
begin
    -- select the product details
    select
        p.[Name] as ProductName,
        p.[Description] as ProductDescription,
        p.[Price] as ProductPrice
    from [dbo].[Products] p
    where p.[Name] = @ProductName

    -- set product price output
    select @ProductPrice = p.[Price]
    from [dbo].[Products] p
    where p.[Name] = @ProductName

    -- set quantity output
    select @TotalQuantity = od.Quantity
    from [dbo].[Products] p
    join [dbo].[OrderDetails] od
    on p.Id = od.ProductId
    where p.[Name] = @ProductName
end
go

declare @ProductPrice decimal(18,2), @TotalQuantityResult int, @TotalPrice decimal(18,2)

execute [dbo].[usp_GetProductDetailsByName]
    'Crunchy',
    @ProductPrice = @ProductPrice output,
    @TotalQuantity = @TotalQuantityResult output

set @TotalPrice = @ProductPrice * @TotalQuantityResult

select @ProductPrice as 'Price of the product',
ISNULL(@TotalQuantityResult, 0) as 'Total quantity', --if is null return 0
@TotalPrice as 'Total price'
go

