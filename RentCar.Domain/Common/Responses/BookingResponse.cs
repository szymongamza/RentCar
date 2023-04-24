using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Domain.Entities;

namespace RentCar.Domain.Common.Responses;
public class BookingResponse : BaseResponse<Booking>
{
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="booking">Saved booking.</param>
    /// <returns>Response.</returns>
    public BookingResponse(Booking booking) : base(booking)
    { }

    /// <summary>
    /// Creates am error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public BookingResponse(string message) : base(message)
    { }
}
