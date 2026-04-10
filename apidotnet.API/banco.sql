IF NOT EXISTS (
    SELECT name 
    FROM sys.databases 
    WHERE name = 'apidotnet'
)
BEGIN
    CREATE DATABASE apidotnet;
END
GO

USE apidotnet;
GO

IF NOT EXISTS (
    SELECT * 
    FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'[dbo].[Contatos]') 
    AND type in (N'U')
)
BEGIN
    CREATE TABLE [dbo].[Contatos] (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(150) NOT NULL,
        DataNascimento DATE NOT NULL,
        Sexo INT NOT NULL,
        Ativo BIT NOT NULL DEFAULT 1,
        DataCriacao DATETIME2 NOT NULL DEFAULT GETDATE(),
        DataAtualizacao DATETIME2 NULL
    );
END
GO

IF NOT EXISTS (
    SELECT * FROM sys.check_constraints 
    WHERE name = 'CK_Contato_DataNascimento'
)
BEGIN
    ALTER TABLE Contatos
    ADD CONSTRAINT CK_Contato_DataNascimento
    CHECK (DataNascimento <= CAST(GETDATE() AS DATE));
END
GO

IF NOT EXISTS (
    SELECT * FROM sys.check_constraints 
    WHERE name = 'CK_Contato_Idade'
)
BEGIN
    ALTER TABLE Contatos
    ADD CONSTRAINT CK_Contato_Idade
    CHECK (DATEDIFF(YEAR, DataNascimento, GETDATE()) >= 18);
END
GO

IF NOT EXISTS (
    SELECT * FROM sys.check_constraints 
    WHERE name = 'CK_Contato_Nome'
)
BEGIN
    ALTER TABLE Contatos
    ADD CONSTRAINT CK_Contato_Nome
    CHECK (LEN(Nome) >= 3);
END
GO

IF NOT EXISTS (
    SELECT * FROM sys.indexes 
    WHERE name = 'IX_Contatos_Ativo'
)
BEGIN
    CREATE INDEX IX_Contatos_Ativo
    ON Contatos (Ativo);
END
GO

IF NOT EXISTS (SELECT 1 FROM Contatos)
BEGIN
    INSERT INTO Contatos (Nome, DataNascimento, Sexo)
    VALUES
    ('Carol', '1998-05-10', 2),
    ('João', '1990-03-20', 1),
    ('Alex', '2000-01-01', 3);
END
GO


SELECT * FROM Contatos;
GO