using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment1RM.Entities
{
	public class MeasurementDbContext : DbContext
	{
		public MeasurementDbContext(DbContextOptions<MeasurementDbContext> options) : base(options) { }

		public DbSet<Measurement> Measurements { get; set; }
		public DbSet<Position> Positions { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Position>().HasData(
				new Position() { PositionId = "ST", Name = "Standing" },
				new Position() { PositionId = "LD", Name = "Lying Down" },
				new Position() { PositionId = "SI", Name = "Sitting" }
				);

			modelBuilder.Entity<Measurement>().HasData(
				new Measurement() 
				{MeasurementId = 1,
				Systolic = 120,
				Diastolic= 80,
				Date = "10/02/2023",
				PositionId="ST"
					},
                new Measurement()
                {
                    MeasurementId = 2,
                    Systolic = 120,
                    Diastolic = 80,
                    Date = "10/02/2023",
                    PositionId = "SI"
                }
                );
		}
	}
}
