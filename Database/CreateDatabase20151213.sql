USE [master]
GO

/****** Object:  Database [AngkorColorEcommerce]    Script Date: 12/13/2015 4:07:12 PM ******/
CREATE DATABASE [AngkorColorEcommerce]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AngkorColorEcommerce', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\AngkorColorEcommerce.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AngkorColorEcommerce_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\AngkorColorEcommerce_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [AngkorColorEcommerce] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AngkorColorEcommerce].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AngkorColorEcommerce] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET ARITHABORT OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [AngkorColorEcommerce] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AngkorColorEcommerce] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AngkorColorEcommerce] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AngkorColorEcommerce] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AngkorColorEcommerce] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET RECOVERY FULL 
GO

ALTER DATABASE [AngkorColorEcommerce] SET  MULTI_USER 
GO

ALTER DATABASE [AngkorColorEcommerce] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AngkorColorEcommerce] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AngkorColorEcommerce] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [AngkorColorEcommerce] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [AngkorColorEcommerce] SET  READ_WRITE 
GO


