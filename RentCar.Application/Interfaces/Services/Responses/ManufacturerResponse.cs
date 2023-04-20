using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services.Responses
{
    public class ManufacturerResponse : BaseResponse<Manufacturer>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="manufacturer">Saved manufacturer.</param>
        /// <returns>Response.</returns>
        public ManufacturerResponse(Manufacturer manufacturer) : base(manufacturer)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ManufacturerResponse(string message) : base(message)
        { }
    }
}
