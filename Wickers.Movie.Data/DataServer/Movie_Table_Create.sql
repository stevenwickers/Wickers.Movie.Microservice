Drop Table [dbo].[Movie]

CREATE TABLE [dbo].[Movie] (
    [MovieID]          INT           IDENTITY (1, 1) NOT NULL,
    [MovieName]        VARCHAR (150) NULL,
    [ReleaseDate]      VARCHAR (50)  NULL,
    [WorldwideGross]   VARCHAR (50)  NULL,
    [ProductionBudget] VARCHAR (50)  NULL,
    [DomesticGross]    VARCHAR (50)  NULL,
    [MovieLink]        VARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([MovieID] ASC)
);