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
    public int ManufacturerId { get; set; }
}
