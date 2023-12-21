USE [EVODB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Email] [varchar](200) NULL,
	[Address] [varchar](200) NULL,
	[Phone] [varchar](200) NULL,
	[CreatedByUser] [uniqueidentifier] NOT NULL,
	[RegisterDate] [datetime2](7) NOT NULL,
	[LastUpdate] [datetime2](7) NOT NULL,
	[Comments] [varchar](200) NULL,
 CONSTRAINT [Pk_Customer_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [Fk_Customer_User_CreatedByUser] FOREIGN KEY([CreatedByUser])
REFERENCES [dbo].[User] ([ID])

GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [Fk_Customer_User_CreatedByUser]