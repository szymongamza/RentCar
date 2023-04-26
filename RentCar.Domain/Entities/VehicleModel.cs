
using RentCar.Domain.Common;

namespace RentCar.Domain.Entities;
public class VehicleModel : BaseEntity
{
    public string ModelName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public int NumberOfSeats { get; set; }
    public double RangeInKilometers { get; set; }
    public double CargoCapacityInLitres { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}
