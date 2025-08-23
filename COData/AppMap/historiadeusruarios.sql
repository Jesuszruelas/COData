Create DataBase Usuario;

-- Tabla Usuario
create table Tabla_Usuario(
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    apellido NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    rol NVARCHAR(20) CHECK (rol IN ('admin', 'editor', 'lector')) DEFAULT 'lector',
    fecha_registro DATETIME DEFAULT GETDATE()
);

-- Tabla CATEGORIA_DAT
CREATE TABLE CATEGORIA_DAT (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    descripcion NVARCHAR(MAX),
    icono NVARCHAR(30)
);

-- Tabla DATOS_MUNIC
CREATE TABLE DATOS_MUNIC (
    id_dato INT IDENTITY(1,1) PRIMARY KEY,
    id_categoria INT NOT NULL,
    id_usuario INT NOT NULL,
    titulo NVARCHAR(100) NOT NULL,
    contenido NVARCHAR(MAX) NOT NULL,
    fecha_public DATETIME DEFAULT GETDATE(),
    estado NVARCHAR(20) CHECK (estado IN ('publicado', 'borrador', 'archivado')) DEFAULT 'borrador',
    FOREIGN KEY (id_categoria) REFERENCES CATEGORIA_DAT(id_categoria),
    FOREIGN KEY (id_usuario) REFERENCES Tabla_Usuario(id_usuario)
);
