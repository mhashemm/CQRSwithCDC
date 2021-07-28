USE [master]
GO
/****** Object:  Database [CQRSwithCDC_Write]    Script Date: 28/07/2021 2:31:43 PM ******/
CREATE DATABASE [CQRSwithCDC_Write]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CQRSwithCDC_Write', FILENAME = N'/var/opt/mssql/data/CQRSwithCDC_Write.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CQRSwithCDC_Write_log', FILENAME = N'/var/opt/mssql/data/CQRSwithCDC_Write_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CQRSwithCDC_Write] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CQRSwithCDC_Write].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CQRSwithCDC_Write] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET ARITHABORT OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET RECOVERY FULL 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET  MULTI_USER 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CQRSwithCDC_Write] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CQRSwithCDC_Write] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CQRSwithCDC_Write', N'ON'
GO
ALTER DATABASE [CQRSwithCDC_Write] SET QUERY_STORE = OFF
GO
USE [CQRSwithCDC_Write]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 28/07/2021 2:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Credits] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disenrollments]    Script Date: 28/07/2021 2:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disenrollments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseID] [bigint] NOT NULL,
	[StudentID] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Disenrollment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 28/07/2021 2:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NOT NULL,
	[CourseID] [bigint] NOT NULL,
	[Grade] [tinyint] NOT NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 28/07/2021 2:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Disenrollments]  WITH CHECK ADD  CONSTRAINT [FK_Disenrollment_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Disenrollments] CHECK CONSTRAINT [FK_Disenrollment_Course]
GO
ALTER TABLE [dbo].[Disenrollments]  WITH CHECK ADD  CONSTRAINT [FK_Disenrollment_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Disenrollments] CHECK CONSTRAINT [FK_Disenrollment_Student]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollment_Course]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollment_Student]
GO
USE [master]
GO
ALTER DATABASE [CQRSwithCDC_Write] SET  READ_WRITE 
GO

ALTER DATABASE [CQRSwithCDC_Write] ADD FILEGROUP [Write_CDC]
GO

USE [CQRSwithCDC_Write]
GO

EXEC sys.sp_cdc_enable_db
GO

EXEC sys.sp_cdc_enable_table
	@source_schema = N'dbo',
	@source_name   = N'Courses',
	@role_name     = NULL,
	@filegroup_name = N'Write_CDC',
	@supports_net_changes = 1
GO
EXEC sys.sp_cdc_enable_table
	@source_schema = N'dbo',
	@source_name   = N'Disenrollments',
	@role_name     = NULL,
	@filegroup_name = N'Write_CDC',
	@supports_net_changes = 1
GO
EXEC sys.sp_cdc_enable_table
	@source_schema = N'dbo',
	@source_name   = N'Enrollments',
	@role_name     = NULL,
	@filegroup_name = N'Write_CDC',
	@supports_net_changes = 1
GO
EXEC sys.sp_cdc_enable_table
	@source_schema = N'dbo',
	@source_name   = N'Students',
	@role_name     = NULL,
	@filegroup_name = N'Write_CDC',
	@supports_net_changes = 1
GO
