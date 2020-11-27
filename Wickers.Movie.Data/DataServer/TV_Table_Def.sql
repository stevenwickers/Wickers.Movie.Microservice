CREATE TABLE [dbo].[TV] (
    [TVID]        INT           IDENTITY (1, 1) NOT NULL,
    [TVName]      VARCHAR (250) NULL,
    [YearStart]   CHAR (4)      NULL,
    [YearEnd]     CHAR (4)      NULL,
    [Description] VARCHAR (MAX) NULL
);