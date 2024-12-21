using Microsoft.EntityFrameworkCore;

namespace azure_app_visualstudio_mb2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person2> Persons2 { get; set; }
    }
}
