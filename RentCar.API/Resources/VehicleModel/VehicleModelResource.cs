using RentCar.API.Resources.Manufacturer;

namespace RentCar.API.Resources.VehicleModel;
public class VehicleModelResource
{
    public int Id { get; set; }
    public string ModelName { get; set; }
    public string Description { get; set; }
    public ManufacturerResource Manufacturer { get; set; }
}
