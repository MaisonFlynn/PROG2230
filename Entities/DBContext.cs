using Microsoft.EntityFrameworkCore;

namespace Ass1gnment.Entities
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Measurement> Measurement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>().HasData(
                new Measurement() { MeasurementID = 1, Systolic = 181, Diastolic = 121, Date = new DateTime(2008, 02, 07) },
                new Measurement() { MeasurementID = 2, Systolic = 142, Diastolic = 91, Date = new DateTime(2025, 12, 29) },
                new Measurement() { MeasurementID = 3, Systolic = 131, Diastolic = 85, Date = new DateTime(2002, 11, 24) },
                new Measurement() { MeasurementID = 4, Systolic = 122, Diastolic = 79, Date = new DateTime(1998, 05, 08) },
                new Measurement() { MeasurementID = 5, Systolic = 118, Diastolic = 78, Date = new DateTime(1996, 02, 09) }
                );
        }
    }
}
