using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace urlaubsplanungstool_backend.Db.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetById(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>?> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            EntityEntry<T> addedEntity =  await _dbContext.Set<T>().AddAsync(entity);
            return addedEntity.Entity;
        }

        public void Update(T entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }
    }
}