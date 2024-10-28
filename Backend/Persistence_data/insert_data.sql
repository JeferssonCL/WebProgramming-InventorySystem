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
