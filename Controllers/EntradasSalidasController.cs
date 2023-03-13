using Microsoft.AspNetCore.Mvc;
using API_RFID.Services;
using API_RFID.Models;

namespace API_RFID.Controllers;

[Route("[controller]")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class EntradasSalidasController : ControllerBase
{
    IEntradasSalidasService entradasService;

    private readonly int records = 5;

    public EntradasSalidasController(IEntradasSalidasService service)
    {
        entradasService = service;
    }

    // Retorna una consulta de todos los datos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(entradasService.Get());
    }

    [HttpGet("historialtrabajador")]
    public IActionResult GetEntradasTrabajador([FromQuery] int? page, int id)
    {
        var hTrabajador = entradasService.GetTrabajador(id);

        int _page = page ?? 1;
        int totalRecords = hTrabajador.Count();
        if (totalRecords == 0)
        {
            return NotFound();
        }

        int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalRecords/records)));

        var res = hTrabajador.Skip((_page-1) * records).Take(records).ToList();
        
        return Ok(new{
            totalPaginas = totalPages,
            resultados = res,
            paginaActual = page
        });
    }

    [HttpPost]
    public IActionResult Post([FromBody] RfidData rfidData)
    {
        int res = entradasService.Save(rfidData.rfidCode);
        if( res == 1) {
            Console.Beep(2000, 500);
            return Ok("Beep... RFID, Acceso correcto"); 
        }else{
            Console.Beep(2000, 500);
            return Ok("Beep... RFID, Tarjeta no reconocida");
        }
    }

    [HttpDelete("{opcion}")]
    public IActionResult DeleteNull(bool opcion)
    {
        if(opcion == true)
        {
            entradasService.DeleteRegistrosNulos();
            return Ok("Registros eliminados de la bitacora");
        }else{ return Ok("Proceso cancelado"); }

    }
}