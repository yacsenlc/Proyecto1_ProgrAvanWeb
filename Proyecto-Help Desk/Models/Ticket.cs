
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Help_Desk.Models
{
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public DateTime? FechaResolucion { get; set; }

        public int IdUsuario { get; set; }

        public int? IdTecnico { get; set; }

        public int IdCategoria { get; set; }

        public int IdEstado { get; set; }

    
        public virtual Usuario UsuarioCreador { get; set; }

        public virtual Usuario TecnicoAsignado { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
