CREATE TABLE [dbo].[users] (
    [id]           INT              IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (50)    NOT NULL,
    [passwordhash] VARBINARY (1024) NOT NULL,
    [passwordsalt] VARBINARY (1024) NOT NULL,
    [role]         INT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC),
    UNIQUE NONCLUSTERED ([name] ASC),
    FOREIGN KEY ([role]) REFERENCES [dbo].[roles] ([id])
);

