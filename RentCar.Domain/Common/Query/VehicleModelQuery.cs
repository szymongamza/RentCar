using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Common.Query;
public class VehicleModelQuery : Query
{
    public int? ManufacturerId { get; set; }

    public VehicleModelQuery(int? manufacturerId, int page, int itemsPerPage) : base(page, itemsPerPage)
    {
        ManufacturerId = manufacturerId;
    }
}