using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Common.Query;
public class VehicleQuery : Query
{
    public int? VehicleModelId;
    public DateTime? StartDateTime;
    public DateTime? EndDateTime;
    public bool? Status;
    public VehicleQuery(int? vehicleModelId,int page, int itemsPerPage, DateTime? startDateTime, DateTime? endDateTime, bool? status) : base(page, itemsPerPage)
    {
        VehicleModelId = vehicleModelId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
    }
}
