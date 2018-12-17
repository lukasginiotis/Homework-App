using Microsoft.EntityFrameworkCore;

namespace MyApplication.Models
{
    public class WantedBundleContext : DbContext
    {
        public WantedBundleContext(DbContextOptions<WantedBundleContext> options)
            : base(options)
        {
        }

        public DbSet<WantedBundle> WantedBundle { get; set; }
    }
}
