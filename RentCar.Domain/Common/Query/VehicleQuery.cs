using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Common.Query;
public class VehicleQuery : Query
{
    public int? VehicleModelId;
    public VehicleQuery(int? vehicleModelId,int page, int itemsPerPage) : base(page, itemsPerPage)
    {
        VehicleModelId = vehicleModelId;
    }
}
