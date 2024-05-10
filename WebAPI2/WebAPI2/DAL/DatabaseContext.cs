using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Security.Cryptography.X509Certificates;
using WebAPI2.DAL.Entities;

namespace WebAPI2.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)//conexion a la BD
        {

        }

        //Metodo propio de EF Core que permite configurar indice de cada campo de una tabla en la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();//No permite que hayan nombres repetidos
        }


        #region DBsets
        //Cada DbSet significa una tabla en la BD
        public DbSet<Country> Countries { get; set; }
        #endregion
    }
}

