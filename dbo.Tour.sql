CREATE TABLE [dbo].[Tour] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (MAX) NOT NULL,
    [Location]         NVARCHAR (MAX) NOT NULL,
    [GroupSize]        NVARCHAR (MAX) NULL,
    [Time]             NVARCHAR (MAX) NOT NULL,
    [Price]            DECIMAL (6, 2) NOT NULL,
    [StartingTourDate] DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [CountryID]        INT            NULL,
    CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Tour_Country_CountryID] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Country] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Tour_CountryID]
    ON [dbo].[Tour]([CountryID] ASC);

