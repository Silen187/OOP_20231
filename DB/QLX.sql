USE [master]
GO
/****** Object:  Database [QLX]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[admin]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[customers]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[employees]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[info]    Script Date: 1/5/2024 11:53:44 AM ******/
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
	[CCCD] [varchar](20) NULL,
	[STK] [varchar](50) NULL,
	[Bank] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[monthly_subscription]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[parking_area]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[parking_level]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[parking_slot]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[permissions]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[reports]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[salary_pass]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salary_pass](
	[user_id] [int] NOT NULL,
	[role_id] [int] NULL,
	[month] [varchar](30) NULL,
	[salary] [int] NULL,
	[pass] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ticket_pass]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[transactions]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactions](
	[transaction_id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_id] [varchar](20) NULL,
	[transaction_time] [datetime] NULL,
	[renueve] [int] NULL,
	[description] [nvarchar](1000) NULL,
	[type] [tinyint] NULL,
	[vehicle_id] [varchar](20) NULL,
	[entry_time] [datetime] NULL,
	[exit_time] [datetime] NULL,
	[type_vehicle] [tinyint] NULL,
	[user_id_did] [int] NULL,
 CONSTRAINT [PK_transaction] PRIMARY KEY CLUSTERED 
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type_transaction_description]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type_transaction_description](
	[type_transaction] [tinyint] NOT NULL,
	[description] [ntext] NULL,
 CONSTRAINT [PK_type_transaction_description] PRIMARY KEY CLUSTERED 
(
	[type_transaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[typecard_description]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[typecard_description](
	[type_card] [tinyint] NOT NULL,
	[description_card] [ntext] NULL,
 CONSTRAINT [PK_typecard_description] PRIMARY KEY CLUSTERED 
(
	[type_card] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 1/5/2024 11:53:44 AM ******/
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
/****** Object:  Table [dbo].[vehicle]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicle](
	[vehicle_name] [nchar](10) NULL,
	[vehicle_id] [tinyint] NOT NULL,
 CONSTRAINT [PK_vehicle] PRIMARY KEY CLUSTERED 
(
	[vehicle_id] ASC
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
ALTER TABLE [dbo].[monthly_subscription]  WITH CHECK ADD  CONSTRAINT [FK_monthly_subscription_typecard_description] FOREIGN KEY([type_card])
REFERENCES [dbo].[typecard_description] ([type_card])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[monthly_subscription] CHECK CONSTRAINT [FK_monthly_subscription_typecard_description]
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
ALTER TABLE [dbo].[salary_pass]  WITH CHECK ADD  CONSTRAINT [FK_salary_pass_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[salary_pass] CHECK CONSTRAINT [FK_salary_pass_users]
GO
ALTER TABLE [dbo].[ticket_pass]  WITH CHECK ADD  CONSTRAINT [FK_ticket_pass_parking_slot] FOREIGN KEY([slot_id])
REFERENCES [dbo].[parking_slot] ([slot_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ticket_pass] CHECK CONSTRAINT [FK_ticket_pass_parking_slot]
GO
ALTER TABLE [dbo].[transactions]  WITH CHECK ADD  CONSTRAINT [FK_transactions_type_transaction_description] FOREIGN KEY([type])
REFERENCES [dbo].[type_transaction_description] ([type_transaction])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[transactions] CHECK CONSTRAINT [FK_transactions_type_transaction_description]
GO
ALTER TABLE [dbo].[transactions]  WITH CHECK ADD  CONSTRAINT [FK_transactions_vehicle] FOREIGN KEY([type_vehicle])
REFERENCES [dbo].[vehicle] ([vehicle_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[transactions] CHECK CONSTRAINT [FK_transactions_vehicle]
GO
/****** Object:  StoredProcedure [dbo].[COUNT_VEHICLE]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[COUNT_VEHICLE]
@level_name VARCHAR(2)
AS
BEGIN
	SELECT 
    vehicle.vehicle_name, count(*) AS SoLuong
	FROM 
		ticket_pass 
	INNER JOIN 
		parking_slot ON ticket_pass.slot_id = parking_slot.slot_id
	INNER JOIN 
		transactions ON ticket_pass.ticket_id = transactions.ticket_id
	INNER JOIN 
		vehicle ON transactions.type_vehicle = vehicle.vehicle_id
	WHERE 
		transactions.renueve IS NULL 
		AND transactions.transaction_time IS NULL 
		AND parking_slot.level_name = @level_name
	GROUP BY vehicle.vehicle_name
END
GO
/****** Object:  StoredProcedure [dbo].[SEARCH_VEHICLE_BY_ID]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SEARCH_VEHICLE_BY_ID]
@vehicle_id VARCHAR(20)
AS
BEGIN
	SELECT 
    parking_slot.slot_id, 
    ticket_pass.ticket_id, 
    transactions.vehicle_id, 
    vehicle.vehicle_name 
	FROM 
		ticket_pass 
	INNER JOIN 
		parking_slot ON ticket_pass.slot_id = parking_slot.slot_id
	INNER JOIN 
		transactions ON ticket_pass.ticket_id = transactions.ticket_id
	INNER JOIN 
		vehicle ON transactions.type_vehicle = vehicle.vehicle_id
	WHERE 
		transactions.renueve IS NULL 
		AND transactions.transaction_time IS NULL 
		AND transactions.vehicle_id = @vehicle_id 
END
GO
/****** Object:  StoredProcedure [dbo].[SEARCH_VEHICLE_BY_ID_AND_TICKET]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SEARCH_VEHICLE_BY_ID_AND_TICKET]
@vehicle_id VARCHAR(20), @ticket_id VARCHAR(20)
AS
BEGIN
	SELECT 
    parking_slot.slot_id, 
    ticket_pass.ticket_id, 
    transactions.vehicle_id, 
    vehicle.vehicle_name 
	FROM 
		ticket_pass 
	INNER JOIN 
		parking_slot ON ticket_pass.slot_id = parking_slot.slot_id
	INNER JOIN 
		transactions ON ticket_pass.ticket_id = transactions.ticket_id
	INNER JOIN 
		vehicle ON transactions.type_vehicle = vehicle.vehicle_id
	WHERE 
		transactions.renueve IS NULL 
		AND transactions.transaction_time IS NULL 
		AND transactions.vehicle_id = @vehicle_id 
		AND ticket_pass.ticket_id = @ticket_id;
END
GO
/****** Object:  StoredProcedure [dbo].[SEARCH_VEHICLE_BY_TICKET]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SEARCH_VEHICLE_BY_TICKET]
@ticket_id VARCHAR(20)
AS
BEGIN
	SELECT 
    parking_slot.slot_id, 
    ticket_pass.ticket_id, 
    transactions.vehicle_id, 
    vehicle.vehicle_name 
	FROM 
		ticket_pass 
	INNER JOIN 
		parking_slot ON ticket_pass.slot_id = parking_slot.slot_id
	INNER JOIN 
		transactions ON ticket_pass.ticket_id = transactions.ticket_id
	INNER JOIN 
		vehicle ON transactions.type_vehicle = vehicle.vehicle_id
	WHERE 
		transactions.renueve IS NULL 
		AND transactions.transaction_time IS NULL 
		AND transactions.ticket_id = @ticket_id 
END
GO
/****** Object:  StoredProcedure [dbo].[updateUser_customer]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[updateUser_customer]
@userID INT, @userName VARCHAR(255), @ngay_sinh DATETIME, @sex VARCHAR(10), @city VARCHAR(50), @contact_num VARCHAR(50)
AS
BEGIN
	UPDATE dbo.info
	SET name = @userName, Birth = @ngay_sinh, sex = @sex, City = @city, contact_number = @contact_num
	WHERE user_id = @userID
END




GO
/****** Object:  StoredProcedure [dbo].[USP_Change_Info]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Change_Info]
@userID INT, @Birth DATE, @Name VARCHAR(255), @sex VARCHAR(10), @city NVARCHAR(50), @SDT VARCHAR(50), @CCCD VARCHAR(20)
AS
BEGIN
	UPDATE dbo.info SET
	name = @Name,
	Birth = @Birth,
	City = @city,
	contact_number = @SDT,
	sex = @sex,
	CCCD = @CCCD
	WHERE user_id = @userID
END





GO
/****** Object:  StoredProcedure [dbo].[USP_HistoryEntry]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_HistoryEntry]
@user_id INT, @start_date DATETIME, @end_date DATETIME
AS
BEGIN
	SELECT *
	FROM dbo.transactions
	INNER JOIN dbo.monthly_subscription ON transactions.ticket_id = monthly_subscription.ticket_id
	WHERE monthly_subscription.person_id = @user_id
		AND (transactions.type = 1 OR transactions.type = 2)
		AND transactions.transaction_time >= CONVERT(datetime, @start_date, 120)
		AND transactions.transaction_time <= CONVERT(datetime, @end_date, 120);
END
GO
/****** Object:  StoredProcedure [dbo].[USP_HistoryMoney]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_HistoryMoney]
@user_id INT, @start_date DATETIME, @end_date DATETIME
AS
BEGIN
	SELECT *
	FROM dbo.transactions
	INNER JOIN dbo.monthly_subscription ON transactions.ticket_id = monthly_subscription.ticket_id
	WHERE monthly_subscription.person_id = @user_id
	AND transactions.type = 4
	AND transactions.renueve IS NOT NULL
	AND transactions.transaction_time >= CONVERT(datetime, @start_date, 120)
    AND transactions.transaction_time <= CONVERT(datetime, @end_date, 120);
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INFO]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_INFO]
@userID INT
AS
BEGIN
	SELECT
	users.password as Password,
    users.user_id as Mã_người_dùng,
    users.username as Tên_đăng_nhập,
    info.name as Tên,
    info.Birth as Ngày_sinh,
    info.Age as Tuổi,
    info.City as Thành_phố,
    info.contact_number as SDT,
    info.sex as Giới_tính,
    info.CCCD,
    permissions.role_name as Mã_chức_vụ
	FROM 
		dbo.info
	INNER JOIN 
		dbo.permissions ON info.role_id = permissions.role_id
	INNER JOIN 
		users ON info.user_id = users.user_id
	WHERE 
		dbo.info.user_id = @userID;
END




GO
/****** Object:  StoredProcedure [dbo].[USP_INPUTPASSWORDCHECK]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_INPUTPASSWORDCHECK]
@user_id INT, @password VARCHAR(255)
AS
BEGIN
	SELECT * FROM users WHERE user_id = @user_id AND password = @password
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_Login]
@userName varchar(255), @passWord varchar(255)
AS
BEGIN
	SELECT * FROM dbo.users WHERE username = @userName AND password = @passWord
END





GO
/****** Object:  StoredProcedure [dbo].[USP_SALARYPASS]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SALARYPASS]
@userID INT
AS
BEGIN
    SELECT 
        info.user_id as 'Mã nhân viên',
        info.role_id as 'Mã vị trí',
        info.name as 'Tên nhân viên',
        info.sex as 'Giới tính',
        info.STK as 'Số tài khoản',
        info.Bank as 'Ngân hàng',
        info.contact_number as 'Số điện thoại',
        CASE 
            WHEN salary_pass.pass = 1 THEN 'Đã thanh toán'
            ELSE N'Chưa thanh toán'
        END as 'Tình trạng',
        salary_pass.month as 'Tháng',
        salary_pass.salary as 'Số tiền'
    FROM dbo.salary_pass 
    INNER JOIN dbo.info ON salary_pass.user_id = info.user_id
    WHERE 
        salary_pass.user_id = @userID
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdatePassword]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdatePassword]
@userName VARCHAR(255), @password VARCHAR(255), @newpassword VARCHAR(255)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.users WHERE username = @userName AND password = @password
	
	IF (@isRightPass = 1)
	BEGIN
		UPDATE users SET password = @newpassword WHERE username = @userName AND password = @password
	END
END

GO
/****** Object:  StoredProcedure [dbo].[VIEW_ALL_TICKET_INFO]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[VIEW_ALL_TICKET_INFO]
AS
BEGIN
	SELECT monthly_subscription.person_id,
		info.name,
		monthly_subscription.ticket_id,
		monthly_subscription.start_date,
		monthly_subscription.end_date,
		monthly_subscription.money,
		'type_card' = CASE 
					WHEN monthly_subscription.type_card = 1 THEN 'Vé nhân viên'
					WHEN monthly_subscription.type_card = 2 THEN 'Vé khách hàng'
					WHEN monthly_subscription.type_card = 3 THEN 'Vé khách hàng'
					WHEN monthly_subscription.type_card = 4 THEN 'Vé dùng một lần'
				 END
	FROM dbo.monthly_subscription 
		INNER JOIN dbo.info ON monthly_subscription.person_id = info.user_id
END
GO
/****** Object:  StoredProcedure [dbo].[VIEW_TICKET_INFO]    Script Date: 1/5/2024 11:53:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[VIEW_TICKET_INFO]
@user_id INT
AS
BEGIN
	SELECT 
    monthly_subscription.person_id,
    info.name,
    monthly_subscription.ticket_id,
    monthly_subscription.start_date,
    monthly_subscription.end_date,
    monthly_subscription.money,
    'type_card' = CASE 
                WHEN monthly_subscription.type_card = 1 THEN 'Vé nhân viên'
                WHEN monthly_subscription.type_card = 2 THEN 'Vé khách hàng'
				WHEN monthly_subscription.type_card = 3 THEN 'Vé khách hàng'
				WHEN monthly_subscription.type_card = 4 THEN 'Vé dùng một lần'
             END
	FROM dbo.monthly_subscription 
	INNER JOIN dbo.info ON monthly_subscription.person_id = info.user_id
	WHERE monthly_subscription.person_id = @user_id;
END
GO
USE [master]
GO
ALTER DATABASE [QLX] SET  READ_WRITE 
GO
