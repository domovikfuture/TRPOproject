drop table Заказы;
drop table Товары;
drop table Поставка;
drop table Поставщик;
drop table Сотрудники;
drop table Клиенты;
drop database bd_stas


create database bd_kurs

use bd_kurs
go

create table Клиенты (
	id_клиента int primary key not null,
	ФИО_клиента nchar(200) not null,
	Адрес nchar(100) not null,
	Телефон nchar(50) not null
)

create table Сотрудники (
	id_сотрудника int primary key not null,
	ФИО_сотрудника nchar(200) not null,
	Адрес nchar(100) not null,
	Телефон nchar(50) not null
)

create table Поставщик (
	id_поставщика int primary key not null,
	ФИО_поставщика nchar(200) not null,
	Телефон nchar(50) not null,
	Адрес nchar(200) not null
)

create table Поставка (
	id_поставки int primary key not null,
	id_поставщика int not null,
	Дата_поставки date not null,
	constraint fk_id_postavschik foreign key (id_поставщика) references Поставщик(id_поставщика)
)

create table Товары (
	id_товара int primary key not null,
	id_поставки int not null,
	Название_товара nchar(200) not null,
	Описание nchar(500) not null,
	Технические_харки nchar(200) not null,
	Наличие nchar(20) not null,
	Количество int not null,
	Стоимость int not null,
	constraint fk_id_postavki foreign key (id_поставки) references Поставка(id_поставки)
)

create table Заказы (
	id_заказа int primary key not null,
	id_сотрудника int not null,
	id_товара int not null,
	id_клиента int not null,
	Дата_размещения date not null,
	Дата_исполнения date not null
	constraint fk_id_sotrudnik foreign key (id_сотрудника) references Сотрудники(id_сотрудника),
	constraint fk_id_tovara foreign key (id_товара) references Товары(id_товара),
	constraint fk_id_client foreign key (id_клиента) references Клиенты(id_клиента),
)



