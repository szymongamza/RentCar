using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Interfaces.Services;
using RentCar.Application.Resources;
using RentCar.Application.Resources.VehicleModel;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;

namespace RentCar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleModelsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IVehicleModelService _vehicleModelService;
    public VehicleModelsController(IMapper mapper, IVehicleModelService vehicleModelService)
    {
        _mapper = mapper;
        _vehicleModelService = vehicleModelService;
    }

    /// <summary>
    /// Lists all existing vehicle models.
    /// </summary>
    /// <returns>List of vehicle models.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<VehicleModelResource>), 200)]
    public async Task<QueryResultResource<VehicleModelResource>> ListAsync([FromQuery] VehicleModelQueryResource query)
    {
        var vehicleModelQuery = _mapper.Map<VehicleModelQueryResource, VehicleModelQuery>(query);
        var queryResult = await _vehicleModelService.ListAsync(vehicleModelQuery);

        var resource = _mapper.Map<QueryResult<VehicleModel>, QueryResultResource<VehicleModelResource>>(queryResult);
        return resource;
    }

    /// <summary>
    /// Saves a new vehicle model.
    /// </summary>
    /// <param name="resource">Vehicle model data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(VehicleModelResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveVehicleModelResource resource)
    {
        var vehicleModel = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
        var result = await _vehicleModelService.AddAsync(vehicleModel);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.Resource);
        return Ok(vehicleModelResource);
    }

    /// <summary>
    /// Updates an existing vehicle model according to an identifier.
    /// </summary>
    /// <param name="id">Vehicle model identifier.</param>
    /// <param name="resource">Vehicle model data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(VehicleModelResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVehicleModelResource resource)
    {
        var vehicleModel = _mapper.Map<SaveVehicleModelResource, VehicleModel>(resource);
        var result = await _vehicleModelService.UpdateAsync(id, vehicleModel);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.Resource);
        return Ok(vehicleModelResource);
    }

    /// <summary>
    /// Deletes a given vehicle model according to an identifier.
    /// </summary>
    /// <param name="id">Vehicle model identifier.</param>
    /// <returns>Response for the request.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(VehicleModelResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _vehicleModelService.DeleteAsync(id);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var vehicleModelResource = _mapper.Map<VehicleModel, VehicleModelResource>(result.Resource);
        return Ok(vehicleModelResource);
    }
}