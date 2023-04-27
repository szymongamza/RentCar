using RentCar.Application.Interfaces.Services;

namespace RentCar.Infrastructure.Services;
public class DateTimeService : IDateTimeService
{
    public DateTime CurrentDateTime()
    {
        return DateTime.Now;
    }
}
