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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220513064848_InitializeData')
BEGIN
    CREATE TABLE [Pension] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Amount] int NOT NULL,
        [Duration] int NOT NULL,
        CONSTRAINT [PK_Pension] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220513064848_InitializeData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220513064848_InitializeData', N'6.0.5');
END;
GO

COMMIT;
GO

