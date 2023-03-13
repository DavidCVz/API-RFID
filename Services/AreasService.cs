using API_RFID.Models;
namespace API_RFID.Services;

public class AreasService : IAreasService
{
    EntradasContext context;

    public AreasService(EntradasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Area> Get()
    {
        return context.Areas;
    }

    public Area GetArea(int id)
    {
        return context.Areas.Find(id);
    }

    public void Save(Area area)
    {
        context.Areas.Add(area);
        context.SaveChanges();
    }

    public void Update(int id, Area area)
    {
        var areaActual = context.Areas.Find(id);

        if (areaActual != null)
        {
            areaActual.Nombre = area.Nombre;
            context.Areas.Update(areaActual);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var areaActual = context.Areas.Find(id);

        if (areaActual != null)
        {
            context.Remove(areaActual);
            context.SaveChanges();
        }
    }
}

public interface IAreasService
{
    IEnumerable<Area> Get();
    Area GetArea(int id);
    void Save(Area area);
    void Update(int id, Area area);
    void Delete(int id);
}