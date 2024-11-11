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

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0x2DA714416EA1E9692DCBE5C9A259DF7AB3B463063D9308ED65AE7F47D2F613104F80AB8C250E1424A81D2DB7EC945B03BC7207C56FAD5B72EA5516C1276159EB, [PasswordSalt] = 0x4E5181907A695ADC98F1200F16098ABE44E277F092E081223B908608C2BF70AD62383FAA1BE8EA27167F59113A8D72E2DE7CA204F8DFC546848FD433DEAA99F94BEB94D05DEF39B061B257F2FFB98BD529A2CBF18BE73AEAA0D056AFB1E2F07A8B9D03ECBD9095E02EDA4B994B6C0008F3ED45E40C6D697F18D2E3D4FCD25BF7
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241110200257_RelacoesViolinoAcessorio', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [TB_ACESSORIOS] SET [Descricao] = 'As cordas Mauro Calixto são indicadas para qualquer estilo musical e procuradas iniciantes...', [Marca] = 'Mauro Calixto', [Materiais] = 'Núcleo de fibra sintética e Revestimento em aço', [Modelo] = 'Padrão', [Nome] = 'Encordeamento', [TipoAcessorios] = 1, [Valor] = 52.0E0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'Nome', N'TipoAcessorios', N'Valor', N'ViolinoId') AND [object_id] = OBJECT_ID(N'[TB_ACESSORIOS]'))
    SET IDENTITY_INSERT [TB_ACESSORIOS] ON;
INSERT INTO [TB_ACESSORIOS] ([Id], [Descricao], [Marca], [Materiais], [Modelo], [Nome], [TipoAcessorios], [Valor], [ViolinoId])
VALUES (2, 'Produzido na Alemanha se utilizando dos melhores materiais, a marca Pirastro é dominante no sergmento de...', 'Pirastro', 'Resina Natural de Pinho', 'CV-52', 'Breu', 2, 54.649999999999999E0, 1),
(3, 'A espaleira Lunnon new apresenta design mais anatômico, que proporciona conforto, segurança e flexibilidade...', 'Lunnon', 'Plástico injetável', 'New', 'Espaleira', 3, 36.0E0, 1),
(4, 'Produto Original da Fábrica, é necessário fazer furos e ajustes em um Luthier para que seja regulado em seu instrumento...', ' NETO VIOLINOS', 'ÉBANO MESCLADO', 'KIT 04 CRAVELHAS TAMARINDO PREMIUM', 'Cravelha', 4, 48.950000000000003E0, 1),
(5, 'Também pode ser chamado simplesmente de fixo, é uma peça que utilizamos para ajudar no momento de afinação...', 'Mavis', 'Metal', 'Niquelado', 'Microafinador', 5, 9.3599999999999994E0, 1),
(6, 'A queixeira é um acessório que se encaixa no extremo do corpo do violino ou da viola de arco. É um peça essencial...', 'Mavis', 'Madeira de Ébano', 'Ébano', 'Queixeira', 6, 84.200000000000003E0, 1),
(7, 'Disponíveis nos tamanhos:  1/10, 1/16, 1/4, 1/2, 3/4 e 4/4...', 'Mavis', 'Madeira de Ébano', 'Ébano', 'Estandarte', 7, 50.939999999999998E0, 1),
(8, 'Cavalete fabricado com madeira Maple de ótima qualidade, com a finalidade de proporcionar ao músico uma maior precisão...', 'Mavis', 'Madeira Mapple', 'Madeira Mapple Mavis', 'Cavalete', 8, 12.470000000000001E0, 1),
(9, 'Descubra a qualidade excepcional do Arco Para Violino Eagle 4/4 VWB-44R Crina Animal Natural...', 'Eagle', 'Hardwood no formato Octogonal (oitavado), Crina animal natural, Talão de ébano com madre-pérola Olho París incrustada', 'VWB44R', 'Arco', 9, 89.099999999999994E0, 1),
(10, 'Disponíveis nos tamanhos: 1/16, 1/8, 1/4, 1/2 e 3/4...', 'Mavis', 'Madeira de Ébano', 'Ébano', 'Espelho', 10, 90.439999999999998E0, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'Nome', N'TipoAcessorios', N'Valor', N'ViolinoId') AND [object_id] = OBJECT_ID(N'[TB_ACESSORIOS]'))
    SET IDENTITY_INSERT [TB_ACESSORIOS] OFF;
GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0xC1BBD01DEEE0414BA3035C7B874487332B4A3F9012C32E1DE3FDA8086EFEA17A7859FEB14BBD8EA95F217096BD7E0E18507C8FF8FBAF0DAF233C33C4E64B62B8, [PasswordSalt] = 0x32348A72AADA135AE69943D6621D57E6D31A764A3F4E184D605F57DFCE26167432216D3B00CBEC04F5A75170AEF10C67698506AB98B6F94D39E1E0435A9FD49B97724944B9CF59EA9E5D00641B92FA80469EDF24CD8A372D467DF24BAF35673157942D73761917C1FEC95DA24B334342B214BA0677E2860DEAB4CCD263F6CB5C
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241111014611_RelacoesUsuarioViolinoAcessorio', N'8.0.10');
GO

COMMIT;
GO

