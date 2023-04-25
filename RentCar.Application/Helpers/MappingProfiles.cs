using AutoMapper;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;
using RentCar.Application.Resources;
using RentCar.Application.Resources.Booking;
using RentCar.Application.Resources.VehicleModel;
using RentCar.Application.Resources.Manufacturer;
using RentCar.Application.Resources.Office;
using RentCar.Application.Resources.Vehicle;

namespace RentCar.Application.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //######################### Model to Resource ##################################
        CreateMap<Manufacturer, ManufacturerResource>();

        CreateMap<VehicleModel, VehicleModelResource>();
        CreateMap<QueryResult<VehicleModel>, QueryResultResource<VehicleModelResource>>();

        CreateMap<Vehicle, VehicleResource>();
        CreateMap<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>();

        CreateMap<Office, OfficeResource>();

        CreateMap<Booking, BookingResource>();
        CreateMap<QueryResult<Booking>, QueryResultResource<BookingResource>>();


        //################## Resource to Model ###################################
        CreateMap<SaveManufacturerResource, Manufacturer>()
            .ForMember(x => x.VehicleModels, opt => opt.Ignore())
            .ForMember(x => x.Id, opt => opt.Ignore());

        CreateMap<SaveVehicleModelResource, VehicleModel>()
            .ForMember(x=>x.Manufacturer, opt => opt.Ignore())
            .ForMember(x=>x.Vehicles, opt => opt.Ignore())
            .ForMember(x => x.Id, opt=> opt.Ignore());
        CreateMap<VehicleModelQueryResource, VehicleModelQuery>();

        CreateMap<SaveVehicleResource, Vehicle>()
            .ForMember(x=>x.VehicleModel, opt => opt.Ignore())
            .ForMember(x=>x.Bookings, opt => opt.Ignore())
            .ForMember(x=>x.Id, opt => opt.Ignore());
        CreateMap<VehicleQueryResource, VehicleQuery>();

        CreateMap<SaveOfficeResource, Office>()
            .ForMember(x => x.Id, opt => opt.Ignore());

        CreateMap<SaveBookingResource, Booking>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.TotalCost, opt => opt.Ignore())
            .ForMember(x => x.Vehicle, opt => opt.Ignore())
            .ForMember(x => x.PickUpOffice, opt => opt.Ignore())
            .ForMember(x => x.DropOffOffice, opt => opt.Ignore());
        CreateMap<BookingQueryResource, BookingQuery>();



    }
}