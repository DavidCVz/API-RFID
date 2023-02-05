using API_RFID.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_RFID.Models;

public class Trabajador
{
    // Claves de entidad
    public int TrabajadorID {get; set;}
    public int? AreaID {get; set;}
    public int? TipoTurnoID {get; set;}

    // Atributos de entidad
    public string RfidCode {get; set;}
    public string Nombres {get; set;}
    public string A_Paterno {get; set;}
    public string A_Materno {get; set;}
    public string Rfc {get; set;}
    public string Curp {get; set;}
    public string Email {get; set;}

    // Atributos relacionales
    //Padres
    public virtual Area Area { get; set; }
    public virtual TipoTurno TipoTurno { get; set; }
    
    //Hijo
    public virtual ICollection<EntradaSalida> Entradas { get; set; }

}