using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Repositories;
public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(RentCarDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Vehicle> FindByIdAsyncIncludeAll(int id)
    {
        return await _dbContext.Vehicles
            .Include(p => p.Bookings).AsSingleQuery()
            .Include(x=>x.VehicleModel.Manufacturer).AsSingleQuery()
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<QueryResult<Vehicle>> ToListAsync(VehicleQuery query)
    {
        IQueryable<Vehicle> queryable = _dbContext.Vehicles
            .Include(p => p.VehicleModel).AsSingleQuery()
            .Include(p=>p.VehicleModel.Manufacturer).AsSingleQuery()
            .Include(p=>p.Bookings).AsSingleQuery()
            .AsNoTracking();

        // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
        // tracking makes the code a little faster
        if (query.VehicleModelId is > 0)
        {
            queryable = queryable.Where(p => p.VehicleModelId == query.VehicleModelId);
        }

        if (query.StartDateTime is not null && query.EndDateTime is not null)
            queryable = queryable.Where(v => !v.Bookings.Any(b => b.PickUpTime.AddHours(-2) <= query.EndDateTime && b.DropOffTime.AddHours(2) >= query.StartDateTime));


        // Here I count all items present in the database for the given query, to return as part of the pagination data.
        int totalItems = await queryable.CountAsync();

        // Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
        // and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
        List<Vehicle> vehicles = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
            .Take(query.ItemsPerPage)
            .ToListAsync();

        // Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
        return new QueryResult<Vehicle>
        {
            Items = vehicles,
            TotalItems = totalItems,
        };
    }
}
