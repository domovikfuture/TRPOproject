Create DATABASE Adjust
GO

USE Adjust

go
DROP TABLE Customer;
go

CREATE TABLE Customer(
	login nchar(20) not null,
	name nchar(40) not null,
	pass nchar(16) not null
	CONSTRAINT Prim_ID_Vlad PRIMARY KEY (Login)
)  
GO

INSERT INTO Customer(login,name,pass)
VALUES
('Log','Yes','1234')

select * from Customer

select * from Customer
where login = 'Log'