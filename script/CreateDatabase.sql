CREATE TABLE Customers 
(
    CustomerID int IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(255),
    PhoneNumber NVARCHAR(15),
    CreateAt DATETIME
)

CREATE TABLE ComicBooks 
(
    ComicBookID int IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255),
    Author NVARCHAR(255),
    PricePerDay DECIMAL(10,2)
)

CREATE TABLE Rentals
(
    RentalID int IDENTITY(1,1) PRIMARY KEY,
    CustomerID int ,
    RentalDate DATETIME,
    ReturnDate DATETIME,
    Status NVARCHAR(50)
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE RentalDetails
(
    RetailDetailID int IDENTITY(1,1) PRIMARY KEY,
    RentalID int,
    ComicBookID int,
    Quantity int,
    PricePerDay DECIMAL(10,2),
    FOREIGN KEY (RentalID) REFERENCES Rentals(RentalID),
    FOREIGN KEY (ComicBookID) REFERENCES ComicBooks(ComicBookID)
)