DROP DATABASE Gimnacio;
-- CREATE DATABASE Gimnacio;
-- USE Gimnacio;
USE master;
-- TABLES
CREATE TABLE Usuarios (
	IdUsuario INT IDENTITY(1,1),
	tipo VARCHAR(12),
	nombre NVARCHAR(30),
	apellidoPaterno NVARCHAR(20),
	apellidoMaterno NVARCHAR(20),
	correoElectronico NVARCHAR(50),
	contrasena NVARCHAR(64),
	IdMiembro INT

	PRIMARY KEY(IdUsuario)
);

CREATE TABLE Miembros (
	IdMiembro INT IDENTITY(1,1),
	fechaIngreso DATE,
	IdMembresia INT,

	PRIMARY KEY(IdMiembro)
);

CREATE TABLE Pagos (
	IdPago INT IDENTITY(1,1),
	cantidad MONEY,
	motivo NVARCHAR(40),
	IdMiembro INT,

	PRIMARY KEY(IdPago)
);

CREATE TABLE Membresias (
	IdMembresia INT IDENTITY(1,1),
	costoMensual MONEY,
	descripcion NVARCHAR(50)

	PRIMARY KEY(IdMembresia)
);

CREATE TABLE MiembrosClases (
	IdMiembroClase INT IDENTITY(1,1),
	IdMiembro INT,
	IdClase INT

	PRIMARY KEY(IdMiembroClase)
);

CREATE TABLE Clases (
	IdClase INT IDENTITY(1,1),
	fecha DATETIME,
	cupoMaximo INT,
	comentarios NVARCHAR(200),
	tipo NVARCHAR(20),
	IdEntrenador INT

	PRIMARY KEY(IdClase)
);


-- CONSTRAINTS
ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuario_Miembro
FOREIGN KEY (IdMiembro) REFERENCES Miembros(IdMiembro) ON DELETE CASCADE;

ALTER TABLE Miembros
ADD CONSTRAINT FK_Miembro_Membresía
FOREIGN KEY (IdMembresia) REFERENCES Membresias(IdMembresia) ON DELETE CASCADE;

ALTER TABLE Pagos
ADD CONSTRAINT FK_Pago_Miembro
FOREIGN KEY (IdMiembro) REFERENCES Miembros(IdMiembro) ON DELETE CASCADE;

ALTER TABLE MiembrosClases
ADD CONSTRAINT FK_MiembroClase_Miembro
FOREIGN KEY (IdMiembro) REFERENCES Miembros(IdMiembro) ON DELETE CASCADE;

ALTER TABLE MiembrosClases
ADD CONSTRAINT FK_MiembroClase_Clase
FOREIGN KEY (IdClase) REFERENCES Clases(IdClase) ON DELETE CASCADE;

ALTER TABLE Clases
ADD CONSTRAINT FK_Clase_Entrenador
FOREIGN KEY (IdEntrenador) REFERENCES Usuarios(IdUsuario) ON DELETE NO ACTION;


-- Datos Precargados
INSERT INTO Membresias (costoMensual, descripcion) VALUES ('$400.00', 'Membresía estándar');
INSERT INTO Miembros (fechaIngreso, IdMembresia) VALUES ('2024-05-10', 1);

INSERT INTO Usuarios (tipo, nombre, apellidoPaterno, apellidoMaterno, correoElectronico, contrasena) VALUES ('Miembro', 'José Armando', 'Reyes', 'Rodríguez', 'armando@gmail.com', 'a05bf9fea0d40dd8d8af546214e00547d4e1bbb489c91ce4803a620e5e1e7844');
INSERT INTO Usuarios (tipo, nombre, apellidoPaterno, apellidoMaterno, correoElectronico, contrasena) VALUES ('Entrenador', 'Jesús Manuel', 'Mújica', 'Conde', 'jesus@gmail.com', '138ff2912c5fca8b3411d11a4be3439d068525f543c9af8eab47b8ec338e2139');
INSERT INTO Usuarios (tipo, nombre, apellidoPaterno, apellidoMaterno, correoElectronico, contrasena) VALUES ('Admin', 'Samuel Elías', 'Gaona', 'Hernández', 'samuel@gmail.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

-- Consultas
SELECT * FROM Usuarios;
SELECT * FROM Miembros;
SELECT * FROM Membresias;
SELECT * FROM Clases;