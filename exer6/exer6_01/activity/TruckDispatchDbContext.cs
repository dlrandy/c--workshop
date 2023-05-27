using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Exer06.activity
{
    public class TruckDispatchDbContext : DbContext
    {
        public DbSet<Truck> Trunks { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<TruckDispatch> TrunkDispatches { get; set; }
        public TruckDispatchDbContext() : base(UsePostgresSqlserverOptions()) { }

        protected static DbContextOptions UsePostgresSqlserverOptions()
        {
            return new DbContextOptionsBuilder().UseNpgsql(Program.TruckLogisticsConnectionString).Options;
        }
        public TruckDispatchDbContext(DbContextOptions<TruckDispatchDbContext> options) : base(options) { }
    }
}