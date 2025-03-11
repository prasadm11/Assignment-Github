CREATE DATABASE InsuranceDB;


USE InsuranceDB;

CREATE TABLE Policies (
    PolicyID INT PRIMARY KEY,
    PolicyHolderName NVARCHAR(100) NOT NULL,
    PolicyType NVARCHAR(20) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL
);

SELECT * FROM Policies