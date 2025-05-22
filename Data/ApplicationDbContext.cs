using clinica2.Models;
using Microsoft.EntityFrameworkCore;

namespace clinica2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<roles> roles { get; set; }
        public DbSet<site> site { get; set; }
        public DbSet<specializations> specializations { get; set; }
        public DbSet<status> status { get; set; }
        public DbSet<diagnosis> diagnosis { get; set; }
        public DbSet<doctors> doctors { get; set; }
        public DbSet<patients> patients { get; set; }
        public DbSet<receptions> receptions { get; set; }
    }
}
