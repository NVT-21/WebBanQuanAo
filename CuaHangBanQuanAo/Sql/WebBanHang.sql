--web cua hang ban quan ao 
create database WebBanQuanAo
use WebBanQuanAo
CREATE TABLE SanPham (
    MaSp nvarchar(10) PRIMARY KEY,
    TenSp VARCHAR(255),
    GiaBan int,
	mota nvarchar(100),
    Anh	ntext
);

CREATE TABLE KhachHang (
    MaKH NVARCHAR(10) PRIMARY KEY,
    TenKH VARCHAR(255),
    NgaySinh DATE,
    SDT VARCHAR(15),
    Anh NTEXT,
    MaTk NVARCHAR(10),
    FOREIGN KEY (MaTk) REFERENCES TaiKhoan (MaTk)
);
CREATE TABLE NhanVien (
    MaNV NVARCHAR(10) PRIMARY KEY,
    TenNV VARCHAR(255),
    NgaySinh DATE,
    SDT VARCHAR(15),
	 ChucVu nvarchar(15),
    Anh NTEXT,
    MaTk NVARCHAR(10),
    FOREIGN KEY (MaTk) REFERENCES TaiKhoan (MaTk)
);

CREATE TABLE TaiKhoan (
    MaTk nvarchar(10) PRIMARY KEY,
    tk nVARCHAR(255) unique,
    MatKhau nVARCHAR(255),
	VaiTro nvarchar(30)
);
use WebBanQuanAo
INSERT INTO SanPham(MaSp, TenSp, GiaBan,MoTa,Anh,Loai)
VALUES ('SpN01', N'Áo thun kos', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','men-06.jpg','men');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpN02', N'Áo thun lox', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','men-07.jpg','men');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpN04', N'Sơ thun nam', 200000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','men-04.jpg','men');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpN05', N'Áo phông ks', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','men-05.jpg','men');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpNu01', N'Áo phông nomo', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-09.jpg','women');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpNu02', N'Áo phông mos', 200000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-10.jpg','women');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpNu03', N'Áo thun mos', 200000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-11.jpg','women');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpNu04', N'áo thun ', 200000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-12.jpg','women');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpN05', N'Áo cooma', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-05.jpg','women');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpN06', N'Áo thun mas', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-06.jpg','women');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpN07', N'Áo thun ks', 250000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-07.jpg','women');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpN08', N'Áo thun koka', 350000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','women-08.jpg','women');


INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpK01', N'Áo mons ', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','kid-08.jpg','Kid');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpK02', N'Áo phông ', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','kid-06.jpg','Kid');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpK03', N'set áo ', 200000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','kid-07.jpg','Kid');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpK04', N'áo thu đông hama ', 200000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','kid-04.jpg','Kid');
INSERT INTO SanPham(MaSp, TenSp, GiaBan, MoTa,Anh,Loai)
VALUES ('SpK05', N'Áo bò hàn', 300000, N'Sản phẩm khi mặc tạo cảm giác dễ chịu ','kid-05.jpg','Kid');




INSERT INTO TaiKhoan (MaTK, tk, MatKhau,VaiTro)
VALUES ('TK01', 'Admin', '123456','admin');
INSERT INTO TaiKhoan (MaTK, tk, MatKhau,VaiTro)
VALUES ('TK02', 'toan1', '123456','Kh');



