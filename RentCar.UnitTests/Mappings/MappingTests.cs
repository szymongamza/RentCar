using System.Runtime.Serialization;
using AutoMapper;
using RentCar.Application.Helpers;
using RentCar.Application.Resources;
using RentCar.Application.Resources.Booking;
using RentCar.Application.Resources.Manufacturer;
using RentCar.Application.Resources.Office;
using RentCar.Application.Resources.Vehicle;
using RentCar.Application.Resources.VehicleModel;
using RentCar.Domain.Common.Query;
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
        [InlineData(typeof(QueryResult<VehicleModel>), typeof(QueryResultResource<VehicleModelResource>))]
        [InlineData(typeof(VehicleModelQueryResource), typeof(VehicleModelQuery))]

        [InlineData(typeof(Vehicle), typeof(VehicleResource))]
        [InlineData(typeof(QueryResult<Vehicle>), typeof(QueryResultResource<VehicleResource>))]
        [InlineData(typeof(SaveVehicleResource), typeof(Vehicle))]
        [InlineData(typeof(VehicleQueryResource), typeof(VehicleQuery))]

        [InlineData(typeof(SaveOfficeResource), typeof(Office))]
        [InlineData(typeof(Office), typeof(OfficeResource))]

        [InlineData(typeof(Booking), typeof(BookingResource))]
        [InlineData(typeof(QueryResult<Booking>), typeof(QueryResultResource<BookingResource>))]
        [InlineData(typeof(SaveBookingResource), typeof(Booking))]
        [InlineData(typeof(BookingQueryResource), typeof(BookingQuery))]
        public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);

            _mapper.Map(instance, origin, destination);
        }
    }
}