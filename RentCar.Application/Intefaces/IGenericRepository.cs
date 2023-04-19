using RentCar.Domain.Common;

namespace RentCar.Application.Intefaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> AddAsync(T entity);

        public Task DeleteAsync(T entity);

        public Task<List<T>?> GetAllAsync();

        public Task<T?> GetByIdAsync(int id);

        public Task UpdateAsync(T entity);
    }
}
