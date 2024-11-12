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

BEGIN TRANSACTION;
GO

DROP TABLE [AcessoriosViolino];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_VIOLINOS]') AND [c].[name] = N'Valor');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_VIOLINOS] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TB_VIOLINOS] ALTER COLUMN [Valor] float NOT NULL;
GO

ALTER TABLE [TB_VIOLINOS] ADD [UsuarioId] int NULL;
GO

CREATE TABLE [TB_ACESSORIOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Modelo] varchar(200) NOT NULL,
    [Marca] varchar(200) NOT NULL,
    [Materiais] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Valor] float NOT NULL,
    [TipoAcessorios] int NOT NULL,
    [ViolinoId] int NULL,
    CONSTRAINT [PK_TB_ACESSORIOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_ACESSORIOS_TB_VIOLINOS_ViolinoId] FOREIGN KEY ([ViolinoId]) REFERENCES [TB_VIOLINOS] ([Id])
);
GO

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Username] varchar(200) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] varchar(200) NOT NULL,
    [Email] varchar(200) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'Nome', N'TipoAcessorios', N'Valor', N'ViolinoId') AND [object_id] = OBJECT_ID(N'[TB_ACESSORIOS]'))
    SET IDENTITY_INSERT [TB_ACESSORIOS] ON;
INSERT INTO [TB_ACESSORIOS] ([Id], [Descricao], [Marca], [Materiais], [Modelo], [Nome], [TipoAcessorios], [Valor], [ViolinoId])
VALUES (1, 'Produzido na Alemanha, utilizando os melhores materiais, a marca Pirastro é dominante no segmento de...', 'Pirastro', 'Resina Natural de Pinho', 'CV-52', 'Breu', 2, 52.649999999999999E0, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'Nome', N'TipoAcessorios', N'Valor', N'ViolinoId') AND [object_id] = OBJECT_ID(N'[TB_ACESSORIOS]'))
    SET IDENTITY_INSERT [TB_ACESSORIOS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Perfil], [Username])
VALUES (1, NULL, 'seuEmail@gmail.com', NULL, -23.520024100000001E0, -46.596497999999997E0, 0x55FED8BEC39B94BD70CB929EC6B0DFAE06423840AD6AF07EC4967C6A84CE93E30D7B861469BFD4364786E9C0B98E960145F6BCFEBA4FE6D338E5B275F0BB7247, 0x267977B9ADFC39D21FC15B5AE7AC4C04CBC9E05EA9A8E923E15EF6B3235D79805186669DDB16A9FEBF3584C28F8A2A4CFAF9ED2683127AC296AAD945B8A44A65AE7106B0065AA3D7CDF94966C56586E686FB311E873C10A31C442D2B52F8D7861C685BE20AD17BA67D5D4A50EBC35C45F91A644A98CF6BF2F482C03958D7C1B7, 'Admin', 'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

UPDATE [TB_VIOLINOS] SET [Descricao] = 'Queixeira, estandarte, cravelhas e botão: Ébano. Encordoamento: M Calixto. Arco de crina natural e madeira maçaranduba. Estojo Gota. Ajuste Profissional (cavalete original, alma, pestana, cravelhas)', [Materiais] = 'Violino: Abeto e Atiro. Ébano. Arco: Maçaranduba', [UsuarioId] = 1, [Valor] = 1283.8499999999999E0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_TB_VIOLINOS_UsuarioId] ON [TB_VIOLINOS] ([UsuarioId]);
GO

CREATE INDEX [IX_TB_ACESSORIOS_ViolinoId] ON [TB_ACESSORIOS] ([ViolinoId]);
GO

ALTER TABLE [TB_VIOLINOS] ADD CONSTRAINT [FK_TB_VIOLINOS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241110194737_MigracaoUsuario', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0x42FCE4407BBC89F6A03FA89B33FE82234D00B6B1EA8A9F7B6D0E1B0C5FACAE4D9EB41CD621EA42ECB1C3C6FF99B4FC7D11E65957618179D86AF000AF6A0F29B9, [PasswordSalt] = 0xE43F44813E533A8C0165B68BB4D14CD754FB3C4747E6BF67CC60EF81934E3E0EBA4ECB4BBAA682BAE749D8015059619ABC5771FC4AAD3E245C6D33D7A08E230471A21E3090B9BD07BE0E040994C89F70CC8CDDC0563703D6B72AB14D913C98DE03F2B6F0231F1A0EDAA1E740DF93366FE1F0F2441394C5305EE469FA6FA0E52B
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241111225925_MigracaoViolino', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0xB75F94045A5126548CF586D5F1B66237095ACB44F1993D92E25EAFDEDD7678E422C6681C86DF8A61DE7B7625A903CBBF9926AEDF980B7F111EAA22077D9AF0F1, [PasswordSalt] = 0x6F75B9EDD084BA9AB650155AADBE724BD7A5D9EADDB4D78B1C4141EADC1CB642F5881BF7D1798EBC4256AA4150FFE9A70C9E8AAB040BFD70926F6513B36C8D38BEF6E44D9C841DC16AC766497AD4C00D4C0F4134D33FD5C93CA96871A53F40082B917895ED09D7533D40C61E0B4B4B88A85E9DCC3756E75405844BAD31CEA33A
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241111230036_MigracaoAcessorio', N'8.0.10');
GO

COMMIT;
GO

