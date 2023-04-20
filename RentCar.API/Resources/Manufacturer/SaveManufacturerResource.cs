using System.ComponentModel.DataAnnotations;

namespace RentCar.API.Resources.Manufacturer;

public class SaveManufacturerResource
{
    [Required]
    [MaxLength(30)]
    public string ManufacturerName { get; set; }
}