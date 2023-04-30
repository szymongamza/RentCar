using Moq;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;


namespace RentCar.UnitTests.Mocks
{
    public class MockIVehicleRepository
    {
        public static Mock<IVehicleRepository> GetMock()
        {
            var mock = new Mock<IVehicleRepository>();

            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                Id = 1,
                DailyPrice = 50,
                Description = "Test description",
                Bookings = new List<Booking>(),
                ImagePath = "TestVehicle.jpg",
                RegistrationNumber = "TEST 1234",
                Year = "2013",
                Status = true,
                VehicleModelId = 1,
                },
                new Vehicle()
                {
                Id = 2,
                DailyPrice = 60,
                Description = "Test description",
                Bookings = new List<Booking>(),
                ImagePath = "TestVehicle.jpg",
                RegistrationNumber = "TEST 1234",
                Year = "2013",
                Status = true,
                VehicleModelId = 2,
                }

            };

            mock.Setup(m => m.ToListAsync())
                .ReturnsAsync(() => vehicles);
            mock.Setup(m => m.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => vehicles.FirstOrDefault(b => b.Id == id));
            mock.Setup(m => m.FindByIdAsyncIncludeAll(It.IsAny<int>()))
                .ReturnsAsync((int id) => vehicles.FirstOrDefault(b => b.Id == id));

            mock.Setup(m => m.AddAsync(It.IsAny<Vehicle>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateAsync(It.IsAny<Vehicle>()))
                .Callback(() => { return; });
            mock.Setup(m => m.DeleteAsync(It.IsAny<Vehicle>()))
                .Callback(() => { return; });
            return mock;
        }
    }
}
