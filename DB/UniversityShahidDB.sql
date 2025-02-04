USE [master]
GO
/****** Object:  Database [UniversityManagementSystemDB_Rads]    Script Date: 8/13/2019 12:36:45 AM ******/
CREATE DATABASE [UniversityManagementSystemDB_Rads]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityManagementSystemDB_Rads', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SHAHIDULSQLSERVER\MSSQL\DATA\UniversityManagementSystemDB_Rads.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManagementSystemDB_Rads_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SHAHIDULSQLSERVER\MSSQL\DATA\UniversityManagementSystemDB_Rads_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagementSystemDB_Rads].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityManagementSystemDB_Rads]
GO
/****** Object:  Table [dbo].[AllocateClassroom]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AllocateClassroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[FromTime] [datetime] NULL,
	[ToTime] [datetime] NULL,
	[Action] [varchar](50) NULL,
 CONSTRAINT [PK_AllocateClassroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssignCourse]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssignCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Action] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Assign_Course_to_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [float] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Days]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Days](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Add_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollCourse]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EnrollCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[Action] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Enroll_in_a_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradeLetter]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GradeLetter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_GradeLetter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Month]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Month](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Month] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Result]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
	[Action] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student_Result] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Add_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RegistrationNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Add_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditTaken] [float] NOT NULL,
	[RemainingCredit] [float] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TutionFee]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TutionFee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNumber] [varchar](50) NOT NULL,
	[MonthName] [varchar](50) NOT NULL,
	[Amount] [float] NULL,
	[Fine] [float] NULL,
	[Date] [nchar](10) NOT NULL,
 CONSTRAINT [PK_TutionFee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[AssignCourseView]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AssignCourseView]
AS
SELECT        dbo.Course.Code, dbo.Course.Name, dbo.Semester.Name AS Semester, dbo.Course.DepartmentId, ISNULL(dbo.Teacher.Name, 'Not Assign Yet') AS TeacherName, dbo.AssignCourse.Action
FROM            dbo.AssignCourse RIGHT OUTER JOIN
                         dbo.Course ON dbo.Course.Id = dbo.AssignCourse.CourseId LEFT OUTER JOIN
                         dbo.Semester ON dbo.Course.SemesterId = dbo.Semester.Id LEFT OUTER JOIN
                         dbo.Teacher ON dbo.AssignCourse.TeacherId = dbo.Teacher.Id


GO
/****** Object:  View [dbo].[GetAllClassSheduleView]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetAllClassSheduleView]
AS
SELECT        dbo.Department.Id AS Departmentid, dbo.Course.Id AS CourseId, dbo.Course.Code AS CourseCode, dbo.Course.Name AS CourseName, dbo.Rooms.RoomNumber, dbo.Days.Day, dbo.AllocateClassroom.FromTime, 
                         dbo.AllocateClassroom.ToTime, dbo.AllocateClassroom.Action
FROM            dbo.AllocateClassroom RIGHT OUTER JOIN
                         dbo.Course ON dbo.AllocateClassroom.CourseId = dbo.Course.Id LEFT OUTER JOIN
                         dbo.Rooms ON dbo.AllocateClassroom.RoomId = dbo.Rooms.Id LEFT OUTER JOIN
                         dbo.Days ON dbo.AllocateClassroom.DayId = dbo.Days.Id LEFT OUTER JOIN
                         dbo.Department ON dbo.Course.DepartmentId = dbo.Department.Id


GO
/****** Object:  View [dbo].[GetCourseView]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[GetCourseView] as
select student.Id AS StudentId,Course.Id As CourseId,Course.Name as CourseName from Student right join Course on Course.DepartmentId= Student.DepartmentId  

GO
/****** Object:  View [dbo].[GetDetailsStudentView]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[GetDetailsStudentView] as
select student.Id, Student.Name,Student.Email,Department.Code,Student.RegistrationNumber from Student left join Department on Student.DepartmentId= Department.Id 

GO
/****** Object:  View [dbo].[GetResultView]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create view [dbo].[GetResultView] as

select Student.Id as StudentId,Student.Name as StudentName,Student.Email,Student.RegistrationNumber,Department.Code,Course.Id as CourseId,Course.Name as CourseName from Student right join EnrollCourse on Student.Id = EnrollCourse.StudentId left join Department on Student.DepartmentId =Department.Id left join Course on EnrollCourse.CourseId = Course.Id

GO
/****** Object:  View [dbo].[ResultView]    Script Date: 8/13/2019 12:36:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ResultView]
AS
SELECT        dbo.Student.Id AS StudentId, dbo.Student.Name AS StudentName, dbo.Student.Email, dbo.Student.RegistrationNumber, dbo.Department.Code AS DepartmentCode, dbo.Course.Name AS CourseName, 
                         dbo.Course.Code AS CourseCode, ISNULL(dbo.GradeLetter.Name, 'Not Graded yet') AS Grade
FROM            dbo.Student RIGHT OUTER JOIN
                         dbo.EnrollCourse ON dbo.Student.Id = dbo.EnrollCourse.StudentId LEFT OUTER JOIN
                         dbo.Result ON dbo.EnrollCourse.CourseId = dbo.Result.CourseId LEFT OUTER JOIN
                         dbo.Department ON dbo.Student.DepartmentId = dbo.Department.Id LEFT OUTER JOIN
                         dbo.Course ON dbo.EnrollCourse.CourseId = dbo.Course.Id LEFT OUTER JOIN
                         dbo.GradeLetter ON dbo.Result.GradeId = dbo.GradeLetter.Id

GO
SET IDENTITY_INSERT [dbo].[AllocateClassroom] ON 

INSERT [dbo].[AllocateClassroom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Action]) VALUES (1, 1, 1, 1, 1, CAST(0x0000A96A00A4CB80 AS DateTime), CAST(0x0000A96A00B54640 AS DateTime), N'delete')
SET IDENTITY_INSERT [dbo].[AllocateClassroom] OFF
SET IDENTITY_INSERT [dbo].[AssignCourse] ON 

INSERT [dbo].[AssignCourse] ([Id], [DepartmentId], [TeacherId], [CourseId], [Action]) VALUES (1, 1, 1, 1, N'delete')
SET IDENTITY_INSERT [dbo].[AssignCourse] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1, N'CSE-1101', N'Computer Fundamentals and Applications', 3, N'good', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (2, N'CSE-1102', N'C Programming', 3, N'Langauge', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (3, N'CSE-1103', N'English', 2, N'English', 1, 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Days] ON 

INSERT [dbo].[Days] ([Id], [Day]) VALUES (1, N'Saturday')
INSERT [dbo].[Days] ([Id], [Day]) VALUES (2, N'Sunday')
INSERT [dbo].[Days] ([Id], [Day]) VALUES (3, N'Monday')
INSERT [dbo].[Days] ([Id], [Day]) VALUES (4, N'Tuesday')
INSERT [dbo].[Days] ([Id], [Day]) VALUES (5, N'Wednessday')
INSERT [dbo].[Days] ([Id], [Day]) VALUES (6, N'Thusday')
SET IDENTITY_INSERT [dbo].[Days] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science And Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2, N'ENG', N'English')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Name]) VALUES (2, N'Assitent Profecesor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (3, N'Chairman')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (1, N'Lecturer')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollCourse] ON 

INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [Date], [Action]) VALUES (1, 1, 1, N'29/09/2018', N'Insert')
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [Date], [Action]) VALUES (2, 1, 2, N'02/05/2019', N'Insert')
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [Date], [Action]) VALUES (3, 1, 3, N'02/05/2019', N'Insert')
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [Date], [Action]) VALUES (4, 2, 1, N'02/05/2019', N'Insert')
SET IDENTITY_INSERT [dbo].[EnrollCourse] OFF
SET IDENTITY_INSERT [dbo].[GradeLetter] ON 

INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (1, N'A+')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (2, N'A')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (3, N'A-')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (4, N'B+')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (5, N'B')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (6, N'B-')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (7, N'C+')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (8, N'C')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (9, N'C-')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (10, N'D+')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (11, N'D')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (12, N'D-')
INSERT [dbo].[GradeLetter] ([Id], [Name]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[GradeLetter] OFF
SET IDENTITY_INSERT [dbo].[Month] ON 

INSERT [dbo].[Month] ([Id], [Name]) VALUES (1, N'January')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (2, N'February')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (3, N'March')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (4, N'April')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (5, N'May')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (6, N'June')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (7, N'July')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (8, N'August')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (9, N'September')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (10, N'October')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (11, N'November')
INSERT [dbo].[Month] ([Id], [Name]) VALUES (12, N'December')
SET IDENTITY_INSERT [dbo].[Month] OFF
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Action]) VALUES (1, 1, 1, 1, N'Insert')
SET IDENTITY_INSERT [dbo].[Result] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [RoomNumber]) VALUES (1, N'Room-1')
INSERT [dbo].[Rooms] ([Id], [RoomNumber]) VALUES (2, N'Room-2')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [Name]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNumber]) VALUES (1, N'Shahidul Islam', N'shahidctg50@gmail.com', N'01326569874', N'29/09/2018', N'Halishahar', 1, N'CSE-2018-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNumber]) VALUES (2, N'Dider', N'd@gmail.com', N'01396587421', N'29/09/2018', N'aas', 1, N'CSE-2018-002')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNumber]) VALUES (3, N'Asif', N'jony@gmail.com', N'01396587421', N'29/09/2018', N'asas', 1, N'CSE-2018-003')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNumber]) VALUES (4, N'jony', N'h@gmail.com', N'01326569874', N'28/09/2019', N'asa', 1, N'CSE-2018-004')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNumber]) VALUES (5, N'Subman', N'subman@gmail.com', N'01356454654', N'28/09/2019', N'Unknown', 2, N'BBA-2019-001')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken], [RemainingCredit]) VALUES (1, N'Salauddin Chy', N'Boropol', N'salauddin@gmail.com', N'01326569874', 2, 1, 20, 17)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [IX_Course] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_Department] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_1]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_Department_1] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Designation]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Designation] ADD  CONSTRAINT [IX_Designation] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Semester]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Semester] ADD  CONSTRAINT [IX_Semester] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Add_Student]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [IX_Add_Student] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Add_Student_1]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [IX_Add_Student_1] UNIQUE NONCLUSTERED 
(
	[RegistrationNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teacher]    Script Date: 8/13/2019 12:36:45 AM ******/
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [IX_Teacher] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_Allocate_Classroom_Add_Day] FOREIGN KEY([DayId])
REFERENCES [dbo].[Days] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_Allocate_Classroom_Add_Day]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_Allocate_Classroom_Add_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_Allocate_Classroom_Add_Room]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_Allocate_Classroom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_Allocate_Classroom_Course]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_Allocate_Classroom_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_Allocate_Classroom_Department]
GO
ALTER TABLE [dbo].[AssignCourse]  WITH CHECK ADD  CONSTRAINT [FK_Assign_Course_to_Teacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AssignCourse] CHECK CONSTRAINT [FK_Assign_Course_to_Teacher_Course]
GO
ALTER TABLE [dbo].[AssignCourse]  WITH CHECK ADD  CONSTRAINT [FK_Assign_Course_to_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[AssignCourse] CHECK CONSTRAINT [FK_Assign_Course_to_Teacher_Department]
GO
ALTER TABLE [dbo].[AssignCourse]  WITH CHECK ADD  CONSTRAINT [FK_Assign_Course_to_Teacher_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[AssignCourse] CHECK CONSTRAINT [FK_Assign_Course_to_Teacher_Teacher]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
ALTER TABLE [dbo].[EnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_Enroll_in_a_Course_Add_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourse] CHECK CONSTRAINT [FK_Enroll_in_a_Course_Add_Student]
GO
ALTER TABLE [dbo].[EnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_Enroll_in_a_Course_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourse] CHECK CONSTRAINT [FK_Enroll_in_a_Course_Course]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_GradeLetter] FOREIGN KEY([GradeId])
REFERENCES [dbo].[GradeLetter] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_GradeLetter]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Student_Result_Add_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Student_Result_Add_Student]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Student_Result_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Student_Result_Course]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Add_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Add_Student_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AssignCourse"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Semester"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 234
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Teacher"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AssignCourseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AssignCourseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AllocateClassroom"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Rooms"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 234
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Days"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 234
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 234
               Left = 38
               Bottom = 347
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetAllClassSheduleView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetAllClassSheduleView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GetAllClassSheduleView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[4] 2[37] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Student"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EnrollCourse"
            Begin Extent = 
               Top = 6
               Left = 272
               Bottom = 136
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Result"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 251
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 252
               Left = 246
               Bottom = 382
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GradeLetter"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 366
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ResultView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ResultView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ResultView'
GO
USE [master]
GO
ALTER DATABASE [UniversityManagementSystemDB_Rads] SET  READ_WRITE 
GO
