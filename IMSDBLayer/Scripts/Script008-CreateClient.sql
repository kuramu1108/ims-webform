CREATE TABLE [dbo].[Client] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]       NVARCHAR (50)    NOT NULL,
    [Location]   NVARCHAR (MAX)   NOT NULL,
    [DistrictId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_District] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[District] ([Id])
);

