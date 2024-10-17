CREATE DATABASE PSC;

USE PSC;

-- Tabla de Vehículos
CREATE TABLE Vehiculos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MarcaId INT,
    Modelo VARCHAR(100),
    Precio DECIMAL(18, 2),
    CONSTRAINT FK_Marca FOREIGN KEY (MarcaId) REFERENCES Marcas(Id)
);

-- Tabla de Marcas
CREATE TABLE Marcas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreMarca VARCHAR(100)
);

-- Tabla de Vendedores
CREATE TABLE Vendedores (
    Cedula VARCHAR(20) PRIMARY KEY,
    Nombre VARCHAR(100),
    Telefono VARCHAR(15)
);

-- Tabla de Ventas
CREATE TABLE Ventas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VehiculoId INT,
    CedulaVendedor VARCHAR(20),
    FechaVenta DATE,
    CONSTRAINT FK_Vehiculo FOREIGN KEY (VehiculoId) REFERENCES Vehiculos(Id),
    CONSTRAINT FK_Vendedor FOREIGN KEY (CedulaVendedor) REFERENCES Vendedores(Cedula)
);

-- Vistas 
CREATE VIEW VistaVentas AS
SELECT 
    v.Id AS VentaId, 
    ve.Nombre AS Vendedor, 
    m.NombreMarca AS Marca, 
    vcl.Modelo AS Vehiculo, 
    v.FechaVenta, 
    vcl.Precio
FROM 
    Ventas v
JOIN Vendedores ve ON v.CedulaVendedor = ve.Cedula
JOIN Vehiculos vcl ON v.VehiculoId = vcl.Id
JOIN Marcas m ON vcl.MarcaId = m.Id;







-- Stored Procedure

CREATE PROCEDURE sp_VentasPorVendedor
@CedulaVendedor VARCHAR(20)
AS
BEGIN
    SELECT 
        v.Id AS VentaId, 
        ve.Nombre AS Vendedor, 
        m.NombreMarca AS Marca, 
        vcl.Modelo AS Vehiculo, 
        v.FechaVenta, 
        vcl.Precio
    FROM 
        Ventas v
    JOIN Vendedores ve ON v.CedulaVendedor = ve.Cedula
    JOIN Vehiculos vcl ON v.VehiculoId = vcl.Id
    JOIN Marcas m ON vcl.MarcaId = m.Id
    WHERE ve.Cedula = @CedulaVendedor;
END;
