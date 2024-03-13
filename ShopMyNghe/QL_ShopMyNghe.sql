create database SanPham
go

--Danh mục
CREATE TABLE Categories (
    category_id VARCHAR(10) PRIMARY KEY,
    name NVARCHAR(255)
);

--Nguồn gốc
CREATE TABLE Sources (
    source_id VARCHAR(10) PRIMARY KEY,
    name NVARCHAR(255)
);

--Sản phẩm
CREATE TABLE Products (
    product_id  VARCHAR(10) PRIMARY KEY,
    name NVARCHAR(255),
    price DECIMAL(10, 2),
    description NVARCHAR(255),
    Images VARCHAR(MAX),
    category_id VARCHAR(10),
	source_id VARCHAR(10),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id),
	FOREIGN KEY (source_id) REFERENCES Sources(source_id)
);

--Người dùng
CREATE TABLE Users (
    user_id VARCHAR(10) PRIMARY KEY,
    username NVARCHAR(255),
	password VARCHAR(255),
	email VARCHAR(100),
    phone VARCHAR(10),
	address NVARCHAR(255)
);

--Giỏ hàng
CREATE TABLE Carts (
    cart_id VARCHAR(10) PRIMARY KEY,
    created_at DATETIME,
	user_id VARCHAR(10),
	FOREIGN KEY (user_id) REFERENCES Users(user_id),
);

--Chi tiết giỏ hàng
CREATE TABLE Cart_Items (
    item_id VARCHAR(10) PRIMARY KEY,
    cart_id VARCHAR(10),
	product_id VARCHAR(10),
	quantity INT,
	FOREIGN KEY (cart_id) REFERENCES Carts(cart_id),
	FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

--Đơn hàng
CREATE TABLE Orders (
    order_id VARCHAR(10) PRIMARY KEY,
    order_date DATETIME,
	user_id VARCHAR(10),
	totalcost DECIMAL(10, 2),
	FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

--Chi tiết đon hàng
CREATE TABLE Order_Items (
    item_id VARCHAR(10) PRIMARY KEY,
	order_id VARCHAR(10),
	product_id VARCHAR(10),
    quantity INT,
	FOREIGN KEY (order_id) REFERENCES Orders(order_id),
	FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

--========================================ALTER===========================================================


--========================================INSERT==========================================================
INSERT INTO Categories (category_id, name)
VALUES
    ('CAT001', N'Gốm sứ'),
    ('CAT002', N'Chạm khắc'),
    ('CAT003', N'Tranh'),
    ('CAT004', N'Điêu khắc'),
	('CAT005', N'Trang sức'),
    ('CAT006', N'Đồ thủ công');

INSERT INTO Sources (source_id, name)
VALUES
    ('SRC001', N'Thái Lan'),
    ('SRC002', N'Trung Quốc'),
    ('SRC003', N'Nhật Bản'),
    ('SRC004', N'Việt Nam');

-- Thêm dữ liệu vào bảng Products
INSERT INTO Products (product_id, name, price, description, Images, category_id, source_id)
VALUES
    ('PRO001', N'Chậu hoa gốm sứ', 15.99, N'Chậu hoa gốm sứ trang trí', 'image1.jpg', 'CAT001', 'SRC001'),
    ('PRO002', N'Tượng Phật chạm khắc', 29.99, N'Tượng Phật chạm khắc trên gỗ', 'image2.jpg', 'CAT002', 'SRC002'),
    ('PRO003', N'Tranh cảnh đẹp', 49.99, N'Tranh cảnh thiên nhiên đẹp', 'image3.jpg', 'CAT003', 'SRC003'),
    ('PRO004', N'Trangs sức hạt tỳ hưu', 9.99, N'Vòng cổ hạt tỳ hưu may mắn', 'imageN.jpg', 'CAT005', 'SRC004'),
	('PRO021', N'Tượng Đức Phật', 39.99, N'Tượng Đức Phật bằng đá', 'image21.jpg', 'CAT004', 'SRC001'),
    ('PRO022', N'Trangs sức hoa mai', 12.99, N'Vòng cổ hoa mai bạc', 'image22.jpg', 'CAT005', 'SRC002'),
    ('PRO023', N'Bình hoa gốm sứ', 19.99, N'Bình hoa gốm sứ trang trí', 'image23.jpg', 'CAT001', 'SRC003'),
    ('PRO024', N'Tượng chó phong thủy', 9.99, N'Tượng chó phong thủy may mắn', 'image24.jpg', 'CAT006', 'SRC004'),
    ('PRO025', N'Vòng cổ hạt đá', 8.99, N'Vòng cổ hạt đá tự nhiên', 'image25.jpg', 'CAT005', 'SRC003'),
    ('PRO026', N'Tranh cảnh biển', 29.99, N'Tranh cảnh biển hoàng hôn', 'image26.jpg', 'CAT003', 'SRC002'),
    ('PRO027', N'Bình hoa gốm sứ', 14.99, N'Bình hoa gốm sứ trang trí', 'image27.jpg', 'CAT001', 'SRC004'),
    ('PRO028', N'Nến trang trí', 6.99, N'Nến trang trí hình hoa', 'image28.jpg', 'CAT006', 'SRC003'),
    ('PRO029', N'Đồ trang trí gỗ', 24.99, N'Đồ trang trí gỗ tự nhiên', 'image29.jpg', 'CAT006', 'SRC001'),
    ('PRO030', N'Tượng thần tài', 35.99, N'Tượng thần tài bằng đá', 'image30.jpg', 'CAT004', 'SRC002'),
    ('PRO031', N'Vòng cổ hạt tỳ hưu', 11.99, N'Vòng cổ hạt tỳ hưu may mắn', 'image31.jpg', 'CAT005', 'SRC004'),
    ('PRO032', N'Trangs sức ngọc bích', 7.99, N'Vòng cổ ngọc bích', 'image32.jpg', 'CAT005', 'SRC003'),
    ('PRO033', N'Trangs sức đá thạch anh', 9.99, N'Bông tai đá thạch anh', 'image33.jpg', 'CAT005', 'SRC002'),
    ('PRO034', N'Tượng quan âm', 21.99, N'Tượng quan âm bằng gỗ', 'image34.jpg', 'CAT004', 'SRC001'),
    ('PRO035', N'Trangs sức hạt tỳ hưu', 12.99, N'Vòng cổ hạt tỳ hưu đen', 'image35.jpg', 'CAT005', 'SRC004'),
    ('PRO036', N'Trangs sức đá mắt mèo', 8.99, N'Vòng cổ đá mắt mèo', 'image36.jpg', 'CAT005', 'SRC003'),
    ('PRO037', N'Trangs sức đá phong thủy', 6.99, N'Vòng cổ đá phong thủy', 'image37.jpg', 'CAT005', 'SRC002'),
    ('PRO038', N'Tượng đá quan âm', 19.99, N'Tượng quan âm đá màu', 'image38.jpg', 'CAT004', 'SRC001'),
    ('PRO039', N'Nến trang trí hoa', 5.99, N'Nến trang trí hình hoa sen', 'image39.jpg', 'CAT006', 'SRC004'),
    ('PRO040', N'Trangs sức hạt đá tự nhiên', 9.99, N'Vòng cổ hạt đá tự nhiên xanh', 'image40.jpg', 'CAT005', 'SRC003');

-- Thêm dữ liệu vào bảng Users
INSERT INTO Users (user_id, username, password, email, phone, address)
VALUES
    ('USR001', N'Phan Trường Thạnh', 'password1', 'user1@example.com', '1234567890', N'Địa chỉ 1'),
    ('USR002', N'Nguyễn Duy Thịnh', 'password2', 'user2@example.com', '9876543210', N'Địa chỉ 2'),
    ('USR003', N'Thằng Thộn Lìn', 'passwordN', 'user3@example.com', '0123456789', N'Địa chỉ 3');

-- Thêm dữ liệu vào bảng Carts
INSERT INTO Carts (cart_id, created_at, user_id)
VALUES
    ('CAR001', '2023-07-27 10:00:00', 'USR001'),
    ('CAR002', '2023-07-27 14:30:00', 'USR002'),
    ('CAR004', '2023-07-28 09:15:00', 'USR003');

-- Thêm dữ liệu vào bảng Cart_Items
INSERT INTO Cart_Items (item_id, cart_id, product_id, quantity)
VALUES
    ('CAR001', 'CAR001', 'PRO001', 2),
    ('CAI002', 'CAR001', 'PRO002', 1),
    ('CAI003', 'CAR002', 'PRO003', 3),
    ('CAI004', 'CAR004', 'PRO004', 1);

-- Thêm dữ liệu vào bảng Orders
INSERT INTO Orders (order_id, order_date, user_id, totalcost)
VALUES
    ('ORD001', '2023-07-27 15:00:00', 'USR001', 45.97),
    ('ORD002', '2023-07-27 16:30:00', 'USR002', 149.97),
    ('ORD003', '2023-07-28 09:45:00', 'USR003', 9.99);

-- Thêm dữ liệu vào bảng Order_Items
INSERT INTO Order_Items (item_id, order_id, product_id, quantity)
VALUES
    ('ORI001', 'ORD001', 'PRO001', 2),
    ('ORI002', 'ORD001', 'PRO002', 1),
    ('ORI003', 'ORD002', 'PRO003', 3),
    ('ORI004', 'ORD003', 'PRO004', 1);


---------Chú Thích----------
--CAT...: category_id
--SRC...: source_id
--PRO...: product_id
--USR...: user_id
--CAR...: cart_id
--CAI...: item_id (Carts)
--ORD...: order_id
--ORI...: item_id (Orders)
