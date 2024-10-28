CREATE TABLE
    IF NOT EXISTS "Category" (
        "Id" UUID PRIMARY KEY,
        "ParentCategoryId" UUID REFERENCES "Category" ("Id"),
        "Name" VARCHAR(255) NOT NULL,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "User" (
        "Id" UUID PRIMARY KEY,
        "Name" VARCHAR(255) NOT NULL,
        "Email" VARCHAR(255) UNIQUE NOT NULL,
        "IdentityId" VARCHAR(255) NOT NULL,
        "UserType" INTEGER NOT NULL,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "Product" (
        "Id" UUID PRIMARY KEY,
        "Name" VARCHAR(255) NOT NULL,
        "Description" TEXT,
        "Price" NUMERIC(10, 2) NOT NULL,
        "Stock" INTEGER NOT NULL DEFAULT 0,
        "AlcoholPercentage" DOUBLE PRECISION DEFAULT 0,
        "Brand" VARCHAR(255),
        "Volume" DOUBLE PRECISION,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "Image" (
        "Id" UUID PRIMARY KEY,
        "ProductId" UUID REFERENCES "Product" ("Id"),
        "AltText" VARCHAR(255),
        "Url" VARCHAR(355) NOT NULL,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "UserAddress" (
        "Id" UUID PRIMARY KEY,
        "UserId" UUID REFERENCES "User" ("Id"),
        "Address" VARCHAR(255) NOT NULL,
        "City" VARCHAR(100) NOT NULL,
        "Country" VARCHAR(100) NOT NULL,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "CategoryProduct" (
        "CategoriesId" UUID NOT NULL REFERENCES "Category" ("Id"),
        "ProductsId" UUID NOT NULL REFERENCES "Product" ("Id"),
        PRIMARY KEY ("CategoriesId", "ProductsId")
    );

CREATE TABLE
    IF NOT EXISTS "Order" (
        "Id" UUID PRIMARY KEY,
        "UserId" UUID REFERENCES "User" ("Id"),
        "OrderDate" TIMESTAMP
        WITH
            TIME ZONE,
            "OrderStatus" INTEGER,
            "TotalPrice" DOUBLE PRECISION,
            "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
            "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "OrderItem" (
        "Id" UUID PRIMARY KEY,
        "OrderId" UUID REFERENCES "Order" ("Id"),
        "ProductId" UUID REFERENCES "Product" ("Id"),
        "Quantity" INTEGER,
        "UnitPrice" DOUBLE PRECISION,
        "DiscountPercent" INTEGER,
        "TotalPrice" DOUBLE PRECISION,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "PaymentTransaction" (
        "Id" UUID PRIMARY KEY,
        "OrderId" UUID REFERENCES "Order" ("Id"),
        "PaymentMethod" INTEGER,
        "TransactionOrderStatus" INTEGER,
        "Amount" DOUBLE PRECISION,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "Combo" (
        "Id" UUID PRIMARY KEY,
        "Name" VARCHAR(255) NOT NULL,
        "Description" TEXT NOT NULL,
        "Price" NUMERIC(10, 2) NOT NULL,
        "Discount" INTEGER,
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone
    );

CREATE TABLE
    IF NOT EXISTS "ProductCombo" (
        "ComboId" UUID NOT NULL REFERENCES "Combo" ("Id"),
        "ProductId" UUID NOT NULL REFERENCES "Product" ("Id"),
        "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
        "CreatedAt" TIMESTAMP
        with
            time zone DEFAULT CURRENT_TIMESTAMP,
            "UpdatedAt" TIMESTAMP
        with
            time zone,
            PRIMARY KEY ("ComboId", "ProductId")
    );
