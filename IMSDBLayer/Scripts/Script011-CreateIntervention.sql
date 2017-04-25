CREATE TABLE [dbo].[Interventions] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [Hours]              DECIMAL (18, 2)  NULL,
    [Costs]              DECIMAL (18, 2)  NULL,
    [LifeRemaining]      INT              NULL,
    [Comments]           NVARCHAR (MAX)   NULL,
    [State]              INT              NULL,
    [DateCreate]         DATETIME         NULL,
    [DateFinish]         DATETIME         NULL,
    [DateRecentVisit]    DATETIME         NULL,
    [InterventionTypeId] UNIQUEIDENTIFIER NULL,
    [ClientId]           UNIQUEIDENTIFIER NULL,
    [CreatedBy]          UNIQUEIDENTIFIER NULL,
    [ApprovedBy]         UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_InterventionType] FOREIGN KEY ([InterventionTypeId]) REFERENCES [dbo].[InterventionTypes] ([Id]),
    CONSTRAINT [FK_Table_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]),
    CONSTRAINT [FK_Table_CreateBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Table_ApprovedBy] FOREIGN KEY ([ApprovedBy]) REFERENCES [dbo].[Users] ([Id])
);

