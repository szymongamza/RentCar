using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCar.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DateTimeController : ControllerBase
{
    private readonly IDateTimeService _dateTimeService;

    public DateTimeController(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }

    [HttpGet]
    public IActionResult GetTime()
    {
        return Ok(_dateTimeService.CurrentDateTime());
    }

}
