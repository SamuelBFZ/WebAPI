using Microsoft.EntityFrameworkCore;
using WebAPI.DAL.Entities;

namespace WebAPI.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Barber> Barbers {  get; set; } 
    }
}
