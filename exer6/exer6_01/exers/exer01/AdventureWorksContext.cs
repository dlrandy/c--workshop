using Microsoft.EntityFrameworkCore;
namespace Exer06.exers.exer01
{
    public class AdventureWorksContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public AdventureWorksContext() : base(UsePostgresSqlServerOptions()) { }
        protected static DbContextOptions UsePostgresSqlServerOptions()
        {
            return new DbContextOptionsBuilder().UseNpgsql(Program.AdventureWorksConnectionString).Options;
        }
        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options) { }
    }
}