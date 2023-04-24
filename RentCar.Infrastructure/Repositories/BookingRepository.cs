using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Repositories;
public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(RentCarDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Booking>> ToListAsync(BookingQuery query)
    {
        IQueryable<Booking> queryable = _dbContext.Bookings
            .Include(p => p.Vehicle.VehicleModel.Manufacturer).AsSingleQuery()
            .Include(p => p.PickUpOffice).AsSingleQuery()
            .Include(p => p.DropOffOffice).AsSingleQuery()
            .AsNoTracking();

        // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
        // tracking makes the code a little faster
        if (query.VehicleId is > 0)
        {
            queryable = queryable.Where(p => p.VehicleId == query.VehicleId);
        }
        if (query.FromDateTime is not null)
        {
            queryable = queryable.Where(p => p.PickUpTime >= query.FromDateTime);
        }
        if (query.ToDateTime is not null)
        {
            queryable = queryable.Where(p => p.DropOffTime <= query.ToDateTime);
        }
        if (query.EmailAddress is not null)
        {
            queryable = queryable.Where(p => p.EmailAddress.ToUpper() == query.EmailAddress.ToUpper());
        }
        if (query.PhoneNumber is not null)
        {
            queryable = queryable.Where(p => p.PhoneNumber == query.PhoneNumber);
        }

        // Here I count all items present in the database for the given query, to return as part of the pagination data.
        int totalItems = await queryable.CountAsync();

        // Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
        // and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
        List<Booking> bookings = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
            .Take(query.ItemsPerPage)
            .ToListAsync();

        // Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
        return new QueryResult<Booking>
        {
            Items = bookings,
            TotalItems = totalItems,
        };
    }
}
