/*Database*/

/*Table Employee*/
CREATE TABLE [dbo].[Employee](
	[Id] [INT] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[PhoneNo] [nvarchar](10) NOT NULL,
	[BirthDate] [date] NULL,
	[IsActive] [bit] NULL
)
