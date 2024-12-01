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

CREATE TABLE [TB_VIOLINOS] (
    [Id] int NOT NULL IDENTITY,
    [Modelo] varchar(200) NOT NULL,
    [Marca] varchar(200) NOT NULL,
    [Materiais] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Valor] float NOT NULL,
    [UsuarioId] int NULL,
    CONSTRAINT [PK_TB_VIOLINOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_VIOLINOS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id])
);
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Perfil], [Username])
VALUES (1, NULL, 'seuEmail@gmail.com', NULL, -23.520024100000001E0, -46.596497999999997E0, 0x4641DEC9B4305BF431EB8D53B9641F22375854690888FA480A97031BBD982BE6F25FE7CFB2A2155014025379779E0FD9EFFA058839E036CEF65AD8546B0137C7, 0x203E406793EBF1BA1AE7ED5CF7F86FB68BDCA7AAA55B10265B434B4AED8068E6B3D902F45551B4AD611369C50432297121927528C4D7E4C9254B4A35D02239C247B54EE5B212A80181AC4457EA59B49A84B0182662E3A16483F7998BD5EA24BB8AA4674518BD2C78CD265E087E3B4B0971EBC04CEC4E856A821B2FAC819559FB, 'Admin', 'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'UsuarioId', N'Valor') AND [object_id] = OBJECT_ID(N'[TB_VIOLINOS]'))
    SET IDENTITY_INSERT [TB_VIOLINOS] ON;
INSERT INTO [TB_VIOLINOS] ([Id], [Descricao], [Marca], [Materiais], [Modelo], [UsuarioId], [Valor])
VALUES (1, 'Queixeira, estandarte, cravelhas e botão: Ébano. Encordoamento: M Calixto. Arco de crina natural e madeira maçaranduba. Estojo Gota. Ajuste Profissional (cavalete original, alma, pestana, cravelhas)', 'Eagles', 'Violino: Abeto e Atiro. Ébano. Arco: Maçaranduba', 'CV-12', 1, 1283.8499999999999E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'UsuarioId', N'Valor') AND [object_id] = OBJECT_ID(N'[TB_VIOLINOS]'))
    SET IDENTITY_INSERT [TB_VIOLINOS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Marca', N'Materiais', N'Modelo', N'Nome', N'TipoAcessorios', N'Valor', N'ViolinoId') AND [object_id] = OBJECT_ID(N'[TB_ACESSORIOS]'))
    SET IDENTITY_INSERT [TB_ACESSORIOS] ON;
INSERT INTO [TB_ACESSORIOS] ([Id], [Descricao], [Marca], [Materiais], [Modelo], [Nome], [TipoAcessorios], [Valor], [ViolinoId])
VALUES (1, 'As cordas Mauro Calixto são indicadas para qualquer estilo musical e procuradas iniciantes...', 'Mauro Calixto', 'Núcleo de fibra sintética e Revestimento em aço', 'Padrão', 'Encordeamento', 1, 52.0E0, 1),
(2, 'Produzido na Alemanha se utilizando dos melhores materiais, a marca Pirastro é dominante no sergmento de...', 'Pirastro', 'Resina Natural de Pinho', 'CV-52', 'Breu', 2, 54.649999999999999E0, 1),
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

CREATE INDEX [IX_TB_ACESSORIOS_ViolinoId] ON [TB_ACESSORIOS] ([ViolinoId]);
GO

CREATE INDEX [IX_TB_VIOLINOS_UsuarioId] ON [TB_VIOLINOS] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241201203656_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

