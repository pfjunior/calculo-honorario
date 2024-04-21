IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Honorarios] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(100) NULL,
    [ProLaboreBruto] decimal(18,4) NOT NULL,
    [ProLaboreLiquido] decimal(18,4) NOT NULL,
    [LucroBruto] decimal(18,4) NOT NULL,
    [LucroLiquido] decimal(18,4) NOT NULL,
    [ValorHonorario] decimal(18,4) NOT NULL,
    [ProvisaoFerias] decimal(18,4) NOT NULL,
    [ProvisaoDecimoTerceiro] decimal(18,4) NOT NULL,
    [Fgts] decimal(18,4) NOT NULL,
    [Inss] decimal(18,4) NOT NULL,
    [Irpf] decimal(18,4) NOT NULL,
    [ValeRefeicao] decimal(18,4) NOT NULL,
    [ValeTransporte] decimal(18,4) NOT NULL,
    [ServicoContabil] decimal(18,4) NOT NULL,
    [SimplesNacional] decimal(18,4) NOT NULL,
    [CadastradoEm] datetime2 NOT NULL,
    [AtualizadoEm] datetime2 NULL,
    CONSTRAINT [PK_Honorarios] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240421221541_Initial', N'8.0.3');
GO

COMMIT;
GO

