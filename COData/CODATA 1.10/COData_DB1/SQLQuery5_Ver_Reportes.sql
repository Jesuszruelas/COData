CREATE PROCEDURE Ver_Reportes
    @Id INT = NULL,
    @Prioridad VARCHAR(20) = NULL
AS
BEGIN
    -- Si se proporciona ID específico
    IF @Id IS NOT NULL
    BEGIN
        SELECT Id, Descripcion, Prioridad, FechaRegistro
        FROM Reportes 
        WHERE Id = @Id;
    END
    -- Si se filtra por prioridad
    ELSE IF @Prioridad IS NOT NULL
    BEGIN
        SELECT Id, Descripcion, Prioridad, FechaRegistro
        FROM Reportes 
        WHERE Prioridad = @Prioridad
        ORDER BY FechaRegistro DESC;
    END
    -- Si no se especifica nada, mostrar todos
    ELSE
    BEGIN
        SELECT Id, Descripcion, Prioridad, FechaRegistro
        FROM Reportes 
        ORDER BY FechaRegistro DESC;
    END
END

