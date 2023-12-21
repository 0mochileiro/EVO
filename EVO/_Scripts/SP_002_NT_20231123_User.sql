USE [SEVO]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[Email] [nvarchar](300) NOT NULL,
	[AccessLevelID] [int] NOT NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[RegisterDate] [datetime2](7) NOT NULL,
	[LastUpdate] [datetime2](7) NOT NULL,
	[CompleteRegistration] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_User_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserAccessLevelDomain_AccessLevelID] FOREIGN KEY([AccessLevelID])
REFERENCES [dbo].[UserAccessLevelDomain] ([ID])

GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserAccessLevelDomain_AccessLevelID]

GO
INSERT [dbo].[User] ([ID], [Name], [Email], [AccessLevelID], [PasswordHash], [PasswordSalt], [RegisterDate], [LastUpdate], [CompleteRegistration], [Active]) VALUES (N'c89b806b-72b9-45ca-9f8a-2dda8dd24c8c', N'Joao Octavio Togniz Zambon Mantovani', N'joao.octavio.mantovani@gmail.com', 1, NULL, NULL, CAST(N'2023-09-22T17:50:07.4266667' AS DateTime2), CAST(N'2023-09-22T17:50:07.4266667' AS DateTime2), 0, 1)
