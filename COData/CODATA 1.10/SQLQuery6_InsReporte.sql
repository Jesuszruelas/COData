EXEC Ins_Reporte 'Poste de luz roto', 'Alta';

EXEC Ins_Reporte 
    @Descripcion = 'Sistema de agua deficiente', 
    @Prioridad = 'Crítica'

select * from Reportes