-- Insert Categories
INSERT INTO "Category" ("Id", "ParentCategoryId", "Name", "IsActive", "CreatedAt", "UpdatedAt") VALUES 
('4e5cb421-968e-4f85-b654-a96e0ab0e3f0', NULL, 'Electronics', true, CURRENT_TIMESTAMP, NULL),
('cff773e7-398e-4820-987e-47c171efdee5', NULL, 'Clothing', true, CURRENT_TIMESTAMP, NULL),
('e0a21115-170c-438c-9b26-71ed8440b62f', '4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'Mobile Phones', true, CURRENT_TIMESTAMP, NULL),
('3e76ea5d-aaaf-468b-ace8-e4944caea1bf', '4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'Laptops', true, CURRENT_TIMESTAMP, NULL),
('95790aaf-adb1-4bad-a916-2122411b5092', '4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'Cameras', true, CURRENT_TIMESTAMP, NULL),
('d7c2fa22-0abf-461f-942d-a4e235f46b8c', 'cff773e7-398e-4820-987e-47c171efdee5', 'Men Clothing', true, CURRENT_TIMESTAMP, NULL),
('111687c4-9ff6-46aa-98b6-3a55c0d880fa', 'cff773e7-398e-4820-987e-47c171efdee5', 'Women Clothing', true, CURRENT_TIMESTAMP, NULL),
('5e09170e-dedd-4ea9-ae0e-0a1091f80742', 'cff773e7-398e-4820-987e-47c171efdee5', 'Accessories', true, CURRENT_TIMESTAMP, NULL);

-- Insert Users
INSERT INTO "User" ("Id", "Name", "Email", "Password", "UserType", "IsActive", "CreatedAt", "UpdatedAt") VALUES 
('c4055860-c902-4787-ba54-0b34e18a1040', 'Jefersson Coronel', 'jefersoncoronel700@gmail.com', 'password123', 0, true, CURRENT_TIMESTAMP, NULL),
('e8489e3b-c12c-4197-8bc1-dac21bc6e82f', 'Karina Aguirre', 'karina123@gmail.com', 'password123', 3, true, CURRENT_TIMESTAMP, NULL);

-- Insert Stores
INSERT INTO "Store" ("Id", "UserId", "Name", "Description", "Address", "PhoneNumber", "IsActive", "CreatedAt", "UpdatedAt") VALUES 
('708096b5-4119-4365-b974-3da5c04f0ba6', 'c4055860-c902-4787-ba54-0b34e18a1040', 'Best Electronics', 'Your one-stop shop for electronics', '789 Tech Ave', 76435676, true, CURRENT_TIMESTAMP, NULL),
('8330f716-3ad1-40f9-a8b4-5720b010328b', 'c4055860-c902-4787-ba54-0b34e18a1040', 'Fashion Hub', 'Latest fashion trends', '101 Fashion St', 65473899, true, CURRENT_TIMESTAMP, NULL);

-- Insert Products
INSERT INTO "Product" ("Id", "StoreId", "Name", "Description", "BasePrice", "Brand", "IsActive", "CreatedAt", "UpdatedAt") VALUES 
('80381bb1-1d22-475a-8b7e-c4b84d02be0e', '708096b5-4119-4365-b974-3da5c04f0ba6', 'iPhone 14', 'Latest Apple smartphone', 999.99, 'Apple', true, CURRENT_TIMESTAMP, NULL),
('d98f6668-2b9f-4a7c-a866-99a73921eed6', '708096b5-4119-4365-b974-3da5c04f0ba6', 'Dell XPS 13', 'Compact laptop with powerful performance', 1199.99, 'Dell', true, CURRENT_TIMESTAMP, NULL),
('fba39c75-29fb-499f-a88a-b0863c1d0f2a', '8330f716-3ad1-40f9-a8b4-5720b010328b', 'T-Shirt', 'Cotton T-Shirt in various colors', 19.99, 'Fashion "Brand"', true, CURRENT_TIMESTAMP, NULL),
('53d78e6d-decc-4244-b116-18bab2f24f09', '8330f716-3ad1-40f9-a8b4-5720b010328b', 'Leather Jacket', 'Genuine leather jacket', 199.99, 'Fashion "Brand"', true, CURRENT_TIMESTAMP, NULL);

-- Insert Images
INSERT INTO "Image" ("Id", "ProductId", "AltText", "Url", "IsActive", "CreatedAt", "UpdatedAt") VALUES  
('3fe7bbff-d878-47be-a235-1ed9ebe2ed00', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14', 'https://www.tiendaamiga.com.bo/media/catalog/product/cache/deb88dadd509903c96aaa309d3e790dc/c/e/celular_iphone_14_pro_128gb_negro.jpg', true, CURRENT_TIMESTAMP, NULL),
('0025a458-14f7-4067-b96a-13c6dec420bc', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14', 'https://www.tiendaamiga.com.bo/media/catalog/product/cache/0f08319f92600c7a6bb31ae1a25ad318/c/e/celular_iphone_14_pro_128gb_black.jpg', true, CURRENT_TIMESTAMP, NULL),
('6be3577a-990a-4140-b726-8be55a2eeacc', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14', 'https://www.tiendaamiga.com.bo/media/catalog/product/cache/0f08319f92600c7a6bb31ae1a25ad318/c/e/celular_iphone_14_pro_128gb_negro_mate.jpg', true, CURRENT_TIMESTAMP, NULL),
('7e47fdc4-3043-416a-afd2-d9a9e9de73b9', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14 in Red', 'https://res.cloudinary.com/mozillion/image/upload/f_auto,q_auto/v1662628007/rclapiepv9xbrfkjwanf.png', true, CURRENT_TIMESTAMP, NULL),
('88ae92e5-6569-47b8-ab80-4e70b98e18cb', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14 in Black', 'https://res.cloudinary.com/mozillion/image/upload/f_auto,q_auto/v1662630243/leujufqlgebytn8c2ync.png', true, CURRENT_TIMESTAMP, NULL),
('7adcaa29-4dd5-48de-a64b-66b5b4977b93', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14 in Yellow', 'https://media.croma.com/image/upload/v1708671880/Croma%20Assets/Communication/Mobiles/Images/270412_5_tynkco.png', true, CURRENT_TIMESTAMP, NULL),
('d870b361-4faf-4a32-8406-cc043d231f63', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/media-gallery/notebook-xps-9315-nt-blue-gallery-3.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=575&qlt=100,1&resMode=sharp2&size=575,402&chrss=full', true, CURRENT_TIMESTAMP, NULL),
('ea4cdcfd-2e68-4981-b2b4-7b73ca7d65d3', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/spi/blue/ng/notebook-xps-13-9315-blue-campaign-hero-504x350-ng.psd?fmt=jpg&wid=570&hei=400', true, CURRENT_TIMESTAMP, NULL),
('6a52de15-4011-4ee6-bd58-afd45a9e4d84', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop', 'https://static.sinerji.gen.tr/Images/LG/KJ1-450x-cqbslnzcjf42820230102dell-xps-9315-02.jpg', true, CURRENT_TIMESTAMP, NULL),
('08e3b2b2-686a-4418-a669-d5d311059ce5', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop in silver', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/media-gallery/notebook-xps-9315-nt-blue-hero-right.psd?fmt=pjpg&pscan=auto&scl=1&wid=5000&hei=5000&qlt=100,1&resMode=sharp2&size=5000,5000&chrss=full&imwidth=5000', true, CURRENT_TIMESTAMP, NULL),
('a8a65793-c46f-49b9-a7cd-5df88b255acf', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop in purple', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/media-gallery/umber/notebook-xps-9315-nt-umber-hero-right.psd?fmt=pjpg&pscan=auto&scl=1&wid=5000&hei=5000&qlt=100,1&resMode=sharp2&size=5000,5000&chrss=full&imwidth=5000', true, CURRENT_TIMESTAMP, NULL),
('b4798521-b246-41d6-bf84-8512a3190731', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6qkuuNGspBfSgJ9fc8xYnxLJ4T1Xe6A-BRQ&s', true, CURRENT_TIMESTAMP, NULL),
('4d421151-d7af-4fce-ab78-c072a381c220', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt', 'https://m.media-amazon.com/images/I/31Yc9uDf+yS._AC_UY350_.jpg', true, CURRENT_TIMESTAMP, NULL),
('f961135a-d76f-4c54-a16f-a7872353d325', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt', 'https://assets.ajio.com/medias/sys_master/root/20230125/dHe5/63d12a38aeb269c651f8cba5/-473Wx593H-469436599-black-MODEL3.jpg', true, CURRENT_TIMESTAMP, NULL),
('248c4196-6203-485c-96c5-10d9f0fa38ad', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt in black', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6qkuuNGspBfSgJ9fc8xYnxLJ4T1Xe6A-BRQ&s', true, CURRENT_TIMESTAMP, NULL),
('63d3ea71-40a3-44df-9a23-0815eec12b94', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt in blue', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZDqRnogdz6C8l5FNh3kO4rHxwo3lZK5K-7Q&s', true, CURRENT_TIMESTAMP, NULL),
('90bea788-43b6-46b8-b027-bbce10fb9e10', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt in gray', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAyiaoqjI0VG4XNawst5XS_7lqrIxwZnKont0VtTBcQjppjVVRLUr_t0Pf7ZvOCDfw4us&usqp=CAU', true, CURRENT_TIMESTAMP, NULL),
('c667ed65-b7fa-4ee8-ae42-8db97a7fbde0', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket', 'https://domino.ua/media/iopt/catalog/product/cache/1338d3702d6df92e886ded663f0927b0/1/5/154584-1_1.webp', true, CURRENT_TIMESTAMP, NULL),
('fa555c36-d992-4c11-9804-daaf197b1d99', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwBI1CgniTfVxA_1xfU4N8XNieGp3xP55OqFF_2HKpoqLnldYSeEMKQjLs1yD533SQums&usqp=CAU', true, CURRENT_TIMESTAMP, NULL),
('d0f286e9-dd58-43c9-b4bd-f8eb4ce6798a', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket', 'https://ae01.alicdn.com/kf/Sa95145b7028f463991ed3acca8579db9Z/Leather-Jackets-for-Women-2023-New-Zipper-Spliced-Short-PU-Leather-Polo-Collar-Outerwear-Coat-Long.jpg', true, CURRENT_TIMESTAMP, NULL),
('2358bcfa-0a2f-4bf8-b4ca-8230b99106f7', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket in brown', 'https://m.media-amazon.com/images/I/61gUmHvIDQL._AC_UF350,350_QL50_.jpg', true, CURRENT_TIMESTAMP, NULL),
('ca49da7c-6deb-45dc-8ae7-65e8abce34d8', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket in black', 'https://domino.ua/media/iopt/catalog/product/cache/1338d3702d6df92e886ded663f0927b0/1/5/154584-1_1.webp', true, CURRENT_TIMESTAMP, NULL);

-- Insert Product Variants
INSERT INTO "ProductVariant"("Id", "ProductId", "ImageId", "PriceAdjustment", "StockQuantity", "IsActive", "CreatedAt", "UpdatedAt") VALUES 
('a793a3c8-8b6f-4f4e-a300-1427ac2cc7b8', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', '7e47fdc4-3043-416a-afd2-d9a9e9de73b9', 0, 10, true, CURRENT_TIMESTAMP, NULL),
('be3f959b-ad95-442b-9cb1-39a967a15e16', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', '88ae92e5-6569-47b8-ab80-4e70b98e18cb', 0, 20, true, CURRENT_TIMESTAMP, NULL),
('022109b8-5a11-46ed-92b5-d5ccf59cf02e', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', '7adcaa29-4dd5-48de-a64b-66b5b4977b93', 0, 8, true, CURRENT_TIMESTAMP, NULL),
('928c8dd1-34f1-4f1c-9809-d3f16e7d4952', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', '08e3b2b2-686a-4418-a669-d5d311059ce5', 0, 15, true, CURRENT_TIMESTAMP, NULL),
('ba71c6ef-e152-4689-be26-8d26de5fe45c', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'a8a65793-c46f-49b9-a7cd-5df88b255acf', 0, 5, true, CURRENT_TIMESTAMP, NULL),
('4bf431cd-85f7-4abd-8499-7c5951e20c87', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', '248c4196-6203-485c-96c5-10d9f0fa38ad', 0, 30, true, CURRENT_TIMESTAMP, NULL),
('a628c13b-d9b8-4671-b068-99a412490de0', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', '63d3ea71-40a3-44df-9a23-0815eec12b94', 0, 10, true, CURRENT_TIMESTAMP, NULL),
('67514681-93cd-41ca-b8d2-a2d57ebb5006', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', '90bea788-43b6-46b8-b027-bbce10fb9e10', 0, 15, true, CURRENT_TIMESTAMP, NULL),
('b41ec61c-754a-4278-9f83-e0af1ba0d626', '53d78e6d-decc-4244-b116-18bab2f24f09', '2358bcfa-0a2f-4bf8-b4ca-8230b99106f7', 0, 10, true, CURRENT_TIMESTAMP, NULL),
('a860a28b-bc2f-41c0-ba12-fb2e88499547', '53d78e6d-decc-4244-b116-18bab2f24f09', 'ca49da7c-6deb-45dc-8ae7-65e8abce34d8', 0, 5, true, CURRENT_TIMESTAMP, NULL),
('03a67d50-9056-42cf-8932-bd7de9622711', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', NULL, 0, 15, true, CURRENT_TIMESTAMP, NULL),
('b0109acd-fc4e-4ebd-bcd7-d6472b7c5af0', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', NULL, 0, 30, true, CURRENT_TIMESTAMP, NULL),
('6bcbfe56-043a-4fd2-95a8-96f7e0f5f8a3', '53d78e6d-decc-4244-b116-18bab2f24f09', NULL, 0, 15, true, CURRENT_TIMESTAMP, NULL);

-- Insert Variants5
INSERT INTO "Variant" ("Id", "Name", "IsActive", "CreatedAt", "UpdatedAt") VALUES 
('c84517ff-e146-4074-a232-4c0b2328d308', 'Color', true, CURRENT_TIMESTAMP, NULL),
('0952150e-7949-4166-a489-9a8eadcd803a', 'Size', true, CURRENT_TIMESTAMP, NULL);

-- Insert Product Attributes
INSERT INTO "ProductAttribute"("Id", "ProductVariantId", "VariantId", "Value",  "IsActive", "CreatedAt", "UpdatedAt") VALUES
('4774ff82-c78b-4980-8c30-0de860d56b5e', 'a793a3c8-8b6f-4f4e-a300-1427ac2cc7b8', 'c84517ff-e146-4074-a232-4c0b2328d308', 'red', true, CURRENT_TIMESTAMP, NULL),
('b2ccd888-b875-4b2c-b8aa-33dd90218fa0', 'be3f959b-ad95-442b-9cb1-39a967a15e16', 'c84517ff-e146-4074-a232-4c0b2328d308', 'black', true, CURRENT_TIMESTAMP, NULL),
('074c3c22-949b-46c9-880a-8fe4114cac98', '022109b8-5a11-46ed-92b5-d5ccf59cf02e', 'c84517ff-e146-4074-a232-4c0b2328d308', 'yellow', true, CURRENT_TIMESTAMP, NULL),
('3e24ead9-8615-4138-9a82-92ad055d3f98', '928c8dd1-34f1-4f1c-9809-d3f16e7d4952', 'c84517ff-e146-4074-a232-4c0b2328d308', 'gray', true, CURRENT_TIMESTAMP, NULL),
('b906da22-29e1-46ef-80bb-e3cf00bad8fe', 'ba71c6ef-e152-4689-be26-8d26de5fe45c', 'c84517ff-e146-4074-a232-4c0b2328d308', 'purple', true, CURRENT_TIMESTAMP, NULL),
('5261ead0-5ad2-4d74-b90d-e4ba9668b4fa', '4bf431cd-85f7-4abd-8499-7c5951e20c87', 'c84517ff-e146-4074-a232-4c0b2328d308', 'black', true, CURRENT_TIMESTAMP, NULL),
('6aecceb3-9579-4108-bfc4-8aa1046e11a7', 'a628c13b-d9b8-4671-b068-99a412490de0', 'c84517ff-e146-4074-a232-4c0b2328d308', 'blue', true, CURRENT_TIMESTAMP, NULL),
('053578fa-af25-4bae-945a-c13f79ee1df6', '67514681-93cd-41ca-b8d2-a2d57ebb5006', 'c84517ff-e146-4074-a232-4c0b2328d308', 'gray', true, CURRENT_TIMESTAMP, NULL),
('fef6a7d1-5502-496e-b912-148f819ecb11', 'b41ec61c-754a-4278-9f83-e0af1ba0d626', 'c84517ff-e146-4074-a232-4c0b2328d308', 'brown', true, CURRENT_TIMESTAMP, NULL),
('3583a422-92e9-49e5-a1db-15bbb05403cb', 'a860a28b-bc2f-41c0-ba12-fb2e88499547', 'c84517ff-e146-4074-a232-4c0b2328d308', 'black', true, CURRENT_TIMESTAMP, NULL),
('40c528e7-491c-4053-9239-53c22c824ef6', '03a67d50-9056-42cf-8932-bd7de9622711', '0952150e-7949-4166-a489-9a8eadcd803a', 'L', true, CURRENT_TIMESTAMP, NULL),
('7d0d36fc-fd54-49d1-9c09-70c1b89e89df', 'b0109acd-fc4e-4ebd-bcd7-d6472b7c5af0', '0952150e-7949-4166-a489-9a8eadcd803a', 'M', true, CURRENT_TIMESTAMP, NULL),
('ae2aa0ff-e020-4cef-9d24-0f40f24ea01d', '6bcbfe56-043a-4fd2-95a8-96f7e0f5f8a3', '0952150e-7949-4166-a489-9a8eadcd803a', 'XS', true, CURRENT_TIMESTAMP, NULL);

-- Insert User Addresses
INSERT INTO "UserAddress" ("Id", "UserId", "Address", "City", "Country", "IsActive", "CreatedAt", "UpdatedAt") VALUES 
('945ff41a-fd1d-431b-9a70-2ae6f1a9ec08', 'c4055860-c902-4787-ba54-0b34e18a1040', '123 Main St', 'Los Angeles', 'USA', true, CURRENT_TIMESTAMP, NULL),
('83249fea-26a9-4de8-9e2b-a14cf7969d81', 'e8489e3b-c12c-4197-8bc1-dac21bc6e82f', '456 Elm St', 'New York', 'USA', true, CURRENT_TIMESTAMP, NULL);

-- Insert Products
INSERT INTO "CategoryProduct" ("CategoriesId", "ProductsId") VALUES 
('e0a21115-170c-438c-9b26-71ed8440b62f', '80381bb1-1d22-475a-8b7e-c4b84d02be0e'),
('4e5cb421-968e-4f85-b654-a96e0ab0e3f0', '80381bb1-1d22-475a-8b7e-c4b84d02be0e'),
('4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'd98f6668-2b9f-4a7c-a866-99a73921eed6'),
('3e76ea5d-aaaf-468b-ace8-e4944caea1bf', 'd98f6668-2b9f-4a7c-a866-99a73921eed6'),
('cff773e7-398e-4820-987e-47c171efdee5', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a'),
('d7c2fa22-0abf-461f-942d-a4e235f46b8c', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a'),
('111687c4-9ff6-46aa-98b6-3a55c0d880fa', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a'),
('111687c4-9ff6-46aa-98b6-3a55c0d880fa', '53d78e6d-decc-4244-b116-18bab2f24f09'),
('cff773e7-398e-4820-987e-47c171efdee5', '53d78e6d-decc-4244-b116-18bab2f24f09');