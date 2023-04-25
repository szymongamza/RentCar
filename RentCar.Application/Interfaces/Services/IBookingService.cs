using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services;
public interface IBookingService
{
    Task<QueryResult<Booking>> ListAsync(BookingQuery query);
    Task<BookingResponse> AddAsync(Booking booking);
    Task<BookingResponse> UpdateAsync(int id, Booking booking);
    Task<BookingResponse> DeleteAsync(int id);
}
