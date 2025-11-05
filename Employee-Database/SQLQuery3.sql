USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05/11/2025 8:25:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 05/11/2025 8:25:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251104150636_initial migration', N'9.0.10')
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [CreatedDate]) VALUES (1, N'santhosh', N'os', N'sdf@gmail.com', CAST(N'2025-11-04' AS Date), 0, CAST(N'2025-11-04T23:40:24.6236282' AS DateTime2))
GO
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email], [DateOfBirth], [IsActive], [CreatedDate]) VALUES (2, N'Naveenkumar', N'sdf', N'sdf@gmail.com', CAST(N'2025-11-05' AS Date), 1, CAST(N'2025-11-05T12:38:46.4842996' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
