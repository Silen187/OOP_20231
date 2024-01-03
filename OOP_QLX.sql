USE [master]
GO
/****** Object:  Database [QLX]    Script Date: 1/2/2024 4:58:20 AM ******/
CREATE DATABASE [QLX]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLX', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QLX.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLX_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QLX_log.ldf' , SIZE = 270336KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLX] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLX].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLX] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLX] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLX] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLX] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLX] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLX] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLX] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLX] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLX] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLX] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLX] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLX] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLX] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLX] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLX] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLX] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLX] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLX] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLX] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLX] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLX] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLX] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLX] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLX] SET  MULTI_USER 
GO
ALTER DATABASE [QLX] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLX] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLX] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLX] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLX] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLX] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLX] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLX] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLX]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[start_date] [date] NULL,
	[salary_level] [int] NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[register_date] [datetime] NULL,
 CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[level_area] [varchar](2) NULL,
	[start_date] [date] NULL,
	[salary_level] [int] NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[info]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[info](
	[user_id] [int] NULL,
	[name] [varchar](255) NULL,
	[Birth] [date] NULL,
	[Age] [int] NULL,
	[City] [nvarchar](50) NULL,
	[contact_number] [varchar](50) NULL,
	[role_id] [int] NULL,
	[sex] [varchar](10) NULL,
	[CCCD] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[monthly_subscription]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[monthly_subscription](
	[person_id] [int] NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[ticket_id] [varchar](20) NOT NULL,
	[money] [int] NULL,
	[type_card] [tinyint] NULL,
 CONSTRAINT [PK_monthly_subscription_1] PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parking_area]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parking_area](
	[area_id] [int] NOT NULL,
	[name] [varchar](255) NULL,
	[capacity_cars] [int] NULL,
	[capacity_bikes] [int] NULL,
 CONSTRAINT [PK_parking_area] PRIMARY KEY CLUSTERED 
(
	[area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parking_level]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parking_level](
	[level_name] [varchar](2) NOT NULL,
	[level_id] [int] NULL,
	[area_id] [int] NULL,
	[capacity_cars] [int] NULL,
	[capacity_bikes] [int] NULL,
 CONSTRAINT [PK_parking_level] PRIMARY KEY CLUSTERED 
(
	[level_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parking_slot]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parking_slot](
	[slot_id] [varchar](10) NOT NULL,
	[level_name] [varchar](2) NULL,
	[is_taken] [tinyint] NULL,
 CONSTRAINT [PK_parking_slot] PRIMARY KEY CLUSTERED 
(
	[slot_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permissions]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permissions](
	[role_id] [int] NOT NULL,
	[role_name] [varchar](255) NULL,
	[can_manage_parking] [tinyint] NULL,
	[can_generate_reports] [tinyint] NULL,
	[can_access_history] [tinyint] NULL,
	[can_access_users] [tinyint] NULL,
 CONSTRAINT [PK_permissions] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reports]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reports](
	[report_id] [int] IDENTITY(1,1) NOT NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[total_entries] [int] NULL,
	[total_renuvue] [decimal](10, 2) NULL,
	[admin_id] [int] NULL,
	[total_error_transaction] [int] NULL,
	[total_income] [int] NULL,
	[total_compensation] [int] NULL,
 CONSTRAINT [PK_reports] PRIMARY KEY CLUSTERED 
(
	[report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ticket_pass]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ticket_pass](
	[ticket_id] [varchar](20) NOT NULL,
	[slot_id] [varchar](10) NULL,
 CONSTRAINT [PK_ticket_pass_1] PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transactions]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactions](
	[transaction_id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_id] [varchar](20) NULL,
	[transaction_time] [datetime] NULL,
	[renueve] [int] NULL,
	[description] [text] NULL,
	[type] [tinyint] NULL,
	[vehicle_id] [varchar](20) NULL,
	[entry_time] [datetime] NULL,
	[exit_time] [datetime] NULL,
	[type_vehicle] [tinyint] NULL,
 CONSTRAINT [PK_transaction] PRIMARY KEY CLUSTERED 
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 1/2/2024 4:58:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] NOT NULL,
	[username] [varchar](255) NULL,
	[password] [varchar](255) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_admin_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_admin_user]
GO
ALTER TABLE [dbo].[customers]  WITH CHECK ADD  CONSTRAINT [FK_customers_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[customers] CHECK CONSTRAINT [FK_customers_user]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_user]
GO
ALTER TABLE [dbo].[info]  WITH CHECK ADD  CONSTRAINT [FK_info_permissions] FOREIGN KEY([role_id])
REFERENCES [dbo].[permissions] ([role_id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[info] CHECK CONSTRAINT [FK_info_permissions]
GO
ALTER TABLE [dbo].[info]  WITH CHECK ADD  CONSTRAINT [FK_info_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[info] CHECK CONSTRAINT [FK_info_user]
GO
ALTER TABLE [dbo].[monthly_subscription]  WITH CHECK ADD  CONSTRAINT [FK_monthly_subscription_user] FOREIGN KEY([person_id])
REFERENCES [dbo].[users] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[monthly_subscription] CHECK CONSTRAINT [FK_monthly_subscription_user]
GO
ALTER TABLE [dbo].[parking_level]  WITH CHECK ADD  CONSTRAINT [FK_parking_level_parking_area] FOREIGN KEY([area_id])
REFERENCES [dbo].[parking_area] ([area_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[parking_level] CHECK CONSTRAINT [FK_parking_level_parking_area]
GO
ALTER TABLE [dbo].[parking_slot]  WITH CHECK ADD  CONSTRAINT [FK_parking_slot_parking_level] FOREIGN KEY([level_name])
REFERENCES [dbo].[parking_level] ([level_name])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[parking_slot] CHECK CONSTRAINT [FK_parking_slot_parking_level]
GO
ALTER TABLE [dbo].[reports]  WITH CHECK ADD  CONSTRAINT [FK_reports_admin] FOREIGN KEY([admin_id])
REFERENCES [dbo].[admin] ([admin_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[reports] CHECK CONSTRAINT [FK_reports_admin]
GO
ALTER TABLE [dbo].[ticket_pass]  WITH CHECK ADD  CONSTRAINT [FK_ticket_pass_parking_slot] FOREIGN KEY([slot_id])
REFERENCES [dbo].[parking_slot] ([slot_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ticket_pass] CHECK CONSTRAINT [FK_ticket_pass_parking_slot]
GO
USE [master]
GO
ALTER DATABASE [QLX] SET  READ_WRITE 
GO
