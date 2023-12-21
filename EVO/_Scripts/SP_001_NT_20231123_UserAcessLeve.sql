USE [EVODB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserAccessLevelDomain](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Function] [varchar](300) NOT NULL,
	[Department] [varchar](300) NOT NULL,
	[Description] [varchar](300) NOT NULL,
 CONSTRAINT [Pk_UserAccessLevelDomain_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[UserAccessLevelDomain] ON 

GO
INSERT [dbo].[UserAccessLevelDomain] ([ID], [Function], [Department], [Description]) VALUES (1, N'Root', N'Departamento de Tecnologia', N'Developer access level')

GO
INSERT [dbo].[UserAccessLevelDomain] ([ID], [Function], [Department], [Description]) VALUES (2, N'Manager', N'Departamento de Ger�ncia', N'Manager access level')

GO
INSERT [dbo].[UserAccessLevelDomain] ([ID], [Function], [Department], [Description]) VALUES (3, N'Employee', N'Departamento de Opera��o', N'Employee access level')

GO
SET IDENTITY_INSERT [dbo].[UserAccessLevelDomain] OFF