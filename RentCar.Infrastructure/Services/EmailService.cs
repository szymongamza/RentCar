

using RentCar.Application.Interfaces.Services;

namespace RentCar.Infrastructure.Services;
public class EmailService : IEmailService
{
    public void SendEmail(string emailAddress, string title, string body)
    {
        Console.WriteLine($@"Email send to: {emailAddress}");
    }
}
