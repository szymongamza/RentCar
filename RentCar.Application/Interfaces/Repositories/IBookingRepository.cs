

using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Repositories;
public interface IBookingRepository : IGenericRepository<Booking>
{
    Task<QueryResult<Booking>> ToListAsync(BookingQuery query);
}
