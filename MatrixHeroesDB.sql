USE [master]
GO
/****** Object:  Database [MatrixHeroes]    Script Date: 22/03/2021 03:32:38 ******/
CREATE DATABASE [MatrixHeroes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MatrixHeroes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MatrixHeroes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MatrixHeroes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MatrixHeroes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MatrixHeroes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MatrixHeroes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MatrixHeroes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MatrixHeroes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MatrixHeroes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MatrixHeroes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MatrixHeroes] SET ARITHABORT OFF 
GO
ALTER DATABASE [MatrixHeroes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MatrixHeroes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MatrixHeroes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MatrixHeroes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MatrixHeroes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MatrixHeroes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MatrixHeroes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MatrixHeroes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MatrixHeroes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MatrixHeroes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MatrixHeroes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MatrixHeroes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MatrixHeroes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MatrixHeroes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MatrixHeroes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MatrixHeroes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MatrixHeroes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MatrixHeroes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MatrixHeroes] SET  MULTI_USER 
GO
ALTER DATABASE [MatrixHeroes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MatrixHeroes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MatrixHeroes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MatrixHeroes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MatrixHeroes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MatrixHeroes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MatrixHeroes] SET QUERY_STORE = OFF
GO
USE [MatrixHeroes]
GO
/****** Object:  Table [dbo].[Heroes]    Script Date: 22/03/2021 03:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Heroes](
	[HeroId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Ability] [nvarchar](50) NOT NULL,
	[TrainStartDate] [datetime] NULL,
	[SuitColors] [nvarchar](50) NOT NULL,
	[StartingPower] [decimal](18, 2) NOT NULL,
	[CurrentPower] [decimal](18, 2) NOT NULL,
	[TrainerId] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Heroes] PRIMARY KEY CLUSTERED 
(
	[HeroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 22/03/2021 03:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[TrainerId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Salt] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Heroes] ([HeroId], [Name], [Ability], [TrainStartDate], [SuitColors], [StartingPower], [CurrentPower], [TrainerId]) VALUES (N'00000000-0000-0000-0000-000000000000', N'AquaMan', N'defender', CAST(N'2021-03-21T13:30:05.013' AS DateTime), N'red, blue', CAST(2.10 AS Decimal(18, 2)), CAST(5.43 AS Decimal(18, 2)), N'2258e40f-0b3c-411c-9d63-18ca6c36b355')
INSERT [dbo].[Heroes] ([HeroId], [Name], [Ability], [TrainStartDate], [SuitColors], [StartingPower], [CurrentPower], [TrainerId]) VALUES (N'3a8056c3-c618-4fbc-a22d-c665f522c672', N'Ninja Boy', N'attacker', CAST(N'2021-01-08T00:00:00.000' AS DateTime), N'yellow, green', CAST(23.10 AS Decimal(18, 2)), CAST(43.73 AS Decimal(18, 2)), N'82e928b6-1335-4ada-89ac-78e1388c8897')
INSERT [dbo].[Heroes] ([HeroId], [Name], [Ability], [TrainStartDate], [SuitColors], [StartingPower], [CurrentPower], [TrainerId]) VALUES (N'42af6268-b4e5-48f2-8baa-b4bea3c6c01c', N'Eggman', N'defender', CAST(N'2021-03-02T00:00:00.000' AS DateTime), N'red, white', CAST(12.20 AS Decimal(18, 2)), CAST(49.54 AS Decimal(18, 2)), N'14578459-8f93-4576-85c1-ef8cabefd464')
INSERT [dbo].[Heroes] ([HeroId], [Name], [Ability], [TrainStartDate], [SuitColors], [StartingPower], [CurrentPower], [TrainerId]) VALUES (N'7b5131c9-6eed-42a8-a834-1ae1a2dcec6f', N'Eggman', N'defender', CAST(N'2021-03-02T00:00:00.000' AS DateTime), N'red, white', CAST(12.20 AS Decimal(18, 2)), CAST(49.54 AS Decimal(18, 2)), N'14578459-8f93-4576-85c1-ef8cabefd464')
GO
INSERT [dbo].[Trainers] ([TrainerId], [Name], [Username], [Password], [Salt]) VALUES (N'1', N'a', N'b', N'c', N'd')
INSERT [dbo].[Trainers] ([TrainerId], [Name], [Username], [Password], [Salt]) VALUES (N'14578459-8f93-4576-85c1-ef8cabefd464', N'Moshe', N'Moish', N'QzPsE1g71o1duFCnab1x4VPtzVZgSu2HrB5bYQZyoMs=', N'zHWAUVt32Oop4OlK64BJlg==')
INSERT [dbo].[Trainers] ([TrainerId], [Name], [Username], [Password], [Salt]) VALUES (N'2258e40f-0b3c-411c-9d63-18ca6c36b355', N'Shlomi', N'Shalom', N'WtP9NUqDYv9tln/3mjZ8JZ6XILg1+YaRmv89RDg5rAM=', N'Vq92tjXFyMrps42Dp7GhOQ==')
INSERT [dbo].[Trainers] ([TrainerId], [Name], [Username], [Password], [Salt]) VALUES (N'82e928b6-1335-4ada-89ac-78e1388c8897', N'David', N'dave', N'/4sbotT9uB9PbylGqY2lFZr4fih/Am8pXVp/dZbegJE=', N'UkztmAO+bXhEIkZwF+jooQ==')
INSERT [dbo].[Trainers] ([TrainerId], [Name], [Username], [Password], [Salt]) VALUES (N'ajsffbgliahg;oang-fgsogna-vsfva', N'Yosi', N'yossef', N'1234', N'3451526475643')
GO
ALTER TABLE [dbo].[Heroes]  WITH CHECK ADD  CONSTRAINT [FK_Heroes_Trainers] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainers] ([TrainerId])
GO
ALTER TABLE [dbo].[Heroes] CHECK CONSTRAINT [FK_Heroes_Trainers]
GO
USE [master]
GO
ALTER DATABASE [MatrixHeroes] SET  READ_WRITE 
GO
