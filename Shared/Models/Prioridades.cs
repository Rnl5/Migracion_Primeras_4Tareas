using System.ComponentModel.DataAnnotations;

public class Prioridades
{
    [Key]
    public int PrioridadId {get; set;}

    [Required(ErrorMessage ="El campo Descripcion es obligatorio")]
    [StringLength(70, MinimumLength = 5, ErrorMessage ="Debe de introducir entre {0} y {1} caracteres")]
    public string Descripcion {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo DiasCompromiso es obligatorio")]
    [Range(1,31, ErrorMessage ="Los dias son entre {0} y {1} dias")]
    public int DiasCompromiso {get; set;} 
}