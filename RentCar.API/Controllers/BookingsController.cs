using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Interfaces.Services;
using RentCar.Application.Resources;
using RentCar.Application.Resources.Booking;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;

namespace RentCar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBookingService _bookingService;
    public BookingsController(IMapper mapper, IBookingService bookingService)
    {
        _mapper = mapper;
        _bookingService = bookingService;
    }

    /// <summary>
    /// Lists all existing bookings.
    /// </summary>
    /// <returns>List of bookings.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<BookingResource>), 200)]
    public async Task<QueryResultResource<BookingResource>> ListAsync([FromQuery] BookingQueryResource query)
    {
        var bookingQuery = _mapper.Map<BookingQueryResource, BookingQuery>(query);
        var queryResult = await _bookingService.ListAsync(bookingQuery);

        var resource = _mapper.Map<QueryResult<Booking>, QueryResultResource<BookingResource>>(queryResult);
        return resource;
    }

    /// <summary>
    /// Saves a new booking.
    /// </summary>
    /// <param name="resource">Booking data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(BookingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveBookingResource resource)
    {
        var booking = _mapper.Map<SaveBookingResource, Booking>(resource);
        var result = await _bookingService.AddAsync(booking);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var bookingResource = _mapper.Map<Booking, BookingResource>(result.Resource);
        return Ok(bookingResource);
    }

    /// <summary>
    /// Updates an existing booking according to an identifier.
    /// </summary>
    /// <param name="id">Booking identifier.</param>
    /// <param name="resource">Booking data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(BookingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBookingResource resource)
    {
        var booking = _mapper.Map<SaveBookingResource, Booking>(resource);
        var result = await _bookingService.UpdateAsync(id, booking);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var bookingResource = _mapper.Map<Booking, BookingResource>(result.Resource);
        return Ok(bookingResource);
    }

    /// <summary>
    /// Deletes a given booking according to an identifier.
    /// </summary>
    /// <param name="id">Booking identifier.</param>
    /// <returns>Response for the request.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(BookingResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bookingService.DeleteAsync(id);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var bookingResource = _mapper.Map<Booking, BookingResource>(result.Resource);
        return Ok(bookingResource);
    }
}