CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Attendees" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Attendees" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Event_Id" TEXT NOT NULL,
    "Created_At" TEXT NOT NULL
);

CREATE TABLE "Events" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Events" PRIMARY KEY,
    "Title" TEXT NOT NULL,
    "Details" TEXT NOT NULL,
    "Slug" TEXT NOT NULL,
    "Maximum_Attendees" INTEGER NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240405133108_teste', '8.0.3');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Events" ADD "teste" TEXT NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240405133225_teste2', '8.0.3');

COMMIT;

