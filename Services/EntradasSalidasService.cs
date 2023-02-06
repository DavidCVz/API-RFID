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

    public void Save(string rfidCode)
    {
        bool ultimaEntrada;
        try{
            ultimaEntrada = (from e in context.EntradasSalidas
                                where e.RfidCode == rfidCode
                                select e.Entrada).Single();
        }catch(System.InvalidOperationException e){
            ultimaEntrada = false;
        }

        Console.WriteLine($"Ultima entrada: {ultimaEntrada}");
        try{
            var trabajador = (from t in context.Trabajadores
                        join a in context.Areas on t.AreaID equals a.AreaID
                        join tt in context.TipoTurnos on t.TipoTurnoID equals tt.TipoTurnoID
                        where t.RfidCode == rfidCode
                        select new 
                        {
                            TrabajadorID = t.TrabajadorID,
                            RfidCode = t.RfidCode,
                            NombresT = t.Nombres,
                            A_Paterno = t.A_Paterno,
                            A_Materno = t.A_Materno,
                            RfcT = t.Rfc,
                            Fecha = DateTime.Now,
                            NombreTurno = tt.Nombre,
                            NombreArea = a.Nombre,
                            Entrada = !ultimaEntrada
                        }).Single();
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                trabajador.TrabajadorID, trabajador.RfidCode, trabajador.NombresT,trabajador.A_Paterno,
                trabajador.A_Materno, trabajador.RfcT, trabajador.Fecha, trabajador.NombreTurno,
                trabajador.NombreArea, trabajador.Entrada);
        }catch(Exception e){
            Console.WriteLine("No se encontraron elementos con ese codigo");
        }
        


        /*context.EntradasSalidas.Add(entradaSalida);
        context.SaveChanges(); */
    }
}

public interface IEntradasSalidasService
{
    IEnumerable<EntradaSalida> Get();
    void Save(string rfidCode);
}