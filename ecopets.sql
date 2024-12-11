create database Ecopets

use Ecopets

create table Categoria(
IdCategoria int primary key identity,
Nombre varchar(50),
FechaCreacion datetime default getdate()
)


create table Producto(
IdProducto UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
Nombre varchar(50),
Descripcion varchar(1000),
IdCategoria int references Categoria(IdCategoria),
Precio decimal(10,2),
PrecioOferta decimal(10,2),
Cantidad int,
Imagen varchar(max),
FechaCreacion datetime default getdate()

)

create table TipoDocumento(
IdTipoDocumento int primary key identity,
cTipoDocumento varchar(50)
)



create table Usuario(
IdUsuario UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
IdTipoDocumento int references TipoDocumento(IdTipoDocumento),
Nombre varchar(50),
Apellido varchar(50),
Correo varchar(50),
Clave varchar(50),
Rol varchar(50),
FechaCreacion datetime default getdate()
)

create table Venta(
    IdVenta UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    IdUsuario UNIQUEIDENTIFIER references Usuario(IdUsuario), -- Corregido: UNIQUEIDENTIFIER en vez de int
    Total decimal(10,2),
    FechaCreacion datetime default getdate()
)
-- Crear la tabla TipoComprobante
create table TipoComprobante(
    IdTipoComprobante int primary key identity,  -- ID del tipo de comprobante
    cTipoComprobante varchar(50)  -- Nombre del tipo de comprobante (Boleta, Factura)
);


insert into TipoComprobante (cTipoComprobante)
values 
('Boleta'),  -- Tipo de comprobante Boleta
('Factura'); -- Tipo de comprobante Factura

select * from TipoComprobante;

create table DetalleVenta(
	IdDetalleVenta int primary key identity,
	IdVenta UNIQUEIDENTIFIER references Venta(IdVenta),
	IdProducto UNIQUEIDENTIFIER references Producto(IdProducto),
	Cantidad int,
	Total decimal(10,2)
)

alter table DetalleVenta
add IdTipoComprobante int references TipoComprobante(IdTipoComprobante);

select * from DetalleVenta;

insert into TipoDocumento (cTipoDocumento)
values 
('DNI'),   -- Documento Nacional de Identidad
('RUC');   -- Registro Único de Contribuyentes



insert into Usuario (IdTipoDocumento, Nombre, Apellido, Correo, Clave, Rol)
values 
(
    (select IdTipoDocumento from TipoDocumento where cTipoDocumento = 'DNI'),  -- Referencia al Tipo de Documento 'DNI'
    'Alonso',  -- Nombre
    'Vera', -- Apellido
    'veraalonso88@gmail.com',  -- Correo
    '4250254',  -- Clave
    'Administrador'  -- Rol
);

select * from Usuario;