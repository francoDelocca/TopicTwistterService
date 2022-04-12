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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [Categories] (
        [CategoryId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [Players] (
        [PlayerId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [email] nvarchar(max) NULL,
        [password] nvarchar(max) NULL,
        CONSTRAINT [PK_Players] PRIMARY KEY ([PlayerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [Words] (
        [WordId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Words] PRIMARY KEY ([WordId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [CategoryWord] (
        [CategoriesCategoryId] int NOT NULL,
        [WordsWordId] int NOT NULL,
        CONSTRAINT [PK_CategoryWord] PRIMARY KEY ([CategoriesCategoryId], [WordsWordId]),
        CONSTRAINT [FK_CategoryWord_Categories_CategoriesCategoryId] FOREIGN KEY ([CategoriesCategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE,
        CONSTRAINT [FK_CategoryWord_Words_WordsWordId] FOREIGN KEY ([WordsWordId]) REFERENCES [Words] ([WordId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [CategoryRound] (
        [CategoriesCategoryId] int NOT NULL,
        [RoundsRoundId] int NOT NULL,
        CONSTRAINT [PK_CategoryRound] PRIMARY KEY ([CategoriesCategoryId], [RoundsRoundId]),
        CONSTRAINT [FK_CategoryRound_Categories_CategoriesCategoryId] FOREIGN KEY ([CategoriesCategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [WordsEnteredByPlayer] (
        [WordsEnteredByPlayerId] int NOT NULL IDENTITY,
        [PlayerId] int NOT NULL,
        [RoundId] int NULL,
        [CategoryId] int NULL,
        [WordEntered] nvarchar(max) NULL,
        CONSTRAINT [PK_WordsEnteredByPlayer] PRIMARY KEY ([WordsEnteredByPlayerId]),
        CONSTRAINT [FK_WordsEnteredByPlayer_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WordsEnteredByPlayer_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [Rounds] (
        [RoundId] int NOT NULL IDENTITY,
        [WinnerPlayerId] int NULL,
        [RoundLetter] nvarchar(1) NOT NULL,
        [MatchId] int NULL,
        CONSTRAINT [PK_Rounds] PRIMARY KEY ([RoundId]),
        CONSTRAINT [FK_Rounds_Players_WinnerPlayerId] FOREIGN KEY ([WinnerPlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE TABLE [Matches] (
        [MatchId] int NOT NULL IDENTITY,
        [MatchClosed] bit NOT NULL,
        [WinnerPlayerId] int NULL,
        [CurrentRoundRoundId] int NULL,
        [PlayerId] int NULL,
        [OpponentPlayerId] int NULL,
        CONSTRAINT [PK_Matches] PRIMARY KEY ([MatchId]),
        CONSTRAINT [FK_Matches_Players_OpponentPlayerId] FOREIGN KEY ([OpponentPlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Matches_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Matches_Players_WinnerPlayerId] FOREIGN KEY ([WinnerPlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Matches_Rounds_CurrentRoundRoundId] FOREIGN KEY ([CurrentRoundRoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_CategoryRound_RoundsRoundId] ON [CategoryRound] ([RoundsRoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_CategoryWord_WordsWordId] ON [CategoryWord] ([WordsWordId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_Matches_CurrentRoundRoundId] ON [Matches] ([CurrentRoundRoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_Matches_OpponentPlayerId] ON [Matches] ([OpponentPlayerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_Matches_PlayerId] ON [Matches] ([PlayerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_Matches_WinnerPlayerId] ON [Matches] ([WinnerPlayerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_Rounds_MatchId] ON [Rounds] ([MatchId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_Rounds_WinnerPlayerId] ON [Rounds] ([WinnerPlayerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_WordsEnteredByPlayer_CategoryId] ON [WordsEnteredByPlayer] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_WordsEnteredByPlayer_PlayerId] ON [WordsEnteredByPlayer] ([PlayerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    CREATE INDEX [IX_WordsEnteredByPlayer_RoundId] ON [WordsEnteredByPlayer] ([RoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    ALTER TABLE [CategoryRound] ADD CONSTRAINT [FK_CategoryRound_Rounds_RoundsRoundId] FOREIGN KEY ([RoundsRoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    ALTER TABLE [WordsEnteredByPlayer] ADD CONSTRAINT [FK_WordsEnteredByPlayer_Rounds_RoundId] FOREIGN KEY ([RoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    ALTER TABLE [Rounds] ADD CONSTRAINT [FK_Rounds_Matches_MatchId] FOREIGN KEY ([MatchId]) REFERENCES [Matches] ([MatchId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Name])
    VALUES (N''Frutas y Verduras''),
    (N''Objetos''),
    (N''Idiomas''),
    (N''Paises y Ciudades''),
    (N''Nombres'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[Words]'))
        SET IDENTITY_INSERT [Words] ON;
    EXEC(N'INSERT INTO [Words] ([Name])
    VALUES (N''anana''),
    (N''anzuelo''),
    (N''aleman''),
    (N''alemania''),
    (N''andrea''),
    (N''espinaca''),
    (N''edredon''),
    (N''eslovaco''),
    (N''eslovenia''),
    (N''esteban''),
    (N''oliva''),
    (N''ocarina''),
    (N''otomi''),
    (N''oslo''),
    (N''oscar''),
    (N''icaco''),
    (N''iman''),
    (N''irani''),
    (N''iran''),
    (N''iñaki''),
    (N''uva''),
    (N''uña''),
    (N''ucrania''),
    (N''ucraniano''),
    (N''urraca'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name') AND [object_id] = OBJECT_ID(N'[Words]'))
        SET IDENTITY_INSERT [Words] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name', N'email', N'password') AND [object_id] = OBJECT_ID(N'[Players]'))
        SET IDENTITY_INSERT [Players] ON;
    EXEC(N'INSERT INTO [Players] ([Name], [email], [password])
    VALUES (N''groso'', N''groso@gmail.com'', N''123''),
    (N''suller'', N''suller@gmail.com'', N''123'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name', N'email', N'password') AND [object_id] = OBJECT_ID(N'[Players]'))
        SET IDENTITY_INSERT [Players] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoriesCategoryId', N'WordsWordId') AND [object_id] = OBJECT_ID(N'[CategoryWord]'))
        SET IDENTITY_INSERT [CategoryWord] ON;
    EXEC(N'INSERT INTO [CategoryWord] ([CategoriesCategoryId], [WordsWordId])
    VALUES (1, 1),
    (1, 6),
    (1, 11),
    (1, 16),
    (1, 21),
    (2, 2),
    (2, 7),
    (2, 12),
    (2, 17),
    (2, 22),
    (3, 3),
    (3, 8),
    (3, 13),
    (3, 18),
    (3, 23),
    (4, 4),
    (4, 9),
    (4, 14),
    (4, 19),
    (4, 25),
    (5, 5),
    (5, 10),
    (5, 15),
    (5, 20),
    (5, 25)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoriesCategoryId', N'WordsWordId') AND [object_id] = OBJECT_ID(N'[CategoryWord]'))
        SET IDENTITY_INSERT [CategoryWord] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211014232756_intial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211014232756_intial', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Rounds_CurrentRoundRoundId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    ALTER TABLE [Rounds] DROP CONSTRAINT [FK_Rounds_Matches_MatchId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    DROP INDEX [IX_Matches_CurrentRoundRoundId] ON [Matches];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Matches]') AND [c].[name] = N'CurrentRoundRoundId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Matches] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Matches] DROP COLUMN [CurrentRoundRoundId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    DROP INDEX [IX_Rounds_MatchId] ON [Rounds];
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Rounds]') AND [c].[name] = N'MatchId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Rounds] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Rounds] ALTER COLUMN [MatchId] int NOT NULL;
    ALTER TABLE [Rounds] ADD DEFAULT 0 FOR [MatchId];
    CREATE INDEX [IX_Rounds_MatchId] ON [Rounds] ([MatchId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    ALTER TABLE [Rounds] ADD [Close] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    ALTER TABLE [Rounds] ADD CONSTRAINT [FK_Rounds_Matches_MatchId] FOREIGN KEY ([MatchId]) REFERENCES [Matches] ([MatchId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211015000344_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211015000344_v2', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016002538_TopicTwister_v2')
BEGIN
    DROP TABLE [CategoryRound];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016002538_TopicTwister_v2')
BEGIN
    ALTER TABLE [Categories] ADD [RoundId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016002538_TopicTwister_v2')
BEGIN
    CREATE INDEX [IX_Categories_RoundId] ON [Categories] ([RoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016002538_TopicTwister_v2')
BEGIN
    ALTER TABLE [Categories] ADD CONSTRAINT [FK_Categories_Rounds_RoundId] FOREIGN KEY ([RoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016002538_TopicTwister_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211016002538_TopicTwister_v2', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016021543_TopicTwister_v3')
BEGIN
    ALTER TABLE [Categories] DROP CONSTRAINT [FK_Categories_Rounds_RoundId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016021543_TopicTwister_v3')
BEGIN
    DROP INDEX [IX_Categories_RoundId] ON [Categories];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016021543_TopicTwister_v3')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'RoundId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Categories] DROP COLUMN [RoundId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016021543_TopicTwister_v3')
BEGIN
    CREATE TABLE [CategoryRound] (
        [CategoriesCategoryId] int NOT NULL,
        [RoundsRoundId] int NOT NULL,
        CONSTRAINT [PK_CategoryRound] PRIMARY KEY ([CategoriesCategoryId], [RoundsRoundId]),
        CONSTRAINT [FK_CategoryRound_Categories_CategoriesCategoryId] FOREIGN KEY ([CategoriesCategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE,
        CONSTRAINT [FK_CategoryRound_Rounds_RoundsRoundId] FOREIGN KEY ([RoundsRoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016021543_TopicTwister_v3')
BEGIN
    CREATE INDEX [IX_CategoryRound_RoundsRoundId] ON [CategoryRound] ([RoundsRoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211016021543_TopicTwister_v3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211016021543_TopicTwister_v3', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211017134521_TopicTwister_v4')
BEGIN
    ALTER TABLE [Rounds] ADD [TimeByLocalUser] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211017134521_TopicTwister_v4')
BEGIN
    ALTER TABLE [Rounds] ADD [TimeByOpponent] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211017134521_TopicTwister_v4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211017134521_TopicTwister_v4', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018210446_TopicTwister_v5')
BEGIN
    ALTER TABLE [Rounds] DROP CONSTRAINT [FK_Rounds_Players_WinnerPlayerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018210446_TopicTwister_v5')
BEGIN
    EXEC sp_rename N'[Rounds].[WinnerPlayerId]', N'WinnerRoundPlayerId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018210446_TopicTwister_v5')
BEGIN
    EXEC sp_rename N'[Rounds].[IX_Rounds_WinnerPlayerId]', N'IX_Rounds_WinnerRoundPlayerId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018210446_TopicTwister_v5')
BEGIN
    ALTER TABLE [Rounds] ADD CONSTRAINT [FK_Rounds_Players_WinnerRoundPlayerId] FOREIGN KEY ([WinnerRoundPlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211018210446_TopicTwister_v5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211018210446_TopicTwister_v5', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019223847_TopicTwister_v6')
BEGIN
    EXEC sp_rename N'[Rounds].[TimeByOpponent]', N'TimeByPlayerTwo', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019223847_TopicTwister_v6')
BEGIN
    EXEC sp_rename N'[Rounds].[TimeByLocalUser]', N'TimeByPlayerOne', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019223847_TopicTwister_v6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211019223847_TopicTwister_v6', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Players_OpponentPlayerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Players_PlayerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    EXEC sp_rename N'[Matches].[PlayerId]', N'PlayerTwoPlayerId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    EXEC sp_rename N'[Matches].[OpponentPlayerId]', N'PlayerOnePlayerId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    EXEC sp_rename N'[Matches].[IX_Matches_PlayerId]', N'IX_Matches_PlayerTwoPlayerId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    EXEC sp_rename N'[Matches].[IX_Matches_OpponentPlayerId]', N'IX_Matches_PlayerOnePlayerId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [FK_Matches_Players_PlayerOnePlayerId] FOREIGN KEY ([PlayerOnePlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [FK_Matches_Players_PlayerTwoPlayerId] FOREIGN KEY ([PlayerTwoPlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019224200_TopicTwister_v7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211019224200_TopicTwister_v7', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019225232_TopicTwister_v8')
BEGIN
    ALTER TABLE [WordsEnteredByPlayer] DROP CONSTRAINT [FK_WordsEnteredByPlayer_Categories_CategoryId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019225232_TopicTwister_v8')
BEGIN
    ALTER TABLE [WordsEnteredByPlayer] DROP CONSTRAINT [FK_WordsEnteredByPlayer_Rounds_RoundId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019225232_TopicTwister_v8')
BEGIN
    DROP INDEX [IX_WordsEnteredByPlayer_RoundId] ON [WordsEnteredByPlayer];
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WordsEnteredByPlayer]') AND [c].[name] = N'RoundId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [WordsEnteredByPlayer] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [WordsEnteredByPlayer] ALTER COLUMN [RoundId] int NOT NULL;
    ALTER TABLE [WordsEnteredByPlayer] ADD DEFAULT 0 FOR [RoundId];
    CREATE INDEX [IX_WordsEnteredByPlayer_RoundId] ON [WordsEnteredByPlayer] ([RoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019225232_TopicTwister_v8')
BEGIN
    DROP INDEX [IX_WordsEnteredByPlayer_CategoryId] ON [WordsEnteredByPlayer];
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WordsEnteredByPlayer]') AND [c].[name] = N'CategoryId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [WordsEnteredByPlayer] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [WordsEnteredByPlayer] ALTER COLUMN [CategoryId] int NOT NULL;
    ALTER TABLE [WordsEnteredByPlayer] ADD DEFAULT 0 FOR [CategoryId];
    CREATE INDEX [IX_WordsEnteredByPlayer_CategoryId] ON [WordsEnteredByPlayer] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019225232_TopicTwister_v8')
BEGIN
    ALTER TABLE [WordsEnteredByPlayer] ADD CONSTRAINT [FK_WordsEnteredByPlayer_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019225232_TopicTwister_v8')
BEGIN
    ALTER TABLE [WordsEnteredByPlayer] ADD CONSTRAINT [FK_WordsEnteredByPlayer_Rounds_RoundId] FOREIGN KEY ([RoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019225232_TopicTwister_v8')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211019225232_TopicTwister_v8', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019234519_TopicTwister_v9')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211019234519_TopicTwister_v9', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019234747_TopicTwister_v10')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Players_PlayerTwoPlayerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019234747_TopicTwister_v10')
BEGIN
    EXEC sp_rename N'[Matches].[PlayerTwoPlayerId]', N'PlayerTwoId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019234747_TopicTwister_v10')
BEGIN
    EXEC sp_rename N'[Matches].[IX_Matches_PlayerTwoPlayerId]', N'IX_Matches_PlayerTwoId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019234747_TopicTwister_v10')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [FK_Matches_Players_PlayerTwoId] FOREIGN KEY ([PlayerTwoId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019234747_TopicTwister_v10')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211019234747_TopicTwister_v10', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211019235207_TopicTwister_v11')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211019235207_TopicTwister_v11', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020000138_TopicTwister_v12')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Players_PlayerOnePlayerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020000138_TopicTwister_v12')
BEGIN
    EXEC sp_rename N'[Matches].[PlayerOnePlayerId]', N'PlayerOneId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020000138_TopicTwister_v12')
BEGIN
    EXEC sp_rename N'[Matches].[IX_Matches_PlayerOnePlayerId]', N'IX_Matches_PlayerOneId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020000138_TopicTwister_v12')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [FK_Matches_Players_PlayerOneId] FOREIGN KEY ([PlayerOneId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211020000138_TopicTwister_v12')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211020000138_TopicTwister_v12', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Players_PlayerOneId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Players_PlayerTwoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [FK_Matches_Players_WinnerPlayerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    DROP TABLE [CategoryRound];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    EXEC sp_rename N'[Matches].[WinnerPlayerId]', N'WinnerPlayerPlayerId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    EXEC sp_rename N'[Matches].[PlayerTwoId]', N'PlayerTwoPlayerId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    EXEC sp_rename N'[Matches].[PlayerOneId]', N'PlayerOnePlayerId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    EXEC sp_rename N'[Matches].[IX_Matches_WinnerPlayerId]', N'IX_Matches_WinnerPlayerPlayerId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    EXEC sp_rename N'[Matches].[IX_Matches_PlayerTwoId]', N'IX_Matches_PlayerTwoPlayerId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    EXEC sp_rename N'[Matches].[IX_Matches_PlayerOneId]', N'IX_Matches_PlayerOnePlayerId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Categories] ADD [RoundId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    CREATE INDEX [IX_Categories_RoundId] ON [Categories] ([RoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Categories] ADD CONSTRAINT [FK_Categories_Rounds_RoundId] FOREIGN KEY ([RoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [FK_Matches_Players_PlayerOnePlayerId] FOREIGN KEY ([PlayerOnePlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [FK_Matches_Players_PlayerTwoPlayerId] FOREIGN KEY ([PlayerTwoPlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [FK_Matches_Players_WinnerPlayerPlayerId] FOREIGN KEY ([WinnerPlayerPlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030142835_TopicTwister_v13')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211030142835_TopicTwister_v13', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030213223_TopicTwister_v14')
BEGIN
    ALTER TABLE [Categories] DROP CONSTRAINT [FK_Categories_Rounds_RoundId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030213223_TopicTwister_v14')
BEGIN
    DROP INDEX [IX_Categories_RoundId] ON [Categories];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030213223_TopicTwister_v14')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'RoundId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Categories] DROP COLUMN [RoundId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030213223_TopicTwister_v14')
BEGIN
    CREATE TABLE [CategoryRound] (
        [CategoriesCategoryId] int NOT NULL,
        [RoundsRoundId] int NOT NULL,
        CONSTRAINT [PK_CategoryRound] PRIMARY KEY ([CategoriesCategoryId], [RoundsRoundId]),
        CONSTRAINT [FK_CategoryRound_Categories_CategoriesCategoryId] FOREIGN KEY ([CategoriesCategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE,
        CONSTRAINT [FK_CategoryRound_Rounds_RoundsRoundId] FOREIGN KEY ([RoundsRoundId]) REFERENCES [Rounds] ([RoundId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030213223_TopicTwister_v14')
BEGIN
    CREATE INDEX [IX_CategoryRound_RoundsRoundId] ON [CategoryRound] ([RoundsRoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211030213223_TopicTwister_v14')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211030213223_TopicTwister_v14', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211103130311_TopicTwister_v15')
BEGIN
    ALTER TABLE [WordsEnteredByPlayer] ADD [IsValid] bit NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211103130311_TopicTwister_v15')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211103130311_TopicTwister_v15', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211107213925_TopicTwister_v16')
BEGIN
    ALTER TABLE [Rounds] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211107213925_TopicTwister_v16')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211107213925_TopicTwister_v16', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212233239_TopicTwister_v17')
BEGIN
    CREATE TABLE [Notifications] (
        [NotificationId] int NOT NULL IDENTITY,
        [PlayerId] int NOT NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY ([NotificationId]),
        CONSTRAINT [FK_Notifications_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([PlayerId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212233239_TopicTwister_v17')
BEGIN
    CREATE UNIQUE INDEX [IX_Notifications_PlayerId] ON [Notifications] ([PlayerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211212233239_TopicTwister_v17')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211212233239_TopicTwister_v17', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220215004818_WinsByPlayer')
BEGIN
    ALTER TABLE [Players] ADD [Wins] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220215004818_WinsByPlayer')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220215004818_WinsByPlayer', N'5.0.11');
END;
GO

COMMIT;
GO

