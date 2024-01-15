using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.IRepositories;

namespace MyApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EMDbContext _dbContext;
        public Repository(EMDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteByIdAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            int row = await _dbContext.SaveChangesAsync();
            return row > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateByIdAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
