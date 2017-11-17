create database NSFW
go
use NSFW
go
create table Blacklist(
	ID int identity(1, 1) primary key,
	Domain nvarchar(2000)
)
go
create table BlockingHandle(
	ID int identity(1, 1) primary key,
	Image nvarchar(2000),
	HTMLPage nvarchar(2000)
)
