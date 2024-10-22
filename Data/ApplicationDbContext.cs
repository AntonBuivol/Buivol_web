using Microsoft.EntityFrameworkCore;

namespace Buivol_web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<string> Articles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
