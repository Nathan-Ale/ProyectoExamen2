using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
            modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("contrasena");
            modelBuilder.Entity<Usuario>().Property(u => u.Created_At).HasColumnName("created_at");
            //-------------------------------------------------------------------------------------
            modelBuilder.Entity<Tarea>().ToTable("tareas");

            modelBuilder.Entity<Tarea>().Property(t => t.Titulo).HasColumnName("titulo");
            modelBuilder.Entity<Tarea>().Property(t => t.Descripcion).HasColumnName("descripcion");
        }
    }
}