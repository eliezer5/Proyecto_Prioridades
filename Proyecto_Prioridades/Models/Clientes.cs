using System.ComponentModel.DataAnnotations;

namespace Proyecto_Prioridades.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [RegularExpression(@"^[a-zA-Z]+(?: [a-zA-Z]+)*$", ErrorMessage = "Ingrese un nombre valido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El Teléfono es requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Teléfono solo puede contener digitos.")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Celular es requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Celular solo puede contener digitos.")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")]

        public string Celular { get; set; }
        [Required(ErrorMessage ="El RNC es requerido")]
        [RegularExpression(@"^[0-9]{9}[-][0-9]{1}$|^[0-9]{11}$", ErrorMessage = "Ingrese un RNC Valido")]
        public string Rnc {  get; set; }
        [Required(ErrorMessage = "El campo de Correo Electronico es requerido.")]
        [EmailAddress(ErrorMessage ="Ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        [RegularExpression(@"^[a-zA-Z0-9\s,'-]*$", ErrorMessage = "Ingrese una dirección válida.")]
        public string Direccion { get; set; }


    }
}
