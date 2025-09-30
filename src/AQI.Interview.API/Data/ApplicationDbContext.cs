using Microsoft.EntityFrameworkCore;
using AQI.Interview.Models;

namespace AQI.Interview.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Measurement entity
            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasKey(e => e.MeasurementId);
                entity.Property(e => e.MeasurementId).ValueGeneratedOnAdd();
                entity.Property(e => e.NumericValue).HasPrecision(18, 6);
                entity.Property(e => e.StringValue).HasMaxLength(500);
                entity.Property(e => e.Parameter).HasConversion<int>();
                entity.Property(e => e.UTCCapturedTimestamp).IsRequired();
                entity.Property(e => e.UTCSavedTimestamp).IsRequired();
            });
        }
    }
}