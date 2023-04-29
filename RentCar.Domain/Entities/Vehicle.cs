using RentCar.Domain.Common;


namespace RentCar.Domain.Entities;
public class Vehicle : BaseEntity
{
    public string RegistrationNumber { get; set; }
    public string ImagePath { get; set; }
    public double DailyPrice { get; set; }
    public string Description { get; set; }
    public string Year { get; set; }
    public bool Status { get; set; }
    public int VehicleModelId { get; set; }
    public VehicleModel VehicleModel { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}
