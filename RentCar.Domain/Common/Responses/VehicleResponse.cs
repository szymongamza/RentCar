
using RentCar.Domain.Entities;

namespace RentCar.Domain.Common.Responses;
public class VehicleResponse : BaseResponse<Vehicle>
{
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="vehicle">Saved vehicle.</param>
    /// <returns>Response.</returns>
    public VehicleResponse(Vehicle vehicle) : base(vehicle)
    {
    }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public VehicleResponse(string message) : base(message)
    {
    }
}
