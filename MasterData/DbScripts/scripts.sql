USE [$(DatabaseName)];
GO
/********* Start CREATE TABLE **************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[MaritalStatus] [nvarchar](10) NULL,
	[Address] [nvarchar](200) NULL,
	[City] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY ([Id])) 
END
GO