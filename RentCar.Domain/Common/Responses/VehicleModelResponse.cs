

using RentCar.Domain.Entities;

namespace RentCar.Domain.Common.Responses;
public class VehicleModelResponse : BaseResponse<VehicleModel>
{
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="vehicleModel">Saved vehicle model.</param>
    /// <returns>Response.</returns>
    public VehicleModelResponse(VehicleModel vehicleModel) : base(vehicleModel)
    { }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public VehicleModelResponse(string message) : base(message)
    { }
}
