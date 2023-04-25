
using RentCar.Domain.Common;

namespace RentCar.Domain.Entities;
public class Booking : BaseEntity
{
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int PickUpOfficeId { get; set; }
    public Office PickUpOffice { get; set; }
    public int DropOffOfficeId { get; set; }
    public Office DropOffOffice { get; set; }
    public DateTime PickUpTime { get; set; }
    public DateTime DropOffTime { get; set; }
    public double TotalCost { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}
