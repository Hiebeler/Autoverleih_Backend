using System.Linq.Expressions;

namespace urlaubsplanungstool_backend.Db.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(object id);
        Task<List<T>> GetAll();
        Task<List<T>?> Find(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}