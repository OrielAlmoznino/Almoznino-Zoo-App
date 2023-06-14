using Microsoft.EntityFrameworkCore;
using ZooDAL.Entities;
using ZooDAL.Services.Interfaces;

namespace ZooDAL.Services
{
   // Add To ZooService "Base"
    public class ZooServiceBase<T> : IZooServiceBase<T> where T : class , IEntity
    {
        protected readonly ZooDbContext _dbContext;
        public ZooServiceBase(ZooDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var dbSet = _dbContext.Set<T>();
            var entitiesList = await dbSet.ToListAsync();

            return entitiesList;
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            var dbSet = _dbContext.Set<T>();

            var existingEntity = await dbSet.FindAsync(id);
            if (existingEntity == null)
            {
                throw new ArgumentException($"Entity with ID {id} does not exist.");
            }

            return existingEntity;
        }
        public async Task CreateAsync(T entity)
        {
          var dbSet = _dbContext.Set<T>();
          await dbSet.AddAsync(entity); 
          await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var dbSet = _dbContext.Set<T>();

            var existingEntity = await dbSet.FindAsync(id);
            if(existingEntity == null)
            {
                throw new ArgumentException($"Entity with ID {id} does not exist.");
            }
            dbSet.Remove(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Guid id, T entity)
        {
            var dbSet = _dbContext.Set<T>();

            var existingEntity = await dbSet.FindAsync(id);
            if (existingEntity == null)
            {
                throw new ArgumentException($"Entity with ID {id} does not exist.");
            }
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
       
    }
}
