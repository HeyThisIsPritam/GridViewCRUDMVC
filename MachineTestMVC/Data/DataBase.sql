CREATE DATABASE MachineTestMVC
GO
USE MachineTestMVC

CREATE TABLE [dbo].[UserDetails] (
    [id]        INT           IDENTITY (20495100, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [Gender]    CHAR (10)     NOT NULL,
    [Birthday]  DATE          NOT NULL,
    [Status]    NVARCHAR (50) NOT NULL,
    [Address]   NVARCHAR (50) NOT NULL,
    [Time]      TIME (7)      NOT NULL,
    [is_active] BIT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
GO