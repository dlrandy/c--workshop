CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'factory') THEN
        CREATE SCHEMA factory;
    END IF;
END $EF$;

CREATE TABLE factory.manufacturer (
    id integer GENERATED ALWAYS AS IDENTITY,
    name character varying(50) NOT NULL,
    country character varying(50) NOT NULL,
    CONSTRAINT manufacturer_pkey PRIMARY KEY (id)
);

CREATE TABLE factory.product (
    id integer GENERATED ALWAYS AS IDENTITY,
    name character varying(50) NOT NULL,
    price money NOT NULL,
    manufacturerid integer NOT NULL,
    CONSTRAINT product_pkey PRIMARY KEY (id),
    CONSTRAINT product_manufacturerid_id FOREIGN KEY (manufacturerid) REFERENCES factory.manufacturer (id) ON DELETE CASCADE
);

CREATE INDEX "IX_product_manufacturerid" ON factory.product (manufacturerid);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230507101012_MyFirstMigration', '7.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE factory.manufacturer ADD date timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230514011848_AddManufacturerFoundedDate', '7.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE factory.manufacturer RENAME COLUMN date TO "FoundedAt";

ALTER TABLE factory.manufacturer ALTER COLUMN "FoundedAt" TYPE date;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230514013337_AddManufacturerFoundedDate2', '7.0.5');

COMMIT;

