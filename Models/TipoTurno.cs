using API_RFID.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_RFID.Models;

public class TipoTurno
{
    // Clave de entidad
    public int TipoTurnoID {get; set;}

    // Atributos de entidad
    public string Nombre {get; set;}
    public TimeSpan Entrada {get; set;}
    public TimeSpan Salida {get; set;}

    // Atributos relacionales
    [JsonIgnore] // Atributo que hace que cuando se haga una consulta
    // No devuelva todos los registros de este atributo
    public virtual ICollection<Trabajador> Trabajadores { get; set; }
}