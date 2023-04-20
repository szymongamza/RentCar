using AutoMapper;
using RentCar.API.Resources;
using RentCar.API.Resources.Manufacturer;
using RentCar.API.Resources.VehicleModel;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;

namespace RentCar.API.Helpers;

public class ApiMappingProfiles : Profile
{
    public ApiMappingProfiles()
    {

        //Model to Resource
        CreateMap<Manufacturer, ManufacturerResource>();
        CreateMap<VehicleModel, VehicleModelResource>();
        CreateMap<QueryResult<VehicleModel>, QueryResultResource<VehicleModelResource>>();

        //Resource to Model
        CreateMap<SaveVehicleModelResource, VehicleModel>();
        CreateMap<SaveManufacturerResource, Manufacturer>();
        CreateMap<VehicleModelQueryResource, VehicleModelQuery>();
    }
}
