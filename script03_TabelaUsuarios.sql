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

CREATE TABLE [TB_VIOLINOS] (
    [Id] int NOT NULL IDENTITY,
    [Modelo] varchar(200) NOT NULL,
    [Marca] varchar(200) NOT NULL,
    [Materiais] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_TB_VIOLINOS] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AcessoriosViolino] (
    [Id] int NOT NULL IDENTITY,
    [Modelo] varchar(200) NOT NULL,
    [Marca] varchar(200) NOT NULL,
    [Materiais] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Acessorios] int NOT NULL,
    [ViolinoId] int NOT NULL,
    CONSTRAINT [PK_AcessoriosViolino] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AcessoriosViolino_TB_VIOLINOS_ViolinoId] FOREIGN KEY ([ViolinoId]) REFERENCES [TB_VIOLINOS] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'Valor') AND [object_id] = OBJECT_ID(N'[TB_VIOLINOS]'))
    SET IDENTITY_INSERT [TB_VIOLINOS] ON;
INSERT INTO [TB_VIOLINOS] ([Id], [Descricao], [Marca], [Materiais], [Modelo], [Valor])
VALUES (1, 'Queixeira, estandarte, cravelhas e botão: Ébano Encordoamento: M Calixto Arco de crina natural e madeira maçaranduba Estojo Gota  Ajuste Profissional (cavalete original, alma, pestana, cravelhas', 'Eagles', 'Violino: Abeto e Atiro.  Ébano Arco:Maçaranduba', 'CV-12', 0.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'Valor') AND [object_id] = OBJECT_ID(N'[TB_VIOLINOS]'))
    SET IDENTITY_INSERT [TB_VIOLINOS] OFF;
GO

CREATE UNIQUE INDEX [IX_AcessoriosViolino_ViolinoId] ON [AcessoriosViolino] ([ViolinoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241030204258_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

