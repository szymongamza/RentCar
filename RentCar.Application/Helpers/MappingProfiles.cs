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
        CreateMap<SaveVehicleModelResource, VehicleModel>();
        CreateMap<SaveManufacturerResource, Manufacturer>();
        CreateMap<VehicleModelQueryResource, VehicleModelQuery>();
    }
}