CREATE TABLE [dbo].[workhours]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [employee] INT NOT NULL FOREIGN KEY REFERENCES employees(id), 
    [contract] INT NOT NULL FOREIGN KEY REFERENCES contracts(id), 
    [worktype] INT NOT NULL FOREIGN KEY REFERENCES worktypes(id),
    [hours] INT NOT NULL, 
    [insertdate] DATE NOT NULL, 
    [insertuser] INT NOT NULL FOREIGN KEY REFERENCES users(id),
)
