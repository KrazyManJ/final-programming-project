CREATE TABLE [dbo].[roles]
(
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR(50)        NOT NULL,
    [perm_full] BIT DEFAULT ((0))   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC)
);
