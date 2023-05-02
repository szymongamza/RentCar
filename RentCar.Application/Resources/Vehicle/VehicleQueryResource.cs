

namespace RentCar.Application.Resources.Vehicle
{
    public class VehicleQueryResource : QueryResource
    {
        public int? VehicleModelId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set;}
        public bool? Status { get; set; }
    }
}
