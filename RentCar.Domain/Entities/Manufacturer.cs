
using RentCar.Domain.Common;

namespace RentCar.Domain.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string ManufacturerName { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
