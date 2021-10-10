create database bd_kurs

drop table Заказы;
drop table Товары;
drop table Поставка;
drop table Поставщик;
drop table Сотрудники;
drop table Клиенты;

use bd_kurs
go

SET DATEFORMAT DMY;
GO

create table Клиенты (
	id_клиента nchar(100) primary key not null,
	ФИО_клиента nchar(100) not null,
	Адрес nchar(100) not null,
	Телефон nchar(50) not null
)

create table Сотрудники (
	id_сотрудника nchar(200) primary key not null,
	ФИО_сотрудника nchar(200) not null,
	Адрес nchar(100) not null,
	Телефон nchar(50) not null
)

create table Поставщик (
	id_поставщика nchar(200) primary key not null,
	ФИО_поставщика nchar(200) not null,
	Телефон nchar(50) not null,
	Адрес nchar(200) not null
)

create table Поставка (
	id_поставки int primary key identity(1,1) not null,
	id_поставщика nchar(200) not null,
	Дата_поставки date not null,
	constraint fk_id_postavschik foreign key (id_поставщика) references Поставщик(id_поставщика)
)

create table Товары (
	id_товара int primary key identity(1,1) not null,
	id_поставки int not null,
	Название_товара nchar(200) not null,
	Описание nchar(500) default('No') not null,
	Технические_харки nchar(200) default('No') not null,
	Наличие nchar(20) not null,
	Количество int default(10) not null,
	Стоимость int not null,
	constraint fk_id_postavki foreign key (id_поставки) references Поставка(id_поставки)
)

create table Заказы (
	id_заказа int primary key identity(1,1) not null,
	id_товара int not null,
	id_клиента nchar(100) not null,
	Дата_размещения date not null
	constraint fk_id_tovara foreign key (id_товара) references Товары(id_товара),
	constraint fk_id_client foreign key (id_клиента) references Клиенты(id_клиента),
)

go

insert into Клиенты(id_клиента, ФИО_клиента, Адрес, Телефон) values ('Admin', 'Null', 'Null', 'Null')

insert into Поставщик(id_поставщика, ФИО_поставщика, Телефон, Адрес) values ('OOO пчёлка', 'Рудольф', 'Домашний', 'Рабочий')

insert into Поставка(id_поставщика, Дата_поставки) values ('OOO пчёлка', '10-10-2021')

insert into Товары(id_поставки, Название_товара, Наличие, Стоимость)
values
(1, 'Спрачник','Есть', 200),
(1, 'Как встать','Есть', 100),
(1, 'Раскраска','Есть', 500),
(1, 'Книга животных','Есть', 650),
(1, 'Зелёная гавань','Есть', 100),
(1, 'Англия на бумаге','Есть', 500),
(1, 'Глупые мысли','Есть', 1000),
(1, 'Умные мысли','Есть', 100),
(1, 'История древнего Рима','Есть', 200),
(1, 'Анекдоты','Есть', 128),
(1, 'Вокзал','Есть', 544)

select * from Клиенты, Поставщик, Поставка
select * from Товары

select * from Заказы

SELECT Заказы.id_товара, Название_товара, Дата_размещения, Стоимость FROM Заказы INNER JOIN Товары ON Заказы.id_товара = Товары.id_товара where id_клиента = 'STAS';
select SUM(Стоимость) from Заказы INNER JOIN Товары ON Заказы.id_товара = Товары.id_товара where id_клиента = 'STAS'