
using Microsoft.EntityFrameworkCore;
using Proyecto_Help_Desk.Models;

namespace Proyecto_Help_Desk.Data
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Rol>().ToTable("Roles");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Estado>().ToTable("Estados");
            modelBuilder.Entity<Comentario>().ToTable("Comentarios");

            // Relación: Usuario - Rol
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol);

            // Relación: Ticket - Usuario creador
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.UsuarioCreador)
                .WithMany()
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Ticket - Técnico asignado
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TecnicoAsignado)
                .WithMany()
                .HasForeignKey(t => t.IdTecnico)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Ticket - Categoría
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Categoria)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.IdCategoria);

            // Relación: Ticket - Estado
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Estado)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.IdEstado);

            // Relación: Comentario - Ticket
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Ticket)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.IdTicket)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Comentario - Usuario
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Ticket>()
    .HasOne(t => t.UsuarioCreador)
    .WithMany(u => u.TicketsCreados)
    .HasForeignKey(t => t.IdUsuario);


        }
    }
}
