using API_RFID.Models;
namespace API_RFID.Services;

public class TrabajadoresService : ITrabajadoresService
{
    EntradasContext context;

    public TrabajadoresService(EntradasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Trabajador> Get()
    {
        return context.Trabajadores;
    }

    public Trabajador GetTrabajador(int id)
    {
        return context.Trabajadores.Find(id);
    }

    public void Save(Trabajador trabajador)
    {
        context.Trabajadores.Add(trabajador);
        context.SaveChanges();
    }

    public void Update(int id, Trabajador trabajador)
    {
        var trabajadorActual = context.Trabajadores.Find(id);

        if (trabajadorActual != null)
        {
            trabajadorActual.AreaID = trabajador.AreaID;
            trabajadorActual.TipoTurnoID = trabajador.TipoTurnoID;
            trabajadorActual.RfidCode = trabajador.RfidCode;
            trabajadorActual.Nombres = trabajador.Nombres;
            trabajadorActual.A_Paterno = trabajador.A_Paterno;
            trabajadorActual.A_Materno = trabajador.A_Materno;
            trabajadorActual.Rfc = trabajador.Rfc;
            trabajadorActual.Curp = trabajador.Curp;
            trabajadorActual.Email = trabajador.Email;

            context.Trabajadores.Update(trabajadorActual);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var trabajadorActual = context.Trabajadores.Find(id);

        if (trabajadorActual != null)
        {
            context.Remove(trabajadorActual);
            context.SaveChanges();
        }
    }
}

public interface ITrabajadoresService
{
    IEnumerable<Trabajador> Get();
    Trabajador GetTrabajador(int id);
    void Save(Trabajador trabajador);
    void Update(int id, Trabajador trabajador);
    void Delete(int id);
}