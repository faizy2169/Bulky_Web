using System.Linq.Expressions;

namespace BulkeyWeb.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
         T Find(Expression<Func<T, bool>> filter);

        public void Add(T entity);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
    }
}
