using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;


namespace RentCar.UnitTests.Mocks
{
    public class MockIBookingRepository
    {
        public static Mock<IBookingRepository> GetMock()
        {
            var mock = new Mock<IBookingRepository>();

            var bookings = new List<Booking>
            {
                new Booking() {
                    Id = 1,
                    PickUpOfficeId = 1,
                    DropOffOfficeId = 1,
                    EmailAddress = "test@test.com",
                    UserName= "Name",
                    UserSurname = "Surname",
                    PhoneNumber = "12345",
                    PickUpTime = DateTime.Now,
                    DropOffTime = DateTime.Now.AddDays(3),
                    VehicleId = 1,
                },
                new Booking() {
                    Id = 2,
                    PickUpOfficeId = 1,
                    DropOffOfficeId = 1,
                    EmailAddress = "test@test.com",
                    UserName= "Name",
                    UserSurname = "Surname",
                    PhoneNumber = "12345",
                    PickUpTime = DateTime.Now,
                    DropOffTime = DateTime.Now.AddDays(3),
                    VehicleId = 2,
                }
            };

            mock.Setup(m => m.ToListAsync(It.IsAny<BookingQuery>()))
                .ReturnsAsync(() => new QueryResult<Booking> {Items = bookings, TotalItems = bookings.Count() } );
            mock.Setup(m => m.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => bookings.FirstOrDefault(b => b.Id == id));

             mock.Setup(m => m.AddAsync(It.IsAny<Booking>()))
                 .Callback(() => { return; });
            mock.Setup(m => m.UpdateAsync(It.IsAny<Booking>()))
                 .Callback(() => { return; });
             mock.Setup(m => m.DeleteAsync(It.IsAny<Booking>()))
                 .Callback(() => { return; });

            return mock;
        }
    }
}
