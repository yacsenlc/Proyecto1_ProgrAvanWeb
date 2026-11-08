
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Help_Desk.Models
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
