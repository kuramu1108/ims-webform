CREATE TABLE [dbo].[InterventionType] (
    [Id]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]  NVARCHAR (MAX)   NOT NULL,
    [Hours] INT              NULL,
    [Costs] DECIMAL (18)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

