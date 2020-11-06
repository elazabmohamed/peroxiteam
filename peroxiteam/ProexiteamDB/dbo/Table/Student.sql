CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [StudentNo] NVARCHAR(50) NOT NULL, 
    [UniversityMail] NVARCHAR(100) NULL, 
    [University] NVARCHAR(100) NULL, 
    [Department] NVARCHAR(100) NULL, 
    [Grade] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(100) NULL, 
    [StudentState] NCHAR(10) NULL
)
