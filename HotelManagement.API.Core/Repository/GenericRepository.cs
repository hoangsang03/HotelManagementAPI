using HotelManagementAPI.Contracts;
using HotelManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelManagementDbContext _context;

        public GenericRepository(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            _ = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public Task<List<T>> GetAllAsync()
        {
            var entities = _context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
