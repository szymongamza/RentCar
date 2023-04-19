using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Intefaces;
using RentCar.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCar.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ManufacturersController : ControllerBase
{
    private readonly IManufacturerRepository _manufacturerRepository;
    // GET: api/<ManufacturersController>
    public ManufacturersController(IManufacturerRepository manufacturerRepository)
    {
        _manufacturerRepository = manufacturerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _manufacturerRepository.GetAllAsync());
    }

    // GET api/<ManufacturersController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _manufacturerRepository.GetByIdAsync(id));
    }

    // POST api/<ManufacturersController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Manufacturer manufacturer)
    {
        await _manufacturerRepository.AddAsync(manufacturer);
        return Ok();
    }

    // PUT api/<ManufacturersController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Manufacturer manufacturer)
    {
        if (id != manufacturer.Id)
        {
            return BadRequest();
        }
        var manufacturerObj = await _manufacturerRepository.GetByIdAsync(id);
        if (manufacturerObj is null)
        {
            return NotFound();
        }

        await _manufacturerRepository.UpdateAsync(manufacturerObj);

        return Ok();
    }

    // DELETE api/<ManufacturersController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var manufacturerObj = await _manufacturerRepository.GetByIdAsync(id);
        if (manufacturerObj is null)
        {
            return NotFound();
        }
        await _manufacturerRepository.DeleteAsync(manufacturerObj);
        return Ok();
    }
}
