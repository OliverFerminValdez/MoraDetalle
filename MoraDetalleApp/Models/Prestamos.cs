using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace MoraDetalleApp.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        [Required(ErrorMessage ="La fecha es obligatoria")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="El nombre de la persona es obligatorio")]
        public string Persona { get; set; }
        [Required(ErrorMessage ="El monto es requerido")]
        public double Monto { get; set; }
        public double Balance { get; set; }
        [ForeignKey("MoraId")]
        public virtual List<MoraDetalle> MoraDetalles { get; set; } = new List<MoraDetalle>();

    }

    
}
