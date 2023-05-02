
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.API.Controllers;
using RentCar.Application.Helpers;
using RentCar.Application.Interfaces.Services;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Services;
using RentCar.UnitTests.Mocks;

namespace RentCar.UnitTests.ServicesTests
{
    public class BookingServiceTests
    {

        [Fact]
        public async void WhenListAsync_ThenAllBookingsReturn()
        {
            var bookingRepository = MockIBookingRepository.GetMock();
            var officeRepository = MockIOfficeRepository.GetMock();
            var vehicleRepository = MockIVehicleRepository.GetMock();
            var bookingService = new BookingService(bookingRepository.Object, vehicleRepository.Object, officeRepository.Object);
            var query = new BookingQuery(null,null,null,null,null,null,1,10);

            var result = await bookingService.ListAsync(query) as QueryResult<Booking>;

            Assert.NotNull(result);
            Assert.NotEmpty(result.Items);
            Assert.Equal(2, result.Items.Count);
            Assert.IsAssignableFrom<Booking>(result.Items[0]);
        }

        [Fact]
        public async Task AddAsync_ValidBooking_ReturnsBookingResponseWithResource()
        {
            var booking = new Booking()
            {
                PickUpOfficeId = 1,
                DropOffOfficeId = 1,
                EmailAddress = "test@test.com",
                UserName = "Name",
                UserSurname = "Surname",
                PhoneNumber = "12345",
                PickUpTime = DateTime.Now.AddDays(7),
                DropOffTime = DateTime.Now.AddDays(9),
                VehicleId = 1,
            };

            var bookingRepository = MockIBookingRepository.GetMock();
            var officeRepository = MockIOfficeRepository.GetMock();
            var vehicleRepository = MockIVehicleRepository.GetMock();
            var bookingService = new BookingService(bookingRepository.Object, vehicleRepository.Object, officeRepository.Object);

            var result = await bookingService.AddAsync(booking);

            Assert.Equal(string.Empty, result.Message);
            Assert.IsType<BookingResponse>(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Resource);

        }
        [Fact]
        public async Task UpdateAsync_ValidBooking_ReturnsBookingResponseWithResource()
        {

            var existingBooking = new Booking()
            {
                Id = 1,
                PickUpOfficeId = 1,
                DropOffOfficeId = 1,
                EmailAddress = "test@test.com",
                UserName = "Name",
                UserSurname = "Surname",
                PhoneNumber = "12345",
                PickUpTime = DateTime.Now.AddDays(7),
                DropOffTime = DateTime.Now.AddDays(9),
                VehicleId = 1,
            };

            var updatedBooking = new Booking()
            {
                Id = 1,
                PickUpOfficeId = 2,
                DropOffOfficeId = 2,
                EmailAddress = "test2@test.com",
                UserName = "UpdatedName",
                UserSurname = "UpdatedSurname",
                PhoneNumber = "54321",
                PickUpTime = DateTime.Now.AddDays(10),
                DropOffTime = DateTime.Now.AddDays(12),
                VehicleId = 2,
            };

            var bookingRepository = MockIBookingRepository.GetMock();
            var officeRepository = MockIOfficeRepository.GetMock();
            var vehicleRepository = MockIVehicleRepository.GetMock();
            var bookingService = new BookingService(bookingRepository.Object, vehicleRepository.Object, officeRepository.Object);

            var result = await bookingService.UpdateAsync(existingBooking.Id, updatedBooking);

            Assert.Equal(string.Empty, result.Message);
            Assert.IsType<BookingResponse>(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Resource);
            Assert.Equal(updatedBooking.Id, result.Resource.Id);
            Assert.Equal(updatedBooking.PickUpOfficeId, result.Resource.PickUpOfficeId);
            Assert.Equal(updatedBooking.DropOffOfficeId, result.Resource.DropOffOfficeId);
            Assert.Equal(updatedBooking.EmailAddress, result.Resource.EmailAddress);
            Assert.Equal(updatedBooking.UserName, result.Resource.UserName);
            Assert.Equal(updatedBooking.UserSurname, result.Resource.UserSurname);
            Assert.Equal(updatedBooking.PhoneNumber, result.Resource.PhoneNumber);
            Assert.Equal(updatedBooking.PickUpTime, result.Resource.PickUpTime);
            Assert.Equal(updatedBooking.DropOffTime, result.Resource.DropOffTime);
            Assert.Equal(updatedBooking.VehicleId, result.Resource.VehicleId);
        }

        [Fact]
        public async Task DeleteAsync_ValidBookingId_ReturnsBookingResponseWithSuccess()
        {
            var bookingId = 1;
            var bookingRepository = MockIBookingRepository.GetMock();
            var officeRepository = MockIOfficeRepository.GetMock();
            var vehicleRepository = MockIVehicleRepository.GetMock();
            var bookingService = new BookingService(bookingRepository.Object, vehicleRepository.Object, officeRepository.Object);

            var result = await bookingService.DeleteAsync(bookingId);

            Assert.Equal(string.Empty, result.Message);
            Assert.True(result.Success);
        }
    }
}