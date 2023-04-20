using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.DTOs;
using RentCar.Application.Interfaces.Services;
using RentCar.Application.Responses;
using RentCar.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCar.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ManufacturersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IManufacturerService _manufacturerService;
    public ManufacturersController(IMapper mapper, IManufacturerService manufacturerService)
    {
        _mapper = mapper;
        _manufacturerService = manufacturerService;
    }

    /// <summary>
    /// Lists all categories.
    /// </summary>
    /// <returns>List os categories.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadManufacturer>), 200)]
    public async Task<IEnumerable<ReadManufacturer>> ListAsync()
    {
        var manufacturers = await _manufacturerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ReadManufacturer>>(manufacturers);

        return resources;
    }

    /// <summary>
    /// Saves a new manufacturer.
    /// </summary>
    /// <param name="resource">Manufacturer data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ReadManufacturer), 201)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> PostAsync([FromBody] CreateManufacturer resource)
    {
        var manufacturer = _mapper.Map<CreateManufacturer, Manufacturer>(resource);
        var result = await _manufacturerService.AddAsync(manufacturer);

        if (!result.Success)
        {
            return BadRequest(new ErrorResponse(result.Message));
        }

        var manufacturerResource = _mapper.Map<Manufacturer, ReadManufacturer>(result.Resource);
        return Ok(manufacturerResource);
    }

    /// <summary>
    /// Updates an existing manufacturer according to an identifier.
    /// </summary>
    /// <param name="id">Manufacturer identifier.</param>
    /// <param name="resource">Updated manufacturer data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ReadManufacturer), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] CreateManufacturer resource)
    {
        var manufacturer = _mapper.Map<CreateManufacturer, Manufacturer>(resource);
        var result = await _manufacturerService.UpdateAsync(id, manufacturer);

        if (!result.Success)
        {
            return BadRequest(new ErrorResponse(result.Message));
        }

        var categoryResource = _mapper.Map<Manufacturer, ReadManufacturer>(result.Resource);
        return Ok(categoryResource);
    }

    /// <summary>
    /// Deletes a given manufacturer according to an identifier.
    /// </summary>
    /// <param name="id">Manufacturer identifier.</param>
    /// <returns>Response for the request.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ReadManufacturer), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _manufacturerService.DeleteAsync(id);

        if (!result.Success)
        {
            return BadRequest(new ErrorResponse(result.Message));
        }

        var categoryResource = _mapper.Map<Manufacturer, ReadManufacturer>(result.Resource);
        return Ok(categoryResource);
    }
}
