CREATE TABLE IF NOT EXISTS "User"
(
    "Id" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Email" text COLLATE pg_catalog."default" NOT NULL,
    "IdentityId" text COLLATE pg_catalog."default",
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "IsActive" boolean NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);


CREATE TABLE IF NOT EXISTS "UserAddress"
(
    "Id" uuid NOT NULL,
    "Address" text COLLATE pg_catalog."default" NOT NULL,
    "City" text COLLATE pg_catalog."default" NOT NULL,
    "Country" text COLLATE pg_catalog."default" NOT NULL,
    "UserId" uuid NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "IsActive" boolean NOT NULL,
    CONSTRAINT "PK_UserAddress" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_UserAddress_User_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);
