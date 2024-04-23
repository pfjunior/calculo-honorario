CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240423194359_Initial') THEN
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
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240423194359_Initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240423194359_Initial', '8.0.3');
    END IF;
END $EF$;
COMMIT;

