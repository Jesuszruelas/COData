CREATE PROCEDURE Del_Ubicacion
    @Id INT
AS
BEGIN
    -- Verificar si la ubicación existe
    IF EXISTS (SELECT 1 FROM Ubicaciones WHERE Id = @Id)
    BEGIN
        -- Guardar información de la ubicación antes de eliminarla
        DECLARE @Descripcion NVARCHAR(255);
        SELECT @Descripcion = Descripcion FROM Ubicaciones WHERE Id = @Id;
        
        -- Eliminar la ubicación
        DELETE FROM Ubicaciones WHERE Id = @Id;
        
        -- Mensaje de confirmación
        SELECT 'Ubicación eliminada exitosamente: ' + @Descripcion AS Mensaje;
    END
    ELSE
    BEGIN
        -- Si no existe la ubicación
        SELECT 'Error: No se encontró la ubicación con ID ' + CAST(@Id AS VARCHAR(10)) AS Mensaje;
    END
END