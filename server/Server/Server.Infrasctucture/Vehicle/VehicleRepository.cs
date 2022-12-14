using Server.Domain.Vehicle;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Server.Infrasctucture.Vehicle
{
    public class VehicleRepository : IVehicleRepositroy
    {

        private readonly VehicleDBContext _dbContext;

        public VehicleRepository(VehicleDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Vehicle.Vehicle> CreateAsync(Domain.Vehicle.Vehicle vehicle)
        {
            var createdVehicle = (await _dbContext.Vehicles.AddAsync(vehicle).ConfigureAwait(false)).Entity;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return createdVehicle;
        }

        public async Task DeleteVehicle(Guid Id)
        {
            var vehicle = await getVehicleByIdAsync(Id);
            if(vehicle != null)
            {
                _dbContext.Vehicles.Remove(vehicle);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Domain.Vehicle.Vehicle>> getAllAsync()
        {
            var result = await _dbContext.Vehicles.ToListAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<Domain.Vehicle.Vehicle> getVehicleByIdAsync(Guid id)
        {
            var result = await _dbContext.Vehicles.Where(v =>v.Id.Equals(id)).SingleOrDefaultAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<Domain.Vehicle.Vehicle> UpdateVehicle(Domain.Vehicle.Vehicle vehicle)
        {
            _dbContext.Vehicles.Update(vehicle);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return vehicle;

        }
    }
}
