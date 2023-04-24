using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Interfaces.Services;
using RentCar.Application.Resources;
using RentCar.Application.Resources.Office;
using RentCar.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCar.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OfficesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOfficeService _officeService;
    public OfficesController(IMapper mapper, IOfficeService officeService)
    {
        _mapper = mapper;
        _officeService = officeService;
    }

    /// <summary>
    /// Lists all categories.
    /// </summary>
    /// <returns>List os categories.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OfficeResource>), 200)]
    public async Task<IEnumerable<OfficeResource>> ListAsync()
    {
        var offices = await _officeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Office>, IEnumerable<OfficeResource>>(offices);

        return resources;
    }

    /// <summary>
    /// Saves a new office.
    /// </summary>
    /// <param name="resource">Office data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(OfficeResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveOfficeResource resource)
    {
        var office = _mapper.Map<SaveOfficeResource, Office>(resource);
        var result = await _officeService.AddAsync(office);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var officeResource = _mapper.Map<Office, OfficeResource>(result.Resource);
        return Ok(officeResource);
    }

    /// <summary>
    /// Updates an existing office according to an identifier.
    /// </summary>
    /// <param name="id">Office identifier.</param>
    /// <param name="resource">Updated office data.</param>
    /// <returns>Response for the request.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(OfficeResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOfficeResource resource)
    {
        var office = _mapper.Map<SaveOfficeResource, Office>(resource);
        var result = await _officeService.UpdateAsync(id, office);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var categoryResource = _mapper.Map<Office, OfficeResource>(result.Resource);
        return Ok(categoryResource);
    }

    /// <summary>
    /// Deletes a given office according to an identifier.
    /// </summary>
    /// <param name="id">Office identifier.</param>
    /// <returns>Response for the request.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(OfficeResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _officeService.DeleteAsync(id);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var categoryResource = _mapper.Map<Office, OfficeResource>(result.Resource);
        return Ok(categoryResource);
    }
}
