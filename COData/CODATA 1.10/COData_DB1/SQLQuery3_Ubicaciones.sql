CREATE TABLE Ubicaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Descripcion NVARCHAR(255) NOT NULL,
    Latitud DECIMAL(9,6) NOT NULL,    
    Longitud DECIMAL(9,6) NOT NULL,    
    FechaRegistro DATETIME DEFAULT GETDATE() 
);


INSERT INTO Ubicaciones (Descripcion, Latitud, Longitud)
VALUES 
('Parque Central', 19.432608, -99.133209),
('Escuela Primaria', 19.430100, -99.135500);

SELECT * FROM Ubicaciones;
