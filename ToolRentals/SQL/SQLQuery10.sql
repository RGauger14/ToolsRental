
SELECT Rental.DateRented AS 'Date Rented', Customer.CustomerName AS 'Customer', CONCAT(Tools.ToolName, ' (', Tools.ToolBrand, ')') AS 'Tool', Rental.DateReturned AS 'Date Returned'
FROM Customer INNER JOIN
Rental ON Rental.CustomerId = Customer.CustomerId INNER JOIN
RentalItems ON Rental.RentalId = RentalItems.RentalId INNER JOIN
Tools ON RentalItems.ToolId = Tools.ToolId
WHERE Rental.DateRented <= '2020-05-21'
ORDER BY DateRented DESC
