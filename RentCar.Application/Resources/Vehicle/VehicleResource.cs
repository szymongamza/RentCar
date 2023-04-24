using RentCar.Application.Resources.VehicleModel;

namespace RentCar.Application.Resources.Vehicle
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public byte[] Image { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public DateTime Year { get; set; }
        public string Mileage { get; set; }
        public int NumberOfSeats { get; set; }
        public bool? Status { get; set; }
        public VehicleModelResource VehicleModel { get; set; }
    }
}
