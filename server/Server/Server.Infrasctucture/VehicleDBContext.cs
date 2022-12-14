using Microsoft.EntityFrameworkCore;


namespace Server.Infrasctucture
{
    public class VehicleDBContext : DbContext
    {

        public DbSet<Domain.Vehicle.Vehicle> Vehicles { get; set; }
        public VehicleDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Domain.Vehicle.Vehicle>()
                .HasKey(x => x.Id);

           
        }



    }
}
