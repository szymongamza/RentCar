using AutoMapper;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;
using RentCar.Application.Resources;
using RentCar.Application.Resources.VehicleModel;
using RentCar.Application.Resources.Manufacturer;

namespace RentCar.Application.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Manufacturer, ManufacturerResource>();
        CreateMap<VehicleModel, VehicleModelResource>();
        CreateMap<QueryResult<VehicleModel>, QueryResultResource<VehicleModelResource>>();

        //Resource to Model
        CreateMap<SaveVehicleModelResource, VehicleModel>()
            .ForMember(x=>x.Manufacturer, opt => opt.Ignore())
            .ForMember(x=>x.Vehicles, opt => opt.Ignore())
            .ForMember(x => x.Id, opt=> opt.Ignore());
        CreateMap<SaveManufacturerResource, Manufacturer>()
            .ForMember(x=>x.VehicleModels, opt=>opt.Ignore())
            .ForMember(x=>x.Id, opt => opt.Ignore());
        CreateMap<VehicleModelQueryResource, VehicleModelQuery>();
    }
}