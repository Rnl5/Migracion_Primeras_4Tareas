using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tickets
{
    [Key]
    public int TicketId {get; set;}

    [Required(ErrorMessage ="Debe de insertar una Fecha")]
    public DateTime Fecha {get; set;} = DateTime.Now;

    [ForeignKey("ClienteId")]
    public int ClienteId {get; set;}

    [ForeignKey("SistemaId")]
    public int SistemaId {get; set;}

    [ForeignKey("PrioridadId")]
    public int PrioridadId {get; set;}

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [StringLength(40, ErrorMessage ="Ha insertado mas de {1} caracteres")]
    [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage ="El campo {0} solo debe de contener caracteres alfabeticos")]
    public string SolicitadoPor {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [StringLength(70, MinimumLength =5, ErrorMessage ="El campo {0} debe de tener entre {2} a {1} caracteres")]
    public string Asunto {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [StringLength(80, MinimumLength = 5, ErrorMessage ="El campo {0} debe de tener entre {2} a {1} caracteres")]
    public string Descripcion {get; set;} = string.Empty;
}