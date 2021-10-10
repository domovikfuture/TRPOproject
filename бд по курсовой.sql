create database bd_kurs

drop table ������;
drop table ������;
drop table ��������;
drop table ���������;
drop table ����������;
drop table �������;

use bd_kurs
go

SET DATEFORMAT DMY;
GO

create table ������� (
	id_������� nchar(100) primary key not null,
	���_������� nchar(100) not null,
	����� nchar(100) not null,
	������� nchar(50) not null
)

create table ���������� (
	id_���������� nchar(200) primary key not null,
	���_���������� nchar(200) not null,
	����� nchar(100) not null,
	������� nchar(50) not null
)

create table ��������� (
	id_���������� nchar(200) primary key not null,
	���_���������� nchar(200) not null,
	������� nchar(50) not null,
	����� nchar(200) not null
)

create table �������� (
	id_�������� int primary key identity(1,1) not null,
	id_���������� nchar(200) not null,
	����_�������� date not null,
	constraint fk_id_postavschik foreign key (id_����������) references ���������(id_����������)
)

create table ������ (
	id_������ int primary key identity(1,1) not null,
	id_�������� int not null,
	��������_������ nchar(200) not null,
	�������� nchar(500) default('No') not null,
	�����������_����� nchar(200) default('No') not null,
	������� nchar(20) not null,
	���������� int default(10) not null,
	��������� int not null,
	constraint fk_id_postavki foreign key (id_��������) references ��������(id_��������)
)

create table ������ (
	id_������ int primary key identity(1,1) not null,
	id_������ int not null,
	id_������� nchar(100) not null,
	����_���������� date not null
	constraint fk_id_tovara foreign key (id_������) references ������(id_������),
	constraint fk_id_client foreign key (id_�������) references �������(id_�������),
)

go

insert into �������(id_�������, ���_�������, �����, �������) values ('Admin', 'Null', 'Null', 'Null')

insert into ���������(id_����������, ���_����������, �������, �����) values ('OOO ������', '�������', '��������', '�������')

insert into ��������(id_����������, ����_��������) values ('OOO ������', '10-10-2021')

insert into ������(id_��������, ��������_������, �������, ���������)
values
(1, '��������','����', 200),
(1, '��� ������','����', 100),
(1, '���������','����', 500),
(1, '����� ��������','����', 650),
(1, '������ ������','����', 100),
(1, '������ �� ������','����', 500),
(1, '������ �����','����', 1000),
(1, '����� �����','����', 100),
(1, '������� �������� ����','����', 200),
(1, '��������','����', 128),
(1, '������','����', 544)

select * from �������, ���������, ��������
select * from ������

select * from ������

SELECT ������.id_������, ��������_������, ����_����������, ��������� FROM ������ INNER JOIN ������ ON ������.id_������ = ������.id_������ where id_������� = 'STAS';
select SUM(���������) from ������ INNER JOIN ������ ON ������.id_������ = ������.id_������ where id_������� = 'STAS'