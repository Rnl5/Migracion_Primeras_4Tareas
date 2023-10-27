using System.ComponentModel.DataAnnotations;

public class Sistemas
{
    [Key]
    public int SistemaId{get; set;}

    [Required (ErrorMessage = "El campo {0} es requerido")]
    [RegularExpression(@"^[a-zA-Z ]+$",
    ErrorMessage ="Debe de insertar un nombre valido")]
    public string Nombre{get; set;} = string.Empty;
}