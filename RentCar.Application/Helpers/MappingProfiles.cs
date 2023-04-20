using AutoMapper;
using RentCar.Application.DTOs;
using RentCar.Domain.Entities;

namespace RentCar.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Manufacturer, ReadManufacturer>()
                .ForMember(dest => dest.ManufacturerId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.ManufacturerName, act => act.MapFrom(src => src.ManufacturerName));

            CreateMap<CreateManufacturer, Manufacturer>()
                .ForMember(dest => dest.ManufacturerName, act => act.MapFrom(src => src.ManufacturerName));
        }
    }
}
