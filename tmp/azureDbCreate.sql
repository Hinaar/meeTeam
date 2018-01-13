/******** DMA Schema Migration Deployment Script      Script Date: 2018. 01. 13. 15:10:28 ********/

/****** Object:  Table [dbo].[Users]    Script Date: 2018. 01. 13. 15:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[PhoneNumber] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Country] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Salt] [varbinary](max) NULL,
	[Hash] [varbinary](max) NULL,
	[Email] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Events]    Script Date: 2018. 01. 13. 15:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Events]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Owner_UserID] [int] NULL,
 CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Events]') AND name = N'IX_Owner_UserID')
CREATE NONCLUSTERED INDEX [IX_Owner_UserID] ON [dbo].[Events]
(
	[Owner_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attends]    Script Date: 2018. 01. 13. 15:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attends]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attends](
	[UserID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
	[willAttend] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Attends] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Attends]') AND name = N'IX_EventID')
CREATE NONCLUSTERED INDEX [IX_EventID] ON [dbo].[Attends]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Attends]') AND name = N'IX_UserID')
CREATE NONCLUSTERED INDEX [IX_UserID] ON [dbo].[Attends]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 2018. 01. 13. 15:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Posts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Posts](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Time] [datetime] NOT NULL,
	[Writer] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Event_EventID] [int] NULL,
 CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Posts]') AND name = N'IX_Event_EventID')
CREATE NONCLUSTERED INDEX [IX_Event_EventID] ON [dbo].[Posts]
(
	[Event_EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coordinate]    Script Date: 2018. 01. 13. 15:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Coordinate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Coordinate](
	[EventID] [int] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
	[LocationName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_dbo.Coordinate] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Coordinate]') AND name = N'IX_EventID')
CREATE NONCLUSTERED INDEX [IX_EventID] ON [dbo].[Coordinate]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2018. 01. 13. 15:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContextKey] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Events_dbo.Users_Owner_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Events]'))
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Events_dbo.Users_Owner_UserID] FOREIGN KEY([Owner_UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Events_dbo.Users_Owner_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Events]'))
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_dbo.Events_dbo.Users_Owner_UserID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Attends_dbo.Events_EventID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attends]'))
ALTER TABLE [dbo].[Attends]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Attends_dbo.Events_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Attends_dbo.Events_EventID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attends]'))
ALTER TABLE [dbo].[Attends] CHECK CONSTRAINT [FK_dbo.Attends_dbo.Events_EventID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Attends_dbo.Users_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attends]'))
ALTER TABLE [dbo].[Attends]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Attends_dbo.Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Attends_dbo.Users_UserID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attends]'))
ALTER TABLE [dbo].[Attends] CHECK CONSTRAINT [FK_dbo.Attends_dbo.Users_UserID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Posts_dbo.Events_Event_EventID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Posts]'))
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Posts_dbo.Events_Event_EventID] FOREIGN KEY([Event_EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Posts_dbo.Events_Event_EventID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Posts]'))
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_dbo.Posts_dbo.Events_Event_EventID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Coordinate_dbo.Events_EventID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Coordinate]'))
ALTER TABLE [dbo].[Coordinate]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Coordinate_dbo.Events_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Coordinate_dbo.Events_EventID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Coordinate]'))
ALTER TABLE [dbo].[Coordinate] CHECK CONSTRAINT [FK_dbo.Coordinate_dbo.Events_EventID]
GO

