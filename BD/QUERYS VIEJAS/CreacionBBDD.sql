CREATE DATABASE TPC_EQUIPO_5
GO
USE TPC_EQUIPO_5
GO
CREATE TABLE Provincias(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(80) NOT NULL
)
CREATE TABLE Ciudades(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(80) NOT NULL,
    IDProvincia INT NOT NULL FOREIGN KEY REFERENCES Provincias(ID)
)
CREATE TABLE Categorias(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(80) NOT NULL
)
CREATE TABLE Marcas(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(80) NOT NULL
)
CREATE TABLE Tipos_Imagenes(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Tipo VARCHAR(80) NOT NULL
)
CREATE TABLE Datos_Personales(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefono INT NULL,
    Direccion VARCHAR(100),
    IDCiudad INT NULL FOREIGN KEY REFERENCES Ciudades(ID)
)
CREATE TABLE Usuarios(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(50) NOT NULL, 
    Clave VARCHAR(50) NOT NULL,
    Administrar BIT NOT NULL,
    IDDatos_Personales INT FOREIGN KEY REFERENCES Datos_Personales(ID)
)

CREATE TABLE Productos(
	ID int not null PRIMARY KEY IDENTITY(1,1),
	ID_Categoria int NOT NULL FOREIGN KEY REFERENCES Categorias(ID),
	ID_Marca int NOT NULL FOREIGN KEY REFERENCES Marcas(ID),
	Nombre VARCHAR(80) NOT NULL,
	Descripcion VARCHAR(80) NOT NULL,
	Precio money,
	Stock int NOT NULL
)
CREATE TABLE Imagen(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    UrlImagen VARCHAR(200) NOT NULL,
    ID_Producto INT NOT NULL FOREIGN KEY REFERENCES Productos(ID),
    Tipo_Imagen INT NOT NULL FOREIGN KEY REFERENCES Tipos_Imagenes(ID)
)
CREATE TABLE Metodos_de_pago(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Metodo_de_pago VARCHAR(50) NOT NULL
)
CREATE TABLE Estados_Pedido(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(80) NOT NULL
)
CREATE TABLE Pedidos(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_MetodoDePago INT not null FOREIGN KEY REFERENCES Metodos_de_pago(ID),
	ID_EstadosPedido  INT not null FOREIGN KEY REFERENCES Estados_Pedido(ID)
)

alter table Pedidos
add ID_Usuario int not null,
Fecha date not null

create table Productos_x_pedido(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_Pedido int not null foreign key references Pedidos(ID),
	ID_Producto int not null foreign key references Productos(ID),
	Cantidad int not null
)

alter table Provincias add Estado bit not null default 1;
alter table Ciudades add Estado bit not null default 1;
alter table Categorias add Estado bit not null default 1;
alter table Marcas add Estado bit not null default 1;
alter table Datos_Personales add Estado bit not null default 1;
alter table Usuarios add Estado bit not null default 1;
alter table Productos add Estado bit not null default 1;
alter table Imagen add Estado bit not null default 1;
alter table Pedidos add Estado bit not null default 1;

alter  table Imagen alter column ID_Producto INT NULL
