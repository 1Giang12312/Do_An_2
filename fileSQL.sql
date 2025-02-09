USE [master]
GO
/****** Object:  Database [QLBanSua]    Script Date: 5/18/2022 7:46:08 PM ******/
CREATE DATABASE [QLBanSua]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBanSua', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLBanSua.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLBanSua_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLBanSua_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLBanSua] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBanSua].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBanSua] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBanSua] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBanSua] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBanSua] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBanSua] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBanSua] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLBanSua] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBanSua] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBanSua] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBanSua] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBanSua] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBanSua] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBanSua] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBanSua] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBanSua] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLBanSua] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBanSua] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBanSua] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBanSua] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBanSua] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBanSua] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBanSua] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBanSua] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLBanSua] SET  MULTI_USER 
GO
ALTER DATABASE [QLBanSua] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBanSua] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBanSua] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBanSua] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLBanSua] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLBanSua]
GO
/****** Object:  Table [dbo].[TblChiTietHDBanSua]    Script Date: 5/18/2022 7:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblChiTietHDBanSua](
	[MaHDBan] [nvarchar](50) NOT NULL,
	[MaSua] [nchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[GiamGia] [float] NULL,
	[ThanhTien] [float] NOT NULL,
 CONSTRAINT [PK_TblChiTietHDBanSua] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC,
	[MaSua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblHDBanSua]    Script Date: 5/18/2022 7:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHDBanSua](
	[MaHDBan] [nvarchar](50) NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[MaKhachHang] [nchar](10) NOT NULL,
	[TongTien] [float] NOT NULL,
 CONSTRAINT [PK_TblHDBanSua] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblKhachHang]    Script Date: 5/18/2022 7:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblKhachHang](
	[MaKhachHang] [nchar](10) NOT NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[DienThoai] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblKhachHang_1] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblLoaiSua]    Script Date: 5/18/2022 7:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblLoaiSua](
	[MaLoaiSua] [nchar](10) NOT NULL,
	[TenLoaiSua] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblLoaiSua] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblNhanVien]    Script Date: 5/18/2022 7:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblNhanVien](
	[MaNhanVien] [nchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](6) NOT NULL,
	[DiaChi] [nvarchar](500) NOT NULL,
	[DienThoai] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
 CONSTRAINT [PK_TblNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPhanLoai]    Script Date: 5/18/2022 7:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPhanLoai](
	[MaPhanLoai] [nchar](10) NOT NULL,
	[TenPhanLoai] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TblPhanLoai] PRIMARY KEY CLUSTERED 
(
	[MaPhanLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblSua]    Script Date: 5/18/2022 7:46:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblSua](
	[MaSua] [nchar](10) NOT NULL,
	[TenSua] [nvarchar](50) NOT NULL,
	[MaLoaiSua] [nchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGiaNhap] [float] NOT NULL,
	[DonGiaBan] [float] NOT NULL,
	[Anh] [nvarchar](1000) NULL,
	[GhiChu] [nvarchar](200) NULL,
	[HanSuDung] [date] NOT NULL,
	[MaPhanLoai] [nchar](10) NOT NULL,
 CONSTRAINT [PK_TblSua] PRIMARY KEY CLUSTERED 
(
	[MaSua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblTaiKhoan]    Script Date: 5/18/2022 7:46:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTaiKhoan](
	[MaNhanVien] [nchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[QuyenHan] [tinyint] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_220823', N'MS05      ', 1, 37000, 0, 37000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_221359', N'MS05      ', 100, 37000, 50, 1850000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_223209', N'MS05      ', 1, 37000, 0, 37000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_223312', N'MS06      ', 5, 6500, 0, 32500)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_223312', N'MS07      ', 5, 25000, 0, 125000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_223312', N'MS08      ', 1, 40000, 5, 38000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_223410', N'MS04      ', 10, 360000, 0, 3600000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5172022_223410', N'MS06      ', 10, 6500, 0, 65000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5182022_073420', N'MS06      ', 4, 6500, 0, 26000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5182022_092107', N'MS03      ', 2, 500000, 5, 950000)
INSERT [dbo].[TblChiTietHDBanSua] ([MaHDBan], [MaSua], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5182022_092107', N'MS04      ', 1, 360000, 0, 360000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_211916', N'NV02      ', CAST(N'2022-05-17 00:00:00.000' AS DateTime), N'KH04      ', 1270000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_220823', N'NV01      ', CAST(N'2022-05-17 00:00:00.000' AS DateTime), N'KH01      ', 37000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_221006', N'NV01      ', CAST(N'2022-05-17 00:00:00.000' AS DateTime), N'KH04      ', 3920000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_221359', N'NV01      ', CAST(N'2022-05-17 00:00:00.000' AS DateTime), N'KH01      ', 11100000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_221540', N'NV01      ', CAST(N'2022-05-17 00:00:00.000' AS DateTime), N'KH01      ', 1190000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_223209', N'NV01      ', CAST(N'2022-01-02 00:00:00.000' AS DateTime), N'KH01      ', 37000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_223312', N'NV01      ', CAST(N'2022-05-17 00:00:00.000' AS DateTime), N'KH01      ', 195500)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5172022_223410', N'NV01      ', CAST(N'2022-04-11 00:00:00.000' AS DateTime), N'KH01      ', 3665000)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5182022_073420', N'NV06      ', CAST(N'2022-05-18 00:00:00.000' AS DateTime), N'KH04      ', 453500)
INSERT [dbo].[TblHDBanSua] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDB5182022_092107', N'NV02      ', CAST(N'2022-05-18 00:00:00.000' AS DateTime), N'KH01      ', 1310000)
INSERT [dbo].[TblKhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [DienThoai], [Email]) VALUES (N'KH01      ', N'Uyen', N'long xuyên', N'0123456789', N'acv@gmail.com')
INSERT [dbo].[TblKhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [DienThoai], [Email]) VALUES (N'KH02      ', N'12', N'123', N'1231231321', N'a@a.com')
INSERT [dbo].[TblKhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [DienThoai], [Email]) VALUES (N'KH04      ', N'giang vuong', N'Long xiên123', N'0123456789', N'abc@gmail.com')
INSERT [dbo].[TblKhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [DienThoai], [Email]) VALUES (N'KH05      ', N'test', N'test', N'0123456789', N'a@a.com')
INSERT [dbo].[TblLoaiSua] ([MaLoaiSua], [TenLoaiSua]) VALUES (N'MILO      ', N'Milo')
INSERT [dbo].[TblLoaiSua] ([MaLoaiSua], [TenLoaiSua]) VALUES (N'NOTI      ', N'NutriMo')
INSERT [dbo].[TblLoaiSua] ([MaLoaiSua], [TenLoaiSua]) VALUES (N'NUTI      ', N'Nutifood')
INSERT [dbo].[TblLoaiSua] ([MaLoaiSua], [TenLoaiSua]) VALUES (N'test      ', N'test')
INSERT [dbo].[TblLoaiSua] ([MaLoaiSua], [TenLoaiSua]) VALUES (N'THTR      ', N'TH True Milk')
INSERT [dbo].[TblLoaiSua] ([MaLoaiSua], [TenLoaiSua]) VALUES (N'VINA      ', N'Vinamilk')
INSERT [dbo].[TblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [Email], [NgaySinh]) VALUES (N'NV01      ', N'Vương Trường Giang', N'Nam', N'68/5e,MỸ phước DT2', N'0123456789', N'a@a.com', CAST(N'2001-12-22' AS Date))
INSERT [dbo].[TblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [Email], [NgaySinh]) VALUES (N'NV02      ', N'Giang Trường Vương', N'Nam', N'68/5e,MỸ phước DT2', N'0123123123', N'giangvng16@gmail.com', CAST(N'2022-04-04' AS Date))
INSERT [dbo].[TblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [Email], [NgaySinh]) VALUES (N'NV03      ', N'Giang Vương', N'Nữ', N'68/5a My PHuong DT 2', N'1231231231', N'abc@gmail.com', CAST(N'1994-10-18' AS Date))
INSERT [dbo].[TblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [Email], [NgaySinh]) VALUES (N'NV05      ', N'giang vuong', N'Nam', N'Mỹ phước', N'0123456789', N'abc@gmail.com', CAST(N'2022-05-10' AS Date))
INSERT [dbo].[TblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [Email], [NgaySinh]) VALUES (N'NV06      ', N'Pham Ngoc Phuong Uyen', N'Nữ', N'Long Xuyen', N'0123456789', N'abc@gmail.com', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[TblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [Email], [NgaySinh]) VALUES (N'NV07      ', N'test', N'Nam', N'test', N'0123456789', N'a@a.com', CAST(N'2022-05-18' AS Date))
INSERT [dbo].[TblPhanLoai] ([MaPhanLoai], [TenPhanLoai]) VALUES (N'PL01      ', N'Cho người lớn 12 tuổi')
INSERT [dbo].[TblPhanLoai] ([MaPhanLoai], [TenPhanLoai]) VALUES (N'PL02      ', N'cho trẻ em trên 16 tuổi')
INSERT [dbo].[TblPhanLoai] ([MaPhanLoai], [TenPhanLoai]) VALUES (N'PL03      ', N'cho trẻ sơ sinh dưới 6 tuổi')
INSERT [dbo].[TblPhanLoai] ([MaPhanLoai], [TenPhanLoai]) VALUES (N'PL04      ', N'cho mọi lứa tuổi')
INSERT [dbo].[TblPhanLoai] ([MaPhanLoai], [TenPhanLoai]) VALUES (N'PL05      ', N'Sữa dành cho phụ nữ có bầu')
INSERT [dbo].[TblPhanLoai] ([MaPhanLoai], [TenPhanLoai]) VALUES (N'PL06      ', N'Cho phụ nữ')
INSERT [dbo].[TblPhanLoai] ([MaPhanLoai], [TenPhanLoai]) VALUES (N'PL07      ', N'test1')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS01      ', N'test', N'MILO      ', 0, 3500, 4000, N'milo.jpg', N'Sản phẩm đã hết hạn sử dụng!', CAST(N'2020-06-13' AS Date), N'PL02      ')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS02      ', N'Sữa nutrifood', N'NUTI      ', 950, 400000, 450000, N'nuti.jpg', N'', CAST(N'2023-06-13' AS Date), N'PL01      ')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS03      ', N'Sữa hộp TH True Milk', N'THTR      ', 953, 450000, 500000, N'THTM.jpg', N'', CAST(N'2025-07-16' AS Date), N'PL01      ')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS04      ', N'sữa hộp VinaMilk', N'VINA      ', 982, 340000, 360000, N'VMILK01.jpg', N'', CAST(N'2025-07-17' AS Date), N'PL01      ')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS05      ', N'Sữa milo 12 hộp', N'MILO      ', 888, 35000, 37000, N'nuti.jpg', N'', CAST(N'2025-02-01' AS Date), N'PL04      ')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS06      ', N'Vinamilk bịch 220ml', N'VINA      ', 981, 6000, 6500, N'socolabichvina', N'', CAST(N'2026-05-01' AS Date), N'PL04      ')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS07      ', N'VinaMilk hộp 180ml', N'VINA      ', 995, 20000, 25000, N'vina180ml.jpg', N'', CAST(N'2026-04-12' AS Date), N'PL04      ')
INSERT [dbo].[TblSua] ([MaSua], [TenSua], [MaLoaiSua], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu], [HanSuDung], [MaPhanLoai]) VALUES (N'MS08      ', N'VinaMilk Thùng 24 gói', N'VINA      ', 999, 35000, 40000, N'vinathung24goi.jpg', N'', CAST(N'2026-04-12' AS Date), N'PL02      ')
INSERT [dbo].[TblTaiKhoan] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [QuyenHan], [GhiChu]) VALUES (N'NV01      ', N'Vương Trường Giang', N'admin', N'c4ca4238a0b923820dcc509a6f75849b', 1, N'tài khoản admin')
INSERT [dbo].[TblTaiKhoan] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [QuyenHan], [GhiChu]) VALUES (N'NV02      ', N'Giang Trường Vương', N'user', N'c4ca4238a0b923820dcc509a6f75849b', 0, N'tài khoản nhân viên')
INSERT [dbo].[TblTaiKhoan] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [QuyenHan], [GhiChu]) VALUES (N'NV03      ', N'Giang Vương', N'user01', N'c4ca4238a0b923820dcc509a6f75849b', 0, N'đang hoạt động')
INSERT [dbo].[TblTaiKhoan] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [QuyenHan], [GhiChu]) VALUES (N'NV05      ', N'giang vuong', N'user02', N'c4ca4238a0b923820dcc509a6f75849b', 0, N'đang hoạt động')
INSERT [dbo].[TblTaiKhoan] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [QuyenHan], [GhiChu]) VALUES (N'NV06      ', N'Pham Ngoc Phuong Uyen', N'user03', N'c4ca4238a0b923820dcc509a6f75849b', 0, N'123')
ALTER TABLE [dbo].[TblChiTietHDBanSua]  WITH CHECK ADD  CONSTRAINT [FK_TblChiTietHDBanSua_TblHDBanSua] FOREIGN KEY([MaHDBan])
REFERENCES [dbo].[TblHDBanSua] ([MaHDBan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblChiTietHDBanSua] CHECK CONSTRAINT [FK_TblChiTietHDBanSua_TblHDBanSua]
GO
ALTER TABLE [dbo].[TblChiTietHDBanSua]  WITH CHECK ADD  CONSTRAINT [FK_TblChiTietHDBanSua_TblSua] FOREIGN KEY([MaSua])
REFERENCES [dbo].[TblSua] ([MaSua])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblChiTietHDBanSua] CHECK CONSTRAINT [FK_TblChiTietHDBanSua_TblSua]
GO
ALTER TABLE [dbo].[TblHDBanSua]  WITH CHECK ADD  CONSTRAINT [FK_TblHDBanSua_TblKhachHang1] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[TblKhachHang] ([MaKhachHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblHDBanSua] CHECK CONSTRAINT [FK_TblHDBanSua_TblKhachHang1]
GO
ALTER TABLE [dbo].[TblHDBanSua]  WITH CHECK ADD  CONSTRAINT [FK_TblHDBanSua_TblNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[TblNhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblHDBanSua] CHECK CONSTRAINT [FK_TblHDBanSua_TblNhanVien]
GO
ALTER TABLE [dbo].[TblSua]  WITH CHECK ADD  CONSTRAINT [FK_TblSua_TblLoaiSua] FOREIGN KEY([MaLoaiSua])
REFERENCES [dbo].[TblLoaiSua] ([MaLoaiSua])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSua] CHECK CONSTRAINT [FK_TblSua_TblLoaiSua]
GO
ALTER TABLE [dbo].[TblSua]  WITH CHECK ADD  CONSTRAINT [FK_TblSua_TblPhanLoai] FOREIGN KEY([MaPhanLoai])
REFERENCES [dbo].[TblPhanLoai] ([MaPhanLoai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSua] CHECK CONSTRAINT [FK_TblSua_TblPhanLoai]
GO
ALTER TABLE [dbo].[TblTaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TblTaiKhoan_TblNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[TblNhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblTaiKhoan] CHECK CONSTRAINT [FK_TblTaiKhoan_TblNhanVien]
GO
USE [master]
GO
ALTER DATABASE [QLBanSua] SET  READ_WRITE 
GO
