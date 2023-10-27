using System.ComponentModel.DataAnnotations;

public class Clientes
{
    [Key]
    public int ClienteId {get; set;}

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [StringLength(40, MinimumLength =2, ErrorMessage ="El campo {0} debe de contener minimo {2} y maximo {1}")]
    [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage ="El campo {0} solo debe de contener caracteres")]
    public string Nombre {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [RegularExpression(@"^[0-9- \s]{10,12}$", ErrorMessage ="Debe de insertar un numero telefonico con el formato correcto")]
    [Phone]
    public string Telefono {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [RegularExpression(@"^[0-9- \s]{10,12}$", ErrorMessage ="Debe de insertar un numero de celular con el formato correcto")]
    [Phone]
    public string Celular {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [StringLength(12, MinimumLength =11, ErrorMessage ="El {0} debe de contener minimo {2} caracteres y maximo {1} caracteres")]
    public string Rnc {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [EmailAddress]
    public string Email {get; set;} = string.Empty;

    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [StringLength(90, MinimumLength =4, ErrorMessage ="El campo {0} debe de contener entre {2} y {1} caracteres")]
    public string Direccion {get; set;} = string.Empty;
}