using API_RFID.Models;
namespace API_RFID.Services;

public class EntradasSalidasService : IEntradasSalidasService
{
    EntradasContext context;

    public EntradasSalidasService(EntradasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<EntradaSalida> Get()
    {
        return context.EntradasSalidas;
    }

    public IEnumerable<EntradaSalida> GetTrabajador(int TrabajadorID)
    {
        return context.EntradasSalidas.Where(p => p.TrabajadorID == TrabajadorID);
    }

    public int Save(string rfidCode)
    {
        bool ultimaEntrada;
        var registro = context.EntradasSalidas
                    .Where(p => p.RfidCode == rfidCode)
                    .OrderByDescending(p => p.Fecha)
                    .FirstOrDefault();

        ultimaEntrada = registro != null ? registro.Entrada : false;

        try{
            var t = (from tr in context.Trabajadores
                        join a in context.Areas on tr.AreaID equals a.AreaID
                        join tt in context.TipoTurnos on tr.TipoTurnoID equals tt.TipoTurnoID
                        where tr.RfidCode == rfidCode
                        select new 
                        {
                            TrabajadorID = tr.TrabajadorID,
                            RfidCode = tr.RfidCode,
                            NombresT = tr.Nombres,
                            A_Paterno = tr.A_Paterno,
                            A_Materno = tr.A_Materno,
                            RfcT = tr.Rfc,
                            Fecha = DateTime.Now,
                            NombreTurno = tt.Nombre,
                            NombreArea = a.Nombre,
                            Entrada = !ultimaEntrada
                        }).Single();
            
            var registroEntrada = new EntradaSalida() {
                TrabajadorID = t.TrabajadorID,
                RfidCode = t.RfidCode,
                NombresT = t.NombresT,
                A_PaternoT = t.A_Paterno,
                A_MaternoT = t.A_Materno,
                RfcT = t.RfcT,
                Fecha = t.Fecha,
                NombreTurno = t.NombreTurno,
                NombreArea = t.NombreArea,
                Entrada = t.Entrada
            };

            context.EntradasSalidas.Add(registroEntrada);
            context.SaveChanges();
            return 1;
        }catch(Exception e){
            Console.WriteLine("No se encontraron elementos con ese codigo");
            return 0;
        }
    }

    public void DeleteRegistrosNulos()
    {
        var consulta = context.EntradasSalidas.Where(p => p.TrabajadorID == null);
        context.RemoveRange(consulta);
        context.SaveChanges();
    }
}

public interface IEntradasSalidasService
{
    IEnumerable<EntradaSalida> Get();
    int Save(string rfidCode);
    IEnumerable<EntradaSalida> GetTrabajador(int TrabajadorID);
    void DeleteRegistrosNulos();
}