USE [QLThuVien]
GO
/****** Object:  Table [dbo].[QLDocGia]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLDocGia](
	[MaDocGia] [int] NOT NULL,
	[TenDocGia] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[NgayDangKi] [date] NULL,
 CONSTRAINT [PK_QLDocGia] PRIMARY KEY CLUSTERED 
(
	[MaDocGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLNhanVien]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLNhanVien](
	[MaNhanVien] [int] NOT NULL,
	[HoTenNhanVien] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[SoDienThoai] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[CapBac] [nvarchar](50) NULL,
 CONSTRAINT [PK_QLNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLPhieuMuon]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLPhieuMuon](
	[MaPhieuMuon] [int] NOT NULL,
	[MaDocGia] [int] NULL,
	[MaSach] [int] NULL,
	[NgayMuon] [date] NULL,
	[NgayHenTra] [date] NULL,
	[NgayTraThucTe] [date] NULL,
	[TinhTrangMuon] [nvarchar](50) NULL,
	[MucPhat] [int] NULL,
 CONSTRAINT [PK_QLPhieuMuon] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLSach]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLSach](
	[MaSach] [int] NOT NULL,
	[TacGia] [nvarchar](50) NULL,
	[NamXuatBan] [int] NULL,
	[SoTrang] [int] NULL,
	[TenSach] [nvarchar](50) NULL,
	[TheLoai] [nvarchar](50) NULL,
	[NgonNgu] [nvarchar](50) NULL,
	[NhaXuatBan] [nvarchar](50) NULL,
	[SoLuongConLai] [int] NULL,
	[GiaSach] [int] NULL,
 CONSTRAINT [PK_QLSach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLTacGia]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLTacGia](
	[MaTacGia] [int] NOT NULL,
	[TenTacGia] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](50) NULL,
	[SoDienThoai] [int] NULL,
 CONSTRAINT [PK_QLTacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLTheLoai]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLTheLoai](
	[MaTheLoai] [int] NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
	[MoTaNgan] [nvarchar](255) NULL,
	[NgayTao] [date] NULL,
 CONSTRAINT [PK_QLLoaiSach] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThungRacQLDocGia]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThungRacQLDocGia](
	[MaDocGia] [int] NOT NULL,
	[TenDocGia] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[NgayDangKi] [date] NULL,
 CONSTRAINT [PK_ThungRacQLDocGia] PRIMARY KEY CLUSTERED 
(
	[MaDocGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThungRacQLNhanVien]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThungRacQLNhanVien](
	[MaNhanVien] [int] NOT NULL,
	[HoTenNhanVien] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[SoDienThoai] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[CapBac] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThungRacQLNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThungRacQLPhieuMuon]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThungRacQLPhieuMuon](
	[MaPhieuMuon] [int] NOT NULL,
	[MaDocGia] [int] NULL,
	[MaSach] [int] NULL,
	[NgayMuon] [date] NULL,
	[NgayHenTra] [date] NULL,
	[NgayTraThucTe] [date] NULL,
	[TinhTrangMuon] [nvarchar](50) NULL,
	[MucPhat] [int] NULL,
 CONSTRAINT [PK_ThungRacQLPhieuMuon] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThungRacQLSach]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThungRacQLSach](
	[MaSach] [int] NOT NULL,
	[TacGia] [nvarchar](50) NULL,
	[NamXuatBan] [int] NULL,
	[SoTrang] [int] NULL,
	[TenSach] [nvarchar](50) NULL,
	[TheLoai] [nvarchar](50) NULL,
	[NgonNgu] [nvarchar](50) NULL,
	[NhaXuatBan] [nvarchar](50) NULL,
	[SoLuongConLai] [int] NULL,
	[GiaSach] [int] NULL,
 CONSTRAINT [PK_ThungRacQLSach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThungRacQLTacGia]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThungRacQLTacGia](
	[MaTacGia] [int] NOT NULL,
	[TenTacGia] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](50) NULL,
	[SoDienThoai] [int] NULL,
 CONSTRAINT [PK_ThungRacTacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThungRacQLTheLoai]    Script Date: 11/16/2023 7:51:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThungRacQLTheLoai](
	[MaTheLoai] [int] NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
	[MoTaNgan] [nvarchar](255) NULL,
	[NgayTao] [date] NULL,
 CONSTRAINT [PK_ThungRacQLTheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
