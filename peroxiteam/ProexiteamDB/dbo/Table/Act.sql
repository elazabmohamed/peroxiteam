CREATE TABLE [dbo].[Act]
(
	[D_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(MAX) NULL, 
    [Category] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Comments] NVARCHAR(MAX) NULL, 
    [Id] INT NULL, 
    [ImagePath] NVARCHAR(MAX) NULL, 
    [Duration] NVARCHAR(50) NULL
)
