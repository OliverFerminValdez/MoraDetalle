using MoraDetalleApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace MoraDetalleApp.Models
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        [Required(ErrorMessage ="El campo fecha es obligatorio")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="El valor es obligatorio")]
        public double Valor { get; set; }
    }

    public class MoraDetalle
    {
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public double Valor { get; set; }

    }
}
