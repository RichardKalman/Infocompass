using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Service.Vehicle;

namespace Server.Controllers
{
    [Route("Vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("list")]
        [Tags("Vehicle")]
        [ProducesResponseType(typeof(IEnumerable<VehicleDto>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<VehicleDto>> GetAllVehicle()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return vehicles;
        }

        [HttpGet("{vehicleId:guid}")]
        [Tags("Vehicle")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleDto>> GetById([FromRoute] Guid vehicleId)
        {
            var vehicles = await _vehicleService.getById(vehicleId);
            return vehicles is null? BadRequest() : Ok(vehicles);
        }

        [HttpPut()]
        [Tags("Vehicle")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> Update(UpsertVehicleDto vehicle)
        {
            var vehicles = await _vehicleService.updateVehicle(vehicle);
            return vehicles is null ? BadRequest() : Ok(vehicles);
        }

        [HttpPost()]
        [Tags("Vehicle")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status400BadRequest)]
        public async Task<VehicleDto> create(UpsertVehicleDto vehhicle)
        {
            var vehicle = await _vehicleService.Create(vehhicle);
            return vehicle;
        }
        [HttpDelete()]
        [Tags("Vehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> delete(Guid Id)
        {
            await _vehicleService.deleteById(Id);
            return Ok();

        }
    }
}
