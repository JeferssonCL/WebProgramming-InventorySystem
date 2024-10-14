CREATE TABLE Category (
    Id UUID PRIMARY KEY,
    ParentCategoryId UUID REFERENCES Category(Id),
    Name VARCHAR(255) NOT NULL,
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE "User" (
    Id UUID PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    UserType INTEGER NOT NULL,
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Store (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES "User"(Id),
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Address VARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(15),
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Product (
    Id UUID PRIMARY KEY,
    StoreId UUID REFERENCES Store(Id),
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Price NUMERIC(10, 2) NOT NULL,
    Brand VARCHAR(255),
    StockQuantity INTEGER NOT NULL,
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE "Image" (
    Id UUID PRIMARY KEY,
    ProductId UUID REFERENCES Product(Id),
    AltText VARCHAR(255),
    Url VARCHAR(355) NOT NULL,
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Variant (
    Id UUID PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE ProductAttribute (
    Id UUID PRIMARY KEY,
    ImageId UUID REFERENCES "Image"(Id),
    ProductId UUID REFERENCES Product(Id),
    VariantId UUID REFERENCES Variant(Id),
    Value VARCHAR(255) NOT NULL,
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE UserAddress (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES "User"(Id),
    Address VARCHAR(255) NOT NULL,
    City VARCHAR(100) NOT NULL,
    Country VARCHAR(100) NOT NULL,
    Latitude DECIMAL(9, 6),
    Longitude DECIMAL(9, 6),
    AddressType VARCHAR(50) NOT NULL,
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP
);

CREATE TABLE CategoryProduct (
    CategoriesId UUID REFERENCES Category(Id),
    ProductsId UUID REFERENCES Product(Id),
    PRIMARY KEY (CategoriesId, ProductsId)
);