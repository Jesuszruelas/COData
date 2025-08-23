EXEC Ins_Reporte 
    @Descripcion = 'Fuga de agua en calle principal', 
    @Prioridad = 'Alta'

-- 2. CONSULTAR todos los reportes
EXEC Ver_Reportes

-- 3. CONSULTAR reporte específico por ID
EXEC Ver_Reportes @Id = 1

-- 4. CONSULTAR reportes por prioridad
EXEC Ver_Reportes @Prioridad = 'Crítica'

-- 5. ACTUALIZAR un reporte
EXEC Upd_Reporte 
    @Id = 1,
    @Descripcion = 'Fuga de agua reparada - seguimiento', 
    @Prioridad = 'Media'

-- 6. ELIMINAR un reporte
EXEC Del_Reporte @Id = 1

-- 7. Verificar cambios
SELECT * FROM Reportes