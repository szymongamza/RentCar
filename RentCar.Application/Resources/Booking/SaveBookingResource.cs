
namespace RentCar.Application.Resources.Booking;
public class SaveBookingResource
{
    public int VehicleId { get; set; }
    public int PickUpOfficeId { get; set; }
    public int DropOffOfficeId { get; set; }
    public DateTime PickUpTime { get; set; }
    public DateTime DropOffTime { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}
