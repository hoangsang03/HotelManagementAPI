START TRANSACTION;

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('265aa0a6-6773-424e-a702-01efe3487384', NULL, 'Administator', 'ADMINISTATOR');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('ee727937-5538-486e-8763-356f0cf99676', NULL, 'User', 'USER');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231202061033_Add_Default_Roles', '7.0.14');

COMMIT;

