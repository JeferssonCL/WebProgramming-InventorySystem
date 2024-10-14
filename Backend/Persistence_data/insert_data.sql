-- Insert Categories
INSERT INTO Category (Id, ParentCategoryId, Name) VALUES 
('4e5cb421-968e-4f85-b654-a96e0ab0e3f0', NULL, 'Electronics'),
('cff773e7-398e-4820-987e-47c171efdee5', NULL, 'Clothing'),
('e0a21115-170c-438c-9b26-71ed8440b62f', '4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'Mobile Phones'),
('3e76ea5d-aaaf-468b-ace8-e4944caea1bf', '4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'Laptops'),
('95790aaf-adb1-4bad-a916-2122411b5092', '4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'Cameras'),
('d7c2fa22-0abf-461f-942d-a4e235f46b8c', 'cff773e7-398e-4820-987e-47c171efdee5', 'Men Clothing'),
('111687c4-9ff6-46aa-98b6-3a55c0d880fa', 'cff773e7-398e-4820-987e-47c171efdee5', 'Women Clothing'),
('5e09170e-dedd-4ea9-ae0e-0a1091f80742', 'cff773e7-398e-4820-987e-47c171efdee5', 'Accessories');

-- Insert Products
INSERT INTO Product (Id, StoreId, Name, Description, Price, Brand, StockQuantity) VALUES 
('80381bb1-1d22-475a-8b7e-c4b84d02be0e', '1df15fe2-2484-4d4d-88ff-830a4490d91c', 'iPhone 14', 'Latest Apple smartphone', 999.99, 'Apple', 50),
('d98f6668-2b9f-4a7c-a866-99a73921eed6', '1df15fe2-2484-4d4d-88ff-830a4490d91c', 'Dell XPS 13', 'Compact laptop with powerful performance', 1199.99, 'Dell', 20),
('fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'eab21138-5858-4539-89fa-4634d2445faa', 'T-Shirt', 'Cotton T-Shirt in various colors', 19.99, 'Fashion Brand', 100),
('53d78e6d-decc-4244-b116-18bab2f24f09', 'eab21138-5858-4539-89fa-4634d2445faa', 'Leather Jacket', 'Genuine leather jacket', 199.99, 'Fashion Brand', 40);

-- Insert Images
INSERT INTO "Image" (Id, ProductId, AltText, Url) VALUES 
('3fe7bbff-d878-47be-a235-1ed9ebe2ed00', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14', 'https://www.tiendaamiga.com.bo/media/catalog/product/cache/deb88dadd509903c96aaa309d3e790dc/c/e/celular_iphone_14_pro_128gb_negro.jpg'),
('0025a458-14f7-4067-b96a-13c6dec420bc', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14', 'https://www.tiendaamiga.com.bo/media/catalog/product/cache/0f08319f92600c7a6bb31ae1a25ad318/c/e/celular_iphone_14_pro_128gb_black.jpg'),
('6be3577a-990a-4140-b726-8be55a2eeacc', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14', 'https://www.tiendaamiga.com.bo/media/catalog/product/cache/0f08319f92600c7a6bb31ae1a25ad318/c/e/celular_iphone_14_pro_128gb_negro_mate.jpg'),
('7e47fdc4-3043-416a-afd2-d9a9e9de73b9', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14 in Red', 'https://res.cloudinary.com/mozillion/image/upload/f_auto,q_auto/v1662628007/rclapiepv9xbrfkjwanf.png'),
('88ae92e5-6569-47b8-ab80-4e70b98e18cb', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14 in Black', 'https://res.cloudinary.com/mozillion/image/upload/f_auto,q_auto/v1662630243/leujufqlgebytn8c2ync.png'),
('7adcaa29-4dd5-48de-a64b-66b5b4977b93', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'iPhone 14 in Yellow', 'https://media.croma.com/image/upload/v1708671880/Croma%20Assets/Communication/Mobiles/Images/270412_5_tynkco.png'),
('d870b361-4faf-4a32-8406-cc043d231f63', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/media-gallery/notebook-xps-9315-nt-blue-gallery-3.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=575&qlt=100,1&resMode=sharp2&size=575,402&chrss=full'),
('ea4cdcfd-2e68-4981-b2b4-7b73ca7d65d3', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/spi/blue/ng/notebook-xps-13-9315-blue-campaign-hero-504x350-ng.psd?fmt=jpg&wid=570&hei=400'),
('6a52de15-4011-4ee6-bd58-afd45a9e4d84', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop', 'https://static.sinerji.gen.tr/Images/LG/KJ1-450x-cqbslnzcjf42820230102dell-xps-9315-02.jpg'),
('08e3b2b2-686a-4418-a669-d5d311059ce5', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop in silver', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/media-gallery/notebook-xps-9315-nt-blue-hero-right.psd?fmt=pjpg&pscan=auto&scl=1&wid=5000&hei=5000&qlt=100,1&resMode=sharp2&size=5000,5000&chrss=full&imwidth=5000'),
('a8a65793-c46f-49b9-a7cd-5df88b255acf', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'Dell XPS 13 Laptop in purple', 'https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-13-9315/media-gallery/umber/notebook-xps-9315-nt-umber-hero-right.psd?fmt=pjpg&pscan=auto&scl=1&wid=5000&hei=5000&qlt=100,1&resMode=sharp2&size=5000,5000&chrss=full&imwidth=5000'),
('b4798521-b246-41d6-bf84-8512a3190731', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6qkuuNGspBfSgJ9fc8xYnxLJ4T1Xe6A-BRQ&s'),
('4d421151-d7af-4fce-ab78-c072a381c220', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt', 'https://m.media-amazon.com/images/I/31Yc9uDf+yS._AC_UY350_.jpg'),
('f961135a-d76f-4c54-a16f-a7872353d325', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt', 'https://assets.ajio.com/medias/sys_master/root/20230125/dHe5/63d12a38aeb269c651f8cba5/-473Wx593H-469436599-black-MODEL3.jpg'),
('248c4196-6203-485c-96c5-10d9f0fa38ad', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt in black', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6qkuuNGspBfSgJ9fc8xYnxLJ4T1Xe6A-BRQ&s'),
('63d3ea71-40a3-44df-9a23-0815eec12b94', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt in blue', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZDqRnogdz6C8l5FNh3kO4rHxwo3lZK5K-7Q&s'),
('90bea788-43b6-46b8-b027-bbce10fb9e10', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'Cotton T-Shirt in gray', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAyiaoqjI0VG4XNawst5XS_7lqrIxwZnKont0VtTBcQjppjVVRLUr_t0Pf7ZvOCDfw4us&usqp=CAU'),
('c667ed65-b7fa-4ee8-ae42-8db97a7fbde0', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket', 'https://domino.ua/media/iopt/catalog/product/cache/1338d3702d6df92e886ded663f0927b0/1/5/154584-1_1.webp');
('fa555c36-d992-4c11-9804-daaf197b1d99', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwBI1CgniTfVxA_1xfU4N8XNieGp3xP55OqFF_2HKpoqLnldYSeEMKQjLs1yD533SQums&usqp=CAU');
('d0f286e9-dd58-43c9-b4bd-f8eb4ce6798a', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket', 'https://ae01.alicdn.com/kf/Sa95145b7028f463991ed3acca8579db9Z/Leather-Jackets-for-Women-2023-New-Zipper-Spliced-Short-PU-Leather-Polo-Collar-Outerwear-Coat-Long.jpg');
('2358bcfa-0a2f-4bf8-b4ca-8230b99106f7', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket in brown', 'https://m.media-amazon.com/images/I/61gUmHvIDQL._AC_UF350,350_QL50_.jpg');
('ca49da7c-6deb-45dc-8ae7-65e8abce34d8', '53d78e6d-decc-4244-b116-18bab2f24f09', 'Genuine Leather Jacket in black', 'https://domino.ua/media/iopt/catalog/product/cache/1338d3702d6df92e886ded663f0927b0/1/5/154584-1_1.webp');

-- Insert Variants
INSERT INTO Variant (Id, Name) VALUES 
('c84517ff-e146-4074-a232-4c0b2328d308', 'Color'),
('0952150e-7949-4166-a489-9a8eadcd803a', 'Size');

-- Insert Product Attributes
INTO ProductAttribute (Id, ImageId, ProductId, VariantId, Value) VALUES 
('b6f3db9e-b64d-4eae-97e9-b8f3dae749cf', '7e47fdc4-3043-416a-afd2-d9a9e9de73b9', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'c84517ff-e146-4074-a232-4c0b2328d308', 'red'),
('b6f3db9e-b64d-4eae-97e9-b8f3dae749cf', '88ae92e5-6569-47b8-ab80-4e70b98e18cb', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'c84517ff-e146-4074-a232-4c0b2328d308', 'black'),
('b6f3db9e-b64d-4eae-97e9-b8f3dae749cf', '7adcaa29-4dd5-48de-a64b-66b5b4977b93', '80381bb1-1d22-475a-8b7e-c4b84d02be0e', 'c84517ff-e146-4074-a232-4c0b2328d308', 'yellow'),

('3e24ead9-8615-4138-9a82-92ad055d3f98', '08e3b2b2-686a-4418-a669-d5d311059ce5', 'd98f6668-2b9f-4a7c-a866-99a73921eed6', 'c84517ff-e146-4074-a232-4c0b2328d308', 'gray'),
('b906da22-29e1-46ef-80bb-e3cf00bad8fe', 'a8a65793-c46f-49b9-a7cd-5df88b255acf', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a', 'c84517ff-e146-4074-a232-4c0b2328d308', 'purple'),

('32f66974-13fa-42f1-8ced-ed200b1e7d23', '248c4196-6203-485c-96c5-10d9f0fa38ad', '53d78e6d-decc-4244-b116-18bab2f24f09', 'c84517ff-e146-4074-a232-4c0b2328d308', 'black'),
('32f66974-13fa-42f1-8ced-ed200b1e7d23', '63d3ea71-40a3-44df-9a23-0815eec12b94', '53d78e6d-decc-4244-b116-18bab2f24f09', 'c84517ff-e146-4074-a232-4c0b2328d308', 'blue'),
('32f66974-13fa-42f1-8ced-ed200b1e7d23', '90bea788-43b6-46b8-b027-bbce10fb9e10', '53d78e6d-decc-4244-b116-18bab2f24f09', 'c84517ff-e146-4074-a232-4c0b2328d308', 'gray'),

('32f66974-13fa-42f1-8ced-ed200b1e7d23', '2358bcfa-0a2f-4bf8-b4ca-8230b99106f7', '53d78e6d-decc-4244-b116-18bab2f24f09', 'c84517ff-e146-4074-a232-4c0b2328d308', 'brown'),
('32f66974-13fa-42f1-8ced-ed200b1e7d23', 'ca49da7c-6deb-45dc-8ae7-65e8abce34d8', '53d78e6d-decc-4244-b116-18bab2f24f09', 'c84517ff-e146-4074-a232-4c0b2328d308', 'black'),

('32f66974-13fa-42f1-8ced-ed200b1e7d23', '248c4196-6203-485c-96c5-10d9f0fa38ad', '53d78e6d-decc-4244-b116-18bab2f24f09', '0952150e-7949-4166-a489-9a8eadcd803a', 'L'),
('32f66974-13fa-42f1-8ced-ed200b1e7d23', '248c4196-6203-485c-96c5-10d9f0fa38ad', '53d78e6d-decc-4244-b116-18bab2f24f09', '0952150e-7949-4166-a489-9a8eadcd803a8', 'M'),

('32f66974-13fa-42f1-8ced-ed200b1e7d23', '2358bcfa-0a2f-4bf8-b4ca-8230b99106f7', '53d78e6d-decc-4244-b116-18bab2f24f09', '0952150e-7949-4166-a489-9a8eadcd803a', 'XS'),


-- Insert Users
INSERT INTO User (Id, Name, Email, Password, UserType) VALUES 
('c4055860-c902-4787-ba54-0b34e18a1040', 'Jefersson Coronel', 'jefersoncoronel700@gmail.com', 'password123', 0),
('e8489e3b-c12c-4197-8bc1-dac21bc6e82f', 'Karina Aguirre', 'jefersoncoronel700@gmail.com', 'password123', 3);

-- Insert User Addresses
INSERT INTO UserAddress (Id, UserId, Address, City, Country, Latitude, Longitude, AddressType) VALUES 
('945ff41a-fd1d-431b-9a70-2ae6f1a9ec08', 'c4055860-c902-4787-ba54-0b34e18a1040', '123 Main St', 'Los Angeles', 'USA', 34.0522, -118.2437, 'Home'),
('4ed85ab2a-19ed-4b0e-98e1-17366bf5e170', 'e8489e3b-c12c-4197-8bc1-dac21bc6e82f', '456 Elm St', 'New York', 'USA', 40.7128, -74.0060, 'Home');

-- Insert Stores
INSERT INTO Store (Id, UserId, Name, Description, Address, PhoneNumber) VALUES 
('708096b5-4119-4365-b974-3da5c04f0ba6', 'c4055860-c902-4787-ba54-0b34e18a1040', 'Best Electronics', 'Your one-stop shop for electronics', '789 Tech Ave', 76435676),
('8330f716-3ad1-40f9-a8b4-5720b010328b', 'c4055860-c902-4787-ba54-0b34e18a1040', 'Fashion Hub', 'Latest fashion trends', '101 Fashion St', 65473899);

-- Insert Products
INSERT INTO CategoryProduct (CategoriesId, ProductsId) VALUES 
('e0a21115-170c-438c-9b26-71ed8440b62f', '80381bb1-1d22-475a-8b7e-c4b84d02be0e'),
('4e5cb421-968e-4f85-b654-a96e0ab0e3f0', '80381bb1-1d22-475a-8b7e-c4b84d02be0e'),
('4e5cb421-968e-4f85-b654-a96e0ab0e3f0', 'd98f6668-2b9f-4a7c-a866-99a73921eed6'),
('3e76ea5d-aaaf-468b-ace8-e4944caea1bf', 'd98f6668-2b9f-4a7c-a866-99a73921eed6'),
('cff773e7-398e-4820-987e-47c171efdee5', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a'),
('d7c2fa22-0abf-461f-942d-a4e235f46b8c', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a'),
('111687c4-9ff6-46aa-98b6-3a55c0d880fa', 'fba39c75-29fb-499f-a88a-b0863c1d0f2a'),
('111687c4-9ff6-46aa-98b6-3a55c0d880fa', '53d78e6d-decc-4244-b116-18bab2f24f09');
('cff773e7-398e-4820-987e-47c171efdee5', '53d78e6d-decc-4244-b116-18bab2f24f09t');