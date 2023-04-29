

using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Interfaces.Services;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Repositories;

namespace RentCar.Infrastructure.Services;
public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IOfficeRepository _officeRepository;

    public BookingService(IBookingRepository bookingRepository, IVehicleRepository vehicleRepository, IOfficeRepository officeRepository)
    {
        _bookingRepository = bookingRepository;
        _vehicleRepository = vehicleRepository;
        _officeRepository = officeRepository;
    }

    public async Task<QueryResult<Booking>> ListAsync(BookingQuery query)
    {
        return await _bookingRepository.ToListAsync(query);
    }

    public async Task<BookingResponse> AddAsync(Booking booking)
    {
        try
        {
            var existingVehicle = await _vehicleRepository.FindByIdAsyncIncludeAll(booking.VehicleId);
            if (existingVehicle == null)
                return new BookingResponse("Invalid vehicle.");

            if (existingVehicle.Bookings.Any(x => x.PickUpTime.AddHours(-2) <= booking.DropOffTime && x.DropOffTime.AddHours(2) >= booking.PickUpTime))
                return new BookingResponse("DateTime span overlap on other booking");

            var existingPickUpOffice = await _officeRepository.FindByIdAsync(booking.PickUpOfficeId);
            if (existingPickUpOffice == null)
                return new BookingResponse("Invalid pickup office.");

            var existingDropOffOffice = await _officeRepository.FindByIdAsync(booking.DropOffOfficeId);
            if (existingDropOffOffice == null)
                return new BookingResponse("Invalid drop off office.");

            if (booking.DropOffTime < DateTime.Now || booking.PickUpTime < DateTime.Now)
                return new BookingResponse("Date has to be in future");

            if (booking.DropOffTime < booking.PickUpTime)
                return new BookingResponse("Pickup time is before drop off time.");

            booking.TotalCost = CalculateTotalCost(booking,existingVehicle);

            await _bookingRepository.AddAsync(booking);



            booking.Vehicle = existingVehicle;
            return new BookingResponse(booking);
        }
        catch (Exception ex)
        {

            return new BookingResponse($"An error occurred when saving the booking: {ex.Message}");
        }
    }

    public async Task<BookingResponse> UpdateAsync(int id, Booking booking)
    {
        var existingBooking = await _bookingRepository.FindByIdAsync(id);

        if (existingBooking == null)
            return new BookingResponse("Booking not found.");

        var existingVehicle = await _vehicleRepository.FindByIdAsync(booking.VehicleId);
        if (existingVehicle == null)
            return new BookingResponse("Invalid vehicle.");

        var existingPickUpOffice = await _officeRepository.FindByIdAsync(booking.PickUpOfficeId);
        if (existingPickUpOffice == null)
            return new BookingResponse("Invalid pickup office.");

        var existingDropOffOffice = await _officeRepository.FindByIdAsync(booking.DropOffOfficeId);
        if (existingDropOffOffice == null)
            return new BookingResponse("Invalid drop off office.");

        if (booking.DropOffTime < booking.PickUpTime)
            return new BookingResponse("Pickup time is before drop off time.");


        existingBooking.PickUpOfficeId = booking.PickUpOfficeId;
        existingBooking.DropOffOfficeId = booking.DropOffOfficeId;
        existingBooking.PickUpTime = booking.PickUpTime;
        existingBooking.DropOffTime = booking.DropOffTime;
        existingBooking.VehicleId = booking.VehicleId;
        existingBooking.UserName = booking.UserName;
        existingBooking.UserSurname = booking.UserSurname;
        existingBooking.EmailAddress = booking.EmailAddress;
        existingBooking.PhoneNumber = booking.PhoneNumber;
        existingBooking.TotalCost = CalculateTotalCost(existingBooking, existingVehicle);




        try
        {
            await _bookingRepository.UpdateAsync(existingBooking);
            return new BookingResponse(existingBooking);
        }
        catch (Exception ex)
        {
            return new BookingResponse($"An error occurred when updating the booking: {ex.Message}");
        }
    }

    public async Task<BookingResponse> DeleteAsync(int id)
    {
        {
            var existingBooking = await _bookingRepository.FindByIdAsync(id);

            if (existingBooking == null)
                return new BookingResponse("Vehicle not found.");

            try
            {
                await _bookingRepository.DeleteAsync(existingBooking);

                return new BookingResponse(existingBooking);
            }
            catch (Exception ex)
            {
                return new BookingResponse($"An error occurred when deleting the booking: {ex.Message}");
            }
        }
    }

    private double CalculateTotalCost(Booking booking, Vehicle vehicle)
    {
        var timeSpan = booking.DropOffTime - booking.PickUpTime;
        int days;
        if (timeSpan.TotalDays > timeSpan.Days)
        {
            days = timeSpan.Days + 1;
        }
        else
        {
            days = timeSpan.Days;
        }

        return days * vehicle.DailyPrice;
    }
}
