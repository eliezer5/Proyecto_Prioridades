using System.ComponentModel.DataAnnotations;

namespace Proyecto_Prioridades.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Descripción { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 31, ErrorMessage = "El rango debe de ser de 1-31")]
        public int DiasCompromiso { get; set; }
    }
}
