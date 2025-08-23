CREATE TABLE Reportes (
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Descripcion VARCHAR(255) NOT NULL,
    Prioridad VARCHAR(20) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE() 
);

INSERT INTO Reportes (Descripcion, Prioridad) VALUES
('Bache grande en la calle principal cerca del mercado', 'Alta'),
('Poste de alumbrado público sin luz en la avenida central', 'Crítica'),
('Acumulación de basura en la esquina de la calle 5', 'Media'),
('Fuga de agua en la calle Juárez esquina con Reforma', 'Alta'),
('Semáforo descompuesto en el cruce principal', 'Alta'),
('Árbol caído obstruyendo la banqueta', 'Media'),
('Ruido excesivo en zona residencial durante la noche', 'Baja'),
('Falta de recolección de basura en el barrio norte', 'Media'),
('Grafitis en la fachada de un edificio público', 'Baja'),
('Alcantarilla sin tapa en calle secundaria', 'Crítica');


select * from reportes
