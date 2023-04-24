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
public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
{
    public VehicleModelRepository(RentCarDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<VehicleModel>> ToListAsync(VehicleModelQuery query)
    {
        IQueryable<VehicleModel> queryable = _dbContext.VehicleModels
            .Include(p => p.Manufacturer)
            .AsNoTracking();

        // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
        // tracking makes the code a little faster
        if (query.ManufacturerId is > 0)
        {
            queryable = queryable.Where(p => p.ManufacturerId == query.ManufacturerId);
        }

        // Here I count all items present in the database for the given query, to return as part of the pagination data.
        int totalItems = await queryable.CountAsync();

        // Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
        // and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
        List<VehicleModel> vehicleModels = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
            .Take(query.ItemsPerPage)
            .ToListAsync();

        // Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
        return new QueryResult<VehicleModel>
        {
            Items = vehicleModels,
            TotalItems = totalItems,
        };
    }
}
