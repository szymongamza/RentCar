using RentCar.Domain.Common;

namespace RentCar.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<T> AddAsync(T entity);

    public Task DeleteAsync(T entity);

    public Task<List<T>> ToListAsync();

    public Task<T> FindByIdAsync(int id);

    public Task UpdateAsync(T entity);
}