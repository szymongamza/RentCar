using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Repositories;
public class OfficeRepository : GenericRepository<Office>, IOfficeRepository
{
    public OfficeRepository(RentCarDbContext dbContext) : base(dbContext)
    {
    }
}
