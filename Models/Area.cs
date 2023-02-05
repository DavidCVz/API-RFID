using API_RFID.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_RFID.Models;

public class Area
{
    // Clave de entidad
    public int AreaID {get; set;}

    // Atributo de entidad
    public string Nombre {get; set;}

    //Atributo relacional
    [JsonIgnore] // Atributo que hace que cuando se haga una consulta
    // No devuelva todos los registros de este atributo
    public virtual ICollection<Trabajador> Trabajadores { get; set; }

}