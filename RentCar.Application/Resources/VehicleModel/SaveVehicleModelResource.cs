using System.ComponentModel.DataAnnotations;

namespace RentCar.Application.Resources.VehicleModel;

public class SaveVehicleModelResource
{
    [Required]
    [MaxLength(50)]
    public string ModelName { get; set; }
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    [Required]
    public int NumberOfSeats { get; set; }
    [Required]
    [MaxLength(50)]
    public string Range { get; set; }
    [Required]
    [MaxLength(50)]
    public string CargoCapacity { get; set; }
    [Required]
    public int ManufacturerId { get; set; }
}
