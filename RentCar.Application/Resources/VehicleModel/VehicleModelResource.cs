﻿using RentCar.Application.Resources.Manufacturer;

namespace RentCar.Application.Resources.VehicleModel;
public class VehicleModelResource
{
    public int Id { get; set; }
    public string ModelName { get; set; }
    public string Description { get; set; }
    public ManufacturerResource Manufacturer { get; set; }
}