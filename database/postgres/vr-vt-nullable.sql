CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Honorarios" (
    "Id" uuid NOT NULL,
    "Descricao" varchar(100) NOT NULL,
    "ProLaboreBruto" numeric(18,4) NOT NULL,
    "ProLaboreLiquido" numeric(18,4) NOT NULL,
    "LucroBruto" numeric(18,4) NOT NULL,
    "LucroLiquido" numeric(18,4) NOT NULL,
    "ValorHonorario" numeric(18,4) NOT NULL,
    "ProvisaoFerias" numeric(18,4) NOT NULL,
    "ProvisaoDecimoTerceiro" numeric(18,4) NOT NULL,
    "Fgts" numeric(18,4) NOT NULL,
    "Inss" numeric(18,4) NOT NULL,
    "Irpf" numeric(18,4) NOT NULL,
    "ValeRefeicao" numeric(18,4) NOT NULL,
    "ValeTransporte" numeric(18,4) NOT NULL,
    "ServicoContabil" numeric(18,4) NOT NULL,
    "SimplesNacional" numeric(18,4) NOT NULL,
    "CadastradoEm" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Honorarios" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240423194359_Initial', '8.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE "Honorarios" ALTER COLUMN "ValeTransporte" TYPE numeric;
ALTER TABLE "Honorarios" ALTER COLUMN "ValeTransporte" DROP NOT NULL;

ALTER TABLE "Honorarios" ALTER COLUMN "ValeRefeicao" TYPE numeric;
ALTER TABLE "Honorarios" ALTER COLUMN "ValeRefeicao" DROP NOT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240502165652_VR-VT-Nullable', '8.0.3');

COMMIT;

