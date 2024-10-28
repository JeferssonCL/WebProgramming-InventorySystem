-- Insert Categories
INSERT INTO
    "Category" (
        "Id",
        "ParentCategoryId",
        "Name",
        "IsActive",
        "CreatedAt",
        "UpdatedAt"
    )
VALUES
    -- Beers and Subcategories
    (
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        NULL,
        'Beers',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '1fe140b5-7133-4d9b-92b6-87038dde690b',
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        'Lager',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '82c596e3-d2d2-48b2-9f6a-1cfd8b21d8b1',
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        'Pilsner',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'f4c7d64a-6c5e-4a3d-bde5-1c689d918b8a',
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        'Ale',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'e373bf32-7b9d-4a10-9e8f-3f22f9be7b5b',
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        'Stout and Porter',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '2b7e0175-bf7d-403b-8d7b-d8d67456a2a5',
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        'Craft',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    -- Wines and Subcategories
    (
        '05563658-5b6d-4022-8920-d3a2784b2033',
        NULL,
        'Wines',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '27e46b32-dbe4-48a8-b377-d6b8418ef0bb',
        '05563658-5b6d-4022-8920-d3a2784b2033',
        'Red',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'cdef417f-2af8-46f2-981e-9a4697e1d8cd',
        '05563658-5b6d-4022-8920-d3a2784b2033',
        'White',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'f7b51cf1-7f28-4c2a-8334-23d3ea39d4cd',
        '05563658-5b6d-4022-8920-d3a2784b2033',
        'Rosé',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '3e2f6e2d-8d9d-4baf-b4fe-8c00e3454e1f',
        '05563658-5b6d-4022-8920-d3a2784b2033',
        'Sparkling',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'bc5a6d4f-8c84-4233-bd26-1f9b5d734fbb',
        '05563658-5b6d-4022-8920-d3a2784b2033',
        'Fortified',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    -- Spirits and Subcategories
    (
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        NULL,
        'Spirits',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '27d4e847-98f8-42e2-b2ff-9eabe2839c60',
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        'Whiskey',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'd2a2a1c5-9f9d-411f-9274-e0f684ed1db1',
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        'Vodka',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'a0e1b7f4-df29-4e3a-bb2e-c5bc1df0569e',
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        'Rum',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'b5f3a947-4a41-4e99-8374-8cf707d5f57d',
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        'Tequila',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '6c2b9b35-5b96-4a5b-9f42-7d5c4749e62f',
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        'Gin',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '1a4b5f3c-d42f-4b35-bb6f-d6f789ac73b7',
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        'Brandy and Cognac',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    -- Liqueurs and Subcategories
    (
        'c5f76b16-5662-42b3-841e-1378638440e6',
        NULL,
        'Liqueurs',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'fa4b9a1e-cdf9-4d27-8f72-1f2e9c8b5c1a',
        'c5f76b16-5662-42b3-841e-1378638440e6',
        'Bitters',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '3a69e5b2-4c8a-42e2-9e24-5f91a2b8e99c',
        'c5f76b16-5662-42b3-841e-1378638440e6',
        'Fruit Liqueurs',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'bb438d5e-fb37-4a27-8cbe-9f4d287fc64a',
        'c5f76b16-5662-42b3-841e-1378638440e6',
        'Cream Liqueurs',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    -- Cocktails and Subcategories
    (
        '8a6c5bd6-5439-4011-b546-c9fbb5a6efb9',
        NULL,
        'Cocktails',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '38b7c6f2-df7e-4fa2-8d94-d5a7cfcb93b5',
        '8a6c5bd6-5439-4011-b546-c9fbb5a6efb9',
        'Margaritas',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'e7d2d347-9b9b-46a6-9d6b-81b7a3b89465',
        '8a6c5bd6-5439-4011-b546-c9fbb5a6efb9',
        'Mojitos',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '28d2c4a1-6a5d-4fb4-b8be-c7d7a6cbb53c',
        '8a6c5bd6-5439-4011-b546-c9fbb5a6efb9',
        'Piña Colada',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '4e2c7c9f-5a9f-44a9-bd4b-1d4d728ca6a3',
        '8a6c5bd6-5439-4011-b546-c9fbb5a6efb9',
        'Aperitifs',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    -- Non alcoholic
    (
        'b1f3e5d2-8c9e-4b89-920f-7314d4b9a3a2',
        NULL,
        'Non-Alcoholic Beverages',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '13e8fb28-8fab-4c2f-b5e7-48b5bd43f624',
        'b1f3e5d2-8c9e-4b89-920f-7314d4b9a3a2',
        'Sodas',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '5d04716c-cfdf-4f52-9855-acfeb23f6449',
        'b1f3e5d2-8c9e-4b89-920f-7314d4b9a3a2',
        'Waters',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '106b3d2b-a416-4a23-9632-928a44a99228',
        'b1f3e5d2-8c9e-4b89-920f-7314d4b9a3a2',
        'Juices',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '88ffbfa6-52bb-47c6-85e1-9a842fedb243',
        'b1f3e5d2-8c9e-4b89-920f-7314d4b9a3a2',
        'Energy Drinks',
        true,
        CURRENT_TIMESTAMP,
        NULL
    );

INSERT INTO
    "User" (
        "Id",
        "Name",
        "Email",
        "IdentityId",
        "UserType",
        "IsActive",
        "CreatedAt",
        "UpdatedAt"
    )
VALUES
    (
        'c4055860-c902-4787-ba54-0b34e18a1040',
        'Jefersson Coronel',
        'jefersoncoronel700@gmail.com',
        'password123',
        0,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'e8489e3b-c12c-4197-8bc1-dac21bc6e82f',
        'Karina Aguirre',
        'karina123@gmail.com',
        'password123',
        3,
        true,
        CURRENT_TIMESTAMP,
        NULL
    );

INSERT INTO
    "Product" (
        "Id",
        "Name",
        "Description",
        "Price",
        "Stock",
        "AlcoholPercentage",
        "Brand",
        "Volume",
        "IsActive",
        "CreatedAt",
        "UpdatedAt"
    )
VALUES
    -- Non-Alcoholic
    (
        'b7f8461c-38a5-4d2a-b719-830592b268a5',
        'Pepsi',
        'Classic cola soft drink',
        12,
        100,
        0,
        'Pepsi',
        500,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '13c45b8e-8e5f-4673-9d89-3b2452c9d91d',
        'Coca-Cola',
        'Carbonated soft drink',
        12,
        100,
        0,
        'Coca-Cola',
        500,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '89eeb09a-3fda-4e4b-bbe1-6c0d9a69e96e',
        'Mountain Dew',
        'Citrus-flavored soft drink',
        10,
        80,
        0,
        'Mountain Dew',
        500,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '8db8e9a5-3c2f-4a27-87bb-293f41ec198b',
        'Aquafina',
        'Purified bottled water',
        8,
        200,
        0,
        'Aquafina',
        600,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'edc97824-9f3b-4e82-8e79-34e7c93fda4f',
        'Minute Maid Orange Juice',
        '100% pure orange juice',
        15,
        150,
        0,
        'Minute Maid',
        450,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    -- Alcoholic
    (
        '20e9a0df-d1b2-4c6f-8e3d-b324b2b92d7a',
        'Heineken',
        'Dutch pale lager beer',
        20,
        120,
        5,
        'Heineken',
        330,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '08fa3c5d-6f5e-4d21-bac3-1abfe147d7b6',
        'Jack Daniels',
        'Tennessee whiskey',
        45,
        75,
        40,
        'Jack Daniels',
        750,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '32cfa947-f2db-4a83-bf27-3c7d9f9d06c9',
        'Grey Goose',
        'Premium French vodka',
        60,
        60,
        40,
        'Grey Goose',
        700,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'a7d6ef01-ef88-4418-b84d-44e6a9e9d19d',
        'Baileys Irish Cream',
        'Cream-based liqueur',
        30,
        50,
        17,
        'Baileys',
        750,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '6f9a293b-2a65-4a9b-8217-b21f19353df8',
        'Corona Extra',
        'Mexican pale lager',
        18,
        140,
        4.6,
        'Corona',
        355,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '9bd4fe4e-5e8b-4e8f-9d45-d5f43be798d6',
        'Moët & Chandon',
        'Champagne',
        90,
        30,
        12,
        'Moët & Chandon',
        750,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '5b2df2d4-56a4-45e5-a2b8-e3db601ca28f',
        'Smirnoff Ice',
        'Flavored malt beverage',
        25,
        90,
        4.5,
        'Smirnoff',
        330,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '2b3b6c0e-4f88-4b97-a8a1-506ff2bc26af',
        'Captain Morgan',
        'Caribbean rum with spices',
        40,
        70,
        35,
        'Captain Morgan',
        750,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '8f0a629e-b6ec-4dd4-9f68-2b18a62d8c1e',
        'Patrón Silver',
        'Premium tequila',
        75,
        40,
        40,
        'Patrón',
        750,
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '4ac4c10b-5406-49b8-98bc-841c94cf93a3',
        'Hennessy VS',
        'Cognac',
        55,
        65,
        40,
        'Hennessy',
        700,
        true,
        CURRENT_TIMESTAMP,
        NULL
    );

INSERT INTO
    "Image" (
        "Id",
        "ProductId",
        "AltText",
        "Url",
        "IsActive",
        "CreatedAt",
        "UpdatedAt"
    )
VALUES
    (
        'a389e63d-322f-4fae-a94a-7ec313522b9e',
        'b7f8461c-38a5-4d2a-b719-830592b268a5',
        'Pepsi image',
        'https://i.postimg.cc/j208Qd2M/download.jpg',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '8b12f497-ec6a-4c6a-813a-4dfcca6f946b',
        '13c45b8e-8e5f-4673-9d89-3b2452c9d91d',
        'Coca Cola image',
        'https://i.postimg.cc/hP0CTnB0/df3f957f-2bf8-46cd-b4d7-100537bf55b7-107cd909-4796-4c68-95af-323e378461e4.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '0ff06aa1-2c8c-4361-ba98-11368e324454',
        '89eeb09a-3fda-4e4b-bbe1-6c0d9a69e96e',
        'Mountain Dew image',
        'https://i.postimg.cc/DwjBpcmJ/c91cc27d-61a8-4cc7-be8c-52f09180bd02-1-c976b9c0ead012567b3d3bd8be7efe7c.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '52427ca0-6b26-4087-9825-3a15e9bae35c',
        '8db8e9a5-3c2f-4a27-87bb-293f41ec198b',
        'Aquafina image',
        'https://i.postimg.cc/bvZL7226/100021123-7-aquafina-packaged-drinking-water.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '1fbb3a78-e7f0-4153-b3d2-0f39dbfca0f9',
        'edc97824-9f3b-4e82-8e79-34e7c93fda4f',
        'Minute Maid Orange Juice image',
        'https://i.postimg.cc/TPBQfYVT/Minute-Maid-100-Orange-Juice-Beverage-450-m-L-6ff04a24-6c0a-455f-9771-9463b1fda6ce-1-245e9522e31d6a36.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '69a36e7a-131d-45b7-8800-2b684ac002b6',
        '20e9a0df-d1b2-4c6f-8e3d-b324b2b92d7a',
        'Heineken image',
        'https://i.postimg.cc/k48s43sK/heineken-pint-330ml-476443-1200x1200.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '988b615b-20dd-4200-acee-f3c27cfd62e3',
        '08fa3c5d-6f5e-4d21-bac3-1abfe147d7b6',
        'Jack Daniels image',
        'https://i.postimg.cc/hvtXYVXv/photo-1521201795527-a80e2debb4c8.avif',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'f78bf348-fdf0-4fd6-9f4a-7d15b2d75f48',
        '32cfa947-f2db-4a83-bf27-3c7d9f9d06c9',
        'Grey Goose image',
        'https://i.postimg.cc/3Nz3ZGpP/image-9b9da7d3-3787-4914-a4f4-3a8582e1ff48-600x.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '00d68077-388c-4940-b8ce-b1c5898851c6',
        'a7d6ef01-ef88-4418-b84d-44e6a9e9d19d',
        'Baileys Irish Cream image',
        'https://i.postimg.cc/hjfjbc6Q/images.jpg',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'fff48fd4-a939-4956-bc57-67ace0e42b27',
        '6f9a293b-2a65-4a9b-8217-b21f19353df8',
        'Corona Extra image',
        'https://i.postimg.cc/L5FpYSpp/00-D92-FCB-5482-46-A6-9906-5-D3896-A404-EC.jpg',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '032d55c0-5436-45b2-8e25-54b2ad22b6aa',
        '9bd4fe4e-5e8b-4e8f-9d45-d5f43be798d6',
        'Moët & Chandon image',
        'https://i.postimg.cc/2jGcBmm7/2a0ee211-13cf-4b6b-aaa0-c710b8a36d90.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'a0cd835b-0fa3-490e-bec4-1e07e5320586',
        '5b2df2d4-56a4-45e5-a2b8-e3db601ca28f',
        'Smirnoff Ice image',
        'https://i.postimg.cc/HL14hPdL/0008200072569.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '4f58c7a6-a4dc-4085-8d9e-a4d8ba4b50bb',
        '2b3b6c0e-4f88-4b97-a8a1-506ff2bc26af',
        'Captain Morgan image',
        'https://i.postimg.cc/L6rzJ0qV/68e9bccc045554f91a612ee9b1279b26.jpg',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        'adb707a9-0645-421c-a4a2-2e474bff1fc1',
        '8f0a629e-b6ec-4dd4-9f68-2b18a62d8c1e',
        'Patrón Silver image',
        'https://i.postimg.cc/hvXdj9cw/Patron-Silver-Tequila-40-ABV-750-ml-Bottle-25164305-31d3-486a-b2ac-0bee35c731aa-5440134119a2b08155c2.avif',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '6ac157ca-e38f-41f9-bf8e-05bc42608b81',
        '4ac4c10b-5406-49b8-98bc-841c94cf93a3',
        ' image',
        'https://i.postimg.cc/fT0dQjHS/Hennessy-VS-no-box-image-983x700.webp',
        true,
        CURRENT_TIMESTAMP,
        NULL
    );

INSERT INTO
    "UserAddress" (
        "Id",
        "UserId",
        "Address",
        "City",
        "Country",
        "IsActive",
        "CreatedAt",
        "UpdatedAt"
    )
VALUES
    (
        '945ff41a-fd1d-431b-9a70-2ae6f1a9ec08',
        'c4055860-c902-4787-ba54-0b34e18a1040',
        '123 Main St',
        'Los Angeles',
        'USA',
        true,
        CURRENT_TIMESTAMP,
        NULL
    ),
    (
        '83249fea-26a9-4de8-9e2b-a14cf7969d81',
        'e8489e3b-c12c-4197-8bc1-dac21bc6e82f',
        '456 Elm St',
        'New York',
        'USA',
        true,
        CURRENT_TIMESTAMP,
        NULL
    );

INSERT INTO
    "CategoryProduct" ("CategoriesId", "ProductsId")
VALUES
    -- Beers Category
    (
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        '20e9a0df-d1b2-4c6f-8e3d-b324b2b92d7a'
    ), -- Heineken
    (
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        '6f9a293b-2a65-4a9b-8217-b21f19353df8'
    ), -- Corona Extra
    (
        '4e5cb421-968e-4f85-b654-a96e0ab0e3f0',
        '5b2df2d4-56a4-45e5-a2b8-e3db601ca28f'
    ), -- Smirnoff Ice
    -- Wines Category
    (
        '05563658-5b6d-4022-8920-d3a2784b2033',
        '9bd4fe4e-5e8b-4e8f-9d45-d5f43be798d6'
    ), -- Moët & Chandon
    -- Spirits Category
    (
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        '08fa3c5d-6f5e-4d21-bac3-1abfe147d7b6'
    ), -- Jack Daniel's
    (
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        '32cfa947-f2db-4a83-bf27-3c7d9f9d06c9'
    ), -- Grey Goose
    (
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        '2b3b6c0e-4f88-4b97-a8a1-506ff2bc26af'
    ), -- Captain Morgan
    (
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        '8f0a629e-b6ec-4dd4-9f68-2b18a62d8c1e'
    ), -- Patrón Silver
    (
        '0dc28a1d-8619-4dc7-9667-cd38266d37db',
        '4ac4c10b-5406-49b8-98bc-841c94cf93a3'
    ), -- Hennessy VS
    -- Liqueurs Category
    (
        'c5f76b16-5662-42b3-841e-1378638440e6',
        'a7d6ef01-ef88-4418-b84d-44e6a9e9d19d'
    ), -- Baileys Irish Cream
    -- Sodas Category
    (
        '13e8fb28-8fab-4c2f-b5e7-48b5bd43f624',
        'b7f8461c-38a5-4d2a-b719-830592b268a5'
    ), -- Pepsi
    (
        '13e8fb28-8fab-4c2f-b5e7-48b5bd43f624',
        '13c45b8e-8e5f-4673-9d89-3b2452c9d91d'
    ), -- Coca-Cola
    (
        '13e8fb28-8fab-4c2f-b5e7-48b5bd43f624',
        '89eeb09a-3fda-4e4b-bbe1-6c0d9a69e96e'
    ), -- Mountain Dew
    -- Waters Category
    (
        '5d04716c-cfdf-4f52-9855-acfeb23f6449',
        '8db8e9a5-3c2f-4a27-87bb-293f41ec198b'
    ), -- Aquafina
    -- Juices Category
    (
        '106b3d2b-a416-4a23-9632-928a44a99228',
        'edc97824-9f3b-4e82-8e79-34e7c93fda4f'
    );

-- Minute Maid Orange Juice


