/* TABLE DROPS */

IF OBJECT_ID('workhours', 'U') IS NOT NULL DROP TABLE workhours;
IF OBJECT_ID('worktypes', 'U') IS NOT NULL DROP TABLE worktypes;
IF OBJECT_ID('users', 'U') IS NOT NULL DROP TABLE users;
IF OBJECT_ID('roles', 'U') IS NOT NULL DROP TABLE roles;
IF OBJECT_ID('employees', 'U') IS NOT NULL DROP TABLE employees;
IF OBJECT_ID('contracts', 'U') IS NOT NULL DROP TABLE contracts;

/* CONTRACTS */

CREATE TABLE [dbo].[contracts]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [customer] NVARCHAR(50) NOT NULL, 
    [description] NTEXT NOT NULL
);

INSERT INTO [dbo].[contracts] VALUES (N'LANIK s.r.o.',N'První zakázka');
INSERT INTO [dbo].[contracts] VALUES (N'Gatema Holding s.r.o.',N'Druhá zakázka');

/* EMPLOYEES */

CREATE TABLE [dbo].[employees]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [firstname] NVARCHAR(50) NOT NULL, 
    [lastname] NVARCHAR(50) NOT NULL, 
    [birthdate] DATE NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [phonenumber] NVARCHAR(50) NOT NULL
);

INSERT INTO [dbo].[employees] VALUES (N'Jaroslav',N'Korčák','2003-05-03',N'KrazyManJ@gmail.com',N'+420 123 456 789')
INSERT INTO [dbo].[employees] VALUES (N'Kamila',N'Fialová','2003-11-11',N'fialova.kamila@stud.vassboskovice.cz',N'+420 987 654 321')

/* ROLES */

CREATE TABLE [dbo].[roles]
(
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR(50)        NOT NULL,
    [perm_full] BIT DEFAULT ((0))   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC)
);

INSERT INTO [dbo].[roles] VALUES (N'admin',1)
INSERT INTO [dbo].[roles] VALUES (N'user',0)

/* USERS */

CREATE TABLE [dbo].[users]
(
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR(50)        NOT NULL,
    [passwordhash] VARBINARY(1024)     NOT NULL,
    [passwordsalt] VARBINARY(1024)     NOT NULL,
    [role]         INT DEFAULT ((1))   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC),
    UNIQUE NONCLUSTERED ([name] ASC),
    FOREIGN KEY ([role]) REFERENCES [dbo].[roles] ([id])
);

/* Initialization of users inside Program.cs */

/* WORKTYPES */

CREATE TABLE [dbo].[worktypes]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [name] NVARCHAR(50) NOT NULL, 
    [description] TEXT NOT NULL
);

INSERT INTO [dbo].[worktypes] VALUES (N'Montáž',N'Jde prostě pracovat na linku')
INSERT INTO [dbo].[worktypes] VALUES (N'Sekretariát',N'Něco tam kliká do toho kompu')

/* WORKHOURS */

CREATE TABLE [dbo].[workhours]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [employee] INT NOT NULL FOREIGN KEY REFERENCES employees(id), 
    [contract] INT NOT NULL FOREIGN KEY REFERENCES contracts(id), 
    [worktype] INT NOT NULL FOREIGN KEY REFERENCES worktypes(id),
    [hours] INT NOT NULL, 
    [insertdate] DATE NOT NULL, 
    [insertuser] INT NOT NULL FOREIGN KEY REFERENCES users(id),
);