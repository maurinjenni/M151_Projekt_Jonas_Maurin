-- --------------------------------------------------
-- --------------------------------------------------
-- Database 'HomeworX' must already exist!!!
-- --------------------------------------------------
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE HomeworX;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Appointme__Subje__145C0A3F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointment] DROP CONSTRAINT [FK__Appointme__Subje__145C0A3F];
GO
IF OBJECT_ID(N'[dbo].[FK__Exam__Appointmen__1920BF5C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam] DROP CONSTRAINT [FK__Exam__Appointmen__1920BF5C];
GO
IF OBJECT_ID(N'[dbo].[FK__Homework__Appoin__164452B1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Homework] DROP CONSTRAINT [FK__Homework__Appoin__164452B1];
GO
IF OBJECT_ID(N'[dbo].[FK__Topic__SubjectUI__1CF15040]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Topic] DROP CONSTRAINT [FK__Topic__SubjectUI__1CF15040];
GO
IF OBJECT_ID(N'[dbo].[FK__TopicToAp__Appoi__20C1E124]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicToAppointment] DROP CONSTRAINT [FK__TopicToAp__Appoi__20C1E124];
GO
IF OBJECT_ID(N'[dbo].[FK__TopicToAp__Topic__1FCDBCEB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicToAppointment] DROP CONSTRAINT [FK__TopicToAp__Topic__1FCDBCEB];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Appointment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appointment];
GO
IF OBJECT_ID(N'[dbo].[Exam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exam];
GO
IF OBJECT_ID(N'[dbo].[Homework]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Homework];
GO
IF OBJECT_ID(N'[dbo].[Subject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subject];
GO
IF OBJECT_ID(N'[dbo].[Topic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Topic];
GO
IF OBJECT_ID(N'[dbo].[TopicToAppointment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TopicToAppointment];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Appointment'
CREATE TABLE [dbo].[Appointment] (
    [UID] uniqueidentifier  NOT NULL,
    [Description] varchar(100)  NOT NULL,
    [Detail] varchar(max)  NULL,
    [Date] datetime  NOT NULL,
    [SubjectUID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Exam'
CREATE TABLE [dbo].[Exam] (
    [UID] uniqueidentifier  NOT NULL,
    [Remind] bit  NOT NULL,
    [Time] datetime  NULL,
    [Mailadress] varchar(50)  NULL
);
GO

-- Creating table 'Homework'
CREATE TABLE [dbo].[Homework] (
    [UID] uniqueidentifier  NOT NULL,
    [Importance] tinyint  NULL
);
GO

-- Creating table 'Subject'
CREATE TABLE [dbo].[Subject] (
    [UID] uniqueidentifier  NOT NULL,
    [Code] varchar(10)  NOT NULL,
    [Description] varchar(100)  NOT NULL,
    [Detail] varchar(max)  NULL
);
GO

-- Creating table 'Topic'
CREATE TABLE [dbo].[Topic] (
    [UID] uniqueidentifier  NOT NULL,
    [Description] varchar(100)  NOT NULL,
    [Detail] varchar(max)  NULL,
    [SubjectUID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'TopicToAppointment'
CREATE TABLE [dbo].[TopicToAppointment] (
    [UID] uniqueidentifier  NOT NULL,
    [TopicUID] uniqueidentifier  NOT NULL,
    [AppointmentUID] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UID] in table 'Appointment'
ALTER TABLE [dbo].[Appointment]
ADD CONSTRAINT [PK_Appointment]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- Creating primary key on [UID] in table 'Exam'
ALTER TABLE [dbo].[Exam]
ADD CONSTRAINT [PK_Exam]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- Creating primary key on [UID] in table 'Homework'
ALTER TABLE [dbo].[Homework]
ADD CONSTRAINT [PK_Homework]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- Creating primary key on [UID] in table 'Subject'
ALTER TABLE [dbo].[Subject]
ADD CONSTRAINT [PK_Subject]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- Creating primary key on [UID] in table 'Topic'
ALTER TABLE [dbo].[Topic]
ADD CONSTRAINT [PK_Topic]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- Creating primary key on [UID] in table 'TopicToAppointment'
ALTER TABLE [dbo].[TopicToAppointment]
ADD CONSTRAINT [PK_TopicToAppointment]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SubjectUID] in table 'Appointment'
ALTER TABLE [dbo].[Appointment]
ADD CONSTRAINT [FK__Appointme__Subje__145C0A3F]
    FOREIGN KEY ([SubjectUID])
    REFERENCES [dbo].[Subject]
        ([UID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Appointme__Subje__145C0A3F'
CREATE INDEX [IX_FK__Appointme__Subje__145C0A3F]
ON [dbo].[Appointment]
    ([SubjectUID]);
GO

-- Creating foreign key on [UID] in table 'Exam'
ALTER TABLE [dbo].[Exam]
ADD CONSTRAINT [FK__Exam__Appointmen__1920BF5C]
    FOREIGN KEY ([UID])
    REFERENCES [dbo].[Appointment]
        ([UID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UID] in table 'Homework'
ALTER TABLE [dbo].[Homework]
ADD CONSTRAINT [FK__Homework__Appoin__164452B1]
    FOREIGN KEY ([UID])
    REFERENCES [dbo].[Appointment]
        ([UID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AppointmentUID] in table 'TopicToAppointment'
ALTER TABLE [dbo].[TopicToAppointment]
ADD CONSTRAINT [FK__TopicToAp__Appoi__20C1E124]
    FOREIGN KEY ([AppointmentUID])
    REFERENCES [dbo].[Appointment]
        ([UID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TopicToAp__Appoi__20C1E124'
CREATE INDEX [IX_FK__TopicToAp__Appoi__20C1E124]
ON [dbo].[TopicToAppointment]
    ([AppointmentUID]);
GO

-- Creating foreign key on [SubjectUID] in table 'Topic'
ALTER TABLE [dbo].[Topic]
ADD CONSTRAINT [FK__Topic__SubjectUI__1CF15040]
    FOREIGN KEY ([SubjectUID])
    REFERENCES [dbo].[Subject]
        ([UID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Topic__SubjectUI__1CF15040'
CREATE INDEX [IX_FK__Topic__SubjectUI__1CF15040]
ON [dbo].[Topic]
    ([SubjectUID]);
GO

-- Creating foreign key on [TopicUID] in table 'TopicToAppointment'
ALTER TABLE [dbo].[TopicToAppointment]
ADD CONSTRAINT [FK__TopicToAp__Topic__1FCDBCEB]
    FOREIGN KEY ([TopicUID])
    REFERENCES [dbo].[Topic]
        ([UID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TopicToAp__Topic__1FCDBCEB'
CREATE INDEX [IX_FK__TopicToAp__Topic__1FCDBCEB]
ON [dbo].[TopicToAppointment]
    ([TopicUID]);
GO