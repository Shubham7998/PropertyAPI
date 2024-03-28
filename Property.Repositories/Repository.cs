using Microsoft.EntityFrameworkCore;
using Property.Data;
using Property.IRepositories;

namespace Property.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PropertyDbContext _dbContext;
        public Repository(PropertyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            int row = await _dbContext.SaveChangesAsync();
            return row > 0;
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
