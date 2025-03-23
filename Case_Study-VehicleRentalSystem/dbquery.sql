use VehicleRentalDB


INSERT INTO Users (Name, Email, Password, Role) 
VALUES 
('John Doe', 'john.doe@example.com', 'password123', 'Admin'),
('Jane Smith', 'jane.smith@example.com', 'securepass', 'Customer'),
('Mike Johnson', 'mike.johnson@example.com', 'mypassword', 'Customer');

INSERT INTO Vehicles (Model, Brand, Type, RentalPricePerDay, IsAvailable) 
VALUES 
('Model X', 'Tesla', 'SUV', 100.00, 1),
('Civic', 'Honda', 'Sedan', 80.00, 1);

INSERT INTO Bookings (VehicleId, UserId, StartDate, EndDate, TotalAmount) 
VALUES 
(1, 3, '2025-04-01', '2025-04-05', 400.00),
(2, 1, '2025-04-10', '2025-04-15', 300.00);



select * from Bookings;
select * from Vehicles;
SELECT * FROM Vehicles;
