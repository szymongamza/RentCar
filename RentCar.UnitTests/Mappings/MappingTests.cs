using System.Runtime.Serialization;
using AutoMapper;
using RentCar.Application.Helpers;
using RentCar.Application.Resources.Manufacturer;
using RentCar.Application.Resources.VehicleModel;
using RentCar.Domain.Entities;

namespace RentCar.UnitTests.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(SaveManufacturerResource), typeof(Manufacturer))]
        [InlineData(typeof(Manufacturer), typeof(ManufacturerResource))]
        [InlineData(typeof(SaveVehicleModelResource), typeof(VehicleModel))]
        [InlineData(typeof(VehicleModel), typeof(VehicleModelResource))]
        public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);

            _mapper.Map(instance, origin, destination);
        }
    }
}