USE [master]
GO
/****** Object:  Database [GreenSwitch_DB]    Script Date: 5/19/2021 11:29:17 AM ******/
CREATE DATABASE [GreenSwitch_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GreenSwitch_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GreenSwitch_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GreenSwitch_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GreenSwitch_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GreenSwitch_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GreenSwitch_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GreenSwitch_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GreenSwitch_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GreenSwitch_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GreenSwitch_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GreenSwitch_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [GreenSwitch_DB] SET  MULTI_USER 
GO
ALTER DATABASE [GreenSwitch_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GreenSwitch_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GreenSwitch_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GreenSwitch_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GreenSwitch_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GreenSwitch_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GreenSwitch_DB', N'ON'
GO
ALTER DATABASE [GreenSwitch_DB] SET QUERY_STORE = OFF
GO
USE [GreenSwitch_DB]
GO
/****** Object:  Table [dbo].[Authentication]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authentication](
	[EmployeeId] [int] NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[EmployeeType] [tinyint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1000000,1) NOT NULL,
	[SupervisorId] [int] NULL,
	[DepartmentId] [int] NOT NULL,
	[JobId] [int] NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MI] [nchar](1) NULL,
	[Dob] [datetime] NOT NULL,
	[StreetAddress] [nvarchar](100) NOT NULL,
	[City] [nvarchar](30) NOT NULL,
	[PostalCode] [nchar](6) NOT NULL,
	[SIN] [nchar](11) NOT NULL,
	[SeniorityDate] [datetime] NOT NULL,
	[JobStartDate] [datetime] NULL,
	[WorkPhone] [nvarchar](13) NOT NULL,
	[CellPhone] [nvarchar](13) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[Status] [tinyint] NULL,
	[LastDayOfWork] [datetime2](7) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Justification] [nvarchar](200) NOT NULL,
	[Location] [nvarchar](200) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Reason] [nvarchar](200) NULL,
	[Price] [money] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[NoLongerNeeded] [bit] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[JobTitle] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[GrandTotal] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[Tax] [money] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceRating] [tinyint] NOT NULL,
	[Comment] [nchar](255) NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[ReviewDate] [datetime] NOT NULL,
	[SupervisorId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReviewReminder]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReviewReminder](
	[ReminderId] [int] IDENTITY(1,1) NOT NULL,
	[HrEmpId] [int] NOT NULL,
	[RecipientSuperviosId] [int] NOT NULL,
	[ReminderDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Job] FOREIGN KEY([JobId])
REFERENCES [dbo].[Job] ([JobId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Job]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_PurchaseOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[PurchaseOrder] ([OrderId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_PurchaseOrder]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Employee]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Employee]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckReviewCount]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE    PROCEDURE [dbo].[sp_CheckReviewCount]
@EmployeeId INT
AS
BEGIN
    SELECT COUNT(*) FROM Review WHERE EmployeeId = @EmployeeId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_checkSentReviewReminderDate]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  PROCEDURE [dbo].[sp_checkSentReviewReminderDate]
	@today DateTime
AS
 
BEGIN
	 
select COUNT(*)  FROM ReviewReminder 
		WHERE FORMAT(ReminderDate, 'dd/MM/yyyy', 'en-US' ) =  FORMAT( @today,'dd/MM/yyyy' ,'en-US' )     

END

GO
/****** Object:  StoredProcedure [dbo].[sp_createDepartment]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE      PROCEDURE [dbo].[sp_createDepartment]
	@name nvarchar(30),
	@description nvarchar(100),
	@creationDate datetime2
AS
	BEGIN
		BEGIN TRY
			IF EXISTS(SELECT Name FROM Department WHERE Name = @name)
				THROW 50001, 'The Department name is already registered. Please try a Department name.',1;
			
			INSERT INTO Department(Name,Description,CreationDate)
				VALUES(@name,@description,@creationDate)
		END TRY
		BEGIN CATCH
			;THROW
		END CATCH
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateNewPurchaseOrder]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[sp_CreateNewPurchaseOrder]
@EmployeeId INT,
@GrandTotal MONEY,
@Total MONEY,
@Tax MONEY,
@Status TINYINT
AS
BEGIN
    INSERT INTO PurchaseOrder(EmployeeId, CreationDate, GrandTotal, Total, Tax, Status)
    VALUES(@EmployeeId, GETDATE(), @GrandTotal, @Total, @Tax, @Status)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreatePOWithFirstItem]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--CreatePOWithFirstItem
CREATE    PROCEDURE [dbo].[sp_CreatePOWithFirstItem]
@PO_EmployeeId INT,
@PO_GrandTotal MONEY,
@PO_Total MONEY,
@PO_Tax MONEY,
@PO_Status TINYINT,
@PO_OrderId INT,
@Item_Name NVARCHAR(50),
@Item_Description NVARCHAR(300),
@Item_Quantity INT,
@Item_Justification NVARCHAR(200),
@Item_Location NVARCHAR(200),
@Item_Status TINYINT,
@Item_Reason NVARCHAR(200),
@Item_Price MONEY
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO PurchaseOrder(EmployeeId, CreationDate, GrandTotal, Total, Tax, Status)
			VALUES(@PO_EmployeeId, GETDATE(), @PO_GrandTotal, @PO_Total, @PO_Tax, @PO_Status)

			SET @PO_OrderId = SCOPE_IDENTITY()

			INSERT INTO Item(OrderId, Name, Description, Quantity, Justification, Location, Status, Reason, Price, NoLongerNeeded)
			VALUES(@PO_OrderId, @Item_Name, @Item_Description, @Item_Quantity, @Item_Justification, @Item_Location, @Item_Status, @Item_Reason, @Item_Price, 0)
			--UPDATE PurchaseOrder SET Tax = (Tax + (@Item_Price * 0.15)), Total = (Total + (@Item_Price * @Item_Quantity)), GrandTotal = (Total + Tax) WHERE OrderId = @PO_OrderId;

			COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN;
			THROW 51000, 'Insert failed. Transaction rolled back. Purchase Order & Item were not inserted.', 1;
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_createReview]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_createReview]
	@performance tinyint,
	@comment nvarchar(200),
	@reviewDate DATETIME,
	@supervisorId int,
	@employeeId int
AS
BEGIN
	BEGIN TRY
		INSERT INTO Review(PerformanceRating,Comment,ReviewDate,SupervisorId,EmployeeId)
		VALUES(@performance,@comment,@reviewDate,@supervisorId,@employeeId)
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage nVarChar(4000)
		DECLARE @ErrorSeverity Int
		DECLARE @ErrorState Int
		SELECT	@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_createReviewReminder]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE      PROCEDURE [dbo].[sp_createReviewReminder]
	@hrEmpId INT,
	@RecipientSupervisorId INT,
	@reminderDate datetime
AS
	BEGIN
		BEGIN TRY
			--IF EXISTS(SELECT Name FROM Department WHERE Name = @name)
			--	THROW 50001, 'The Department name is already registered. Please try a Department name.',1;
			
			INSERT INTO ReviewReminder(HrEmpId,RecipientSuperviosId,ReminderDate)
				VALUES(@hrEmpId,@RecipientSupervisorId,@reminderDate)
		END TRY
		BEGIN CATCH
			;THROW
		END CATCH
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteDepartment]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_deleteDepartment]
	@departmentId	int
AS

BEGIN TRY
	IF (SELECT COUNT(*) FROM Employee WHERE DepartmentId = @departmentId) > 0
	BEGIN
		DECLARE @Error char(100)
		SET @Error = 'You cannot delete the department' + CHAR(13) + 'becuase there is employee in the department'
		RAISERROR (@Error,16,1) 
	END
	DELETE Department WHERE DepartmentId = @departmentId
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllDepartment]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_getAllDepartment]
AS
BEGIN
	SELECT DepartmentId,Name FROM Department
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllHr]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--GetAllSupervisor
CREATE     PROCEDURE [dbo].[sp_getAllHr]
AS
BEGIN
	SELECT Department.Name +'-'+ FirstName+' '+LastName as'FullName',Employee.EmployeeId, Employee.Email AS'Email' FROM Employee 
	INNER JOIN Department ON Employee.DepartmentId = Department.DepartmentId 
	INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId
	WHERE (Authentication.EmployeeType =0 OR Authentication.EmployeeType = 2) AND (Status IS NULL OR Status =2)
	ORDER BY FullName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getAlljJobs]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_getAlljJobs]
AS
BEGIN
	SELECT JobId,JobTitle FROM Job
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllOrDepartmentEmployeeInfo]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[sp_getAllOrDepartmentEmployeeInfo]
@department int = NULL
AS
SET NOCOUNT ON

BEGIN TRY
		if @department IS NULL
			BEGIN
				SELECT *,(SELECT EmployeeType FROM Authentication WHERE EmployeeId = e.EmployeeId) as 'EmployeeType' FROM Employee as e
			END
		ELSE IF EXISTS(SELECT * FROM Employee WHERE DepartmentId = @department)
			BEGIN
				SELECT *,(SELECT EmployeeType FROM Authentication WHERE EmployeeId = e.EmployeeId) as 'EmployeeType' FROM Employee as e
				WHERE DepartmentId = @department
			END
		ELSE
			BEGIN
				DECLARE @Error char(50)
				SET @Error = 'No matching Employee on the department'
				RAISERROR (@Error,16,1) 
			END
		
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllorOneAEmployeeInfo]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       PROCEDURE [dbo].[sp_getAllorOneAEmployeeInfo]
@empId int NULL
AS
SET NOCOUNT ON

BEGIN TRY
		if @empId IS NULL
			BEGIN
				SELECT * FROM Employee
			END
		ELSE IF EXISTS(SELECT * FROM Employee WHERE EmployeeId = @empId)
			BEGIN
				SELECT * FROM Employee WHERE EmployeeId = @empId
			END
		ELSE
			BEGIN
				DECLARE @Error char(50)
				SET @Error = 'No matching Employee on file'
				RAISERROR (@Error,16,1) 
			END
		
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllReviewsByEmp]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getAllReviewsByEmp]
	@empId int
AS

BEGIN TRY
	
	BEGIN
		SELECT * FROM Review WHERE EmployeeId = @empId ORDER BY ReviewDate DESC ;
	END

END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllSupervisor]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--GetAllSupervisor
CREATE     PROCEDURE [dbo].[sp_getAllSupervisor]
AS
BEGIN
	SELECT Department.Name +'-'+ FirstName+' '+LastName as'FullName',Employee.EmployeeId, Employee.Email AS'Email' FROM Employee 
	INNER JOIN Department ON Employee.DepartmentId = Department.DepartmentId 
	INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId
	WHERE (Authentication.EmployeeType =1 OR Authentication.EmployeeType = 0) AND (Status IS NULL OR Status =2)
	ORDER BY FullName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getDepartmentBySupervisor]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE        PROCEDURE [dbo].[sp_getDepartmentBySupervisor]
	@employeeId	int
AS

SET NOCOUNT ON

BEGIN TRY

	SELECT Department.DepartmentId,Name,Description,CreationDate,Department.TimeStamp FROM Department 
	INNER JOIN Employee ON Department.DepartmentId = Employee.DepartmentId
	WHERE EmployeeId =@employeeId

END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_getDepartmentOne]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE      PROCEDURE [dbo].[sp_getDepartmentOne]
	@departmentId	int
AS

SET NOCOUNT ON

BEGIN TRY
	IF NOT EXISTS (SELECT * FROM Department WHERE DepartmentId = @departmentId)
	BEGIN
		DECLARE @Error char(50)
		SET @Error = 'Department Id, ' + @departmentId + ', is not on file'
		RAISERROR (@Error,16,1) 
	END
	SELECT * FROM Department WHERE DepartmentId = @departmentId
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_getEmployee]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[sp_getEmployee]
@Keyword nvarchar(30)
AS
SET NOCOUNT ON
BEGIN TRY
	IF EXISTS(SELECT * FROM Employee WHERE LastName LIKE '%' + @Keyword + '%')
		BEGIN
			SELECT *
			FROM Employee 
			WHERE LastName LIKE '%' + @Keyword + '%'
		END
	ELSE IF EXISTS (SELECT * FROM Employee WHERE EmployeeId = @Keyword)
		BEGIN
			SELECT *
			FROM Employee 
			WHERE EmployeeId = @Keyword
		END
	ELSE
		BEGIN
			DECLARE @Error char(50)
			SET @Error = 'No matching Employee on file'
			RAISERROR (@Error,16,1) 
		END
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_getEmployeeBySupervisor]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_getEmployeeBySupervisor]
	@supervisor int
as
BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT * FROM Employee WHERE SupervisorId = @supervisor)
			BEGIN
				DECLARE @Error char(50)
				SET @Error = 'You dont have a employee to review';
				RAISERROR (@Error,16,1) 
			END
	
		SELECT Employee.EmployeeId, FirstName +' '+LastName  AS 'FullName' FROM Employee LEFT JOIN Review ON Employee.EmployeeId = Review.EmployeeId 
		WHERE Employee.SupervisorId = @supervisor  AND Review.ReviewId IS NULL

	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage nVarChar(4000)
		DECLARE @ErrorSeverity Int
		DECLARE @ErrorState Int
		SELECT	@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getEmployeeLookup]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_getEmployeeLookup]
@Keyword nvarchar(30)
AS
SET NOCOUNT ON

BEGIN TRY
	IF EXISTS(SELECT * FROM Employee WHERE LastName LIKE  @Keyword + '%')
		BEGIN
			SELECT EmployeeId, FirstName +' '+LastName  AS 'FullName'
			FROM Employee 
			WHERE LastName LIKE  @Keyword + '%'
		END
	ELSE IF EXISTS (SELECT * FROM Employee WHERE TRY_CONVERT(int, @Keyword) IS NOT NULL AND EmployeeId = CONVERT(int,@Keyword))
		BEGIN
			SELECT  EmployeeId, FirstName +' '+LastName  AS 'FullName'
			FROM Employee 
			WHERE EmployeeId = @Keyword AND Status IS NULL
		END
	ELSE
		BEGIN
			DECLARE @Error char(50)
			SET @Error = 'No matching Employee on file'
			RAISERROR (@Error,16,1) 
		END
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_getEmployeeOne]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[sp_getEmployeeOne]
	@employeeId	int
AS

SET NOCOUNT ON

BEGIN TRY
	IF NOT EXISTS (SELECT * FROM Employee WHERE EmployeeId = @employeeId)
	BEGIN
		DECLARE @Error char(50)
		SET @Error = 'Employee Id, ' + @employeeId + ', is not on file'
		RAISERROR (@Error,16,1) 
	END
	SELECT * FROM Employee 
	INNER JOIN Authentication  
	ON Employee.EmployeeId = Authentication.EmployeeId
	WHERE Employee.EmployeeId = @employeeId
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLastestReviewDate]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[sp_GetLastestReviewDate]
@EmployeeId INT
AS
BEGIN
    SELECT * FROM Review 
    WHERE ReviewDate IN (SELECT MAX(ReviewDate) FROM Review WHERE EmployeeId = @EmployeeId) 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getLoginInformation]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetLoginInformation
CREATE   PROCEDURE [dbo].[sp_getLoginInformation]
    @Username Int, 
    @Password NVARCHAR(255)
AS
 
BEGIN
    BEGIN TRY
            IF NOT EXISTS( SELECT * FROM Authentication WHERE EmployeeId = @Username AND Password = @Password)
                THROW 50001, 'There is no Employee with the username and password',1;

			  IF EXISTS( SELECT * FROM Authentication 
				INNER JOIN Employee ON Authentication.EmployeeId = Employee.EmployeeId
				WHERE Authentication.EmployeeId = @Username AND Password = @Password AND IsActive = 0)
					THROW 50001, 'User is not activated',1;

            SELECT * FROM Authentication WHERE EmployeeId = @Username AND Password = @Password

			
			
    END TRY
    BEGIN CATCH
        ;THROW
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getReviewsBySupervisorWithQuarter]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getReviewsBySupervisorWithQuarter]

AS

BEGIN TRY
	
	BEGIN

		SELECT Employee.SupervisorId AS 'EmployeeId', FirstName +' '+LastName  AS 'FullName',Employee.Email FROM Employee LEFT JOIN Review ON Employee.EmployeeId = Review.EmployeeId 
			WHERE ReviewId IS NULL AND EXISTS (SELECT Employee.EmployeeId FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
			WHERE (EmployeeType = 2 OR EmployeeType = 3) AND (Status IS NULL OR Status = 2))
			--AND 
			--	(Convert(datetime,ReviewDate,103)  >= Convert(datetime,'01/05/2021',103) 
			--	And (Convert(datetime,ReviewDate,103) <=  Convert(datetime,'31/05/2021',103)))
			ORDER BY Employee.SupervisorId
	END


END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_getSupervisorDetailById]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[sp_getSupervisorDetailById]
	@supervisorId INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT * FROM Employee WHERE EmployeeId = @supervisorId)
				DECLARE @Error char(50)
				SET @Error = 'Supervisor doesnt exists';
				RAISERROR (@Error,16,1) 
	
		SELECT EmployeeId, FirstName +' '+LastName  AS 'FullName' FROM Employee WHERE EmployeeId = @supervisorId
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage nVarChar(4000)
		DECLARE @ErrorSeverity Int
		DECLARE @ErrorState Int
		SELECT	@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmployee]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_insertEmployee]
	@empId int output,
	@supervisorId int null,
	@departmentId int,
	@jobId int,
    @lastName nvarchar(30), 
	@firstName nvarchar(30), 
	@mi nchar(1), 
	@dob datetime2,
    @streetAddress nvarchar(30),	
	@city nvarchar(30),
	@postalCode nchar(6),
	@sin nchar(9), 
	@seniorityDate datetime2,
	@jobStartDate datetime2, 
	@workPhone nvarchar(13),
	@cellPhone nvarchar(13),
	@Email nvarchar(30),
	@isActive bit,
	@empType tinyint,
	@username nvarchar(30),
	@password nvarchar(500) null
AS



BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @numSupervisor int;
		DECLARE @numEmployee int;

		SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
		WHERE DepartmentId = 1 AND Status IS NULL
		SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
		WHERE DepartmentId = 1 AND EmployeeType = 3 AND Status IS NULL
		SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
		WHERE DepartmentId = 1 AND EmployeeType = 1 AND Status IS NULL


		SET @numSupervisor = (SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
				WHERE DepartmentId = @departmentId AND  Status IS NULL AND (Authentication.EmployeeType=0 OR Authentication.EmployeeType=1) );

		SET @numEmployee = (SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
			WHERE DepartmentId = @departmentId AND  Status IS NULL AND (Authentication.EmployeeType=2 OR Authentication.EmployeeType=3));
		
			IF @departmentId NOT IN (SELECT DISTINCT  DepartmentId FROM Employee WHERE EmployeeId = @supervisorId) AND @supervisorId IS NOT NULL
				BEGIN
					RAISERROR ('Supervisor should be same dpeartment',16,1) 
				END

			IF  (@numSupervisor*10)+@numSupervisor <= (SELECT COUNT(*) FROM Employee WHERE DepartmentId=@departmentId) AND @supervisorId IS NOT NULL
				BEGIN
					RAISERROR ('There are not enough supervisors in that department to add another employee.',16,1) 
				END

			IF @supervisorId  IN (SELECT EmployeeId FROM Employee WHERE EmployeeId = @empId)
				BEGIN
					RAISERROR ('You cannot put your name in supervisor',16,1) 
				END

		INSERT INTO Employee (SupervisorId, DepartmentId,JobId,
		LastName,FirstName,MI,Dob,
		StreetAddress,City,PostalCode,SIN,SeniorityDate,
		JobStartDate,WorkPhone,CellPhone,Email,IsActive)
		VALUES (@supervisorId,@departmentId,@jobId,
		@lastName,@firstName,@mi,@dob,
		@streetAddress,@city,@postalCode,@sin,@seniorityDate,
		@jobStartDate,@workPhone,@cellPhone,@email,@isActive)

		SET @empId = @@IDENTITY	

		IF EXISTS(SELECT * FROM Authentication WHERE UserName = @username)
			BEGIN
				RAISERROR ('The username already exists',16,1) 
			END
		IF @password is not null
			INSERT INTO Authentication (EmployeeId,Password,UserName,EmployeeType)
			VALUES (@empId, @password,@username ,@empType)
		ELSE
			INSERT INTO Authentication (EmployeeId,Password,UserName,EmployeeType)
			VALUES (@empId, 'password',@username ,@empType)	
		COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION
		END
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertItem]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





--InsertItem
CREATE    PROCEDURE [dbo].[sp_InsertItem]
@PO_OrderId INT,
@Item_Name NVARCHAR(50),
@Item_Description NVARCHAR(300),
@Item_Quantity INT,
@Item_Justification NVARCHAR(200),
@Item_Location NVARCHAR(200),
@Item_Status TINYINT,
@Item_Reason NVARCHAR(200),
@Item_Price MONEY
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF EXISTS(SELECT * FROM Item WHERE Name = @Item_Name AND Description = @Item_Description AND Justification = @Item_Justification AND Location = @Item_Location AND Price = @Item_Price AND OrderId = @PO_OrderId)
				BEGIN
					UPDATE Item SET Quantity += @Item_Quantity WHERE Name = @Item_Name AND Description = @Item_Description AND Justification = @Item_Justification AND Location = @Item_Location AND Price = @Item_Price AND OrderId = @PO_OrderId;
					UPDATE PurchaseOrder SET Tax = (Tax + (@Item_Price * 0.15)), Total = (Total + (@Item_Price * @Item_Quantity)), GrandTotal = (GrandTotal + (Total + Tax)) WHERE OrderId = @PO_OrderId;
				END
			ELSE
			INSERT INTO Item(OrderId, Name, Description, Quantity, Justification, Location, Status, Reason, Price, NoLongerNeeded)
			VALUES(@PO_OrderId, @Item_Name, @Item_Description, @Item_Quantity, @Item_Justification, @Item_Location, @Item_Status, @Item_Reason, @Item_Price, 0)
			UPDATE PurchaseOrder SET Tax += ((@Item_Price * @Item_Quantity) * 0.15), Total += (@Item_Price * @Item_Quantity), GrandTotal += ((@Item_Price * @Item_Quantity) + ((@Item_Price * @Item_Quantity) * 0.15)) WHERE OrderId = @PO_OrderId;

			COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN;
			THROW 51000, 'Insert failed. Transaction rolled back. Item was not inserted.', 1;
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyItem]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--ModifyItem
CREATE    PROCEDURE [dbo].[sp_ModifyItem]
@TimeStamp TIMESTAMP OUTPUT,
@ItemId INT,
@OrderId INT,
@Name NVARCHAR(50),
@Quantity INT,
@Description NVARCHAR(300),
@Price MONEY,
@Justification NVARCHAR(200),
@Location NVARCHAR(200),
@Status TINYINT,
@Reason NVARCHAR(200),
@NoLongerNeeded BIT
AS
BEGIN
	BEGIN TRY
		IF @TimeStamp <> (SELECT [TimeStamp] FROM Item WHERE ItemId = @ItemId)
			THROW 50003, 'The record has been modified since you last retrieved it. Please reload the item and try again.', 1;

		--IF EXISTS(SELECT * FROM Item WHERE Name = @Name AND Description = @Description AND Justification = @Justification AND Location = @Location AND Price = @Price AND OrderId = @OrderId)
		--		BEGIN
		--			UPDATE Item SET Quantity += @Quantity WHERE Name = @Name AND Description = @Description AND Justification = @Justification AND Location = @Location AND Price = @Price AND OrderId = @OrderId;
		--			--UPDATE PurchaseOrder SET Tax += (@Price * 0.15), Total += (@Price * @Quantity), GrandTotal += (Total + Tax) WHERE OrderId = @PO_OrderId;
		--		END
		--ELSE
		UPDATE Item SET
			Name = @Name,
			Quantity = @Quantity,
			Description = @Description,
			Price = @Price,
			Justification = @Justification,
			Location = @Location,
			Status = @Status,
			Reason = @Reason,
			NoLongerNeeded = @NoLongerNeeded
		WHERE ItemId = @ItemId;

		SET @TimeStamp = (SELECT [TimeStamp] FROM Item WHERE ItemId = @ItemId)
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyItemStatus]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ModifyItemStatus]
@TimeStamp TIMESTAMP OUTPUT,
@ItemId INT,
@Status TINYINT,
@Reason NVARCHAR(200)
AS
BEGIN
	BEGIN TRY
	IF @TimeStamp <> (SELECT [TimeStamp] FROM Item WHERE ItemId = @ItemId)
			THROW 50003, 'The record has been modified since you last retrieved it. Please reload the item and try again.', 1;

		UPDATE Item SET
			Status = @Status,
			Reason = @Reason
		WHERE ItemId = @ItemId;

		SET @TimeStamp = (SELECT [TimeStamp] FROM Item WHERE ItemId = @ItemId)
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyPO]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[sp_ModifyPO]
@TimeStamp TIMESTAMP OUTPUT,
@OrderId INT,
@Tax MONEY,
@Total MONEY,
@GrandTotal MONEY,
@Status TINYINT
AS
BEGIN
	BEGIN TRY
	IF @TimeStamp <> (SELECT [TimeStamp] FROM PurchaseOrder WHERE OrderId = @OrderId)
			THROW 50003, 'The record has been modified since you last retrieved it. Please reload the item and try again.', 1;

		UPDATE PurchaseOrder SET
			Tax = @Tax,
			Total = @Total,
			GrandTotal = @GrandTotal,
			Status = @Status
		WHERE OrderId = @OrderId;

		SET @TimeStamp = (SELECT [TimeStamp] FROM PurchaseOrder WHERE OrderId = @OrderId)
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyPOStatus]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ModifyPOStatus]
@TimeStamp TIMESTAMP OUTPUT,
@OrderId INT,
@Status TINYINT
AS
BEGIN
	BEGIN TRY
	IF @TimeStamp <> (SELECT [TimeStamp] FROM PurchaseOrder WHERE OrderId = @OrderId)
			THROW 50003, 'The record has been modified since you last retrieved it. Please reload the item and try again.', 1;

		UPDATE PurchaseOrder SET
			Status = @Status
		WHERE OrderId = @OrderId;

		SET @TimeStamp = (SELECT [TimeStamp] FROM PurchaseOrder WHERE OrderId = @OrderId)
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModyfyDuplicateItem]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[sp_ModyfyDuplicateItem]
@TimeStamp TIMESTAMP OUTPUT,
@Quantity INT,
@Name NVARCHAR(50),
@Description NVARCHAR(300),
@Justification NVARCHAR(200),
@Location NVARCHAR(200),
@Price MONEY,
@OrderId INT,
@ItemId INT,
@PO_OrderId INT,
@DuplicateItemId INT,
@NoLongerNeeded BIT
AS	
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF @ItemId != @DuplicateItemId
				BEGIN
					UPDATE Item SET Quantity += @Quantity WHERE 
					Name = @Name 
					AND Description = @Description 
					AND Justification = @Justification 
					AND Location = @Location 
					AND Price = @Price 
					AND OrderId = @OrderId
					AND ItemId = @ItemId
					AND NoLongerNeeded = @NoLongerNeeded;
			
					DELETE FROM Item WHERE ItemId = @DuplicateItemId;
				END				
			ELSE
				BEGIN
					UPDATE Item SET Quantity = @Quantity WHERE 
					Name = @Name 
					AND Description = @Description 
					AND Justification = @Justification 
					AND Location = @Location 
					AND Price = @Price 
					AND OrderId = @OrderId
					AND ItemId = @ItemId
					AND NoLongerNeeded = @NoLongerNeeded;
				END

				SET @TimeStamp = (SELECT [TimeStamp] FROM Item WHERE ItemId = @ItemId)
			COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN;
			THROW 51000, 'Modify failed. Transaction rolled back. Purchase Order & Item were not modified.', 1;
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveAllItemsInPO]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--RetrieveAllItemsInPO
CREATE    PROCEDURE [dbo].[sp_RetrieveAllItemsInPO]
@OrderId INT
AS
BEGIN
	SELECT *, EmployeeId FROM Item
	INNER JOIN PurchaseOrder ON PurchaseOrder.OrderId = Item.OrderId
	WHERE Item.OrderId = @OrderId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveItemInformation]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--RetrieveItemInformation
CREATE    PROCEDURE [dbo].[sp_RetrieveItemInformation]
@ItemId INT
AS
BEGIN
	SELECT *, GrandTotal, PurchaseOrder.Status AS POStatus FROM Item
	INNER JOIN PurchaseOrder ON PurchaseOrder.OrderId = Item.OrderId
	WHERE ItemId = @ItemId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrievePOInformation]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_RetrievePOInformation]
@OrderId INT
AS
BEGIN
	SELECT * FROM PurchaseOrder WHERE OrderId = @OrderId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrievePurchaseOrderTimeStampByItemId]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--RetrievePurchaseOrderTimeStampByItemId
CREATE    PROCEDURE [dbo].[sp_RetrievePurchaseOrderTimeStampByItemId]
@ItemId INT
AS
BEGIN
	SELECT PurchaseOrder.TimeStamp FROM PurchaseOrder
	INNER JOIN Item ON Item.OrderId = PurchaseOrder.OrderId
	WHERE item.ItemId = @ItemId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchByIdSupervisor]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_SearchByIdSupervisor]
@OrderId INT,
@DepartmentId INT
AS 
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name, SupervisorId FROM PurchaseOrder 
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE OrderId = @OrderId AND Department.DepartmentId = @DepartmentId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchByMultipleFilters]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_SearchByMultipleFilters]
@NameSearch NVARCHAR(60),
@StartDate DATETIME2,
@EndDate DATETIME2,
@Status TINYINT,
@DepartmentId INT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS FullName, PurchaseOrder.CreationDate, PurchaseOrder.OrderId FROM Employee 
	INNER JOIN PurchaseOrder ON PurchaseOrder.EmployeeId = Employee.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE FirstName + ' ' + LastName LIKE '%'+@NameSearch+'%' 
	AND PurchaseOrder.CreationDate >= @StartDate AND PurchaseOrder.CreationDate <= @EndDate
	AND PurchaseOrder.Status = @Status		
	AND Department.DepartmentId = @DepartmentId
	ORDER BY PurchaseOrder.CreationDate;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchPOByDate]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SearchPOByDate
CREATE    PROCEDURE [dbo].[sp_SearchPOByDate]
@StartDate DATETIME2,
@EndDate DATETIME2,
@EmployeeId INT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name, SupervisorId FROM PurchaseOrder 
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE PurchaseOrder.CreationDate >= @StartDate AND PurchaseOrder.CreationDate <= @EndDate AND PurchaseOrder.EmployeeId = @EmployeeId 
	ORDER BY PurchaseOrder.CreationDate DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchPOByDateSupervisor]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_SearchPOByDateSupervisor]
@StartDate DATETIME2,
@EndDate DATETIME2,
@DepartmentId INT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name, SupervisorId FROM PurchaseOrder 
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE PurchaseOrder.CreationDate >= @StartDate AND PurchaseOrder.CreationDate <= @EndDate AND Department.DepartmentId = @DepartmentId 
	ORDER BY PurchaseOrder.CreationDate DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchPOById]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SearchById
CREATE    PROCEDURE [dbo].[sp_SearchPOById]
@OrderId INT,
@EmployeeId INT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name, SupervisorId FROM PurchaseOrder 
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE OrderId = @OrderId AND PurchaseOrder.EmployeeId = @EmployeeId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchPOByIdSupervisor]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_SearchPOByIdSupervisor]
@OrderId INT,
@DepartmentId INT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name, SupervisorId FROM PurchaseOrder 
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE OrderId = @OrderId AND Department.DepartmentId = @DepartmentId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllPObyEmployeeWithoutStatus]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SelectAllPurchaseOrdersbyEmployee
CREATE   PROCEDURE [dbo].[sp_SelectAllPObyEmployeeWithoutStatus]
@EmployeeId INT
AS 
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name FROM PurchaseOrder
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE PurchaseOrder.EmployeeId = @EmployeeId
	ORDER BY PurchaseOrder.Status;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllPOFromDepartment]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_SelectAllPOFromDepartment]
@DepartmentId INT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name FROM PurchaseOrder
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE Department.DepartmentId = @DepartmentId
	ORDER BY PurchaseOrder.Status;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllPurchaseOrdersbyEmployee]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SelectAllPurchaseOrdersbyEmployee
CREATE    PROCEDURE [dbo].[sp_SelectAllPurchaseOrdersbyEmployee]
@EmployeeId INT,
@Status TINYINT
AS 
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name FROM PurchaseOrder
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE PurchaseOrder.EmployeeId = @EmployeeId AND PurchaseOrder.Status = @Status
	ORDER BY PurchaseOrder.Status;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllPurchaseOrdersByEmployeeWithStatusSupervisor]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_SelectAllPurchaseOrdersByEmployeeWithStatusSupervisor]
@DepartmentId INT,
@Status TINYINT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name FROM PurchaseOrder
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE Department.DepartmentId = @DepartmentId AND PurchaseOrder.Status = @Status
	ORDER BY PurchaseOrder.Status;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectLastInsertedPO]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SelectLastInsertedPO
CREATE    PROCEDURE [dbo].[sp_SelectLastInsertedPO]
AS
BEGIN
    SELECT OrderId FROM PurchaseOrder WHERE OrderId = (SELECT MAX(OrderId) FROM PurchaseOrder)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectLoggedInEmployee]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SelectLoggedInEmployee
CREATE    PROCEDURE [dbo].[sp_SelectLoggedInEmployee] @EmployeeId INT
AS
BEGIN
    SELECT *, Department.Name FROM Employee 
    INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
    WHERE EmployeeId = @EmployeeId    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectPurchaseOrderById]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SelectPurchaseOrderById
CREATE    PROCEDURE [dbo].[sp_SelectPurchaseOrderById]
@OrderId INT,
@EmployeeId INT
AS
BEGIN
	SELECT *, FirstName + ' ' + LastName AS Fullname, Department.Name, Department.DepartmentId, SupervisorId FROM PurchaseOrder 
	INNER JOIN Employee ON Employee.EmployeeId = PurchaseOrder.EmployeeId
	INNER JOIN Department ON Department.DepartmentId = Employee.DepartmentId
	WHERE OrderId = @OrderId AND PurchaseOrder.EmployeeId = @EmployeeId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectPurchaseOrderItems]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SelectPurchaseOrderItems
CREATE    PROCEDURE [dbo].[sp_SelectPurchaseOrderItems]
@OrderId INT
AS
BEGIN
	SELECT * FROM Item
	WHERE OrderId = @OrderId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectSupervisorName]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






--SelectSupervisorName
CREATE     PROCEDURE [dbo].[sp_SelectSupervisorName]
@SupervisorId INT
AS
BEGIN
    SELECT SupervisorId, FirstName + ' ' + LastName AS FullName 
    FROM Employee
    WHERE EmployeeId = @SupervisorId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_updateDepartmentByHR]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[sp_updateDepartmentByHR]
	@TimeStamp TIMESTAMP OUTPUT,
    @departmentId	int,		
	@name nvarchar(50),
    @description nvarchar(200),	
	@creationDate DATETIME

AS

BEGIN TRY
	IF NOT EXISTS (SELECT * FROM Department WHERE DepartmentId = @departmentId)
		BEGIN
			DECLARE @Error char(50)
			SET @Error = 'Department Id, ' + @departmentId + ', is not on file'
			RAISERROR (@Error,16,1) 
		END

	IF(SELECT[TimeStamp] FROM Department WHERE DepartmentId=@departmentId) <> @TimeStamp
		THROW 51005,'The record has been updated by someone since you last retrieved it. Retrieve the record again before you make updates.',1

	UPDATE Department 
		SET Name = @name, Description = @description, CreationDate = @creationDate 
		WHERE DepartmentId = @departmentId

		SET @TimeStamp = (SELECT [TimeStamp]  FROM Department where DepartmentId = @departmentId)
		
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_updateEmployeeStatus]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       PROCEDURE [dbo].[sp_updateEmployeeStatus]
	@TimeStamp TIMESTAMP OUTPUT,
	@empId INT,
	@empStatus TINYINT,
	@lastdayofwork DATETIME2
AS

BEGIN TRY
	IF NOT EXISTS (SELECT * FROM Employee WHERE EmployeeId = @empId)
		BEGIN
			DECLARE @Error char(50)
			SET @Error = 'Employee Id, ' + @empId + ', is not on file'
			RAISERROR (@Error,16,1) 
		END

	IF(SELECT[TimeStamp] FROM Employee WHERE EmployeeId=@empId) <> @TimeStamp
		THROW 51005,'The record has been updated by someone since you last retrieved it. Retrieve the record again before you make updates.',1

		if(@empStatus=2)
			BEGIN
				UPDATE Employee 
					SET Status = @empStatus, LastDayOfWork =@lastdayofwork, IsActive = 1
					WHERE EmployeeId = @empId
					SET @TimeStamp = (SELECT [TIMESTAMP] FROM Employee where EmployeeId = @empId)
			END
		ELSE
			BEGIN
				UPDATE Employee 
					SET Status = @empStatus, LastDayOfWork =@lastdayofwork, IsActive = 0
					WHERE EmployeeId = @empId
					SET @TimeStamp = (SELECT [TIMESTAMP] FROM Employee where EmployeeId = @empId)
			END
		
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_updateJobByHr]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [dbo].[sp_updateJobByHr]
	@TimeStamp TIMESTAMP output,
	@empId int,
	@supervisorId int,
	@departmentId int,
	@jobId int,
	@jobStartDate datetime2
AS



BEGIN TRY
		BEGIN TRANSACTION

		IF(SELECT[TimeStamp] FROM Employee WHERE EmployeeId=@empId) <> @TimeStamp
		THROW 51005,'The record has been updated by someone since you last retrieved it. Retrieve the record again before you make updates.',1

		IF (SELECT DepartmentId FROM Employee WHERE EmployeeId = @empId) != @departmentId
			BEGIN 
				DECLARE @numSupervisor int;
				DECLARE @numEmployee int;

				SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
				WHERE DepartmentId = 1 AND Status IS NULL
				SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
				WHERE DepartmentId = 1 AND EmployeeType = 3 AND Status IS NULL
				SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
				WHERE DepartmentId = 1 AND EmployeeType = 1 AND Status IS NULL


				SET @numSupervisor = (SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
						WHERE DepartmentId = @departmentId AND  Status IS NULL AND (Authentication.EmployeeType=0 OR Authentication.EmployeeType=1) );

				SET @numEmployee = (SELECT COUNT(*) FROM Employee INNER JOIN Authentication ON Employee.EmployeeId = Authentication.EmployeeId 
					WHERE DepartmentId = @departmentId AND  Status IS NULL AND (Authentication.EmployeeType=2 OR Authentication.EmployeeType=3));
		
					IF @departmentId NOT IN (SELECT DISTINCT  DepartmentId FROM Employee WHERE EmployeeId = @supervisorId)
						BEGIN
							RAISERROR ('Supervisor should be same dpeartment',16,1) 
						END

					IF  (@numSupervisor*10)+@numSupervisor <= (SELECT COUNT(*) FROM Employee WHERE DepartmentId=@departmentId)
						BEGIN
							RAISERROR ('There are not enough supervisors in that department to add another employee.',16,1) 
						END

					IF @supervisorId  IN (SELECT EmployeeId FROM Employee WHERE EmployeeId = @empId)
						BEGIN
							RAISERROR ('You cannot put your name in supervisor',16,1) 
						END
				UPDATE Employee
					SET SupervisorId = @supervisorId,
						JobId = @jobId,
						DepartmentId = @departmentId,
						JobStartDate = @jobStartDate
					WHERE EmployeeId =@empId
			END
		ELSE
			IF @departmentId NOT IN (SELECT DISTINCT  DepartmentId FROM Employee WHERE EmployeeId = @supervisorId)
						BEGIN
							RAISERROR ('Supervisor should be same dpeartment',16,1) 
						END
							IF @supervisorId  IN (SELECT EmployeeId FROM Employee WHERE EmployeeId = @empId)
						BEGIN
							RAISERROR ('You cannot put your name in supervisor',16,1) 
						END
			UPDATE Employee
				SET SupervisorId = @supervisorId,
					JobId = @jobId,
					DepartmentId = @departmentId,
					JobStartDate = @jobStartDate
				WHERE EmployeeId =@empId

		SET @TimeStamp = (SELECT [TIMESTAMP] FROM Employee where EmployeeId = @empId)
	
		COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION
		END
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_updatePersonalInfo]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_updatePersonalInfo]
	@TimeStamp TIMESTAMP OUTPUT,
    @empId	int,		
	@streetAddress nvarchar(30),
    @City		nvarchar(20),	
	@PostalCode char(6),
	@workPhone	varchar(13),
	@cellPhone	varchar(13)	
AS

BEGIN TRY
	IF NOT EXISTS (SELECT * FROM Employee WHERE EmployeeId = @empId)
		BEGIN
			DECLARE @Error char(50)
			SET @Error = 'Employee Id, ' + @empId + ', is not on file'
			RAISERROR (@Error,16,1) 
		END

	IF(SELECT[TimeStamp] FROM Employee WHERE EmployeeId=@empId) <> @TimeStamp
		THROW 51005,'The record has been updated by someone since you last retrieved it. Retrieve the record again before you make updates.',1

		UPDATE Employee 
			SET StreetAddress = @streetAddress, City = @City, PostalCode = @PostalCode, 
				CellPhone = @cellPhone, WorkPhone = @workPhone
			WHERE EmployeeId = @empId
			SET @TimeStamp = (SELECT [TIMESTAMP] FROM Employee where EmployeeId = @empId)
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_updatePersonalInfoByHR]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       PROCEDURE [dbo].[sp_updatePersonalInfoByHR]
	@TimeStamp TIMESTAMP OUTPUT,
    @empId	int,		
    @lastName nvarchar(30), 
	@firstName nvarchar(30), 
	@mi nchar(1), 
	@dob datetime2,
    @streetAddress nvarchar(30),	
	@city nvarchar(30),
	@postalCode nchar(6),
	@workPhone nvarchar(13),
	@cellPhone nvarchar(13),
	@email nvarchar(30),
	@isActive bit,
	@username nvarchar(30)
AS

BEGIN TRY
	IF NOT EXISTS (SELECT * FROM Employee WHERE EmployeeId = @empId)
		BEGIN
			DECLARE @Error char(50)
			SET @Error = 'Employee Id, ' + @empId + ', is not on file'
			RAISERROR (@Error,16,1) 
		END

	IF(SELECT[TimeStamp] FROM Employee WHERE EmployeeId=@empId) <> @TimeStamp
		THROW 51005,'The record has been updated by someone since you last retrieved it. Retrieve the record again before you make updates.',1

		UPDATE Employee 
			SET StreetAddress = @streetAddress, 
				City = @City, 
				PostalCode = @PostalCode, 
				CellPhone = @cellPhone, 
				WorkPhone = @workPhone,
				LastName = @lastName,
				FirstName= @firstName,
				IsActive = @isActive,
				MI = @mi, 
				Dob = @dob,
				Email = @email
			WHERE EmployeeId = @empId

		UPDATE Authentication
			SET UserName = @username
			WHERE EmployeeId = @empId

			SET @TimeStamp = (SELECT [TIMESTAMP] FROM Employee where EmployeeId = @empId)
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage nVarChar(4000)
	DECLARE @ErrorSeverity Int
	DECLARE @ErrorState Int
	SELECT	@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_VerifyIsActiveUser]    Script Date: 5/19/2021 11:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--VerifyIsActiveUser
CREATE    PROCEDURE [dbo].[sp_VerifyIsActiveUser]
@Username NVARCHAR(30),
@Password NVARCHAR(30)
AS
BEGIN
    SELECT * FROM Employee
    INNER JOIN Authentication ON Authentication.EmployeeId = Employee.EmployeeId
    WHERE IsActive = 1 AND Username = @Username AND Password = @Password
END
GO
USE [master]
GO
ALTER DATABASE [GreenSwitch_DB] SET  READ_WRITE 
GO
