
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Help_Desk.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

