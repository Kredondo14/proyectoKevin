-- CREAR BASE DE DATOS
CREATE DATABASE ReparacionesDB;
USE ReparacionesDB;

-- TABLA DE USUARIOS
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    CorreoElectronico VARCHAR(100) UNIQUE NOT NULL,
    Telefono VARCHAR(15) NOT NULL
);

-- TABLA DE EQUIPOS
CREATE TABLE Equipos (
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    TipoEquipo VARCHAR(50) NOT NULL,
    Modelo VARCHAR(100) NOT NULL,
    UsuarioID INT NOT NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- TABLA DE TECNICOS
CREATE TABLE Tecnicos (
    TecnicoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL
);

-- TABLA DE REPARACIONES
CREATE TABLE Reparaciones (
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT NOT NULL,
    FechaSolicitud DATE NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
);

-- TABLA DE ASIGNACIONES
CREATE TABLE Asignaciones (
    AsignacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT NOT NULL,
    TecnicoID INT NOT NULL,
    FechaAsignacion DATE NOT NULL,
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
);

-- TABLA DE DETALLES DE REPARACION
CREATE TABLE DetallesReparacion (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT NOT NULL,
    Descripcion TEXT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE,
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID)
);


-- INSERTAR USUARIOS
INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES 
('Ana Mendoza', 'ana.mendoza@mail.com', '3123456789'),
('Luis Herrera', 'luis.herrera@mail.com', '3159876543'),
('Sofia Torres', 'sofia.torres@mail.com', '3196543210');
('Kevin Redondo', 'kevin@gmail.com', '123');

-- INSERTAR EQUIPOS
INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES 
('Laptop', 'Dell Inspiron 15', 1),
('Impresora', 'HP LaserJet Pro', 2),
('Celular', 'Samsung Galaxy S21', 3);

-- INSERTAR TECNICOS
INSERT INTO Tecnicos (Nombre, Especialidad) VALUES 
('Carlos Pérez', 'Hardware'),
('Mariana Gómez', 'Software'),
('Diego López', 'Redes');

-- INSERTAR REPARACIONES
INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES 
(1, '2024-03-01', 'Pendiente'),
(2, '2024-03-02', 'En Proceso'),
(3, '2024-03-03', 'Completado');

-- INSERTAR ASIGNACIONES
INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES 
(1, 1, '2024-03-02'),
(2, 2, '2024-03-03'),
(3, 3, '2024-03-04');

-- INSERTAR DETALLES DE REPARACION
INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES 
(1, 'Cambio de disco duro y reinstalación de sistema operativo', '2024-03-02', '2024-03-05'),
(2, 'Configuración de drivers y solución de errores en software', '2024-03-03', NULL),
(3, 'Reparación de pantalla rota y calibración de colores', '2024-03-04', '2024-03-06');


-- Insertar Usuario
CREATE PROCEDURE InsertarUsuario
    @Nombre VARCHAR(100),
    @CorreoElectronico VARCHAR(100),
    @Telefono VARCHAR(15)
AS
BEGIN
    INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono)
    VALUES (@Nombre, @CorreoElectronico, @Telefono);
END;

-- Obtener Usuarios
CREATE PROCEDURE ObtenerUsuarios
AS
BEGIN
    SELECT * FROM Usuarios;
END;

-- Actualizar Usuario
CREATE PROCEDURE ActualizarUsuario
    @UsuarioID INT,
    @Nombre VARCHAR(100),
    @CorreoElectronico VARCHAR(100),
    @Telefono VARCHAR(15)
AS
BEGIN
    UPDATE Usuarios 
    SET Nombre = @Nombre, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono
    WHERE UsuarioID = @UsuarioID;
END;

-- Eliminar Usuario
CREATE PROCEDURE EliminarUsuario
    @UsuarioID INT
AS
BEGIN
    DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID;
END;


-- Insertar Equipo
CREATE PROCEDURE InsertarEquipo
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(100),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID)
    VALUES (@TipoEquipo, @Modelo, @UsuarioID);
END;

-- Obtener Equipos
CREATE PROCEDURE ObtenerEquipos
AS
BEGIN
    SELECT * FROM Equipos;
END;

-- Actualizar Equipo
CREATE PROCEDURE ActualizarEquipo
    @EquipoID INT,
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(100),
    @UsuarioID INT
AS
BEGIN
    UPDATE Equipos
    SET TipoEquipo = @TipoEquipo,
        Modelo = @Modelo,
        UsuarioID = @UsuarioID
    WHERE EquipoID = @EquipoID;
END;

-- Eliminar Equipo
CREATE PROCEDURE EliminarEquipo
    @EquipoID INT
AS
BEGIN
    DELETE FROM Equipos WHERE EquipoID = @EquipoID;
END;



-- Insertar Tecnico
CREATE PROCEDURE InsertarTecnico
    @Nombre VARCHAR(100),
    @Especialidad VARCHAR(100)
AS
BEGIN
    INSERT INTO Tecnicos (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad);
END;

-- Obtener Tecnicos
CREATE PROCEDURE ObtenerTecnicos
AS
BEGIN
    SELECT * FROM Tecnicos;
END;


-- Actualizar Tecnico
CREATE PROCEDURE ActualizarTecnico
    @TecnicoID INT,
    @Nombre VARCHAR(100),
    @Especialidad VARCHAR(100)
AS
BEGIN
    UPDATE Tecnicos
    SET Nombre = @Nombre,
        Especialidad = @Especialidad
    WHERE TecnicoID = @TecnicoID;
END;

-- Eliminar Tecnico
CREATE PROCEDURE EliminarTecnico
    @TecnicoID INT
AS
BEGIN
    DELETE FROM Tecnicos WHERE TecnicoID = @TecnicoID;
END;


-- Insertar Reparacion
CREATE PROCEDURE InsertarReparacion
    @EquipoID INT,
    @FechaSolicitud DATE,
    @Estado VARCHAR(50)
AS
BEGIN
    INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado)
    VALUES (@EquipoID, @FechaSolicitud, @Estado);
END;

-- Obtener Reparaciones
CREATE PROCEDURE ObtenerReparaciones
AS
BEGIN
    SELECT * FROM Reparaciones;
END;

-- Actualizar Reparacion
CREATE PROCEDURE ActualizarReparacion
    @ReparacionID INT,
    @EquipoID INT,
    @FechaSolicitud DATE,
    @Estado VARCHAR(50)
AS
BEGIN
    UPDATE Reparaciones
    SET EquipoID = @EquipoID,
        FechaSolicitud = @FechaSolicitud,
        Estado = @Estado
    WHERE ReparacionID = @ReparacionID;
END;

-- Eliminar Reparacion
CREATE PROCEDURE EliminarReparacion
    @ReparacionID INT
AS
BEGIN
    DELETE FROM Reparaciones WHERE ReparacionID = @ReparacionID;
END;


-- Insertar Asignacion
CREATE PROCEDURE InsertarAsignacion
    @ReparacionID INT,
    @TecnicoID INT,
    @FechaAsignacion DATE
AS
BEGIN
    INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion)
    VALUES (@ReparacionID, @TecnicoID, @FechaAsignacion);
END;

-- Obtener Asignaciones
CREATE PROCEDURE ObtenerAsignaciones
AS
BEGIN
    SELECT * FROM Asignaciones;
END;

-- Actualizar Asignacion
CREATE PROCEDURE ActualizarAsignacion
    @AsignacionID INT,
    @ReparacionID INT,
    @TecnicoID INT,
    @FechaAsignacion DATE
AS
BEGIN
    UPDATE Asignaciones
    SET ReparacionID = @ReparacionID,
        TecnicoID = @TecnicoID,
        FechaAsignacion = @FechaAsignacion
    WHERE AsignacionID = @AsignacionID;
END;

-- Eliminar Asignacion
CREATE PROCEDURE EliminarAsignacion
    @AsignacionID INT
AS
BEGIN
    DELETE FROM Asignaciones WHERE AsignacionID = @AsignacionID;
END;


-- Insertar Detalle de Reparacion
CREATE PROCEDURE InsertarDetalleReparacion
    @ReparacionID INT,
    @Descripcion TEXT,
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin)
    VALUES (@ReparacionID, @Descripcion, @FechaInicio, @FechaFin);
END;

-- Obtener Detalles de Reparacion
CREATE PROCEDURE ObtenerDetallesReparacion
AS
BEGIN
    SELECT * FROM DetallesReparacion;
END;

-- Actualizar Detalle de Reparacion
CREATE PROCEDURE ActualizarDetalleReparacion
    @DetalleID INT,
    @ReparacionID INT,
    @Descripcion TEXT,
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    UPDATE DetallesReparacion
    SET ReparacionID = @ReparacionID,
        Descripcion = @Descripcion,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin
    WHERE DetalleID = @DetalleID;
END;

-- Eliminar Detalle de Reparacion
CREATE PROCEDURE EliminarDetalleReparacion
    @DetalleID INT
AS
BEGIN
    DELETE FROM DetallesReparacion WHERE DetalleID = @DetalleID;
END;




-- ObtenerAsignacionPorID
CREATE PROCEDURE ObtenerAsignacionPorID
    @ID INT
AS
BEGIN
    SELECT * FROM Asignaciones WHERE AsignacionID = @ID;
END;

-- ObtenerDetalleReparacionPorID
CREATE PROCEDURE ObtenerDetalleReparacionPorID
    @DetalleID INT
AS
BEGIN
    SELECT * FROM DetallesReparacion WHERE DetalleID = @DetalleID;
END;

-- ObtenerDetallesPorReparacion
CREATE PROCEDURE ObtenerDetallesPorReparacion
    @ReparacionID INT
AS
BEGIN
    SELECT * FROM DetallesReparacion WHERE ReparacionID = @ReparacionID;
END;

-- ObtenerEquipoPorID
CREATE PROCEDURE ObtenerEquipoPorID
    @ID INT
AS
BEGIN
    SELECT * FROM Equipos WHERE EquipoID = @ID;
END;

-- ObtenerReparacionPorID
CREATE PROCEDURE ObtenerReparacionPorID
    @ID INT
AS
BEGIN
    SELECT * FROM Reparaciones WHERE ReparacionID = @ID;
END;

-- ObtenerTecnicoPorID
CREATE PROCEDURE ObtenerTecnicoPorID
    @ID INT
AS
BEGIN
    SELECT * FROM Tecnicos WHERE TecnicoID = @ID;
END;

-- ObtenerNombreTecnico
CREATE PROCEDURE ObtenerNombreTecnico
    @ID INT
AS
BEGIN
    SELECT Nombre, Especialidad FROM Tecnicos WHERE TecnicoID = @ID;
END;

-- ObtenerUsuarioPorID
CREATE PROCEDURE ObtenerUsuarioPorID
    @UsuarioID INT
AS
BEGIN
    SELECT * FROM Usuarios WHERE UsuarioID = @UsuarioID;
END;

-- ValidarUsuario
CREATE PROCEDURE ValidarUsuario
    @CorreoElectronico VARCHAR(100),
    @Telefono VARCHAR(15)
AS
BEGIN
    SELECT COUNT(*) FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico AND Telefono = @Telefono;
END;

-- ObtenerInfoReparacion
CREATE PROCEDURE ObtenerInfoReparacion
    @ID INT
AS
BEGIN
    SELECT e.Modelo, r.Estado 
    FROM Reparaciones r 
    JOIN Equipos e ON r.EquipoID = e.EquipoID 
    WHERE r.ReparacionID = @ID;
END;




-- VER TODOS LOS USUARIOS
SELECT * FROM Usuarios;

