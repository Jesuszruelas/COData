CREATE PROCEDURE Del_Reporte
    @Id INT
AS
BEGIN
    -- Verificar si el reporte existe
    IF EXISTS (SELECT 1 FROM Reportes WHERE Id = @Id)
    BEGIN
        -- Guardar información del reporte antes de eliminarlo
        DECLARE @Descripcion VARCHAR(255);
        SELECT @Descripcion = Descripcion FROM Reportes WHERE Id = @Id;
        
        -- Eliminar el reporte
        DELETE FROM Reportes WHERE Id = @Id;
        
        -- Mensaje de confirmación
        SELECT 'Reporte eliminado exitosamente: ' + @Descripcion AS Mensaje;
    END
    ELSE
    BEGIN
        -- Si no existe el reporte
        SELECT 'Error: No se encontró el reporte con ID ' + CAST(@Id AS VARCHAR(10)) AS Mensaje;
    END
END