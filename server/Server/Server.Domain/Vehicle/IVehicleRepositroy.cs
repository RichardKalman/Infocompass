namespace Server.Domain.Vehicle
{
    public interface IVehicleRepositroy
    {
        Task<Vehicle> CreateAsync(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> getAllAsync();
        Task<Vehicle> getVehicleByIdAsync(Guid id);
        Task<Vehicle> UpdateVehicle(Vehicle vehicle);
        Task DeleteVehicle(Guid id);
    }
}
