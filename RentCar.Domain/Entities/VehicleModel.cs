
using RentCar.Domain.Common;

namespace RentCar.Domain.Entities;
public class VehicleModel : BaseEntity
{
    public string ModelName { get; set; }
    public string Description { get; set; }
    public int NumberOfSeats { get; set; }
    public string Range { get; set; }
    public string CargoCapacity { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}
