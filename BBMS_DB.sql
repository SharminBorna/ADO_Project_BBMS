USE [master]
GO
/****** Object:  Database [BloodBankManagementSystem]    Script Date: 7/19/2021 7:16:25 PM ******/
CREATE DATABASE [BloodBankManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BloodBankManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BloodBankManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BloodBankManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BloodBankManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BloodBankManagementSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BloodBankManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BloodBankManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BloodBankManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BloodBankManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BloodBankManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BloodBankManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [BloodBankManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BloodBankManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BloodBankManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BloodBankManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BloodBankManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BloodBankManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BloodBankManagementSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BloodBankManagementSystem', N'ON'
GO
ALTER DATABASE [BloodBankManagementSystem] SET QUERY_STORE = OFF
GO
USE [BloodBankManagementSystem]
GO
/****** Object:  Table [dbo].[tblBloodStock]    Script Date: 7/19/2021 7:16:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBloodStock](
	[bloodGroup] [nvarchar](10) NOT NULL,
	[bloodStock] [int] NOT NULL,
 CONSTRAINT [PK_tblBloodStock] PRIMARY KEY CLUSTERED 
(
	[bloodGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDonors]    Script Date: 7/19/2021 7:16:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDonors](
	[donorId] [int] IDENTITY(501,1) NOT NULL,
	[donorName] [nvarchar](50) NOT NULL,
	[age] [int] NOT NULL,
	[gender] [nvarchar](10) NOT NULL,
	[bloodGroup] [nvarchar](10) NOT NULL,
	[contactNo] [nvarchar](20) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[lastDonationDate] [datetime] NULL,
	[imageName] [nvarchar](150) NULL,
 CONSTRAINT [PK_tblDonors] PRIMARY KEY CLUSTERED 
(
	[donorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPatients]    Script Date: 7/19/2021 7:16:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPatients](
	[patientID] [int] IDENTITY(101,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[age] [int] NOT NULL,
	[gender] [nvarchar](10) NOT NULL,
	[bloodGroup] [nvarchar](10) NOT NULL,
	[quantity] [int] NOT NULL,
	[caseDate] [datetime] NOT NULL,
	[contact] [nvarchar](20) NOT NULL,
	[address] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_tblPatient] PRIMARY KEY CLUSTERED 
(
	[patientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTransferBlood]    Script Date: 7/19/2021 7:16:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransferBlood](
	[transferId] [int] IDENTITY(1001,1) NOT NULL,
	[patientName] [nvarchar](50) NOT NULL,
	[bloodGroup] [nvarchar](10) NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_tblTransferBlood] PRIMARY KEY CLUSTERED 
(
	[transferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 7/19/2021 7:16:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[userId] [int] IDENTITY(101,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[password] [nvarchar](150) NOT NULL,
	[fullName] [nvarchar](150) NOT NULL,
	[contact] [nvarchar](20) NOT NULL,
	[address] [nvarchar](250) NULL,
	[addedDate] [datetime] NULL,
	[imageName] [nvarchar](250) NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'A-', 2)
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'A+', 1)
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'AB-', 0)
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'AB+', 0)
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'B-', 2)
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'B+', 4)
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'O-', 0)
INSERT [dbo].[tblBloodStock] ([bloodGroup], [bloodStock]) VALUES (N'O+', 2)
GO
SET IDENTITY_INSERT [dbo].[tblDonors] ON 

INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (501, N'Shahidur Rahman', 65, N'Male', N'A+', N'01917617658', N'Joypara, Dohar', CAST(N'2021-05-24T15:39:09.000' AS DateTime), N'Blood_Bank_MS_Donor_729.jpeg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (502, N'Zohra Juwariyah', 18, N'Female', N'AB-', N'01917865432', N'Chittagong', CAST(N'2021-05-24T21:38:33.000' AS DateTime), N'Blood_Bank_MS_Donor_406.JPG')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (503, N'Sharmin Sultana ', 29, N'Female', N'B+', N'01918681861', N'Shukrabad, Dhaka', CAST(N'2021-04-25T21:05:58.000' AS DateTime), N'Blood_Bank_MS_Donor_95.jpg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (504, N'Shanta Islam', 31, N'Female', N'O+', N'01714452238', N'Nababgong', CAST(N'2021-07-19T13:49:07.000' AS DateTime), N'Blood_Bank_MS_Donor_109.png')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (505, N'Monika Mostafa', 32, N'Female', N'B-', N'01817637989', N'Chittagong', CAST(N'2021-05-25T10:59:06.000' AS DateTime), N'Blood_Bank_MS_Donor_994.jpg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (506, N'Md. Mahbubur Rahman', 64, N'Male', N'AB+', N'01716157871', N'Narisha, Dohar', CAST(N'2021-04-08T21:12:19.000' AS DateTime), N'Blood_Bank_MS_Donor_678.jpg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (507, N'Mahbuba Mimi', 24, N'Female', N'O-', N'01718165431', N'Khulna', CAST(N'2021-05-25T14:03:05.000' AS DateTime), N'Blood_Bank_MS_Donor_882.jpg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (508, N'Arikh Rahman', 18, N'Male', N'A-', N'01819189018', N'Joypara', CAST(N'2021-05-24T21:18:51.713' AS DateTime), N'Blood_Bank_MS_Donor_375.jpg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (509, N'Rahim Mia', 27, N'Male', N'O+', N'01872653478', N'Comilla, Gouripur', CAST(N'2021-05-24T21:22:55.000' AS DateTime), N'Blood_Bank_MS_Donor_807.jpg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (510, N'Nazrul Islam', 30, N'Male', N'O-', N'01718176541', N'Barishal', CAST(N'2021-05-24T21:26:20.000' AS DateTime), N'Blood_Bank_MS_Donor_609.jpg')
INSERT [dbo].[tblDonors] ([donorId], [donorName], [age], [gender], [bloodGroup], [contactNo], [address], [lastDonationDate], [imageName]) VALUES (511, N'Hasibul Hasan', 25, N'Male', N'A+', N'01910198109', N'Jatrabari', CAST(N'2021-05-24T21:27:02.900' AS DateTime), N'Blood_Bank_MS_Donor_96.jpg')
SET IDENTITY_INSERT [dbo].[tblDonors] OFF
GO
SET IDENTITY_INSERT [dbo].[tblPatients] ON 

INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (101, N'Khushi Kumari Gupta', 25, N'Female', N'O+', 1, CAST(N'2021-05-24T15:41:13.573' AS DateTime), N'01897654323', N'Central Hospital')
INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (102, N'Jalal Uddin', 50, N'Male', N'AB-', 2, CAST(N'2021-05-24T18:53:31.827' AS DateTime), N'01717153488', N'LabAid Hospital')
INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (103, N'Md. Jahangir', 30, N'Male', N'B-', 1, CAST(N'2021-05-24T18:55:14.203' AS DateTime), N'01918781861', N'Dhaka Medical')
INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (104, N'Anarkali Putul', 26, N'Female', N'A+', 1, CAST(N'2021-05-24T18:56:53.570' AS DateTime), N'01817167891', N'Ad-Din Hospital')
INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (105, N'Aman Ali Shah', 25, N'Male', N'O-', 1, CAST(N'2021-05-24T18:57:48.000' AS DateTime), N'01817165161', N'Dhaka Medical')
INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (106, N'Arafat Rahman Shohag', 36, N'Male', N'B+', 2, CAST(N'2021-05-24T21:41:00.783' AS DateTime), N'01718896654', N'Dhaka Medical')
INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (107, N'Kabir Ahmed', 35, N'Male', N'A-', 1, CAST(N'2021-05-24T21:42:19.620' AS DateTime), N'01615678765', N'LabAid Hospital')
INSERT [dbo].[tblPatients] ([patientID], [name], [age], [gender], [bloodGroup], [quantity], [caseDate], [contact], [address]) VALUES (108, N'Razu Ahmed', 28, N'Male', N'AB+', 1, CAST(N'2021-05-24T21:43:58.483' AS DateTime), N'01718910081', N'Square Hospital')
SET IDENTITY_INSERT [dbo].[tblPatients] OFF
GO
SET IDENTITY_INSERT [dbo].[tblTransferBlood] ON 

INSERT [dbo].[tblTransferBlood] ([transferId], [patientName], [bloodGroup], [quantity]) VALUES (1001, N'Khushi Kumari Gupta', N'O+', 1)
INSERT [dbo].[tblTransferBlood] ([transferId], [patientName], [bloodGroup], [quantity]) VALUES (1002, N'Md. Jahangir', N'B-', 1)
INSERT [dbo].[tblTransferBlood] ([transferId], [patientName], [bloodGroup], [quantity]) VALUES (1003, N'Aman Ali Shah', N'O-', 1)
INSERT [dbo].[tblTransferBlood] ([transferId], [patientName], [bloodGroup], [quantity]) VALUES (1004, N'Razu Ahmed', N'AB+', 1)
INSERT [dbo].[tblTransferBlood] ([transferId], [patientName], [bloodGroup], [quantity]) VALUES (1005, N'Jalal Uddin', N'AB-', 2)
INSERT [dbo].[tblTransferBlood] ([transferId], [patientName], [bloodGroup], [quantity]) VALUES (1006, N'Aman Ali Shah', N'O-', 1)
INSERT [dbo].[tblTransferBlood] ([transferId], [patientName], [bloodGroup], [quantity]) VALUES (1007, N'Anarkali Putul', N'A+', 1)
SET IDENTITY_INSERT [dbo].[tblTransferBlood] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUsers] ON 

INSERT [dbo].[tblUsers] ([userId], [username], [email], [password], [fullName], [contact], [address], [addedDate], [imageName]) VALUES (1109, N'borna', N'borna@gmail.com', N'1234', N'Borna', N'01918171615', N'Dhaka', CAST(N'2021-07-19T17:22:02.213' AS DateTime), N'D:\IsDB BISEW\Projects\Final_Project_ADO\ADO_Project_BBMS\BloodBankManagementSystem\BloodBankManagementSystem\Images\07-19-2021-17-22.jpg')
INSERT [dbo].[tblUsers] ([userId], [username], [email], [password], [fullName], [contact], [address], [addedDate], [imageName]) VALUES (1117, N'zohra', N'zj@gmail.com', N'1234', N'Zohra Juwariyah', N'01918171615', N'CTG', CAST(N'2021-07-19T19:03:46.713' AS DateTime), N'D:\IsDB BISEW\Projects\Final_Project_ADO\ADO_Project_BBMS\BloodBankManagementSystem\BloodBankManagementSystem\Images\07-19-2021-19-03.jpg')
INSERT [dbo].[tblUsers] ([userId], [username], [email], [password], [fullName], [contact], [address], [addedDate], [imageName]) VALUES (1118, N'liton', N'liton@gmail.com', N'1234', N'Jahangir Alam', N'01716151412', N'CTG', CAST(N'2021-07-19T19:04:55.240' AS DateTime), N'D:\IsDB BISEW\Projects\Final_Project_ADO\ADO_Project_BBMS\BloodBankManagementSystem\BloodBankManagementSystem\Images\07-19-2021-19-04.jpg')
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [unique_constraint]    Script Date: 7/19/2021 7:16:26 PM ******/
ALTER TABLE [dbo].[tblUsers] ADD  CONSTRAINT [unique_constraint] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BloodBankManagementSystem] SET  READ_WRITE 
GO
