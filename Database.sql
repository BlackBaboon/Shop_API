use master 
go
drop database ËàðèîíîâÄîòà
go
create database ËàðèîíîâÄîòà
go
use ËàðèîíîâÄîòà

create table Users
(
ID int primary key,
Nickname nvarchar(20) not null,
Surname nvarchar(20) not null,
[Name] nvarchar(20) not null,
Email nvarchar(50) null,
Phonenumber nvarchar(50) null,
Authed bit not null,
IsAdmin bit not null
);

create table SavedAdresses
(
UserId int,
Title nvarchar(20) not null,
City nvarchar(50) not null,
Street nvarchar(50) not null,
House int not null,
Building int null,
Front int null,
Apartament int null,
Primary key(UserId,Title),
FOREIGN KEY (UserId) references Users(ID)
);

create table Goods
(
ID int primary key,
Title nvarchar(100) not null,
Price decimal(20,2) not null,
Amount int not null,
Descryption nvarchar(MAX) not null
);

create table GoodsList
(
UserId int,
GoodId int,
Amount int not null,
PRIMARY KEY(UserId, GoodId),
FOREIGN KEY (UserId) references Users(ID),
FOREIGN KEY (GoodId) references Goods(ID)
);

create table LikedList
(
UserId int,
GoodId int,
PRIMARY KEY(UserId, GoodId),
FOREIGN KEY (UserId) references Users(ID),
FOREIGN KEY (GoodId) references Goods(ID)
);

create table Comments
(
UserId int,
GoodId int,
Rate int not null,
Comment int,
PRIMARY KEY(UserId, GoodId),
FOREIGN KEY (UserId) references Users(ID),
FOREIGN KEY (GoodId) references Goods(ID)
);

create table Ships
(
ID int,
UserId int,
GoodId int,
Amount int,
ShipDate datetime not null,
[Status] nvarchar(100) null,
primary key(ID,UserId,GoodId),
FOREIGN KEY (UserId) references Users(ID),
FOREIGN KEY (GoodId) references Goods(ID)
);
