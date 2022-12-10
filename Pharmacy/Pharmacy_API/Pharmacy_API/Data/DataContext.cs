using Microsoft.EntityFrameworkCore;

namespace Pharmacy_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Pharmacy> Pharmacies { get; set; }
    }
}

