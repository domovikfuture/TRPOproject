Create DATABASE Adjust
GO

USE Adjust

DROP TABLE Orders;
DROP TABLE Customer;
DROP TABLE Goods;
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
	login nchar(20) not null,
	good nchar(20) not null,
	count int not null default(1),
	CONSTRAINT FK_List_Customer FOREIGN KEY (login) REFERENCES Customer(login),
	CONSTRAINT FK_List_Goods FOREIGN KEY (good) REFERENCES Goods(name)
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