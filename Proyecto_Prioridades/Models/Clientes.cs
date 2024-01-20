using System.ComponentModel.DataAnnotations;

namespace Proyecto_Prioridades.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }

        [RegularExpression(@"^[a-zA-Z]+(?: [a-zA-Z]+)*$", ErrorMessage = "El nombre es requerido")]
        public string Nombres { get; set; }
        [RegularExpression(@"/+(?:[0-9] ?){6,14}[0-9]$")]
        public string? Telefono { get; set; }
        [RegularExpression(@"/+(?:[0-9] ?){6,14}[0-9]$", ErrorMessage = "El Celular es requerido")]
        public string Celular { get; set; }
        [RegularExpression(@"^[0-9]{9}[-][0-9]{1}$|^[0-9]{11}$", ErrorMessage = "El RNC es requerido")]
        public string Rnc {  get; set; }
        [Required(ErrorMessage = "El campo de Correo Electronico es requerido.")]
        [EmailAddress(ErrorMessage ="Ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\s,'-]*$", ErrorMessage = "Ingrese una dirección válida.")]
        public string Direccion { get; set; }


    }
}
