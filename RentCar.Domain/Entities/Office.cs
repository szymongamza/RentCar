
using RentCar.Domain.Common;

namespace RentCar.Domain.Entities;
public class Office : BaseEntity
{
    public string OfficeName { get; set; }
    public string PhoneNumber { get; set;}
    public string Address { get; set; }
    public TimeOnly TimeOpen { get; set; }
    public TimeOnly TimeClose { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}
