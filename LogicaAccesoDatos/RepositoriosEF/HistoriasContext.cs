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
        public DbSet<Lectura> Lectura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                    (@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=Historias;Integrated Security=true");
        }
    }
}
