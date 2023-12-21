USE [SEVO]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InvoiceServices](
	[ID] [uniqueidentifier] NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
	[CreatedByUser] [uniqueidentifier] NOT NULL,
	[Montante] [decimal](9, 2) NULL,
	[OpenDate] [datetime2](7) NOT NULL,
	[CloseDate] [datetime2](7) NULL,
	[Approved] [bit] NOT NULL,
	[ApprovedDate] [datetime2](7) NULL,
	[ApprovedByUser] [uniqueidentifier] NULL,
 CONSTRAINT [Pk_Demand_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[InvoiceServices]  WITH CHECK ADD  CONSTRAINT [Fk_InvoiceServices_User_CreatedByUser] FOREIGN KEY([CreatedByUser])
REFERENCES [dbo].[User] ([ID])

GO
ALTER TABLE [dbo].[InvoiceServices] CHECK CONSTRAINT [Fk_InvoiceServices_User_CreatedByUser]

GO
ALTER TABLE [dbo].[InvoiceServices]  WITH CHECK ADD  CONSTRAINT [Fk_InvoiceServices_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])

GO
ALTER TABLE [dbo].[InvoiceServices] CHECK CONSTRAINT [Fk_InvoiceServices_Customer_CustomerID]

GO
ALTER TABLE [dbo].[InvoiceServices]  WITH CHECK ADD  CONSTRAINT [Fk_InvoiceServices_User_ApprovedByUser] FOREIGN KEY([ApprovedByUser])
REFERENCES [dbo].[User] ([ID])

GO
ALTER TABLE [dbo].[InvoiceServices] CHECK CONSTRAINT [Fk_InvoiceServices_User_ApprovedByUser]