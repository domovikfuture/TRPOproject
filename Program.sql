Create DATABASE Adjust
GO

USE Adjust

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
	image nvarchar(max) null
	CONSTRAINT PK_Goods PRIMARY KEY (name)
)

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

select * from Customer
select * from Goods

select * from Customer
where login = 'Log' and pass = '1234'