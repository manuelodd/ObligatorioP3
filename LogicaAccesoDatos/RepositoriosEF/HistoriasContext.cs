using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF
{
    public class HistoriasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Intermedio> Intermedios { get; set; }
        public DbSet<Final> Finales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
        public DbSet<Lectura> Lecturas { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                    (@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=Historias;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Historia - Capítulos (1 a muchos)
            modelBuilder.Entity<Historia>()
                .HasMany(h => h.Capitulos)
                .WithOne(c => c.Historia)
                .HasForeignKey(c => c.HistoriaId);

            // Historia - Capítulo inicial (1 a 1 desde Historia)
            modelBuilder.Entity<Historia>()
                .HasOne(h => h.CapituloInicial)
                .WithMany()
                .HasForeignKey(h => h.CapituloInicialId)
                .OnDelete(DeleteBehavior.Restrict);

            // Historia - Categorías (muchos a muchos)
            modelBuilder.Entity<Historia>()
                .HasMany(h => h.Categorias)
                .WithMany();
        }
    }
}
