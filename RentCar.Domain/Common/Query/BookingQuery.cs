

using System.ComponentModel.DataAnnotations;

namespace RentCar.Domain.Common.Query;
public class BookingQuery : Query
{
    public int? VehicleId;
    public int? BookingId;
    public DateTime? FromDateTime;
    public DateTime? ToDateTime;
    public string? EmailAddress;
    public string? PhoneNumber;
    public BookingQuery(int? vehicleId, int? bookingId, DateTime? fromDateTime, DateTime? toDateTime, string? emailAddress, string? phoneNumber, int page, int itemsPerPage) : base(page, itemsPerPage)
    {
        VehicleId = vehicleId;
        BookingId = bookingId;
        FromDateTime = fromDateTime;
        ToDateTime = toDateTime;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
    }
}
