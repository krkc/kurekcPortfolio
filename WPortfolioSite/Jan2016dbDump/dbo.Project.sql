CREATE TABLE [dbo].[Project] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100) NOT NULL,
    [Language]    NVARCHAR (20)  NOT NULL,
    [Subtopic]    NVARCHAR (50)  NULL,
    [Title]       NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([ID] ASC)
);

