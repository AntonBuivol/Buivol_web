using Buivol_web.Models;
using Microsoft.EntityFrameworkCore;

namespace Buivol_web.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Toode> Tooded { get; set; }
        public DbSet<Kasutajad> Kasutajad { get; set; }
        public DbSet<Pood> Pood { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
    }
}
