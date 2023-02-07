using Microsoft.AspNetCore.Mvc;
using API_RFID.Services;
using API_RFID.Models;

namespace API_RFID.Controllers;

[Route("[controller]")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class TipoTurnoController : ControllerBase
{
    ITiposTurnosService turnoService;

    public TipoTurnoController(ITiposTurnosService service)
    {
        turnoService = service;
    }

    // Retorna una consulta de todos los datos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(turnoService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] TipoTurno tipoTurno)
    {
        turnoService.Save(tipoTurno);
        return Ok("Registro guardado con exito");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TipoTurno tipoTurno)
    {
        turnoService.Update(id, tipoTurno);
        return Ok("Actualizacion exitosa");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        turnoService.Delete(id);
        return Ok();
    }
}