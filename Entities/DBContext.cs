using Microsoft.EntityFrameworkCore;

namespace Ass1gnment.Entities
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Position> Position { get; set; }
        public DbSet<Measurement> Measurement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position() { PositionID = 1, Name = "Standing" },
                new Position() { PositionID = 2, Name = "Sitting" },
                new Position() { PositionID = 3, Name = "Supine" }
                );

            modelBuilder.Entity<Measurement>().HasData(
                new Measurement() { MeasurementID = 1, Systolic = 181, Diastolic = 121, Date = new DateTime(2008, 02, 07), PositionID = 1 },
                new Measurement() { MeasurementID = 2, Systolic = 142, Diastolic = 91, Date = new DateTime(2025, 12, 29), PositionID = 3 },
                new Measurement() { MeasurementID = 3, Systolic = 131, Diastolic = 85, Date = new DateTime(2002, 11, 24), PositionID = 1 },
                new Measurement() { MeasurementID = 4, Systolic = 122, Diastolic = 79, Date = new DateTime(1998, 05, 08), PositionID = 2 },
                new Measurement() { MeasurementID = 5, Systolic = 118, Diastolic = 78, Date = new DateTime(1996, 02, 09), PositionID = 2 }
                );
        }
    }
}
