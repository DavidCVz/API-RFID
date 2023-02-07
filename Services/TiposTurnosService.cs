using API_RFID.Models;
namespace API_RFID.Services;

public class TiposTurnosService : ITiposTurnosService
{
    EntradasContext context;

    public TiposTurnosService(EntradasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<TipoTurno> Get()
    {
        return context.TipoTurnos;
    }

    public void Save(TipoTurno tipoTurno)
    {
        context.TipoTurnos.Add(tipoTurno);
        context.SaveChanges();
    }

    public void Update(int id, TipoTurno tipoTurno)
    {
        var turnoActual = context.TipoTurnos.Find(id);

        if (turnoActual != null)
        {
            turnoActual.Nombre = tipoTurno.Nombre;
            turnoActual.Entrada = tipoTurno.Entrada;
            turnoActual.Salida = tipoTurno.Salida;
            context.TipoTurnos.Update(turnoActual);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var turnoActual = context.TipoTurnos.Find(id);

        if (turnoActual != null)
        {
            context.Remove(turnoActual);
            context.SaveChanges();
        }
    }
}

public interface ITiposTurnosService
{
    IEnumerable<TipoTurno> Get();
    void Save(TipoTurno tipoTurno);
    void Update(int id, TipoTurno tipoTurno);
    void Delete(int id);
}