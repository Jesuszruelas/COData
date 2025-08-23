CREATE PROCEDURE Upd_Reporte
    @Id INT,
    @Descripcion VARCHAR(255),
    @Prioridad VARCHAR(20)
AS
BEGIN
    -- Verificar si el reporte existe
    IF EXISTS (SELECT 1 FROM Reportes WHERE Id = @Id)
    BEGIN
        UPDATE Reportes 
        SET 
            Descripcion = @Descripcion,
            Prioridad = @Prioridad
        WHERE Id = @Id;
        
        -- Mensaje de confirmación
        SELECT 'Reporte actualizado exitosamente' AS Mensaje;
    END
    ELSE
    BEGIN
        -- Si no existe el reporte
        SELECT 'Error: No se encontró el reporte con ID ' + CAST(@Id AS VARCHAR(10)) AS Mensaje;
    END
END

select * from reportes