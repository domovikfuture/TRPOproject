drop table ������;
drop table ������;
drop table ��������;
drop table ���������;
drop table ����������;
drop table �������;
drop database bd_stas


create database bd_kurs

use bd_kurs
go

create table ������� (
	id_������� int primary key not null,
	���_������� nchar(200) not null,
	����� nchar(100) not null,
	������� nchar(50) not null
)

create table ���������� (
	id_���������� int primary key not null,
	���_���������� nchar(200) not null,
	����� nchar(100) not null,
	������� nchar(50) not null
)

create table ��������� (
	id_���������� int primary key not null,
	���_���������� nchar(200) not null,
	������� nchar(50) not null,
	����� nchar(200) not null
)

create table �������� (
	id_�������� int primary key not null,
	id_���������� int not null,
	����_�������� date not null,
	constraint fk_id_postavschik foreign key (id_����������) references ���������(id_����������)
)

create table ������ (
	id_������ int primary key not null,
	id_�������� int not null,
	��������_������ nchar(200) not null,
	�������� nchar(500) not null,
	�����������_����� nchar(200) not null,
	������� nchar(20) not null,
	���������� int not null,
	��������� int not null,
	constraint fk_id_postavki foreign key (id_��������) references ��������(id_��������)
)

create table ������ (
	id_������ int primary key not null,
	id_���������� int not null,
	id_������ int not null,
	id_������� int not null,
	����_���������� date not null,
	����_���������� date not null
	constraint fk_id_sotrudnik foreign key (id_����������) references ����������(id_����������),
	constraint fk_id_tovara foreign key (id_������) references ������(id_������),
	constraint fk_id_client foreign key (id_�������) references �������(id_�������),
)



