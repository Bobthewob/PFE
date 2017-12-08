CREATE TABLE [dbo].[App] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [guid]  UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [descr] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_App] PRIMARY KEY CLUSTERED ([id] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [IX_AppGuid]
    ON [dbo].[App]([guid] ASC) WITH (FILLFACTOR = 90);

