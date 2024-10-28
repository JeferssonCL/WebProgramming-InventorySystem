CREATE TABLE IF NOT EXISTS "Category" (
    "Id" UUID PRIMARY KEY,
    "ParentCategoryId" UUID REFERENCES "Category"("Id"),
    "Name" VARCHAR(255) NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP  with time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP  with time zone
);

CREATE TABLE IF NOT EXISTS "User" (
    "Id" UUID PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Email" VARCHAR(255) UNIQUE NOT NULL,
    "IdentityId" VARCHAR(255) NOT NULL,
    "UserType" INTEGER NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP  with time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP  with time zone
);


CREATE TABLE IF NOT EXISTS "Product"
(
    "Id" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default" NOT NULL,
    "Price" double precision NOT NULL,
    "Stock" integer NOT NULL,
    "AlcoholPercentage" DOUBLE PRECISION,
    "Volume" VARCHAR(50),
    "Brand" text COLLATE pg_catalog."default" NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "IsActive" boolean NOT NULL,
    CONSTRAINT "PK_Product" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Product_Store_StoreId" FOREIGN KEY ("StoreId")
        REFERENCES public."Store" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "Combo"
(
    "Id" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default" NOT NULL,
    "Price" double precision NOT NULL,
    "DiscountPercent" integer NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "IsActive" boolean NOT NULL,
    CONSTRAINT "PK_Combo" PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS "ComboProduct"
(
    "CombosId" uuid NOT NULL,
    "ProductsId" uuid NOT NULL,
    CONSTRAINT "PK_ComboProduct" PRIMARY KEY ("CombosId", "ProductsId"),
    CONSTRAINT "FK_ComboProduct_Combo_CombosId" FOREIGN KEY ("CombosId")
        REFERENCES public."Combo" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_ComboProduct_Product_ProductsId" FOREIGN KEY ("ProductsId")
        REFERENCES public."Product" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "Image" (
    "Id" UUID PRIMARY KEY,
    "ProductId" UUID REFERENCES "Product"("Id"),
    "AltText" VARCHAR(255),
    "Url" VARCHAR(355) NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP  with time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP  with time zone
);

CREATE TABLE IF NOT EXISTS "UserAddress" (
    "Id" UUID PRIMARY KEY,
    "UserId" UUID REFERENCES "User"("Id"),
    "Address" VARCHAR(255) NOT NULL,
    "City" VARCHAR(100) NOT NULL,
    "Country" VARCHAR(100) NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP  with time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP  with time zone
);

CREATE TABLE IF NOT EXISTS "CategoryProduct" (
    "CategoriesId" UUID NOT NULL REFERENCES "Category"("Id"),
    "ProductsId" UUID NOT NULL REFERENCES "Product"("Id"),
    PRIMARY KEY ("CategoriesId", "ProductsId")
);


CREATE TABLE IF NOT EXISTS "Order"
(
    "Id" UUID PRIMARY KEY,
    "UserId" UUID REFERENCES "User"("Id"),
    "OrderDate" TIMESTAMP WITH TIME ZONE,
    "OrderStatus" INTEGER,
    "TotalPrice" DOUBLE PRECISION,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP  with time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP  with time zone
);

CREATE TABLE IF NOT EXISTS "OrderItem"
(
    "Id" UUID PRIMARY KEY,
    "OrderId" UUID REFERENCES "Order"("Id"),
    "ProductId" UUID REFERENCES "Product"("Id"),
    "Quantity" INTEGER,
    "UnitPrice" DOUBLE PRECISION,
    "DiscountPercent" INTEGER ,
    "TotalPrice" DOUBLE PRECISION,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP  with time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP  with time zone
);

CREATE TABLE IF NOT EXISTS "PaymentTransaction"
(
    "Id" UUID PRIMARY KEY,
    "OrderId" UUID REFERENCES "Order"("Id"),
    "PaymentMethod" INTEGER,
    "TransactionOrderStatus" INTEGER,
    "Amount" DOUBLE PRECISION,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP  with time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP  with time zone
);
