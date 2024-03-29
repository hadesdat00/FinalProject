USE [master]
GO
/****** Object:  Database [FinalProjectDB]    Script Date: 1/29/2022 1:22:10 PM ******/
CREATE DATABASE [FinalProjectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinalProjectDB', FILENAME = N'C:\D\3_TranTienDat_190521_DoAnTotNghiep_K15CNTT\FinalProject\FinalProjectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FinalProjectDB_log', FILENAME = N'C:\D\3_TranTienDat_190521_DoAnTotNghiep_K15CNTT\FinalProject\FinalProjectDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinalProjectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinalProjectDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FinalProjectDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FinalProjectDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FinalProjectDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FinalProjectDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FinalProjectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FinalProjectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinalProjectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinalProjectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinalProjectDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FinalProjectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FinalProjectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinalProjectDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FinalProjectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinalProjectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FinalProjectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinalProjectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinalProjectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinalProjectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinalProjectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinalProjectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FinalProjectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinalProjectDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FinalProjectDB] SET  MULTI_USER 
GO
ALTER DATABASE [FinalProjectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinalProjectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinalProjectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinalProjectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FinalProjectDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FinalProjectDB]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[CustomerID] [nvarchar](10) NOT NULL,
	[ShipName] [nvarchar](50) NULL,
	[ShipMobile] [nvarchar](10) NULL,
	[ShipAddress] [nvarchar](200) NULL,
	[ShipEmail] [nvarchar](50) NULL,
	[OrderID] [bigint] NULL,
	[MaUser] [nvarchar](10) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoHang]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoHang](
	[MaKho] [nvarchar](10) NOT NULL,
	[TenKho] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](200) NULL,
 CONSTRAINT [PK_KhoHang] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLSP] [nvarchar](10) NOT NULL,
	[TenLSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [nvarchar](10) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](200) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ShipName] [nvarchar](50) NULL,
	[ShipMobile] [nvarchar](10) NULL,
	[ShipAddress] [nvarchar](200) NULL,
	[ShipEmail] [nvarchar](50) NULL,
	[Status] [nvarchar](200) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [bigint] NOT NULL,
	[ProductID] [nvarchar](20) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ProductID] [nvarchar](20) NOT NULL,
	[TenSP] [nvarchar](200) NULL,
	[LoaiSP] [nvarchar](10) NULL,
	[ThuongHieu] [nvarchar](10) NULL,
	[GiaNhap] [decimal](18, 0) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[SoLuong] [bigint] NULL,
	[image] [nvarchar](255) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[MaUser] [nvarchar](10) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[MaGroup] [nvarchar](5) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[MaUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 1/29/2022 1:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[MaGroup] [nvarchar](5) NOT NULL,
	[TenGroup] [nvarchar](10) NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[MaGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhachHang] ([CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [OrderID], [MaUser]) VALUES (N'G0001', N'Trần Đạt', N'0339489228', N'9 Baker Street, NYC', N'hadesdat00@gmail.com', 11, N'USER002')
INSERT [dbo].[KhachHang] ([CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [OrderID], [MaUser]) VALUES (N'G0002', N'Diễn Diễn', N'0192387456', N'10 Brooklyn Street, NY', N'jackkactus69@gmail.com', 11, N'ADMIN001')
GO
INSERT [dbo].[KhoHang] ([MaKho], [TenKho], [SoDienThoai], [DiaChi]) VALUES (N'KHODN', N'Kho Đà Nẵng', N'0339456002', N'40 Ngô Quyền, Quận Sơn Trà, Đà Nẵng')
INSERT [dbo].[KhoHang] ([MaKho], [TenKho], [SoDienThoai], [DiaChi]) VALUES (N'KHOHCM1', N'Kho Hồ Chí Minh 1', N'0339456003', N'270 Điện Biên Phủ, Quận 3, Thành phố Hồ Chí Minh')
INSERT [dbo].[KhoHang] ([MaKho], [TenKho], [SoDienThoai], [DiaChi]) VALUES (N'KHOHCM2', N'Kho Hồ Chí Minh 2', N'0339456004', N'30 Võ Văn Ngân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh')
INSERT [dbo].[KhoHang] ([MaKho], [TenKho], [SoDienThoai], [DiaChi]) VALUES (N'KHOHN', N'Kho Hà Nội', N'0339456001', N'30 Hai Bà Trưng, Quận Hoàn Kiếm, Hà Nội')
GO
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (N'MENS001', N'Giày nam')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (N'WOMENS001', N'Giày nữ')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'ADI001', N'Adidas', N'19002222', N'Herzogenaurach, Germany')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'JOR001', N'Jordan', N'19002981', N'Chicago, United State')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SoDienThoai], [DiaChi]) VALUES (N'NKE001', N'Nike', N'19001111', N'Beaverton, Oregon, United State')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [CreatedDate], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (11, NULL, N'Trần Đạt', N'0339489228', N'9 Baker Street, NYC', N'hadesdat00@gmail.com', N'Chờ xử lý')
INSERT [dbo].[Order] ([OrderID], [CreatedDate], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (12, CAST(N'2021-08-16T15:21:20.497' AS DateTime), N'Trần Đạt', N'0339489228', N'sadsdsadas', N'hadesdat00@gmail.com', N'Chờ xử lý')
INSERT [dbo].[Order] ([OrderID], [CreatedDate], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (13, CAST(N'2021-08-17T08:26:47.453' AS DateTime), N'Trần Đạt', N'0339489228', N'sadsdsadas', N'hadesdat00@gmail.com', N'Chờ xử lý')
INSERT [dbo].[Order] ([OrderID], [CreatedDate], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (14, CAST(N'2021-08-18T00:07:34.917' AS DateTime), N'Trần Đạt', N'0339489228', N'sadsdsadas', N'hadesdat00@gmail.com', N'Chờ xử lý')
INSERT [dbo].[Order] ([OrderID], [CreatedDate], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (15, CAST(N'2021-08-19T09:50:24.483' AS DateTime), N'Trần Đạt', N'0339489228', N'sadsdsadas', N'hadesdat00@gmail.com', N'Chờ xử lý')
INSERT [dbo].[Order] ([OrderID], [CreatedDate], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (16, CAST(N'2022-01-22T16:43:22.613' AS DateTime), N'đạt', N'0339489228', N'23 Brooklyn', N'hadesdat00@gmail.com', N'Chờ xử lý')
INSERT [dbo].[Order] ([OrderID], [CreatedDate], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (17, CAST(N'2022-01-29T13:17:27.210' AS DateTime), N'đạt', N'0339489228', N'23 Brooklyn', N'hadesdat00@gmail.com', N'Chờ xử lý')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (12, N'10001', 1, CAST(518 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (13, N'10001', 2, CAST(518 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (13, N'10003', 1, CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (14, N'10001', 1, CAST(518 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (15, N'10001', 2, CAST(518 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (15, N'10002', 1, CAST(1615 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (15, N'10003', 1, CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (16, N'10001', 1, CAST(518 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (17, N'10001', 2, CAST(518 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (17, N'10002', 1, CAST(1615 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity], [Price]) VALUES (17, N'10004', 1, CAST(435 AS Decimal(18, 0)))
GO
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'10001', N'Giày Air Jordan 1 Retro High OG ''Dark Mocha'' 555088-105', N'MENS001', N'JOR001', CAST(424 AS Decimal(18, 0)), CAST(518 AS Decimal(18, 0)), 20, N'sp10001.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'10002', N'Giày Air Jordan 1 x Off-White Retro High OG ''UNC'' AQ0818-148', N'MENS001', N'JOR001', CAST(1496 AS Decimal(18, 0)), CAST(1615 AS Decimal(18, 0)), 1, N'sp10002.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'10003', N'Giày Air Jordan 5 x Off-White ''Sail'' DH8565-100', N'MENS001', N'JOR001', CAST(450 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)), 2, N'sp10003.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'10004', N'Giày Air Jordan 4 Retro OG ''University Blue'' CT8527-400', N'MENS001', N'JOR001', CAST(297 AS Decimal(18, 0)), CAST(435 AS Decimal(18, 0)), 10, N'sp10004.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'10005', N'Giày Air Jordan 11 Retro UNC ''Win Like 82'' (GS) 378038-123', N'WOMENS001', N'JOR001', CAST(208 AS Decimal(18, 0)), CAST(260 AS Decimal(18, 0)), 1, N'sp10005.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'10006', N'Giày Jordan 3 Retro ''Cool Grey'' (GS) 398614-012', N'WOMENS001', N'JOR001', CAST(124 AS Decimal(18, 0)), CAST(135 AS Decimal(18, 0)), 5, N'sp10006.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'20001', N'Giày Nike Air Max 1 OG ''Anniversary Red''  908375-103', N'MENS001', N'NKE001', CAST(299 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), 17, N'sp20001.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'30002', N'Giày Adidas Ultra Boost 4.0 Bape Camo  F35097', N'MENS001', N'ADI001', CAST(225 AS Decimal(18, 0)), CAST(330 AS Decimal(18, 0)), 5, N'sp30002.jpg')
INSERT [dbo].[SanPham] ([ProductID], [TenSP], [LoaiSP], [ThuongHieu], [GiaNhap], [GiaBan], [SoLuong], [image]) VALUES (N'30003', N'Giày Adidas Yeezy Boost 700 Wave Runner B75571', N'MENS001', N'ADI001', CAST(407 AS Decimal(18, 0)), CAST(422 AS Decimal(18, 0)), 10, N'sp30003.jpg')
GO
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'ADMIN001', N'hadesdat00', N'19032001q', N'1')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'ADMIN002', N'hadesdat01', N'19032001w', N'1')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'STAFF001', N'st001', N'st1', N'2')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'STAFF002', N'st002', N'st2', N'2')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'STAFF003', N'st003', N'st3', N'2')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'STAFF004', N'st004', N'st4', N'2')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'STAFF005', N'st005', N'st5', N'2')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'STAFF006', N'st006', N'st6', N'2')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'USER001', N'anon1', N'1', N'3')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'USER002', N'USER002', N'2', N'3')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'USER003', N'USER003', N'3', N'3')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'USER004', N'USER004', N'4', N'3')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'USER005', N'USER005', N'5', N'3')
INSERT [dbo].[User] ([MaUser], [Username], [password], [MaGroup]) VALUES (N'USER006', N'USER006', N'6', N'3')
GO
INSERT [dbo].[UserGroup] ([MaGroup], [TenGroup]) VALUES (N'1', N'Admin')
INSERT [dbo].[UserGroup] ([MaGroup], [TenGroup]) VALUES (N'2', N'Staff')
INSERT [dbo].[UserGroup] ([MaGroup], [TenGroup]) VALUES (N'3', N'User')
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_Order]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_User] FOREIGN KEY([MaUser])
REFERENCES [dbo].[User] ([MaUser])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_SanPham] FOREIGN KEY([ProductID])
REFERENCES [dbo].[SanPham] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_SanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([LoaiSP])
REFERENCES [dbo].[LoaiSanPham] ([MaLSP])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaCungCap] FOREIGN KEY([ThuongHieu])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaCungCap]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserGroup] FOREIGN KEY([MaGroup])
REFERENCES [dbo].[UserGroup] ([MaGroup])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserGroup]
GO
USE [master]
GO
ALTER DATABASE [FinalProjectDB] SET  READ_WRITE 
GO
