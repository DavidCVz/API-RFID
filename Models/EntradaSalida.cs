using API_RFID.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

public class EntradaSalida
{
    // Claves de entidad
    public int Id {get; set;}
    public int? TrabajadorID {get; set;}

    // Atributos de entidad
    public string RfidCode {get; set;}
    public string NombresT {get; set;}
    public string A_PaternoT {get; set;}
    public string A_MaternoT {get; set;}
    public string RfcT {get; set;}
    public DateTime Fecha {get; set;}
    public string NombreTurno {get; set;}
    public string NombreArea {get; set;}
    public bool Entrada {get; set;}

    // Atributo relacional
    //Padre
    public virtual Trabajador Trabajador { get; set; }
}

public class RfidData
{
    public string rfidCode {get; set;}
}

public class ParamsDelete
{
    public bool proceder {get; set;}
}