/*
	- This database are designed to track the supply at the clinic (in - out)
	someone from any departments can send a order to supply personnel to get the supplies that needed.
	- The personnel from supply department can order supply from third party, then input data to the system so they can track what they have
*/

USE master;
GO

-- Drop the database if it already exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'SupplyTracker')
BEGIN
    DROP DATABASE SupplyTracker;
END
GO

-- Create the new database
CREATE DATABASE SupplyTracker;
GO

-- Use the new database
USE SupplyTracker;
GO

-- Drop tables if they already exist
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NOT NULL DROP TABLE dbo.OrderDetail;
IF OBJECT_ID('dbo.[Orders]', 'U') IS NOT NULL DROP TABLE dbo.[Order];
IF OBJECT_ID('dbo.ShipmentDetails', 'U') IS NOT NULL DROP TABLE dbo.ShipmentDetail;
IF OBJECT_ID('dbo.Shipments', 'U') IS NOT NULL DROP TABLE dbo.Shipment;
IF OBJECT_ID('dbo.Inventory', 'U') IS NOT NULL DROP TABLE dbo.Inventory;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Product;
IF OBJECT_ID('dbo.Vendors', 'U') IS NOT NULL DROP TABLE dbo.Vendor;
IF OBJECT_ID('dbo.ProductCategories', 'U') IS NOT NULL DROP TABLE dbo.ProductCategory;
IF OBJECT_ID('dbo.[Users]', 'U') IS NOT NULL DROP TABLE dbo.[User];
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customer;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
GO

-- Create Departments table
CREATE TABLE Departments (
    DepartmentCode INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100)
);
GO

-- Create Customer table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DepartmentCode INT,
    PhoneNumber NVARCHAR(15),
    Position NVARCHAR(50),
    FOREIGN KEY (DepartmentCode) REFERENCES Departments(DepartmentCode)
);
GO

-- Create SupplyRequest table
CREATE TABLE SupplyRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    RequestorName NVARCHAR(100),
    DepartmentCode INT,
    DateOfRequest DATE,
    FOREIGN KEY (DepartmentCode) REFERENCES Departments(DepartmentCode)
);
GO

-- Create User table
CREATE TABLE [Users] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE,
    Password NVARCHAR(255),
    Role NVARCHAR(50),
    LastDateLogin DATETIME
);
GO

-- Create ProductCategory table
CREATE TABLE ProductCategories (
    ProductCategoryCode INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100),
    Purpose NVARCHAR(255)
);
GO

-- Create Vendor table
CREATE TABLE Vendors (
    VendorCode INT PRIMARY KEY IDENTITY(1,1),
    VendorName NVARCHAR(100),
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100)
);
GO

-- Create Product table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    LotNumber NVARCHAR(50),
    Price DECIMAL(10, 2),
    UnitOfSupply NVARCHAR(50),
	DateOfProduct DATE,
    DateOfExpire DATE,
    ProductCategoryCode INT,
    VendorCode INT,
    FOREIGN KEY (ProductCategoryCode) REFERENCES ProductCategories(ProductCategoryCode),
    FOREIGN KEY (VendorCode) REFERENCES Vendors(VendorCode)
);
GO

-- Create Inventory table
CREATE TABLE Inventories (
    InventoryID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    QuantityInStock INT,
    ReorderLevel INT,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

-- Create Shipment table
CREATE TABLE Shipments (
    ShipmentID INT PRIMARY KEY IDENTITY(1,1),
    VendorCode INT,
    ShipmentDate DATE,
    Status CHAR(1),
    FOREIGN KEY (VendorCode) REFERENCES Vendors(VendorCode)
);
GO

-- Create ShipmentDetail table
CREATE TABLE ShipmentDetails (
    ShipmentDetailID INT PRIMARY KEY IDENTITY(1,1),
    ShipmentID INT,
    ProductID INT,
    QuantityOrdered INT,
	QuantityReceived INT,
	QuantityLeft AS (QuantityOrdered - QuantityReceived),
    FOREIGN KEY (ShipmentID) REFERENCES Shipments(ShipmentID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

-- Create Order table
CREATE TABLE [Orders] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    VendorID INT,
    DateOfOrder DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (VendorID) REFERENCES Vendors(VendorCode)
);
GO

-- Create OrderDetail table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES [Orders](OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

-- Insert sample data into Departments table
INSERT INTO Departments (DepartmentName)
VALUES 
('Cardiology'),
('Pediatrics');
GO

-- Insert sample data into Customer table
INSERT INTO Customers (FirstName, LastName, DepartmentCode, PhoneNumber, Position)
VALUES 
('John', 'Doe', 01, '555-1234', 'Doctor'),
('Jane', 'Smith', 02, '555-5678', 'Nurse');
GO

-- Insert sample data into User table
INSERT INTO [Users] (Username, Password, Role, LastDateLogin)
VALUES 
('johndoe', 'password123', 'Admin', '2024-06-10'),
('janesmith', 'password456', 'User', '2024-06-11');
GO

-- Insert sample data into ProductCategory table
INSERT INTO ProductCategories (CategoryName, Purpose)
VALUES 
('Medication', 'Treatment'),
('Equipment', 'Medical Procedures');
GO

-- Insert sample data into Vendor table
INSERT INTO Vendors (VendorName, Address, PhoneNumber, Email)
VALUES 
('MedSupplies Co.', '123 Main St', '555-1010', 'contact@medsupplies.com'),
('HealthEquip Inc.', '456 Elm St', '555-2020', 'support@healthequip.com');
GO

-- Insert sample data into Product table
INSERT INTO Products (ProductName, LotNumber, Price, UnitOfSupply, DateOfProduct, DateOfExpire, ProductCategoryCode, VendorCode)
VALUES 
('Aspirin', 'L12345', 5.99, 'Bottle', '2024-01-01', '2025-01-01', 1, 1),
('Stethoscope', 'L67890', 99.99, 'Piece','2024-02-01', '2028-02-01', 2, 2);
GO

-- Insert sample data into Inventory table
INSERT INTO Inventories (ProductID, QuantityInStock, ReorderLevel)
VALUES 
(1, 100, 20),
(2, 50, 10);
GO

-- Insert sample data into Shipment table
INSERT INTO Shipments (VendorCode, ShipmentDate, Status)
VALUES 
(1, '2024-06-01', 'Z'),
(2, '2024-06-02', 'A');
GO

-- Insert sample data into ShipmentDetail table
INSERT INTO ShipmentDetails (ShipmentID, ProductID, QuantityOrdered, QuantityReceived)
VALUES 
(1, 1, 50, 50),
(2, 2, 25, 20);
GO

-- Insert sample data into Order table
INSERT INTO [Orders] (CustomerID, VendorID, DateOfOrder)
VALUES 
(1, 1, '2024-06-01'),
(2, 2, '2024-06-02');
GO

-- Insert sample data into OrderDetail table
INSERT INTO OrderDetails (OrderID, ProductID, Quantity)
VALUES 
(1, 1, 5),
(2, 2, 2);
GO

-- Insert sample data into SupplyRequest table
INSERT INTO SupplyRequests (RequestorName, DepartmentCode, DateOfRequest)
VALUES 
('John Doe', 01, '2024-06-01'),
('Jane Smith', 02, '2024-06-02');
GO
