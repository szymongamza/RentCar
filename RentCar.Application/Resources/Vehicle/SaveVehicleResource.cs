
using System.ComponentModel.DataAnnotations;

namespace RentCar.Application.Resources.Vehicle
{
    public class SaveVehicleResource
    {
        [Required]
        [MaxLength(20)]
        public string RegistrationNumber { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public double DailyPrice { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime Year { get; set; }
        [Required]
        [MaxLength(10)]
        public string Mileage { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public bool? Status { get; set; }
        public int VehicleModelId { get; set; }
    }
}
