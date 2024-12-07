CREATE Database VanPhongPham
GO
Use VanPhongPham
Go

CREATE TABLE [Account] (
  [AccountId] int PRIMARY KEY IDENTITY(1, 1),
  [AccountName] nvarchar(100),
  [Role] nvarchar(100),
  [Username] varchar(50),
  [Password] varchar(100),
  [Email] varchar(100),
  [Phone] varchar(100)
)
GO

CREATE TABLE [Product] (
  [ProductId] int PRIMARY KEY IDENTITY(1, 1),
  [ProductName] nvarchar(100),
  [Description] nvarchar(200),
  [Price] Decimal,
  [Unit] nvarchar(100),
  [ImgUrl] varchar(100),
  [CategoryId] int
)
GO

CREATE TABLE [Category] (
  [CategoryId] int PRIMARY KEY IDENTITY(1, 1),
  [CategoryName] nvarchar(100)
)
GO

CREATE TABLE [Inventory] (
  [InventoryId] int PRIMARY KEY IDENTITY(1, 1),
  [ProductId] int,
  [Quantity] int
)
GO

CREATE TABLE [Order] (
  [OrderId] int PRIMARY KEY IDENTITY(1, 1),
  [AccountId] int,
  [CreateDate] date,
  [Total] Decimal,
  [PaymentId] int
)
GO

CREATE TABLE [OrderDetail] (
  [OrderDetailId] int PRIMARY KEY IDENTITY(1, 1),
  [ProductId] int,
  [Quantity] int,
  [Total] Decimal,
  [OrderId] int,
  [Status] Bit
)
GO

CREATE TABLE [Payment] (
  [PaymentId] int PRIMARY KEY IDENTITY(1, 1),
  [PaymentMethod] nvarchar(100)
)
GO

ALTER TABLE [Order] ADD FOREIGN KEY ([AccountId]) REFERENCES [Account] ([AccountId])
GO

ALTER TABLE [OrderDetail] ADD FOREIGN KEY ([OrderId]) REFERENCES [Order] ([OrderId])
GO

ALTER TABLE [OrderDetail] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId])
GO

--ALTER TABLE [Inventory] ADD FOREIGN KEY ([ProductId]) REFERENCES [OrderDetail] ([ProductId])
--GO
-- Tạo lại ràng buộc khóa ngoại giữa Inventory và Product (chính xác hơn)
ALTER TABLE [Inventory] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]);
GO
ALTER TABLE [Order] ADD FOREIGN KEY ([PaymentId]) REFERENCES [Payment] ([PaymentId])
GO

INSERT INTO [Account] ([AccountName], [Role], [Username], [Password], [Email], [Phone]) VALUES
('Jerry Nguyen', 'admin', 'huyfin',CONVERT(VARCHAR(40), HASHBYTES('SHA1', '12345'), 2), 'huyfin2004@gmail.com', '0123456789'),
('Huyen Panda', 'staff', 'huyentrinh', CONVERT(VARCHAR(40), HASHBYTES('SHA1', '12345'), 2), 'jane.smith@example.com', '0987654321'),
('Nhan vien A', 'staff', 'staff111', CONVERT(VARCHAR(40), HASHBYTES('SHA1', '123456'), 2), 'robert.brown@example.com', '1122334455'),
('Nhan vien B', 'staff', 'emilywhite', CONVERT(VARCHAR(40), HASHBYTES('SHA1', '123457'), 2), 'emily.white@example.com', '2233445566'),
('Nhan vien C', 'staff', 'hihi', CONVERT(VARCHAR(40), HASHBYTES('SHA1', 'hihi'), 2), 'michael.green@example.com', '6677889900');


INSERT INTO [Category] ([CategoryName]) VALUES
(N'Bút'),
(N'Vở'),
(N'Đồ dùng văn phòng'),
(N'Dụng cụ học tập'),
(N'Máy tính'),
(N'Giấy'),
(N'Sổ');

INSERT INTO [Product] ([ProductName], [Description], [Price], [Unit], [ImgUrl], [CategoryId]) VALUES
(N'Bút bi', 'Blue ballpoint pen', 2, N'Chiếc', 'butbi.jpg', 1),
(N'Bút chì', 'abcccccccc', 1.5, N'Chiếc', 'butchi.jpg', 1),
(N'Vở ô ly kẻ ngang', 'Ergonomic office book', 2.5, N'Quyển', 'voolykengang.jpg', 2),
(N'Kẹp giấy - Kẹp bướm', 'aaaaaaaaaaaaaaa', 0.5, N'Cái', 'kepgiay.jpg', 3),
(N'Giấy kiểm tra', '500 sheets of A4 printer paper', 0.2, N'Tờ', 'giaykiemtra.jpg', 4),
(N'Bút viết bảng trắng', 'Set of 4 colored whiteboard markers', 3.5, N'Chiếc', 'butvietbangtrang.jpg', 1),
(N'Bàn làm việc trắng', 'Wooden desk organizer', 29.99, N'Cái', 'banlamviectrang.jpg', 3),
(N'Casio', 'Casio', 12.99, N'Cái', 'casio.jpg', 5),
(N'Máy đánh fax', 'High-speed fax machine', 109.9, N'Cái', 'maydanhfax.jpg', 3),
(N'Sổ giáo án', 'Siêu dày thơm , trắng', 5.99, N'Cuốn', 'sogiaoan.jpg', 7),
(N'Giấy photo', 'bbbbbbbbbbbbbb', 9.99, N'Tệp', 'giayphoto.jpg', 6),
(N'Tẩy', 'abccbcbcbc', 0.99, N'Cái', 'tay.jpg', 4),
(N'Máy chiếu', 'HD Projector for presentations', 249.99, N'Cái', 'maychieu.jpg', 3),
(N'Máy bấm ghim', 'Heavy-duty stapler', 8.99, N'Chiếc', 'maybamghim.jpg', 3),
(N'Máy hủy tài liệu', 'Paper shredder for office use', 59.99, N'Chiếc', 'mayhuytailieu.jpg', 3);


INSERT INTO [Inventory] ([ProductId], [Quantity]) VALUES
(1, 100),
(2, 50),
(3, 25),
(4, 10),
(5, 40),
(6, 50),
(8, 100),
(9, 30),
(12, 70),
(10, 200);


INSERT INTO [Payment] ([PaymentMethod]) VALUES
('Credit Card'),
('PayPal'),
('Bank Transfer'),
('Cash');

INSERT INTO [Order] ([AccountId], [CreateDate], [Total], [PaymentId]) VALUES
(1, '2024-10-10', 79.99, 1),
(2, '2024-11-22', 25.99, 2),
(3, '2024-9-03', 149.99, 3),
(4, '2024-7-04', 799.99, 4),
(5, '2024-11-25', 60.99, 1);


INSERT INTO [OrderDetail] ([ProductId], [Quantity], [Total], [OrderId], [Status]) VALUES
(1, 5, 9.95, 1, 1),
(2, 2, 6.98, 1, 1),
(3, 1, 149.99, 2, 1),
(4, 1, 799.99, 2, 1),
(5, 10, 59.90, 2, 1),
(6, 3, 5.97, 3, 0),
(7, 1, 3.49, 3, 0),
(8, 1, 149.99, 4, 1),
(1, 2, 1599.98, 4, 0),
(2, 5, 29.95, 5, 1),
(1, 7, 13.93, 5, 0),
(2, 4, 13.96, 5, 0),
(12, 2, 299.98, 1, 1),
(10, 3, 2399.97, 3, 1),
(14, 12, 71.88, 5, 1);





ALTER TABLE [Product] ALTER COLUMN [Price] Decimal(12, 2);
ALTER TABLE [Order] ALTER COLUMN [Total] Decimal(12, 2);
ALTER TABLE [OrderDetail] ALTER COLUMN [Total] Decimal(12, 2);


-- Thong ke theo doanh thu theo thang (Order)
SELECT 
    MONTH(CreateDate) AS Month, 
    SUM(Total) AS Revenue
FROM [Order]
GROUP BY MONTH(CreateDate)
ORDER BY Month;

-- Thong ke theo % san pham ban chay nhat (OrderDetail)
WITH ProductSales AS (
    SELECT 
        p.ProductName, 
        SUM(od.Quantity) AS TotalQuantity
    FROM 
        OrderDetail od
    INNER JOIN 
        Product p ON od.ProductId = p.ProductId
    GROUP BY 
        p.ProductName
), RankedProducts AS (
    SELECT 
        ProductName, 
        TotalQuantity,
        ROW_NUMBER() OVER (ORDER BY TotalQuantity DESC) AS Rank
    FROM 
        ProductSales
)
SELECT 
    CASE 
        WHEN Rank <= 5 THEN ProductName
        ELSE 'Other'
    END AS ProductGroup,
    SUM(TotalQuantity) AS TotalQuantity
FROM 
    RankedProducts
GROUP BY 
    CASE 
        WHEN Rank <= 5 THEN ProductName
        ELSE 'Other'
    END;

	Select * from Account 
	Select * from [Order]
	SELECT * FROM OrderDetail WHERE OrderId = 21 AND OrderDetailId = 
