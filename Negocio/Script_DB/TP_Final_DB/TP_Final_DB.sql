create database TP_Final
go
use TP_Final
go
CREATE TABLE Tamano(
    ID int not null primary key identity(1,1),
    Tamano varchar(50) not null
)
Go
CREATE TABLE Categoria(
    ID int not null primary key identity(1,1),
    Nombre varchar(50) not null
)
Go
CREATE TABLE Tipo(
    ID int not null primary key identity(1,1),
    IdCategoria int not null foreign key references Categoria(ID),
    Tipo varchar(50) not null
)
Go
CREATE TABLE Articulos(
    ID int not null primary key identity(1,1),
    Nombre varchar(50) not null,
    Descripcion varchar(100) not null,
    IdCategoria int not null foreign key references Categoria(ID),
    IdTamano int not null foreign key references Tamano(ID),
    Precio money not null CHECK(Precio > 0), 
    ImagenUrl varchar (1000),
    Disponible bit default(1)
)
CREATE TABLE Usuarios(
    ID int not null primary key identity(1,1),
    Usuario varchar(50) not null UNIQUE
    Pass varchar(16) not null, 
    Apellidos varchar(100) null,
    Nombres varchar(100) null,
    Nacimiento date null,
    ImagenUrl varchar (1000) null,
    Adm bit default(0) NULL
)
Create Procedure insertarNuevo
@user varchar(50),
@pass varchar(16)
as
insert into Usuarios (Usuario, Pass, TipoUsuario) values (@user, @pass, 0)

Insert into Usuarios (Usuario, Pass, Adm)
values
('juancruz@gmail.com', 'admin123', 1),
('josias@gmail.com', 'admin123', 1),
('prueba@gmail.com','noesadmin', 0)