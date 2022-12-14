

namespace Server.Infrasctucture.Seeder
{
    public interface IDataSeeder
    {

    }
    public class DataSeeder : IDataSeeder
    {
        private readonly VehicleDBContext _dbContext;

        private DataSeeder() { }

        private DataSeeder(VehicleDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static IDataSeeder CreateSeeder(VehicleDBContext dbContext)
        {
            return new DataSeeder(dbContext);
        }
    }
}
