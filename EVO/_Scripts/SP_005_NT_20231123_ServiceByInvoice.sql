USE [EVODB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ServiceByInvoice](
	[ID] [uniqueidentifier] NOT NULL,
	[InvoiceServicesID] [uniqueidentifier] NOT NULL,
	[CreatedByUser] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[Details] [varchar](1000) NULL,
	[RegisterDate] [datetime2](7) NOT NULL,
 CONSTRAINT [Pk_ServiceDemand_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ServiceByInvoice]  WITH CHECK ADD  CONSTRAINT [Fk_ServiceByInvoice_InvoiceServices_InvoiceServicesID] FOREIGN KEY([InvoiceServicesID])
REFERENCES [dbo].[InvoiceServices] ([ID])

GO
ALTER TABLE [dbo].[ServiceByInvoice] CHECK CONSTRAINT [Fk_ServiceByInvoice_InvoiceServices_InvoiceServicesID]

GO
ALTER TABLE [dbo].[ServiceByInvoice]  WITH CHECK ADD  CONSTRAINT [Fk_ServiceByInvoice_User_CreatedByUser] FOREIGN KEY([CreatedByUser])
REFERENCES [dbo].[User] ([ID])

GO
ALTER TABLE [dbo].[ServiceByInvoice] CHECK CONSTRAINT [Fk_ServiceByInvoice_User_CreatedByUser]
