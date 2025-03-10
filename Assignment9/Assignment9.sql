CREATE DATABASE BookStoreDB;
USE BookStoreDB;


CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY, 
    Name VARCHAR(100) NOT NULL, 
    Country VARCHAR(50) NOT NULL
);

INSERT INTO Authors VALUES(1,'Ravi','India'),
(2,'Rakesh','India'),
(3,'Rushi','USA'),
(4,'Alice','Japan'),
(5,'Paulo','Brazil')


CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    AuthorID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0), 
    PublishedYear INT NOT NULL CHECK (PublishedYear >= 1500 AND PublishedYear <= YEAR(GETDATE())), 
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID) ON DELETE CASCADE
);

INSERT INTO Books VALUES
(1, 'The Power of Subconcious Mind', 1, 1999.99, 1997),
(2, 'The Real Gem', 2, 2400.50, 1996),
(3, 'The Katha', 3, 1800.00, 1977),
(4, 'The Robert Hook', 4, 1700.75, 1988),
(5, 'SQL Mastery', 5, 3000.00, 2021);


CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL, 
    PhoneNumber VARCHAR(15) UNIQUE NOT NULL 
);
INSERT INTO Customers (CustomerID, Name, Email, PhoneNumber) VALUES
(1, 'Ramesh Parkhar', 'rp@email.com', '1234567890'),
(2, 'Bob Danj', 'bob@email.com', '0987654321'),
(3, 'Rownie Das', 'RD@email.com', '1112223333'),
(4, 'Prakash Charba', 'david@email.com', '4445556666'),
(5, 'Dhanush Parkhar', 'eve@email.com', '7778889999');


CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATE NOT NULL DEFAULT GETDATE(), 
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE
);
INSERT INTO Orders VALUES
(1, 1, '2024-03-01', 5000.99),
(2, 2, '2024-03-02', 2500.50),
(3, 3, '2024-03-03', 1800.00),
(4, 4, '2024-03-04', 1700.75),
(5, 1, '2024-03-05', 3000.00);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY,
    OrderID INT NOT NULL,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0), 
    SubTotal DECIMAL(10,2) NOT NULL CHECK (SubTotal >= 0), 
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (BookID) REFERENCES Books(BookID) ON DELETE CASCADE
);
INSERT INTO OrderItems (OrderItemID, OrderID, BookID, Quantity, SubTotal) VALUES
(1, 1, 1, 1, 1999.99),
(2, 2, 2, 1, 2500.50),
(3, 3, 3, 1, 1800.00),
(4, 4, 4, 1, 1700.75),
(5, 5, 5, 1, 3000.00);

--select all from all tables
select * from Authors
select * from Books
select * from Customers
select * from Orders
select * from OrderItems


--DML
--update price by 10% 
UPDATE Books SET Price = Price * 1.10 WHERE Title = 'SQL Mastery'
select * from Books

DELETE FROM Customers WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders)


--Operators
select * from Books
select * from Books WHERE Price>2000

SELECT COUNT(BookID) FROM Books

SELECT PublishedYear FROM Books WHERE PublishedYear BETWEEN 2015 AND 2023

--cust who placed at least 1 order
select * from Customers
select * FROM Orders

SELECT DISTINCT Customers.* FROM Customers JOIN Orders ON Customers.CustomerID=Orders.OrderID;

SELECT * FROM Books WHERE Title LIKE 'SQL%'

SELECT MAX(Price) FROM Books

SELECT Customers.* FROM Customers WHERE Name LIKE 'A%' OR Name LIKE '%J' 

select sum(TotalAmount) as TotalRevenue from Orders 



--Joins
SELECT * FROM Authors
SELECT * FROM Books
SELECT Books.Title, Authors.Name AS AuthorName FROM Books JOIN Authors ON Books.AuthorID = Authors.AuthorID

SELECT Books.* FROM Books LEFT JOIN OrderItems ON Books.BookID = OrderItems.BookID WHERE OrderItems.BookID IS NULL

SELECT Customers.Name , Orders.OrderID FROM Customers LEFT JOIN Orders ON Customers.CustomerID=Orders.CustomerID

SELECT Customers.Name, COUNT(Orders.OrderID) AS OrderCount FROM Customers LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID GROUP BY Customers.Name;

SELECT Books.Title, OrderItems.Quantity FROM OrderItems JOIN Books ON OrderItems.BookID = Books.BookID

SELECT Customers.Name, Orders.OrderID FROM Customers LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID

SELECT Authors.* FROM Authors LEFT JOIN Books ON Authors.AuthorID = Books.AuthorID WHERE Books.AuthorID IS NULL










