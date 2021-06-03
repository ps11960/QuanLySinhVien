create database FPL_daotao;
use FPL_daotao;

create table students(
	masv nvarchar(50) not null primary key,
	hoten nvarchar(50),
	email nvarchar(50),
	sodt nvarchar(15),
	gioitinh bit,
	diachi nvarchar(50),
	hinh nvarchar(50)
);
create table grade(
	id int IDENTITY(1,1) primary key,
	masv nvarchar(50),
	tienganh int,
	tinhoc int,
	gdtc int,
	foreign key (masv) references students(masv)
);
create table users(
	username nvarchar(50) not null primary key,
	password nvarchar(50),
	role nvarchar(50)
);

insert into students values 
	('PS11960','Mai The Anh','anhmtps11960@fpt.edu.vn','0971404710',1,'Phuong 8, Quan 11',''),
	('PS11111','Pham Thi Thien Nhi','nhipttps11111@fpt.edu.vn','0912345678',0,'Phuong 5, Quan 8',''),
	('PS12566','Nguyen Minh Hang','hangnmps12566@fpt.edu.vn','0123456789',0,'3/2, Quan 11','');
insert into grade(masv,tienganh,tinhoc,gdtc) values 
	('PS11960',7,9,8),
	('PS11111',10,5,6),
	('PS12566',5,6,5);
insert into users values 
	('admin','admin','full'),
	('giangvien','1','qlsv'),
	('canbodaotao','1','qld');