--Select
select * from Customers

Select ContactName,CompanyName, City from Customers

Select * from Customers Where City = 'London'

Select * from Products Where CategoryId = 1

-- Group By

Select * from Products Order By ProductName Desc

Select Count(*) Adet from Products Where CategoryId= 2

Select Count(*) ProductSpecies, CategoryId from Products Where UnitPrice > 20
Group By CategoryId Having Count(*) < 10