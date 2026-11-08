
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Help_Desk.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(120)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        public int IdRol { get; set; }

        public bool Activo { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual ICollection<Ticket> TicketsCreados { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
