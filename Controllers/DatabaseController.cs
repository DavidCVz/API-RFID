using Microsoft.AspNetCore.Mvc;
using API_RFID.Services;
using API_RFID.Models;

namespace API_RFID.Controllers;

[Route("/dbconection")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class DatabaseController : ControllerBase
{
    EntradasContext context;

    public DatabaseController(EntradasContext dbcontext)
    {
        context = dbcontext;
    }

    // Retorna una consulta de todos los datos
    [HttpGet]
    public IActionResult Get()
    {
        context.Database.EnsureCreated();
        return Ok("BD creada correctamente");
    }
}