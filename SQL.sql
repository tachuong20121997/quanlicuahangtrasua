CREATE DATABASE QuanLiTraSua
GO
USE QuanLiTraSua
--bàn ăn
CREATE TABLE BanAn
(
	id INT IDENTITY PRIMARY KEY,
	tenban NVARCHAR(100),
	trangthai NVARCHAR(100) DEFAULT N'Trống',--Trống || có người
	banhoatdong NVARCHAR(100) DEFAULT N'Còn'
)
GO
--Tài khoản
CREATE TABLE Account
(
		id INT IDENTITY PRIMARY KEY,
		tenhienthi NVARCHAR(100) NOT NULL,
		tennguoidung NVARCHAR(100) NOT NULL,
		matkhau NVARCHAR(1000) DEFAULT N'0',
		loaitaikhoan INT NOT NULL
)
GO
--Loại trà sữa (foodcatagory)
CREATE TABLE LoaiThucAn
(
	id INT IDENTITY PRIMARY KEY,
	tenloaithucan NVARCHAR(100),
	trangthai NVARCHAR(100) DEFAULT N'Còn'
)
GO
--Thức ăn: nước-->trà sữa, ngược lại là topping (food)
CREATE TABLE ThucAn
(
	id INT IDENTITY PRIMARY KEY,
	tenthucan NVARCHAR(100),
	idloaithucan INT NOT NULL,
	gia FLOAT NOT NULL DEFAULT 0,
	trangthai NVARCHAR(100) DEFAULT N'Còn',
	FOREIGN KEY (idloaithucan) REFERENCES dbo.LoaiThucAn(id)
)
GO
--Hóa đơn (bill)
CREATE TABLE HoaDon
(
	id INT IDENTITY PRIMARY KEY,
	ngayvao	DATE NOT NULL DEFAULT GETDATE(),
	ngayra	DATE,
	idbanan INT NOT NULL,
	thanhtoan INT NOT NULL, --0: chưa thanh toán, 1 thanh toán
	tongtien FLOAT,
	giamgia INT
	FOREIGN KEY (idbanan) REFERENCES dbo.BanAn(id)
)
GO

--Chi tiết hóa đơn (bill info)
CREATE TABLE ChiTietHoaDon
(
	id INT IDENTITY PRIMARY KEY,
	idhoadon INT NOT NULL,
	idthucan INT NOT NULL,
	soluong INT NOT NULL DEFAULT 0
	FOREIGN KEY (idhoadon) REFERENCES dbo.HoaDon(id),
	FOREIGN KEY (idthucan) REFERENCES dbo.ThucAn(id)
)
GO

--tạo store pro đăng nhập
CREATE PROC USP_Accuont
@username nvarchar(100), @password NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE tenhienthi = @username AND matkhau = @password
END
GO
-----tạo store bàn ăn
CREATE PROC USP_Table
AS
BEGIN
	SELECT * FROM dbo.BanAn 
END
GO
EXEC USP_Table

--store thêm chi tiết hóa đơn

CREATE PROC InsertBillInfo
@idhoadon int , @idthucan int , @soluong int
AS
BEGIN
	DECLARE @Exitsidchitiethoadon INT-- kiểm tra id bill có tồn tại hay chưa
	DECLARE @cuont INT --lấy ra số lượng thức ăn hiện tại của chi tiết hóa đơn khi chưa thêm món mới
	DECLARE @dem INT--kiểm tra xem người dùng thêm món hay bỏ món
	
	SELECT @Exitsidchitiethoadon = id, @cuont = soluong
	FROM dbo.ChiTietHoaDon
	WHERE idhoadon = @idhoadon AND idthucan = @idthucan
	
	IF(@Exitsidchitiethoadon > 0)
	BEGIN
		SET @dem = @cuont + @soluong
		IF(@dem > 0)
			UPDATE dbo.ChiTietHoaDon SET soluong = @cuont + @soluong WHERE idhoadon = @idhoadon AND idthucan = @idthucan
		ELSE
			DELETE dbo.ChiTietHoaDon WHERE idhoadon = @idhoadon AND idthucan = @idthucan
	END
	ELSE 
	BEGIN
		INSERT dbo.ChiTietHoaDon
	        ( idhoadon, idthucan, soluong )
		VALUES  ( @idhoadon, -- idhoadon - int
	          @idthucan, -- idthucan - int
	          @soluong  -- soluong - int
	          )
	END
	
END
GO

--tạo proc để chuyển bàn 
--ta cần tạo một bản trung gian để lưu giá trị của idbillinfo của bàn thứ 2
--sau khi chuyển idbillinfo từ bàn 1 -> 2 ta dựa vào id của bảng đc tạo mà chuyển idbillinfo về bàn 1
 
CREATE PROC ChuyenBan
@idtable1 INT, @idtable2 INT
AS
BEGIN
	DECLARE @idbill1 INT
	DECLARE @idbill2 INT
	DECLARE @tableemty1 INT = 1
	DECLARE @tableemty2 INT = 1
	
	SELECT @idbill1 = id FROM dbo.HoaDon WHERE idbanan = @idtable1 AND thanhtoan = 0 
	SELECT @idbill2 = id FROM dbo.HoaDon WHERE idbanan = @idtable2 AND thanhtoan = 0 
	
	IF(@idbill1 IS NULL)--đảm bảo luôn lấy được giá trị id của bàn 1, ko null
	BEGIN
		INSERT dbo.HoaDon
		        ( ngayvao, ngayra, idbanan, thanhtoan )
		VALUES  ( GETDATE(), -- ngayvao - date
		          NULL, -- ngayra - date
		          @idtable1, -- idbanan - int
		          0  -- thanhtoan - int
		          )
		SELECT @idbill1 = MAX(id) FROM dbo.HoaDon WHERE idbanan = @idtable1 AND thanhtoan = 0
	END
	
	SELECT @tableemty1 = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idhoadon = @idbill1
		
	IF(@idbill2 IS NULL)
	BEGIN
		INSERT dbo.HoaDon
		        ( ngayvao, ngayra, idbanan, thanhtoan )
		VALUES  ( GETDATE(), -- ngayvao - date
		          NULL, -- ngayra - date
		          @idtable2, -- idbanan - int
		          0  -- thanhtoan - int
		          )
		SELECT @idbill2 = MAX(id) FROM dbo.HoaDon WHERE idbanan = @idtable2 AND thanhtoan = 0
	END
	
	SELECT @tableemty2 = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idhoadon = @idbill2
	
	SELECT id INTO idbillinfotable FROM dbo.ChiTietHoaDon WHERE idhoadon = @idbill2
	
	--chuyển idbillinfo từ 1- > 2
	UPDATE dbo.ChiTietHoaDon SET idhoadon = @idbill2 WHERE idhoadon = @idbill1
	--chuyển idbillinfo từ 2- > 1
	UPDATE dbo.ChiTietHoaDon SET idhoadon = @idbill1 WHERE id IN (SELECT * FROM idbillinfotable)
	
	DROP TABLE idbillinfotable
	
	IF(@tableemty1 = 0)
		UPDATE dbo.BanAn SET trangthai = N'Trống' WHERE id = @idtable2 AND dbo.BanAn.banhoatdong = N'Còn'
	IF(@tableemty2 = 0)
		UPDATE dbo.BanAn SET trangthai = N'Trống' WHERE id = @idtable1 AND dbo.BanAn.banhoatdong = N'Còn'
END
GO

--store hiển thị danh sách hóa đơn theo ngày vào, ngày ra
CREATE PROC GetListBillByDate
@ngayvao DATE, @ngayra DATE
AS
BEGIN
	SELECT tenban,TongTien,ngayvao,ngayra
	FROM dbo.BanAn, dbo.HoaDon
	WHERE dbo.BanAn.id = dbo.HoaDon.idbanan AND dbo.HoaDon.thanhtoan = 1 
	AND dbo.HoaDon.ngayvao >= @ngayvao AND dbo.HoaDon.ngayra <= @ngayra AND dbo.BanAn.banhoatdong = N'Còn'
END
GO
--store hiển thị danh sách hóa đơn theo ngày vào, ngày ra
CREATE PROC GetListBillByDateReport
@ngayvao DATE, @ngayra DATE
AS
BEGIN
	SELECT tenban, ngayvao, ngayra, giamgia, tongtien
	FROM dbo.HoaDon, dbo.BanAn
	WHERE dbo.HoaDon.idbanan = dbo.BanAn.id AND thanhtoan = 1 
	AND dbo.HoaDon.ngayvao >= @ngayvao AND dbo.HoaDon.ngayra <= @ngayra
END
GO

--store lấy tài khoản bằng username
CREATE PROC GetAccountByUsername
@username nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE tenhienthi = @username
END
GO

--store tạo mật khẩu mới
CREATE PROC UpdateAccount
@username nvarchar(100), @displayname nvarchar(100), @pass1 nvarchar(1000), @pass2 nvarchar(1000)
AS
BEGIN
	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.Account WHERE tenhienthi = @username AND matkhau = @pass1
	IF(@count > 0)
		UPDATE dbo.Account SET matkhau = @pass2, tennguoidung = @displayname WHERE tenhienthi = @username
END
GO

--store hiển thị loại thức ăn theo id
CREATE PROC GetCatagoryById
@idcatagory int
AS 
BEGIN
	SELECT * FROM dbo.LoaiThucAn WHERE id = @idcatagory
END
GO

--tạo trigger để cập nhật trạng thái của bàn có người hay không có người
--có người: khi user thêm hoặc sửa món ăn vào hóa đơn của bàn đó
CREATE TRIGGER BillInfo_CoNguoi
ON dbo.ChiTietHoaDon FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idbill INT
	DECLARE @idtable INT
	
	SELECT @idbill = Inserted.idhoadon FROM Inserted--lấy được id của hóa đơn thêm vào
	
	SELECT @idtable = idbanan --lấy id bàn đang được chọn
	FROM dbo.HoaDon
	WHERE id = @idbill AND thanhtoan = 0
	
	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idhoadon = @idbill 
	
	IF(@count > 0)
	--tiến hành update lại trạng thái cho bàn ấy
		UPDATE dbo.BanAn SET trangthai = N'Có Người' WHERE id = @idtable AND dbo.BanAn.banhoatdong = N'Còn'
	ELSE
		UPDATE dbo.BanAn SET trangthai = N'Trống' WHERE id = @idtable AND dbo.BanAn.banhoatdong = N'Còn'
	
END
GO

--trống: 
CREATE TRIGGER Bill_Trong
ON dbo.HoaDon FOR UPDATE
AS 
BEGIN
	DECLARE @idbill INT
	DECLARE @idtable INT
	DECLARE @count INT = 0
	
	SELECT @idbill = id FROM Inserted --lấy được id của hóa đơn thêm vào
	
	SELECT @idtable = idbanan --lấy id bàn đang được chọn
	FROM dbo.HoaDon
	WHERE id = @idbill
	
	SELECT @count = COUNT(*)
	FROM dbo.HoaDon 
	WHERE idbanan = @idtable AND thanhtoan = 0 
	
	IF(@count = 0)
		UPDATE dbo.BanAn SET trangthai = N'Trống' WHERE id = @idtable AND dbo.BanAn.banhoatdong = N'Còn'
END	
GO
--tạo trigger cho xóa thức ăn, cập nhật tình trạng bàn ăn
--xóa thức ăn => ảnh hưởng đến bảng chitiethoadon
--từ chitiethoadon => id hóa đơn => id bàn ăn => cập nhật tình trạng bàn

CREATE TRIGGER UpdateSatusTableAfterDeleteFood
ON dbo.chitiethoadon FOR delete
AS 
BEGIN
	DECLARE @idbill INT
	DECLARE @idbillinfo INT 
	SELECT @idbillinfo = id, @idbill = deleted.idhoadon FROM deleted
	
	DECLARE @idtable INT
	SELECT @idtable = dbo.HoaDon.idbanan FROM dbo.HoaDon WHERE id = @idbill
	
	DECLARE @count INT = 0
	SELECT  @count = COUNT(*)
	FROM dbo.HoaDon, dbo.ChiTietHoaDon 
	WHERE dbo.HoaDon.id = dbo.ChiTietHoaDon.idhoadon 
	AND dbo.HoaDon.id = @idbill 
	AND dbo.HoaDon.thanhtoan = 0
	
	IF(@count = 0)
	 UPDATE dbo.BanAn SET trangthai = N'Trống' WHERE id = @idtable AND dbo.BanAn.banhoatdong = N'Còn'
END  
GO
--store thêm hóa đơn
CREATE PROC InsertBill
@idbanan int
AS 
BEGIN
	INSERT dbo.HoaDon
	        ( ngayvao ,
	          ngayra ,
	          idbanan ,
	          thanhtoan ,
	          TongTien,
	          giamgia
	        )
	VALUES  ( GETDATE() , -- ngayvao - date
	          NULL , -- ngayra - date
	          @idbanan , -- idbanan - int
	          0 , -- thanhtoan - int
	          0.0,  -- TongTien - float
	          0
	        )
END
GO

--tìm kiếm thức ăn theo tên

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' 
RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) 
DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)
ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') 
RETURN @strInput END

--inset tài khoản adminnistrator
--Set IDENTITY_INSERT dbo.Account ON
INSERT dbo.Account
        ( tenhienthi ,
          tennguoidung ,
          matkhau,
          loaitaikhoan
        )
VALUES  ( N'admin' , -- tenhienthi - nvarchar(100)
          N'chuong' ,
          1, -- tennguoidung - nvarchar(100)
          1-- loaitaikhoan - int
        )
INSERT dbo.Account
        ( tenhienthi ,
          tennguoidung ,
          loaitaikhoan
        )
VALUES  ( N'user' , -- tenhienthi - nvarchar(100)
          N'chuong' , -- tennguoidung - nvarchar(100)
          0-- loaitaikhoan - int
        )             

--tạo loại thức ăn
INSERT dbo.LoaiThucAn
        ( tenloaithucan )
VALUES  ( N'Trà sữa'  -- tenloaithucan - nvarchar(100)
          )

INSERT dbo.LoaiThucAn
        ( tenloaithucan )
VALUES  ( N'Topping'  -- tenloaithucan - nvarchar(100)
          )
          
--tạo bàn ăn
DECLARE  @i INT = 0
WHILE @i <= 9
BEGIN
	INSERT dbo.BanAn(tenban) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END
--tạo thức ăn

INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Trà sữa thái xanh', -- tenthucan - nvarchar(100)
          1, -- idloaithucan - int
		15000  -- gia - float
          )          
INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Trà sữa thái đỏ', -- tenthucan - nvarchar(100)
          1, -- idloaithucan - int
		15000  -- gia - float
          )          
   
INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Sương sáo', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		4000  -- gia - float
          )          
   
INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'flan', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		5000  -- gia - float
          ) 

   
INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Trân châu', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		2000  -- gia - float
          ) 
   
INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Khoai dẻo', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch thập cẩm', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		5000  -- gia - float
          ) 
          
 INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch phô mai', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch trái cây', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch trà xanh', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch trà đỏ', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch sương sáo', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch cafe', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch khóm', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch chanh dây', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch mứt dâu', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
  INSERT dbo.ThucAn
        ( tenthucan, idloaithucan, gia )
VALUES  ( N'Thạch củ năng', -- tenthucan - nvarchar(100)
          2, -- idloaithucan - int
		3000  -- gia - float
          ) 
GO





