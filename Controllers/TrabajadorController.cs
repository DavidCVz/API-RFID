using Microsoft.AspNetCore.Mvc;
using API_RFID.Services;
using API_RFID.Models;

namespace API_RFID.Controllers;

[Route("[controller]")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class TrabajadorController : ControllerBase
{
    ITrabajadoresService trabajadorService;

    public TrabajadorController(ITrabajadoresService service)
    {
        trabajadorService = service;
    }

    // Retorna una consulta de todos los datos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(trabajadorService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetTrabajador(int id)
    {
        var trabajador = trabajadorService.GetTrabajador(id);
        if (trabajador != null)
        {
            return Ok(trabajadorService.GetTrabajador(id));
        }else{
            return Ok(null);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Trabajador trabajador)
    {
        trabajadorService.Save(trabajador);
        return Ok("Registro guardado con exito");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Trabajador trabajador)
    {
        trabajadorService.Update(id, trabajador);
        return Ok("Actualizacion exitosa");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        trabajadorService.Delete(id);
        return Ok();
    }
}