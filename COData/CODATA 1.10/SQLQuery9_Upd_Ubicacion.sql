CREATE PROCEDURE Upd_Ubicacion
    @Id INT,
    @Descripcion NVARCHAR(255),
    @Latitud DECIMAL(9,6),
    @Longitud DECIMAL(9,6)
AS
BEGIN
    -- Verificar si la ubicación existe
    IF EXISTS (SELECT 1 FROM Ubicaciones WHERE Id = @Id)
    BEGIN
        UPDATE Ubicaciones 
        SET 
            Descripcion = @Descripcion,
            Latitud = @Latitud,
            Longitud = @Longitud
        WHERE Id = @Id;
        
        -- Mensaje de confirmación
        SELECT 'Ubicación actualizada exitosamente' AS Mensaje;
    END
    ELSE
    BEGIN
        -- Si no existe la ubicación
        SELECT 'Error: No se encontró la ubicación con ID ' + CAST(@Id AS VARCHAR(10)) AS Mensaje;
    END
END