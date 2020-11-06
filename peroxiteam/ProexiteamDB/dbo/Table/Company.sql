CREATE TABLE [dbo].[Company]
(
	[D_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyName] NVARCHAR(50) NOT NULL, 
    [CompanyMail] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(100) NOT NULL, 
    [Tag] NVARCHAR(50) NULL, 
    [Id] INT NULL
)
