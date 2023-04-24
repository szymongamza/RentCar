using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Interfaces.Services;
using RentCar.Application.Resources;
using RentCar.Application.Resources.Vehicle;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;

namespace RentCar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IVehicleService _vehicleService;
    public VehiclesController(IMapper mapper, IVehicleService vehicleService)
    {
        _mapper = mapper;
        _vehicleService = vehicleService;
    }

    /// <summary>
    /// Lists all existing vehicles.
    /// </summary>
    /// <returns>List of vehicles.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<VehicleResource>), 200)]
    public async Task<QueryResultResource<VehicleResource>> ListAsync([FromQuery] VehicleQueryResource query)
    {
        var vehicleQuery = _mapper.Map<VehicleQueryResource, VehicleQuery>(query);
        var queryResult = await _vehicleService.ListAsync(vehicleQuery);

        var resource = _mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);
        return resource;
    }

    /// <summary>
    /// Saves a new vehicle.
    /// </summary>
    /// <param name="resource">Vehicle data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(VehicleResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveVehicleResource resource)
    {
        var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(resource);
        var result = await _vehicleService.AddAsync(vehicle);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(result.Resource);
        return Ok(vehicleResource);
    }

    /// <summary>
    /// Updates an existing vehicle according to an identifier.
    /// </summary>
    /// <param name="id">Vehicle identifier.</param>
    /// <param name="resource">Vehicle data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(VehicleResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVehicleResource resource)
    {
        var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(resource);
        var result = await _vehicleService.UpdateAsync(id, vehicle);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(result.Resource);
        return Ok(vehicleResource);
    }

    /// <summary>
    /// Deletes a given vehicle according to an identifier.
    /// </summary>
    /// <param name="id">Vehicle identifier.</param>
    /// <returns>Response for the request.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(VehicleResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _vehicleService.DeleteAsync(id);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(result.Resource);
        return Ok(vehicleResource);
    }
}