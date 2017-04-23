CREATE TABLE [dbo].[User] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]            NVARCHAR (50)    NOT NULL,
    [Type]            INT              NULL,
    [AuthorisedHours] DECIMAL (18, 2)  NULL,
    [AuthorisedCosts] DECIMAL (18, 2)  NULL,
    [IdentityId]      NVARCHAR (128)   NOT NULL,
    [DistrictId]      UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_ToAspNetUsers] FOREIGN KEY ([IdentityId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_User_ToDistrict] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[District] ([Id])
);

