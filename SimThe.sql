-- Tạo Cơ Sở Dữ Liệu "SimThe"
CREATE DATABASE SimThe;
GO

-- Chọn cơ sở dữ liệu "SimThe"
USE SimThe;
GO

-- Tạo bảng "Mang" chứa thông tin nhà mạng
CREATE TABLE Mang (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenMang NVARCHAR(50) NOT NULL
);

-- Tạo bảng "Sim" chứa thông tin về số sim
CREATE TABLE Sim (
    ID INT PRIMARY KEY IDENTITY(1,1),
    SoSim NVARCHAR(15) NOT NULL,
    MangID INT FOREIGN KEY REFERENCES Mang(ID),
    NgayKichHoat DATE NOT NULL,
    NgayHetHan DATE
);
GO

-- Thêm một số nhà mạng mẫu vào bảng "Mang"
INSERT INTO Mang (TenMang) VALUES ('Viettel');
INSERT INTO Mang (TenMang) VALUES ('Mobifone');
INSERT INTO Mang (TenMang) VALUES ('Vinaphone');

-- Thêm một số số sim vào bảng "Sim"
INSERT INTO Sim (SoSim, MangID, NgayKichHoat, NgayHetHan) VALUES ('0987654321', 1, '2022-01-01', '2023-01-01');
INSERT INTO Sim (SoSim, MangID, NgayKichHoat, NgayHetHan) VALUES ('0901234567', 2, '2022-02-01', '2023-02-01');
INSERT INTO Sim (SoSim, MangID, NgayKichHoat, NgayHetHan) VALUES ('0912345678', 3, '2022-03-01', '2023-03-01');
GO
