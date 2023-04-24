using RentCar.Application.Resources.Office;
using RentCar.Application.Resources.Vehicle;

namespace RentCar.Application.Resources.Booking;
public class BookingResource
{
    public int Id { get; set; }
    public VehicleResource Vehicle { get; set; }
    public OfficeResource PickUpOffice { get; set; }
    public OfficeResource DropOffOffice { get; set; }
    public DateTime PickUpTime { get; set; }
    public DateTime DropOffTime { get; set; }
    public double TotalCost { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}
