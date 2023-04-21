using System.ComponentModel.DataAnnotations;

namespace RentCar.Application.Resources.Manufacturer;

public class SaveManufacturerResource
{
    [Required]
    [MaxLength(30)]
    public string ManufacturerName { get; set; }
}