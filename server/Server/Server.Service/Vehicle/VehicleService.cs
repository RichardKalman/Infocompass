using AutoMapper;
using Server.Domain.Vehicle;

namespace Server.Service.Vehicle
{
    public interface IVehicleService
    {
        Task<VehicleDto> Create(UpsertVehicleDto upsertVehicleDto);
        Task<IEnumerable<VehicleDto>> GetAllAsync();
        Task<VehicleDto> getById(Guid Id);
        Task<VehicleDto> updateVehicle(UpsertVehicleDto vehicleDto);

        Task deleteById(Guid Id);
    }
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepositroy _vehicleRepositroy;
        public VehicleService(IMapper mapper, IVehicleRepositroy vehicleRepositroy)
        {
            _mapper = mapper;
            _vehicleRepositroy = vehicleRepositroy;
        }

        public async Task<VehicleDto> Create(UpsertVehicleDto upsertVehicleDto)
        {
            var vehicleToCreate = _mapper.Map<Domain.Vehicle.Vehicle>(upsertVehicleDto);

            var result = await _vehicleRepositroy.CreateAsync(vehicleToCreate);

            return _mapper.Map<VehicleDto>(upsertVehicleDto);


        }

        public async Task deleteById(Guid Id)
        {
            await _vehicleRepositroy.DeleteVehicle(Id);
        }

        public async Task<IEnumerable<VehicleDto>> GetAllAsync()
        {
            var result = await _vehicleRepositroy.getAllAsync();
            return _mapper.Map<IEnumerable<VehicleDto>>(result);
        }

        public async Task<VehicleDto> getById(Guid Id)
        {
            var result = await _vehicleRepositroy.getVehicleByIdAsync(Id);
            return _mapper.Map<VehicleDto>(result);
        }

        public async Task<VehicleDto> updateVehicle(UpsertVehicleDto vehicleDto)
        {
            var vehicleToUpate = _mapper.Map<Domain.Vehicle.Vehicle>(vehicleDto);
            var result = await _vehicleRepositroy.UpdateVehicle(vehicleToUpate);
            return _mapper.Map<VehicleDto>(result);
        }

    }
}
