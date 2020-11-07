CREATE TABLE [dbo].[Student]
(
	[D_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [StudentNo] NVARCHAR(50) NOT NULL, 
    [UniversityMail] NVARCHAR(100) NOT NULL, 
    [University] NVARCHAR(100) NULL, 
    [Department] NVARCHAR(100) NULL, 
    [Grade] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(100) NOT NULL, 
    [StudentState] NCHAR(10) NULL, 
    [Tag] NCHAR(10) NULL, 
    [Id] INT NULL, 
    [CvPath] NVARCHAR(MAX) NULL
)
