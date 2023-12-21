USE [EVODB]
GO

CREATE TABLE [dbo].[ApplicationVersion] (
    [ID]                 UNIQUEIDENTIFIER NOT NULL,
    [Version]            VARCHAR (200)    NOT NULL,
    [DeploymentDateTime] DATETIME2 (7)    NOT NULL,
    [ReleaseNotes]       VARCHAR (MAX)    NOT NULL,
    [Author]             VARCHAR (200)    NOT NULL,
    [Repository]         VARCHAR (200)    NOT NULL,
    CONSTRAINT [PK_ApplicationVersion] PRIMARY KEY CLUSTERED ([ID] ASC)
);

GO
INSERT INTO [dbo].[ApplicationVersion] VALUES ('ea20370c-a6a8-44aa-90e0-694ab593b662', '1.0-20231221', GETDATE(), 'Application in the development phase, without a stable version.', 'João Mantovani', 'https://github.com/0mochileiro/EVO')

GO
CREATE TABLE [dbo].[ApplicationVersionLabel] (
    [ID]                   UNIQUEIDENTIFIER NOT NULL,
    [Label]                VARCHAR (200)    NOT NULL,
    [ApplicationVersionID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ApplicationVersionLabel] PRIMARY KEY CLUSTERED ([ID] ASC)
);

GO
ALTER TABLE [dbo].[ApplicationVersionLabel]  WITH CHECK ADD  CONSTRAINT [Fk_ApplicationVersionLabel_ApplicationVersion_ID] FOREIGN KEY([ApplicationVersionID])
REFERENCES [dbo].[ApplicationVersion] ([ID])

GO
ALTER TABLE [dbo].[ApplicationVersionLabel] CHECK CONSTRAINT [Fk_ApplicationVersionLabel_ApplicationVersion_ID]

GO
INSERT INTO [dbo].[ApplicationVersionLabel] VALUES ('7be729e2-5e44-4565-a691-380ec9818f6b', 'EVO - Financial Solutions', 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
CREATE TABLE [dbo].[ApplicationVersionComponent] (
    [ID]                   UNIQUEIDENTIFIER NOT NULL,
    [Name]                 VARCHAR (200)    NOT NULL,
    [Label]                VARCHAR (200)    NOT NULL,
    [Description]          VARCHAR (200)    NOT NULL,
    [Version]              VARCHAR (200)    NOT NULL,
    [Running]              BIT              NOT NULL,
    [ApplicationVersionID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_NewTable] PRIMARY KEY CLUSTERED ([ID] ASC)
);

GO
ALTER TABLE [dbo].[ApplicationVersionComponent]  WITH CHECK ADD  CONSTRAINT [Fk_ApplicationVersionComponent_ApplicationVersion_ID] FOREIGN KEY([ApplicationVersionID])
REFERENCES [dbo].[ApplicationVersion] ([ID])

GO
ALTER TABLE [dbo].[ApplicationVersionComponent] CHECK CONSTRAINT [Fk_ApplicationVersionComponent_ApplicationVersion_ID]

GO
INSERT INTO [dbo].[ApplicationVersionComponent] VALUES (NEWID(), 'EVO.ApiService', 'EVO - API Service', 'This architecture component is responsible for carrying out communication between the UI component and the financial database. Web API REST written in dotnet.','1.0-20231312', 1, 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
INSERT INTO [dbo].[ApplicationVersionComponent] VALUES (NEWID(), 'EVO.UserInterface', 'EVO - User Interface', 'This architectural component serves as a Single Page Application (SPA) responsible for serving as the user interface. This interface has been developed using Angular.','1.0-20231312', 1, 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
CREATE TABLE [dbo].[ApplicationVersionScript] (
    [ID]                   UNIQUEIDENTIFIER NOT NULL,
    [Database]             VARCHAR (100)    NOT NULL,
    [ScriptName]           VARCHAR (200)    NOT NULL,
    [ExecutionDate]        DATETIME2 (7)    NOT NULL,
    [Success]              BIT              NOT NULL,
    [Rollback]             BIT              NOT NULL,
    [ErrorMessage]         VARCHAR (MAX)    NULL,
    [Sequence]             INT              NOT NULL,
    [ApplicationVersionID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ApplicationVersionScript] PRIMARY KEY CLUSTERED ([ID] ASC)
);

GO
ALTER TABLE [dbo].[ApplicationVersionScript]  WITH CHECK ADD  CONSTRAINT [Fk_ApplicationVersionScript_ApplicationVersion_ID] FOREIGN KEY([ApplicationVersionID])
REFERENCES [dbo].[ApplicationVersion] ([ID])

GO
ALTER TABLE [dbo].[ApplicationVersionScript] CHECK CONSTRAINT [Fk_ApplicationVersionScript_ApplicationVersion_ID]

GO
INSERT INTO [dbo].[ApplicationVersionScript] VALUES (NEWID(), 'EVODB', 'SP_000_NT_20231123_ApplicationVersion.sql', GETDATE(), 1, 0, NULL, 0, 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
INSERT INTO [dbo].[ApplicationVersionScript] VALUES (NEWID(), 'EVODB', 'SP_001_NT_20231123_UserAcessLeve.sql', GETDATE(), 1, 0, NULL, 1, 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
INSERT INTO [dbo].[ApplicationVersionScript] VALUES (NEWID(), 'EVODB', 'SP_002_NT_20231123_User.sql', GETDATE(), 1, 0, NULL, 2, 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
INSERT INTO [dbo].[ApplicationVersionScript] VALUES (NEWID(), 'EVODB', 'SP_003_NT_20231123_Customer.sql', GETDATE(), 1, 0, NULL, 3, 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
INSERT INTO [dbo].[ApplicationVersionScript] VALUES (NEWID(), 'EVODB', 'SP_004_NT_20231123_InvoiceServices.sql', GETDATE(), 1, 0, NULL, 4, 'ea20370c-a6a8-44aa-90e0-694ab593b662')

GO
INSERT INTO [dbo].[ApplicationVersionScript] VALUES (NEWID(), 'EVODB', 'SP_005_NT_20231123_ServiceByInvoice.sql', GETDATE(), 1, 0, NULL, 5, 'ea20370c-a6a8-44aa-90e0-694ab593b662')