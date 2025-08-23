CREATE PROCEDURE Ins_Ubicacion
    @Descripcion NVARCHAR(255),
    @Latitud DECIMAL(9,6),
    @Longitud DECIMAL(9,6),
    @FechaRegistro DATETIME = NULL
AS
BEGIN
    -- Si no se proporciona fecha, usar la actual
    IF @FechaRegistro IS NULL
        SET @FechaRegistro = GETDATE();

    INSERT INTO Ubicaciones (Descripcion, Latitud, Longitud, FechaRegistro)
    VALUES (@Descripcion, @Latitud, @Longitud, @FechaRegistro);
    
    -- Mensaje de confirmación
    SELECT 'Ubicación registrada exitosamente' AS Mensaje;
END