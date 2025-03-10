USE BookStoreDB;

select * from Authors
select * from Books
select * from Customers
select * from Orders
select * from OrderItems

--Subqueries
SELECT CustomerID FROM Orders WHERE OrderDate = (SELECT MIN(OrderDate) FROM Orders)

SELECT CustomerID, COUNT(*) AS OrderCount FROM Orders GROUP BY CustomerID HAVING COUNT(*) = (SELECT MAX(OrderCount) FROM (SELECT COUNT(*) AS OrderCount FROM Orders GROUP BY CustomerID) AS OrderCounts)

SELECT * FROM Customers 
WHERE CustomerID NOT IN (SELECT CustomerID FROM Orders)

SELECT * FROM Books WHERE Price < (SELECT MAX(Price) FROM Books)

SELECT * FROM Customers WHERE CustomerID IN (SELECT CustomerID FROM Orders GROUP BY CustomerID HAVING SUM(TotalAmount) > (SELECT AVG(TotalAmount) FROM Orders))

--stored procedure

CREATE PROCEDURE GetOrdersByCustomer @CustomerID INT AS BEGIN
SELECT * FROM Orders WHERE CustomerID = @CustomerID END;

exec GetOrdersByCustomer @CustomerID=1;


CREATE PROCEDURE GetBooksByPriceRange
    @MinPrice DECIMAL(10,2),
    @MaxPrice DECIMAL(10,2)
AS BEGIN
SELECT * FROM Books WHERE Price BETWEEN @MinPrice AND @MaxPrice END;

SELECT * FROM Books
ALTER TABLE Books ADD Stocks INT
UPDATE Books SET Stocks=12 WHERE BookID=1
UPDATE  Books SET Stocks=2 WHERE BookID=2
UPDATE  Books SET Stocks=0 WHERE BookID=3
UPDATE  Books SET Stocks=5 WHERE BookID=4
UPDATE  Books SET Stocks=0 WHERE BookID=5




CREATE VIEW AvailableBooks AS
SELECT BookID, Title, AuthorID, Price FROM Books
WHERE Stocks > 0

SELECT * FROM AvailableBooks