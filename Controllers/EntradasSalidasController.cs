using Microsoft.AspNetCore.Mvc;
using API_RFID.Services;
using API_RFID.Models;

namespace API_RFID.Controllers;

[Route("[controller]")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class EntradasSalidasController : ControllerBase
{
    IEntradasSalidasService entradasService;

    public EntradasSalidasController(IEntradasSalidasService service)
    {
        entradasService = service;
    }

    // Retorna una consulta de todos los datos
    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("Operacion GET");
        return Ok(entradasService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] RfidData rfidData)
    {
        entradasService.Save(rfidData.rfidCode);
        return Ok("Beep... RFID");
    }
}