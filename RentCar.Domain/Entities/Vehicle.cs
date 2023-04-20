using RentCar.Domain.Common;


namespace RentCar.Domain.Entities;
public class Vehicle : BaseEntity
{
    public string RegistrationNumber { get; set; }
    public byte[] Image { get; set; }
    public double DailyPrice { get; set; }
    public string Description { get; set; }
    public DateTime Year { get; set; }
    public string Mileage { get; set; }
    public int NumberOfSeats { get; set; }
    public bool? Status { get; set; }
    public int VehicleTypeId { get; set; }
    public int VehicleModelId { get; set; }
    public VehicleModel VehicleModel { get; set; }
}
