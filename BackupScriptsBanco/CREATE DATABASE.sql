USE [master]
GO

/****** Object:  Database [BDInventarioOtacom]    Script Date: 25/10/2019 16:18:56 ******/
CREATE DATABASE [BDInventarioOtacom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDInventarioOtacom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BDInventarioOtacom.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BDInventarioOtacom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BDInventarioOtacom_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [BDInventarioOtacom] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDInventarioOtacom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BDInventarioOtacom] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET ARITHABORT OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BDInventarioOtacom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BDInventarioOtacom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BDInventarioOtacom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BDInventarioOtacom] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET RECOVERY FULL 
GO

ALTER DATABASE [BDInventarioOtacom] SET  MULTI_USER 
GO

ALTER DATABASE [BDInventarioOtacom] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BDInventarioOtacom] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BDInventarioOtacom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BDInventarioOtacom] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [BDInventarioOtacom] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BDInventarioOtacom] SET  READ_WRITE 
GO


