
using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Help_Desk.Models
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }

        [Required]
        public string Contenido { get; set; }

        public DateTime Fecha { get; set; }

        public int IdTicket { get; set; }

        public int IdUsuario { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
