using API_RFID.Models;

namespace API_RFID.Seeds;

public class ContextSeeds
{

    #region AREAS
    private static readonly string[] nombreAreas = new[]
    {
        "Administración y Finanzas", "Calidad administrativa", "Calidad de proyectos",
        "Compras", "Almacén", "Recursos Humanos", "Construcción", "Ingeniería", "Aplicaciones",
        "Higiene", "Soporte Técnico", "Area de ventas", "Desarrollo"
    };

    public List<Area> GetAreasSeed()
    {
        var areaInit = new List<Area>();

        for (int i = 0; i < nombreAreas.Length; i++)
        {
            areaInit.Add(new Area { 
                AreaID = i+1,
                Nombre = nombreAreas[i],
            });
        }

        return areaInit;
    }
    #endregion AREAS

    #region TIPO DE TURNOS
    public List<TipoTurno> GetTurnosSeed()
    {
        var turnosInit = new List<TipoTurno>();
        turnosInit.Add(new TipoTurno { 
            TipoTurnoID = 1, 
            Nombre = "Normal", 
            Entrada = new TimeSpan(8, 0, 0),
            Salida = new TimeSpan(19, 0, 0)
        });

        turnosInit.Add(new TipoTurno { 
            TipoTurnoID = 1, 
            Nombre = "Normal", 
            Entrada = new TimeSpan(7, 0, 0),
            Salida = new TimeSpan(18, 0, 0)
        });

        return turnosInit;
    }
    #endregion TIPO DE TURNOS

    #region TRABAJADORES
    public List<Trabajador> GetTrabajadoresSeed()
    {
        var trabajadorInit = new List<Trabajador>();

        trabajadorInit.Add( new Trabajador{
            TrabajadorID = 1,
            AreaID = 13,
            TipoTurnoID = 1,
            RfidCode = "0000145236",
            Nombres = "David",
            A_Paterno = "Carrillo",
            A_Materno = "Velazquez",
            Rfc = "CAVD990306LS4",
            Curp = "CAVD990306HVZRLV01",
            Email = "davidacarrillovz@outlook.com"
        });

        trabajadorInit.Add( new Trabajador{
            TrabajadorID = 2,
            AreaID = 3,
            TipoTurnoID = 1,
            RfidCode = "0000145233",
            Nombres = "Juan Manuel",
            A_Paterno = "Torres",
            A_Materno = "Beltrán",
            Rfc = "TOBJ980528ZK8",
            Curp = "TOBJ980528JUT9P4",
            Email = "juanmanueltb06@outlook.com"
        });

        trabajadorInit.Add( new Trabajador{
            TrabajadorID = 3,
            AreaID = 10,
            TipoTurnoID = 2,
            RfidCode = "0000145234",
            Nombres = "Oscar",
            A_Paterno = "Jimenez",
            A_Materno = "Shimabuko",
            Rfc = "JISO980619MI6",
            Curp = "JISO980619HVJRMK07",
            Email = "oscjimenez55@outlook.com"
        });

        trabajadorInit.Add( new Trabajador{
            TrabajadorID = 4,
            AreaID = 11,
            TipoTurnoID = 1,
            RfidCode = "0000145235",
            Nombres = "Márcos Antonio",
            A_Paterno = "Gonzalez",
            A_Materno = "Belmán",
            Rfc = "GOBM990427YU9",
            Curp = "GOBM990427HVZRBB41",
            Email = "marcosgblm99@outlook.com"
        });

        return trabajadorInit;
    }
    #endregion TRABAJADORES

}
