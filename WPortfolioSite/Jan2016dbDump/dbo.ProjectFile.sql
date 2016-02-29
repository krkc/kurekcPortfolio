CREATE TABLE [dbo].[ProjectFile] (
    [ProjectID]  INT           IDENTITY (1, 1) NOT NULL,
    [Filename]   NVARCHAR (50) NOT NULL,
    [ProjectID1] INT           NULL,
    CONSTRAINT [PK_ProjectFile] PRIMARY KEY CLUSTERED ([ProjectID] ASC),
    CONSTRAINT [FK_ProjectFile_Project_ProjectID1] FOREIGN KEY ([ProjectID1]) REFERENCES [dbo].[Project] ([ID])
);

