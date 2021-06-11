Create DATABASE Adjust
GO

USE Adjust

DROP TABLE Orders;
DROP TABLE Customer;
DROP TABLE Goods;
DROP TABLE ListOrders;
go

CREATE TABLE Customer(
	login nchar(20) not null,
	name nchar(40) not null,
	pass nchar(16) not null
	CONSTRAINT PK_Customer PRIMARY KEY (Login)
)  
GO

CREATE TABLE Goods(
	name nchar(20) not null,
	price float not null,
	CONSTRAINT PK_Goods PRIMARY KEY (name)
)
GO

CREATE TABLE Orders(
	id int identity(1,1) not null,
	login nchar(20) not null,
	good nchar(20) not null,
	count int not null default(1),
	CONSTRAINT PK_List_ID PRIMARY KEY(id),
	CONSTRAINT FK_List_Customer FOREIGN KEY (login) REFERENCES Customer(login),
	CONSTRAINT FK_List_Goods FOREIGN KEY (good) REFERENCES Goods(name)
)
GO

CREATE TABLE ListOrders(
	id int not null,
	orders int not null,
	status nchar(10) not null,
	CONSTRAINT FK_ListORders_Orders FOREIGN KEY (orders) REFERENCES Orders(id)
)
GO

INSERT INTO Customer(login,name,pass)
VALUES
('Admin',' ','Admin')

INSERT INTO Goods(name,price)
VALUES
('Футболка',100),
('Рубашка',50),
('Толстовка',30),
('Свитер',40),
('Жилетка',50),
('Джинсы',70),
('Брюки',40),
('Пальто',100)

INSERT INTO Orders(login, good, count)
VALUES
('Admin', 'Футболка', 2)

select * from Customer
select * from Goods
select * from Orders

select * from Customer
where login = 'Log' and pass = '1234'

select login, good, count, price from Orders 
inner join Goods on Orders.good = Goods.name where login = N'Admin'

update Orders set count = 8 where login = 'Admin' and good = N'Футболка'

delete Orders where good = 'Футболка'