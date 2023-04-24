

namespace RentCar.Application.Resources.Booking;
public class BookingQueryResource : QueryResource
{
    public int? VehicleId { get; set; }
    public int? BookingId { get; set; }
    public DateTime? FromDateTime { get; set; }
    public DateTime? ToDateTime { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber{ get; set; }
}
