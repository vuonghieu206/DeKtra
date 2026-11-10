/* Database QLHangHoa - SQL Server Express. Chạy trong SSMS. */
IF DB_ID(N'QLHangHoa') IS NULL CREATE DATABASE QLHangHoa;
GO
USE QLHangHoa;
GO
IF OBJECT_ID(N'dbo.LoaiHang', N'U') IS NULL
BEGIN
 CREATE TABLE dbo.LoaiHang (MaLoai INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_LoaiHang PRIMARY KEY, TenLoai NVARCHAR(50) NOT NULL);
END
GO
IF OBJECT_ID(N'dbo.HangHoa', N'U') IS NULL
BEGIN
 CREATE TABLE dbo.HangHoa (
  MaHang INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HangHoa PRIMARY KEY,
  MaLoai INT NOT NULL, TenHang NVARCHAR(50) NOT NULL, Gia NUMERIC(18,0) NULL, Anh NVARCHAR(100) NULL,
  CONSTRAINT FK_HangHoa_LoaiHang FOREIGN KEY (MaLoai) REFERENCES dbo.LoaiHang(MaLoai));
END
GO
IF OBJECT_ID(N'dbo.tblAccount', N'U') IS NULL
BEGIN
 CREATE TABLE dbo.tblAccount (Uid INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_tblAccount PRIMARY KEY, Username NCHAR(10) NULL, Password NCHAR(10) NULL);
END
GO
IF NOT EXISTS (SELECT 1 FROM dbo.LoaiHang)
BEGIN
 SET IDENTITY_INSERT dbo.LoaiHang ON;
 INSERT dbo.LoaiHang (MaLoai, TenLoai) VALUES (1,N'Điện thoại'),(2,N'Máy tính'),(3,N'Ti vi'),(4,N'Tủ lạnh'),(5,N'Phụ kiện');
 SET IDENTITY_INSERT dbo.LoaiHang OFF;
END
GO
IF NOT EXISTS (SELECT 1 FROM dbo.HangHoa)
BEGIN
 SET IDENTITY_INSERT dbo.HangHoa ON;
 INSERT dbo.HangHoa (MaHang,MaLoai,TenHang,Gia,Anh) VALUES
 (1,1,N'Samsung J8',1000,N'Img_1.jpg'),(2,1,N'Iphone 8',2000,N'Img_2.jpg'),(3,1,N'Nokia 8',1500,N'Img_3.jpg'),
 (4,2,N'Dell xps',2500,N'Img_4.jpg'),(5,2,N'Sony SVT',2000,N'Img_5.jpg'),(6,3,N'Sony S1393',1800,N'Img_6.jpg'),
 (7,3,N'Hang moi',1000,N'Img_1.jpg'),(8,3,N'ghjk',1500,N'Img_2.jpg'),(9,1,N'Hang moi',1200,N'Img_3.jpg'),
 (10,1,N'xxxx',1400,N'Img_4.jpg'),(16,2,N'akjdf;lakj',1200,N'Img_5.jpg'),(23,5,N'Ốp điện thoại',100,N'Img_1.jpg'),
 (24,1,N'Hang moi',150,N'Img_2.jpg'),(25,1,N'Honda',NULL,N'Img_1.jpg');
 SET IDENTITY_INSERT dbo.HangHoa OFF;
END
GO
IF NOT EXISTS (SELECT 1 FROM dbo.tblAccount) INSERT dbo.tblAccount (Username,Password) VALUES (N'dzlm',N'123456'),(N'abc',N'123456');
GO
SELECT * FROM dbo.LoaiHang ORDER BY MaLoai;
SELECT * FROM dbo.HangHoa ORDER BY MaHang;
