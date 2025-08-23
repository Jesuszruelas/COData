CREATE PROCEDURE Ins_Reporte
    @Descripcion VARCHAR(255),
    @Prioridad VARCHAR(20), 
    @FechaRegistro DATETIME = NULL
AS
BEGIN
    IF @FechaRegistro IS NULL
        SET @FechaRegistro = GETDATE();

    INSERT INTO Reportes (Descripcion, Prioridad, FechaRegistro)
    VALUES (@Descripcion, @Prioridad, @FechaRegistro);
END


    select * from Reportes