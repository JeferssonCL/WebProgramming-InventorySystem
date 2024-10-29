
INSERT INTO "User" ("Id", "Name", "Email", "IdentityId", "IsActive", "CreatedAt", "UpdatedAt") VALUES
('c4055860-c902-4787-ba54-0b34e18a1040', 'Jefersson Coronel', 'jefersoncoronel700@gmail.com', 'Zdgt7Re9p1gDABAuBMa1V8lkXu73', true, CURRENT_TIMESTAMP, NULL),
('e8489e3b-c12c-4197-8bc1-dac21bc6e82f', 'Karina Aguirre', 'karina123@gmail.com', 'password123', true, CURRENT_TIMESTAMP, NULL);


INSERT INTO "UserAddress" ("Id", "UserId", "Address", "City", "Country", "IsActive", "CreatedAt", "UpdatedAt") VALUES
('945ff41a-fd1d-431b-9a70-2ae6f1a9ec08', 'c4055860-c902-4787-ba54-0b34e18a1040', '123 Main St', 'Los Angeles', 'USA', true, CURRENT_TIMESTAMP, NULL),
('83249fea-26a9-4de8-9e2b-a14cf7969d81', 'e8489e3b-c12c-4197-8bc1-dac21bc6e82f', '456 Elm St', 'New York', 'USA', true, CURRENT_TIMESTAMP, NULL);
