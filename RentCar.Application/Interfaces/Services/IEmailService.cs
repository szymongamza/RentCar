using System.Reflection;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services;
public interface IEmailService
{
    public void SendEmail(string emailAddress, string title, string body);
}
