create database Library_Manager
go
use Library_Manager
go
create table Staff(
	Staff_id char(8) primary key,
	Staff_name nvarchar(60) not null,
	Birthday date not null,
	Sex nvarchar(5) not null,
	Email nvarchar(50) null,
	Phone_no nvarchar(11) not null,
	Addr nvarchar(60) null,
	StartDate date not null,
	Salary char(12) not null
)

go
create table AuthenticationSystem(
	Staff_id char(8),
	Username char(15) primary key,
	Pass_word nvarchar(20) not null
)

go
create table Authors(
	Author_id char(8) primary key,
	Author_name nvarchar(40) not null
)

go
create table Publishers(
	Publisher_id char(8) primary key,
	Publisher_name nvarchar(40) not null, 
	Email nvarchar(40) null, 
	Phone_no nvarchar(11) not null, 
	Addr nvarchar(60) null
)

go
create table Books(
	Book_id char(8) primary key,
	Title nvarchar(60) not null,
	Category nvarchar(20) not null,
	Author_id char(8),
	Publisher_id char(8),
	YearOfPublication int not null,
	Price char(7) not null,
	Quantity int not null
)

go
create table Readers(
	Reader_id char(8) primary key,
	Reader_name nvarchar(50) not null,
	Birthday date not null,
	Sex nvarchar(5) not null,
	Email nvarchar(50) null,
	Phone_no nvarchar(11) not null,
	Addr nvarchar(60) null
)

go
create table Reverse_Return (
	Reg_id char(8) primary key,
	Reader_id char(8),
	Book_id char(8),
	ReserveDate date not null,
	DueDate date not null,
	ReturnDate date not null,
	ReserveStaff_id char(8),
	ReturnStaff_id char(8)
)
go

-- Create data Staff
INSERT INTO dbo.Staff VALUES('NV001', N'Nguyễn Hương Thảo',	'2002-05-15', N'Nữ', 'thaonguyen@gmail.com', '0943502525', N'Linh Xuân, TP.Thủ Đức, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV002', N'Lê Thị Lan Hương', '2002-10-20', N'Nữ', 'lanhuong@gmail.com', '0942182919', N'Phạm Ngũ Lão, Quận 1, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV003', N'Nguyễn Thanh Bình', '2001-12-06', N'Nam', 'thanhbinh0612@gmail.com', '0866155688', N'Phường 1, Quận Bình Thạnh, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV004', N'Dương Quốc Tuấn', '2002-04-18', N'Nam', 'tuanduong@gmail.com', '0975387583', N'Hiệp Phú, TP.Thủ Đức, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV005', N'Võ Gia Minh', '2002-11-08', N'Nam', 'vogiaminh08@gmail.com', '0978723968', N'Bình Chiểu, TP.Thủ Đức, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV006', N'Nguyễn Bảo Ngọc', '2001-03-09', N'Nữ', 'baongoc2001@gmail.com', '0953350394', N'Nguyễn Cư Trinh, Quận 1, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV007', N'Phạm Diễm Quỳnh', '2001-10-04', N'Nữ', 'quynhpham0410@gmail.com', '0879059971', N'Thạnh Xuân, Quận 12, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV008', N'Đặng Xuân Bách', '2000-05-20', N'Nam', 'bachdang2000@gmail.com', '0853519273', N'Thảo Điền, Quận 2, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV009', N'Nguyễn Phạm Ngọc Duy', '2002-08-13', N'Nam', 'phamngocduy@gmail.com', '0979058640', N'Phường 4, Quận Gò Vấp, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV010', N'Hoàng Diệu Anh', '2001-02-05', N'Nữ', 'hoangdieuanh@gmail.com', '0947034195', N'Phạm Ngũ Lão, Quận 1, TP.HCM', '2022-01-01', '6000000')
INSERT INTO dbo.Staff VALUES('NV011', N'Bùi Nhật Lệ', '2000-04-24', N'Nữ', 'buinhatle@gmail.com', '0848697132', N'Tân Định, Quận 1, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV012', N'Trương Anh Đào', '2001-11-01', N'Nữ', 'truonganhdao@gmail.com', '0879058943', N'Bình Chiểu, TP.Thủ Đức, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV013', N'Đỗ Kim Oanh', '2000-10-20', N'Nữ', 'dokimoanh@gmail.com', '0947024501', N'Phước Bình, TP.Thủ Đức, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV014', N'Trần Thị Diệu Hiền', '2002-03-23', N'Nữ', 'hientran2002@gmail.com', '0879058646', N'Bình Trưng Tây, Quận 2, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV015', N'Đinh Thị Hải Yến', '2001-07-07', N'Nữ', 'haiyen0707@gmail.com', '0852502749', N'Đông Hưng Thuận, Quận 12, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV016', N'Huỳnh Công Hậu', '2001-02-18', N'Nam', 'huynhconghau@gmail.com', '0979058701', N'Thạnh Mỹ Lợi, Quận 2, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV017', N'Nguyễn Ngọc Hoài', '2001-09-09', N'Nam', 'nguyenngochoai@gmail.com', '0946136915', N'Long Thạnh Mỹ, TP.Thủ Đức, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV018', N'Phạm Đinh Quốc Hòa', '2001-05-20', N'Nam', 'quochoa2001@gmail.com', '0979057814', N'Linh Trung, TP.Thủ Đức, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV019', N'Huỳnh Gia Huy', '2000-08-14', N'Nam', 'giahuy2000@gmail.com', '0854526720', N'Thủ Thiêm, Quận 2, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV020', N'Hồ Ngọc Đăng Khoa', '2001-06-28', N'Nam', 'dangkhoaho@gmail.com', '0847054974', N'Tân Phú, TP.Thủ Đức, TP.HCM', '2022-01-15', '7000000')
INSERT INTO dbo.Staff VALUES('NV021', N'Đặng Quế Chi', '2000-05-12', N'Nữ', 'dangquechi@gmail.com', '0952109756', N'Hiệp Thành, Quận 12, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV022', N'Nguyễn Thị Tường Vi', '2001-09-17', N'Nữ', 'nguyentuongvi@gmail.com', '0835105164', N'Trường Thạnh, TP.Thủ Đức, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV023', N'Huỳnh Trương Thùy Vân', '2001-03-16', N'Nữ', 'truongthuyvan@gmail.com', '0979057453', N'Phường 12, Quận Tân Bình, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV024', N'Lê Nguyễn Quỳnh Chi', '2002-10-01', N'Nữ', 'quynhchile@gmail.com', '0879058832', N'Thạnh Xuân, Quận 12, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV025', N'Đỗ Thị Mỹ Lan', '2001-04-22', N'Nữ', 'mylando2001@gmail.com', '0937091496', N'Tân Chánh Hiệp, Quận 12, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV026', N'Lê Đức Long', '2002-01-19', N'Nam', 'leduclong@gmail.com', '0938076349', N'Linh Xuân, TP.Thủ Đức, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV027', N'Văn Hoàng Lương', '2001-04-14', N'Nam', 'hoangluong14@gmail.com', '0834180557', N'Phường 1, Quận Bình Thạnh, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV028', N'Lê Hoàng Minh', '2001-07-25', N'Nam', 'lehoangminh@gmail.com', '0979059367', N'An Lợi Đông, Quận 2, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV029', N'Đinh Quang Thắng', '2000-04-20', N'Nam', 'quangthangdinh@gmail.com', '0837115824', N'Đông Hưng Thuận, Quận 12, TP.HCM', '2022-02-10', '6500000')
INSERT INTO dbo.Staff VALUES('NV030', N'Trần Văn Trọng', '2002-12-08', N'Nam', 'tranvantrong@gmail.com', '0979060854', N'Phường 10, Quận Bình Thạnh, TP.HCM', '2022-02-10', '6500000')

-- Create data AuthenticationSystem
INSERT INTO dbo.AuthenticationSystem VALUES('NV001', 'thuvien001', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV002', 'thuvien002', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV003', 'thuvien003', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV004', 'thuvien004', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV005', 'thuvien005', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV006', 'thuvien006', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV007', 'thuvien007', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV008', 'thuvien008', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV009', 'thuvien009', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV010', 'thuvien010', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV011', 'thuvien011', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV012', 'thuvien012', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV013', 'thuvien013', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV014', 'thuvien014', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV015', 'thuvien015', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV016', 'thuvien016', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV017', 'thuvien017', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV018', 'thuvien018', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV019', 'thuvien019', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV020', 'thuvien020', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV021', 'thuvien021', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV022', 'thuvien022', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV023', 'thuvien023', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV024', 'thuvien024', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV025', 'thuvien025', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV026', 'thuvien026', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV027', 'thuvien027', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV028', 'thuvien028', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV029', 'thuvien029', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV030', 'thuvien030', 'nhanvien')
INSERT INTO dbo.AuthenticationSystem VALUES('NV000', 'admin', 'admin')
-- Create data Authors
INSERT INTO dbo.Authors VALUES('TG001', N'Anh Khang')
INSERT INTO dbo.Authors VALUES('TG002', N'Đặng Hoàng Giang')
INSERT INTO dbo.Authors VALUES('TG003', N'Dưa Hấu Hạt Tím')
INSERT INTO dbo.Authors VALUES('TG004', N'Trần Minh Phương Thảo')
INSERT INTO dbo.Authors VALUES('TG005', N'Nguyễn Ngọc Tư')
INSERT INTO dbo.Authors VALUES('TG006', N'Lưu Đình Long')
INSERT INTO dbo.Authors VALUES('TG007', N'Hà Nhân')
INSERT INTO dbo.Authors VALUES('TG008', N'Hamlet Trương')
INSERT INTO dbo.Authors VALUES('TG009', N'Độc Mộc Châu')
INSERT INTO dbo.Authors VALUES('TG010', N'Paulo Coelho')
INSERT INTO dbo.Authors VALUES('TG011', N'Hae Min')
INSERT INTO dbo.Authors VALUES('TG012', N'Nhất Linh')
INSERT INTO dbo.Authors VALUES('TG013', N'Nicola Yoon')
INSERT INTO dbo.Authors VALUES('TG014', N'Thomas Harris')
INSERT INTO dbo.Authors VALUES('TG015', N'Colleen McCullough')
INSERT INTO dbo.Authors VALUES('TG016', N'Mario Puzo')
INSERT INTO dbo.Authors VALUES('TG017', N'Jeffrey Archer')
INSERT INTO dbo.Authors VALUES('TG018', N'Harper Lee')
INSERT INTO dbo.Authors VALUES('TG019', N'Dương Minh Tuấn')
INSERT INTO dbo.Authors VALUES('TG020', N'Dale Carnegie')
INSERT INTO dbo.Authors VALUES('TG021', N'Og Mandino ')
INSERT INTO dbo.Authors VALUES('TG022', N'Stephen R. Covey')
INSERT INTO dbo.Authors VALUES('TG023', N'Napoleon Hill')
INSERT INTO dbo.Authors VALUES('TG024', N'Anthony Robbins')
INSERT INTO dbo.Authors VALUES('TG025', N'John Gray')
INSERT INTO dbo.Authors VALUES('TG026', N'David J Lieberman')
INSERT INTO dbo.Authors VALUES('TG027', N'Eran Katz')
INSERT INTO dbo.Authors VALUES('TG028', N'David J Schwartz')
INSERT INTO dbo.Authors VALUES('TG029', N'Henri Bergson')
INSERT INTO dbo.Authors VALUES('TG030', N'Nguyễn Thanh Tùng')
INSERT INTO dbo.Authors VALUES('TG031', N'Ngô Thu Hằng')
INSERT INTO dbo.Authors VALUES('TG032', N'YBM')
INSERT INTO dbo.Authors VALUES('TG033', N'David')
INSERT INTO dbo.Authors VALUES('TG034', N'Michael McCarthy')
INSERT INTO dbo.Authors VALUES('TG035', N'Raymond Murphy')
INSERT INTO dbo.Authors VALUES('TG036', N'Mozilge')

-- Create data Publishers
INSERT INTO dbo.Publishers VALUES('NXB001', N'Trẻ', 'hopthubandoc@nxbtre.com.vn', '02839316289', N'161B Lý Chính Thắng, Võ Thị Sáu, Quận 3 , TP.HCM')
INSERT INTO dbo.Publishers VALUES('NXB002', N'Hội nhà văn', 'nxbhoinhavan65@gmail.com', '02438221135', N'65 Nguyễn Du, Hai Bà Trưng, Hà Nội')
INSERT INTO dbo.Publishers VALUES('NXB003', N'Văn Học', 'info@nxbvanhoc.com.vn', '02437161518 ', N'18 Nguyễn Trường T, Ba Đình, Hà Nội')
INSERT INTO dbo.Publishers VALUES('NXB004', N'Hồng Đức', 'nxbhongduc@gmail.com', '02439260024', N'65 Tràng Thi, Hàng Bông, Hoàn Kiếm, Hà Nội')
INSERT INTO dbo.Publishers VALUES('NXB005', N'Thế Giới', 'nxbthegioi@gmail.com', '02438253841', N'7 Nguyễn Thị Minh Khai, Quận 1, TP Hồ Chí Minh')
INSERT INTO dbo.Publishers VALUES('NXB006', N'Thanh Niên', 'chinhanhnxbthanhnien@gmail.com', '0982526569', N'64 Bà Triệu, Hoàn Kiếm, Hà Nội')
INSERT INTO dbo.Publishers VALUES('NXB007', N'Tổng hợp TPHCM', 'tonghop@nxbhcm.com.vn', '02838256804', N'62 Nguyễn Thị Minh Khai, Đa Kao, Quận 1, TPHCM')
INSERT INTO dbo.Publishers VALUES('NXB008', N'Dân Trí', 'nxbdantri@gmail.com', '02466860751', N'9 Hoàng Cầu, Ô Chợ Dừa, Đống Đa, Hà Nội')
INSERT INTO dbo.Publishers VALUES('NXB009', N'Phụ nữ Việt Nam', 'truyenthongvaprnxbpn@gmail.com', '02439710717', N'39 Hàng Chuối, Hai Bà Trưng, Hà Nội')
INSERT INTO dbo.Publishers VALUES('NXB010', N'Lao động', 'nxblaodong@gmail.com', '0438515380', N'75 Giảng Võ, Đống Đa, Hà Nội')

-- Create data Books
	-- Book Category: Truyện ngắn - 30 days
INSERT INTO dbo.Books VALUES('S0001', N'Thả thính chân kinh', N'Truyện ngắn', 'TG001', 'NXB001', 2020, '95000', 30)
INSERT INTO dbo.Books VALUES('S0002', N'Điểm đến của cuộc đời', N'Truyện ngắn', 'TG002', 'NXB002', 2018, '60000', 30)
INSERT INTO dbo.Books VALUES('S0003', N'Chúng ta là những đứa trẻ cô đơn', N'Truyện ngắn', 'TG003', 'NXB003', 2019, '70000', 30)
INSERT INTO dbo.Books VALUES('S0004', N'Đừng yêu thầm nữa - tỏ tình đi', N'Truyện ngắn', 'TG004', 'NXB004', 2021, '70000', 30)
INSERT INTO dbo.Books VALUES('S0005', N'Hành lý hư vô', N'Truyện ngắn', 'TG005', 'NXB001', 2019, '80000', 30)
INSERT INTO dbo.Books VALUES('S0006', N'Bình an mà sống', N'Truyện ngắn', 'TG006', 'NXB005', 2021, '80000', 30)
INSERT INTO dbo.Books VALUES('S0007', N'Sống như cây rừng', N'Truyện ngắn', 'TG007', 'NXB003', 2016, '55000', 30)
INSERT INTO dbo.Books VALUES('S0008', N'Thương nhau để đó', N'Truyện ngắn', 'TG008', 'NXB003', 2019, '62000', 30)
INSERT INTO dbo.Books VALUES('S0009', N'Giấu mình giữa biển người bao la', N'Truyện ngắn', 'TG009', 'NXB003', 2019, '100000', 30)
INSERT INTO dbo.Books VALUES('S0010', N'Thế giới rộng lớn lòng người chật hẹp', N'Truyện ngắn', 'TG003', 'NXB003', 73000, '2020', 30)
	-- Book Category: Tiểu thuyết - 30 days
INSERT INTO dbo.Books VALUES('S0011', N'Nhà giả kim', N'Tiểu thuyết', 'TG010', 'NXB002', 2020, '67000', 35)
INSERT INTO dbo.Books VALUES('S0012', N'Bước chậm lại giữa thế gian vội vã', N'Tiểu thuyết', 'TG011', 'NXB002', 2018, '68000', 30)
INSERT INTO dbo.Books VALUES('S0013', N'Đoạn Tuyệt', N'Tiểu thuyết', 'TG012', 'NXB004', 2018, '63000', 30)
INSERT INTO dbo.Books VALUES('S0014', N'Every Thing', N'Tiểu thuyết', 'TG013', 'NXB003', 2020, '90000', 30)
INSERT INTO dbo.Books VALUES('S0015', N'Sự im lặng của bầy cừu', N'Tiểu thuyết', 'TG014', 'NXB002', 2019, '95000', 35)
INSERT INTO dbo.Books VALUES('S0016', N'Những con chim ẩn mình chờ chết', N'Tiểu thuyết', 'TG015', 'NXB001', 2020, '135000', 30)
INSERT INTO dbo.Books VALUES('S0017', N'Bố Già', N'Tiểu thuyết', 'TG016', 'NXB003', 2021, '215000', 30)
INSERT INTO dbo.Books VALUES('S0018', N'Hai Số Phận', N'Tiểu thuyết', 'TG017', 'NXB003', 2018, '147000', 35)
INSERT INTO dbo.Books VALUES('S0019', N'Giết Con Chim Nhại', N'Tiểu thuyết', 'TG018', 'NXB003', 2019, '96000', 30)
INSERT INTO dbo.Books VALUES('S0020', N'Những Đứa Trẻ Không Bao Giờ Lớn', N'Tiểu thuyết', 'TG019', 'NXB003', 2021, '78000', 30)
	-- Book Category: Kỹ năng sống - 30 days
INSERT INTO dbo.Books VALUES('S0021', N'Đắc nhân tâm', N'Kỹ năng sống', 'TG020', 'NXB007', 2005, '86000', 40)
INSERT INTO dbo.Books VALUES('S0022', N'Người bán hàng vĩ đại nhất thế giới', N'Kỹ năng sống', 'TG021', 'NXB007', 2010, '120000', 40)
INSERT INTO dbo.Books VALUES('S0023', N'7 thói quen của người thành đạt', N'Kỹ năng sống', 'TG022', 'NXB007', 2010, '85000', 40)
INSERT INTO dbo.Books VALUES('S0024', N'Cách nghĩ để thành công', N'Kỹ năng sống', 'TG023', 'NXB007', 2010, '85000', 40)
INSERT INTO dbo.Books VALUES('S0025', N'Đánh thức con người phi thường trong bạn', N'Kỹ năng sống', 'TG024', 'NXB007', 2010, '133000', 40)
INSERT INTO dbo.Books VALUES('S0026', N'Đàn Ông Sao Hỏa Đàn Bà Sao Kim', N'Kỹ năng sống', 'TG025', 'NXB007', 2019, '99000', 40)
INSERT INTO dbo.Books VALUES('S0027', N'Đọc Vị Bất Kỳ Ai', N'Kỹ năng sống', 'TG026', 'NXB007', 2018, '55000', 40)
INSERT INTO dbo.Books VALUES('S0028', N'Trí Tuệ Do Thái', N'Kỹ năng sống', 'TG027', 'NXB007', 2010, '135000', 40)
INSERT INTO dbo.Books VALUES('S0029', N'Dám Nghĩ Lớn', N'Kỹ năng sống', 'TG028', 'NXB007', 2015, '100000', 40)
INSERT INTO dbo.Books VALUES('S0030', N'Năng Lực Tinh Thần', N'Kỹ năng sống', 'TG029', 'NXB005', 2020, '100000', 40)
	-- Book Category: Tiếng anh - 60 days
INSERT INTO dbo.Books VALUES('S0031', N'Hackers Ielts Reading', N'Tiếng Anhh', 'TG030', 'NXB005', 2019, '120000', 25)
INSERT INTO dbo.Books VALUES('S0032', N'Hackers Ielts Listening', N'Tiếng Anhh', 'TG030', 'NXB005', 2019, '120000', 25)
INSERT INTO dbo.Books VALUES('S0033', N'Hackers Ielts Speaking', N'Tiếng Anhh', 'TG031', 'NXB005', 2019, '120000', 25)
INSERT INTO dbo.Books VALUES('S0034', N'Hackers Ielts Writing', N'Tiếng Anhh', 'TG031', 'NXB005', 2019, '120000', 25)
INSERT INTO dbo.Books VALUES('S0035', N'YBM Toeic Reading 1000', N'Tiếng Anhh', 'TG032', 'NXB008', 2018, '180000', 30)
INSERT INTO dbo.Books VALUES('S0036', N'YBM Toeic Listening 1000', N'Tiếng Anhh', 'TG032', 'NXB008', 2018, '180000', 30)
INSERT INTO dbo.Books VALUES('S0037', N'Hacker Toiec 1', N'Tiếng Anhh', 'TG033', 'NXB007', 2019, '100000', 35)
INSERT INTO dbo.Books VALUES('S0038', N'Hacker Toiec 2', N'Tiếng Anhh', 'TG033', 'NXB007', 2019, '100000', 35)
INSERT INTO dbo.Books VALUES('S0039', N'Hacker Toiec 3', N'Tiếng Anhh', 'TG033', 'NXB007', 2019, '100000', 35)
INSERT INTO dbo.Books VALUES('S0040', N'English Vocabulary in Use Elementary', N'Tiếng Anhh', 'TG034', 'NXB005', 2015, '80000', 25)
INSERT INTO dbo.Books VALUES('S0041', N'English Vocabulary in Use Pre-Intermediate and Intermediate', N'Tiếng Anhh', 'TG034', 'NXB005', 2015, '80000', 25)
INSERT INTO dbo.Books VALUES('S0042', N'English Vocabulary in Use Upper-Intermediate', N'Tiếng Anhh', 'TG034', 'NXB005', 2015, '80000', 25)
INSERT INTO dbo.Books VALUES('S0043', N'English Vocabulary in Use Advanced ', N'Tiếng Anhh', 'TG034', 'NXB005', 2015, '80000', 25)
INSERT INTO dbo.Books VALUES('S0044', N'Essential Grammar In Use', N'Tiếng Anhh', 'TG035', 'NXB005', 2015, '85000', 25)
INSERT INTO dbo.Books VALUES('S0045', N'Advanced Grammar In Use', N'Tiếng Anhh', 'TG035', 'NXB005', 2015, '85000', 25)
INSERT INTO dbo.Books VALUES('S0046', N'Englosh Grammar In Use', N'Tiếng Anhh', 'TG035', 'NXB005', 2015, '85000', 25)
INSERT INTO dbo.Books VALUES('S0047', N'Economy Toiec RC1000 Volume 1', N'Tiếng Anhh', 'TG036', 'NXB007', 2014, '120000', 30)
INSERT INTO dbo.Books VALUES('S0048', N'Economy Toiec LC1000 Volume 1', N'Tiếng Anhh', 'TG036', 'NXB007', 2014, '120000', 30)
INSERT INTO dbo.Books VALUES('S0049', N'Economy Toiec RC1000 Volume 2', N'Tiếng Anhh', 'TG036', 'NXB007', 2014, '120000', 30)
INSERT INTO dbo.Books VALUES('S0050', N'Economy Toiec LC1000 Volume 2', N'Tiếng Anhh', 'TG036', 'NXB007', 2014, '120000', 30)

-- Create data Readers
INSERT INTO dbo.Readers VALUES('DG001', N'Nguyễn Duy Tân', '2005-03-15', N'Nam', 'hoangminh@gmail.com', '0987745066', N'Tăng Nhơn Phú A, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG002', N'Trần Gia Bảo', '2003-07-05', N'Nam', 'giabao@gmail.com', ' 0336431969', N'Linh Xuân, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG003', N'Nguyễn Lê Huỳnh', '2000-12-20', N'Nam', 'huynhnguyen@gmail.com', '0946992013', N'Tân Chánh Hiệp, Quận 12, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG004', N'Ngô Hoàng Duy', '2002-04-09', N'Nam', 'hoangduy20@gmail.com', '0979058632', N'Linh Trung, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG005', N'Trịnh Thị Tuyết Thùy', '2003-11-20', N'Nữ', 'thuytrinh@gmail.com', '0879060825', N'Bình Chiểu, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG006', N'Thái Thị Thu Uyên', '2001-04-23', N'Nữ', 'thuuyen2001@gmail.com', '0379059287', N'Phường 12, Quận Tân Bình, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG007', N'Phạm Bá Thắng', '2002-02-07', N'Nam', 'bathangpham@gmail.com', '0879058965', N'An Lợi Đông, Quận 2, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG008', N'Châu Tiến Phát', '2004-08-11', N'Nam', 'chautienphat@gmail.com', '0979059923', N'Phường 4, Quận Gò Vấp, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG009', N'Nguyễn Trần Quốc Bảo', '2006-10-14', N'Nam', 'tranquocbao@gmail.com', '0969059365', N'Thạnh Xuân, Quận 12, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG010', N'Lê Hương Giang', '2002-05-15', N'Nữ', 'lehuongiang@gmail.com', '0879058721', N'Linh Trung, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG011', N'Tăng Thị Thùy Linh', '2001-02-19', N'Nữ', 'thuylinh0219@gmail.com', '0959059443', N'Phạm Ngũ Lão, Quận 1, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG012', N'Nguyễn Minh Chiến', '2003-10-02', N'Nam', 'minhchiennguyen@gmail.com', '0349059247', N'Thảo Điền, Quận 2, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG013', N'Ngô Tuyết Lan', '2000-12-06', N'Nữ', 'ngolantuyet@gmail.com', '0369061428', N'Đông Hưng Thuận, Quận 1, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG014', N'Dương Thị Mỹ Duyên', '2002-06-11', N'Nữ', 'myduyen06@gmail.com', '0849059704', N'Trường Thạnh, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG015', N'Lê Quốc Bình', '2002-04-04', N'Nam', 'quocbinhle@gmail.com', '0869060134', N'Thủ Thiêm, Quận 2, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG016', N'Nguyễn Tấn An', '2003-07-24', N'Nam', 'tanannguyen@gmail.com', '0879059052', N'Tân Định, Quận 1, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG017', N'Đỗ Ngọc Trâm Anh', '2001-03-28', N'Nữ', 'dongoctramanh@gmail.com', '0379061452', N'Phước Bình, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG018', N'Nguyễn Đức Thiện', '2002-08-11', N'Nam', 'ducthien2002@gmail.com', '0369059144', N'Tân Phú, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG019', N'Nguyễn Đức Việt', '2004-05-14', N'Nam', 'nguyenducviet14@gmail.com', '3579060951', N'An Lợi Đông, Quận 2, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG020', N'Lê Ngọc Kim Cương', '2001-08-17', N'Nữ', 'kimcuongle@gmail.com', '0879059381', N'Bình Trưng Tây, Quận 2, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG021', N'Nguyễn Hoàng Diệu', '2004-11-10', N'Nữ', 'dieuhoang@gmail.com', '0889059560', N'Nguyễn Cư Trinh, Quận 1, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG022', N'Phan Nguyễn Quỳnh Thư', '2003-09-25', N'Nữ', 'quynhthunguyen@gmail.com', '0919058907', N'Thạnh Xuân, Quận 12, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG023', N'Bùi Thị Bảo Yến', '2001-03-22', N'Nữ', 'baoyenbui01@gmail.com', '0948754934', N'Tân Định, Quận 1, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG024', N'Đổ Chí An', '2000-10-15', N'Nam', 'chian200010@gmail.com', '0948938713', N'Phước Bình, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG025', N'Đào Vũ Nhật Hạ', '2000-05-06', N'Nữ', 'vunhatha05@gmail.com', '0898759035', N'Thạnh Mỹ Lợi, Quận 2, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG026', N'Cao Hoàng Khang', '2003-10-07', N'Nam', 'caohoangkhang@gmail.com', '0898534814', N'Trường Thạnh, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG027', N'Nguyễn Thị Thảo Dâng', '2002-05-13', N'Nữ', 'thaodangnguyen@gmail.com', '0818534607', N'Phường 12, Quận Tân Bình, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG028', N'Phạm Thành Danh', '2001-07-02', N'Nam', 'phanthanhdanh@gmail.com', '0918697223', N'Linh Trung, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG029', N'Võ Trọng Bằng', '2003-09-27', N'Nam', 'votrongbang@gmail.com', '0898519850', N'Phước Bình, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG030', N'Lâm Thị Tâm Như', '2004-04-19', N'Nữ', 'lamtamnhu10@gmail.com', '0948660594', N'Phường 6, Quận Gò Vấp, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG031', N'Lê Phúc Trường', '2002-07-13', N'Nam', 'lephuctruong@gmail.com', '0358541875', N'Thạnh Xuân, Quận 12, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG032', N'Nguyễn Việt Hoàng', '2002-03-20', N'Nam', 'nguyenviethoang@gmail.com', '0898542643', N'Linh Xuân, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG033', N'Võ Tiến Đạt', '2001-12-03', N'Nam', 'votiendat@gmail.com', '0388543710', N'Nguyễn Thái Bình, Quận 1, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG034', N'Nguyễn Thị Thùy Dương', '2003-07-10', N'Nữ', 'thuyduongnguyen@gmail.com', '0918643041', N'Phường 12, Quận Bình Thạnh, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG035', N'Phan Hoài Sơn', '2005-06-24', N'Nam', 'hoaisonphan24@gmail.com', '0918523095', N'Bình Thọ, TP.Thủ Đức, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG036', N'Nguyễn Mạnh Quân', '2003-01-18', N'Nam', 'manhquan2003@gmail.com', '0858622815', N'Cầu Kho, Quận 1, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG037', N'Nguyễn Thanh Trọng', '2002-06-18', N'Nam', 'thanhtrongnguyen@gmail.com', '0882623127', N'Phường 6, Quận Bình Thạnh, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG038', N'Dương Anh Kiệt', '2004-04-29', N'Nam', 'duonganhkiet@gmail.com', '0778642373', N'Đông Hưng Thuận, Quận 12, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG039', N'Đỗ Minh Đức', '2001-10-08', N'Nam', 'dominhduc@gmail.com', '0898543672', N'Phường 10, Quận 4, TP.HCM')
INSERT INTO dbo.Readers VALUES('DG040', N'Lê Tuấn Phương', '2002-04-13', N'Nam', 'letuanpuong@gmail.com', '0978551734', N'Tân Thới Nhất, Quận 12, TP.HCM')

-- Create data Reverse_Return
INSERT INTO dbo.Reverse_Return VALUES('MTS001', 'DG001', 'S0001', '2022-02-10', '2022-03-10', '2022-02-20', 'NV002', 'NV004')
INSERT INTO dbo.Reverse_Return VALUES('MTS002', 'DG001', 'S0003', '2022-02-10', '2022-03-10', '2022-02-25', 'NV002', 'NV001')
INSERT INTO dbo.Reverse_Return VALUES('MTS003', 'DG002', 'S0001', '2022-02-12', '2022-03-12', '2022-02-17', 'NV001', 'NV002')
INSERT INTO dbo.Reverse_Return VALUES('MTS004', 'DG003', 'S0002', '2022-02-12', '2022-03-12', '2022-03-01', 'NV001', 'NV005')
INSERT INTO dbo.Reverse_Return VALUES('MTS005', 'DG004', 'S0011', '2022-02-13', '2022-03-13', '2022-02-20', 'NV004', 'NV008')
INSERT INTO dbo.Reverse_Return VALUES('MTS006', 'DG004', 'S0020', '2022-02-13', '2022-03-13', '2022-03-10', 'NV004', 'NV010')
INSERT INTO dbo.Reverse_Return VALUES('MTS007', 'DG005', 'S0015', '2022-02-13', '2022-03-13', '2022-02-18', 'NV008', 'NV018')
INSERT INTO dbo.Reverse_Return VALUES('MTS008', 'DG005', 'S0007', '2022-02-13', '2022-03-13', '2022-02-25', 'NV008', 'NV009')
INSERT INTO dbo.Reverse_Return VALUES('MTS009', 'DG005', 'S0022', '2022-02-13', '2022-03-13', '2022-03-03', 'NV008', 'NV024')
INSERT INTO dbo.Reverse_Return VALUES('MTS010', 'DG006', 'S0034', '2022-02-14', '2022-04-14', '2022-03-25', 'NV017', 'NV007')
INSERT INTO dbo.Reverse_Return VALUES('MTS011', 'DG007', 'S0005', '2022-02-16', '2022-03-16', '2022-03-01', 'NV028', 'NV029')
INSERT INTO dbo.Reverse_Return VALUES('MTS012', 'DG008', 'S0015', '2022-02-16', '2022-03-16', '2022-02-23', 'NV016', 'NV003')
INSERT INTO dbo.Reverse_Return VALUES('MTS013', 'DG009', 'S0022', '2022-02-16', '2022-03-16', '2022-02-27', 'NV016', 'NV008')
INSERT INTO dbo.Reverse_Return VALUES('MTS014', 'DG010', 'S0018', '2022-02-16', '2022-03-16', '2022-03-08', 'NV019', 'NV009')
INSERT INTO dbo.Reverse_Return VALUES('MTS015', 'DG011', 'S0038', '2022-02-16', '2022-04-16', '2022-04-03', 'NV019', 'NV022')
INSERT INTO dbo.Reverse_Return VALUES('MTS016', 'DG012', 'S0007', '2022-02-17', '2022-03-17', '2022-02-20', 'NV014', 'NV007')
INSERT INTO dbo.Reverse_Return VALUES('MTS017', 'DG013', 'S0011', '2022-02-17', '2022-03-17', '2022-02-24', 'NV026', 'NV018')
INSERT INTO dbo.Reverse_Return VALUES('MTS018', 'DG014', 'S0018', '2022-02-18', '2022-03-18', '2022-03-02', 'NV011', 'NV014')
INSERT INTO dbo.Reverse_Return VALUES('MTS019', 'DG015', 'S0016', '2022-02-18', '2022-03-18', '2022-03-07', 'NV005', 'NV009')
INSERT INTO dbo.Reverse_Return VALUES('MTS020', 'DG016', 'S0022', '2022-02-18', '2022-03-18', '2022-03-11', 'NV013', 'NV027')
INSERT INTO dbo.Reverse_Return VALUES('MTS021', 'DG017', 'S0027', '2022-02-20', '2022-03-20', '2022-03-04', 'NV011', 'NV022')
INSERT INTO dbo.Reverse_Return VALUES('MTS022', 'DG017', 'S0024', '2022-02-20', '2022-03-20', '2022-03-18', 'NV011', 'NV014')
INSERT INTO dbo.Reverse_Return VALUES('MTS023', 'DG018', 'S0029', '2022-02-20', '2022-03-20', '2022-02-27', 'NV015', 'NV018')
INSERT INTO dbo.Reverse_Return VALUES('MTS024', 'DG019', 'S0030', '2022-02-22', '2022-04-22', '2022-04-08', 'NV004', 'NV002')
INSERT INTO dbo.Reverse_Return VALUES('MTS025', 'DG020', 'S0018', '2022-02-23', '2022-03-23', '2022-03-07', 'NV023', 'NV009')
INSERT INTO dbo.Reverse_Return VALUES('MTS026', 'DG021', 'S0009', '2022-02-23', '2022-03-23', '2022-03-18', 'NV027', 'NV011')
INSERT INTO dbo.Reverse_Return VALUES('MTS027', 'DG022', 'S0006', '2022-02-23', '2022-03-23', '2022-03-10', 'NV030', 'NV016')
INSERT INTO dbo.Reverse_Return VALUES('MTS028', 'DG023', 'S0005', '2022-02-24', '2022-03-24', '2022-03-20', 'NV015', 'NV015')
INSERT INTO dbo.Reverse_Return VALUES('MTS029', 'DG024', 'S0044', '2022-02-24', '2022-04-24', '2022-04-07', 'NV018', 'NV005')
INSERT INTO dbo.Reverse_Return VALUES('MTS030', 'DG025', 'S0039', '2022-02-24', '2022-04-24', '2022-04-13', 'NV018', 'NV018')
INSERT INTO dbo.Reverse_Return VALUES('MTS031', 'DG026', 'S0025', '2022-02-25', '2022-03-25', '2022-03-04', 'NV012', 'NV002')
INSERT INTO dbo.Reverse_Return VALUES('MTS032', 'DG027', 'S0033', '2022-02-25', '2022-04-25', '2022-04-22', 'NV010', 'NV028')
INSERT INTO dbo.Reverse_Return VALUES('MTS033', 'DG028', 'S0037', '2022-02-25', '2022-04-25', '2022-04-13', 'NV008', 'NV014')
INSERT INTO dbo.Reverse_Return VALUES('MTS034', 'DG029', 'S0046', '2022-02-25', '2022-04-25', '2022-04-04', 'NV019', 'NV010')
INSERT INTO dbo.Reverse_Return VALUES('MTS035', 'DG030', 'S0004', '2022-02-25', '2022-03-25', '2022-03-17', 'NV020', 'NV024')
INSERT INTO dbo.Reverse_Return VALUES('MTS036', 'DG031', 'S0008', '2022-02-26', '2022-03-26', '2022-03-22', 'NV006', 'NV005')
INSERT INTO dbo.Reverse_Return VALUES('MTS037', 'DG031', 'S0029', '2022-02-26', '2022-03-26', '2022-03-06', 'NV006', 'NV008')
INSERT INTO dbo.Reverse_Return VALUES('MTS038', 'DG032', 'S0050', '2022-02-27', '2022-04-27', '2022-04-08', 'NV018', 'NV001')
INSERT INTO dbo.Reverse_Return VALUES('MTS039', 'DG033', 'S0018', '2022-02-28', '2022-03-28', '2022-03-19', 'NV014', 'NV017')
INSERT INTO dbo.Reverse_Return VALUES('MTS040', 'DG033', 'S0013', '2022-03-01', '2022-04-01', '2022-03-30', 'NV014', 'NV014')
INSERT INTO dbo.Reverse_Return VALUES('MTS041', 'DG034', 'S0016', '2022-03-01', '2022-04-01', '2022-03-13', 'NV023', 'NV015')
INSERT INTO dbo.Reverse_Return VALUES('MTS042', 'DG035', 'S0042', '2022-03-04', '2022-05-04', '2022-04-26', 'NV006', 'NV019')
INSERT INTO dbo.Reverse_Return VALUES('MTS043', 'DG035', 'S0009', '2022-03-04', '2022-04-04', '2022-03-17', 'NV006', 'NV009')
INSERT INTO dbo.Reverse_Return VALUES('MTS044', 'DG036', 'S0046', '2022-03-04', '2022-05-04', '2022-04-20', 'NV011', 'NV025')
INSERT INTO dbo.Reverse_Return VALUES('MTS045', 'DG037', 'S0023', '2022-03-07', '2022-04-07', '2022-03-17', 'NV019', 'NV010')
INSERT INTO dbo.Reverse_Return VALUES('MTS046', 'DG038', 'S0028', '2022-03-08', '2022-04-08', '2022-03-29', 'NV028', 'NV007')
INSERT INTO dbo.Reverse_Return VALUES('MTS047', 'DG038', 'S0039', '2022-03-08', '2022-05-08', '2022-04-25', 'NV028', 'NV023')
INSERT INTO dbo.Reverse_Return VALUES('MTS048', 'DG039', 'S0034', '2022-03-08', '2022-05-08', '2022-04-20', 'NV008', 'NV017')
INSERT INTO dbo.Reverse_Return VALUES('MTS049', 'DG040', 'S0010', '2022-03-10', '2022-04-10', '2022-03-15', 'NV014', 'NV009')
INSERT INTO dbo.Reverse_Return VALUES('MTS050', 'DG040', 'S0041', '2022-03-10', '2022-05-10', '2022-04-24', 'NV014', 'NV004')
