﻿using Microsoft.EntityFrameworkCore;
using RentCar.Application.Intefaces;
using RentCar.Domain.Common;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly RentCarDbContext _dbContext;

        protected GenericRepository(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>?> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            T? exist = _dbContext.Set<T>().Find(entity.Id);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}