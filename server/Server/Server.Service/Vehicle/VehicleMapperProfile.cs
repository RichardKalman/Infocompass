using AutoMapper;

namespace Server.Service.Vehicle
{
    public class VehicleMapperProfile : Profile
    {
        public VehicleMapperProfile()
        {
            CreateMap<VehicleDto, Server.Domain.Vehicle.Vehicle>().ReverseMap();
            CreateMap<UpsertVehicleDto, Server.Domain.Vehicle.Vehicle>().ReverseMap();
            CreateMap<UpsertVehicleDto, VehicleDto>().ReverseMap();
        }
    }
}
