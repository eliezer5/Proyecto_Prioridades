using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Prioridades.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage ="La Fecha es requerida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage ="El ClienteId es Requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona un ClienteId")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="La PrioridadId es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una PrioridadId")]
        [ForeignKey("PrioridadId")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "El SistemaId es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona un sistemaId")]
        [ForeignKey("SistemaId")]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "El SolicitadoPor es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El SolicitadoPor no puede tener más de 100 caracteres.")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "El Asunto es obligatorio.")]
        [MaxLength(255, ErrorMessage = "El Asunto no puede tener más de 255 caracteres.")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "La Descripcion es obligatoria.")]
        public string? Descripcion { get; set; }



    }
}
