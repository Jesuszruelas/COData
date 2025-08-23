CREATE PROCEDURE Ver_Ubicaciones
    @Id INT = NULL,
    @BuscarDescripcion NVARCHAR(255) = NULL
AS
BEGIN
    -- Si se proporciona ID específico
    IF @Id IS NOT NULL
    BEGIN
        SELECT Id, Descripcion, Latitud, Longitud, FechaRegistro
        FROM Ubicaciones 
        WHERE Id = @Id;
    END
    -- Si se busca por descripción (búsqueda parcial)
    ELSE IF @BuscarDescripcion IS NOT NULL
    BEGIN
        SELECT Id, Descripcion, Latitud, Longitud, FechaRegistro
        FROM Ubicaciones 
        WHERE Descripcion LIKE '%' + @BuscarDescripcion + '%'
        ORDER BY FechaRegistro DESC;
    END
    -- Si no se especifica nada, mostrar todas
    ELSE
    BEGIN
        SELECT Id, Descripcion, Latitud, Longitud, FechaRegistro
        FROM Ubicaciones 
        ORDER BY FechaRegistro DESC;
    END
END