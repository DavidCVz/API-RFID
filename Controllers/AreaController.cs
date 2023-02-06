using Microsoft.AspNetCore.Mvc;
using API_RFID.Services;
using API_RFID.Models;

namespace API_RFID.Controllers;

[Route("[controller]")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class AreaController : ControllerBase
{
    IAreasService areaService;

    public AreaController(IAreasService service)
    {
        areaService = service;
    }

    // Retorna una consulta de todos los datos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(areaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Area area)
    {
        areaService.Save(area);
        return Ok("Registro guardado con exito");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Area area)
    {
        areaService.Update(id, area);
        return Ok("Actualizacion exitosa");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        areaService.Delete(id);
        return Ok();
    }
}