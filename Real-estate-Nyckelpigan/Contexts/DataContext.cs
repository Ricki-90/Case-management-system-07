using Microsoft.EntityFrameworkCore;
using Real_estate_Nyckelpigan.Models.Entities;

namespace Real_estate_Nyckelpigan.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Berrr\Desktop\Case-management-system-07\Case-management-system-07\Real-estate-Nyckelpigan\Contexts\sql_db_01.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion

        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionstring);
        }

        #endregion

        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CaseEntity> Cases { get; set; } = null!;
        public DbSet<RenterEntity> Renters { get; set; } = null!;
    }
}
