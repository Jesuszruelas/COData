-- 1. INSERTAR una ubicación
EXEC Ins_Ubicacion 
    @Descripcion = 'Plaza Principal del Centro',
    @Latitud = 19.432608,
    @Longitud = -99.133209

-- 2. INSERTAR otra ubicación
EXEC Ins_Ubicacion 
    @Descripcion = 'Parque de la Colonia Norte',
    @Latitud = 19.445123,
    @Longitud = -99.145876

-- 3. CONSULTAR todas las ubicaciones
EXEC Ver_Ubicaciones

-- 4. CONSULTAR ubicación específica por ID
EXEC Ver_Ubicaciones @Id = 1

-- 5. BUSCAR ubicaciones por descripción
EXEC Ver_Ubicaciones @BuscarDescripcion = 'Plaza'

-- 6. ACTUALIZAR una ubicación
EXEC Upd_Ubicacion 
    @Id = 1,
    @Descripcion = 'Plaza Principal - Centro Histórico',
    @Latitud = 19.432800,
    @Longitud = -99.133100

-- 7. ELIMINAR una ubicación
EXEC Del_Ubicacion @Id = 2

-- 8. Verificar cambios
SELECT * FROM Ubicaciones