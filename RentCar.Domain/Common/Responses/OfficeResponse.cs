
using RentCar.Domain.Entities;

namespace RentCar.Domain.Common.Responses;
public class OfficeResponse : BaseResponse<Office>
{
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="office">Saved office.</param>
    /// <returns>Response.</returns>
    public OfficeResponse(Office office) : base(office)
    {
    }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public OfficeResponse(string message) : base(message)
    {
    }
}
