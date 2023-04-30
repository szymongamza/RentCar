using Moq;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;


namespace RentCar.UnitTests.Mocks
{
    public class MockIOfficeRepository
    {
        public static Mock<IOfficeRepository> GetMock()
        {
            var mock = new Mock<IOfficeRepository>();

            var offices = new List<Office>
            {
                new Office()
            {
                Id = 1,
                OfficeName = "Test Office",
                Address = "Test Address",
                Description = "Test description",
                TimeOpen = TimeOnly.Parse("07:00:00"),
                TimeClose = TimeOnly.Parse("21:00:00"),
                ImagePath = "TestOffice.jpg",
                PhoneNumber = "12345",
            },
                new Office()
            {
                Id = 2,
                OfficeName = "Test Office2",
                Address = "Test Address2",
                Description = "Test description",
                TimeOpen = TimeOnly.Parse("07:00:00"),
                TimeClose = TimeOnly.Parse("21:00:00"),
                ImagePath = "TestOffice2.jpg",
                PhoneNumber = "54321",
            }

            };

            mock.Setup(m => m.ToListAsync())
                .ReturnsAsync(() => offices);
            mock.Setup(m => m.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => offices.FirstOrDefault(b => b.Id == id));

            mock.Setup(m => m.AddAsync(It.IsAny<Office>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateAsync(It.IsAny<Office>()))
                .Callback(() => { return; });
            mock.Setup(m => m.DeleteAsync(It.IsAny<Office>()))
                .Callback(() => { return; });
            return mock;
        }
    }
}
