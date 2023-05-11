using aspnetcore_crud.Models;
using System.Linq.Expressions;

namespace aspnetcore_crud.Interfaces
{
    public interface IGenericRepository<T>
    {
        //Task<IEnumerable<T>> GetEntities();
        //Task<T> GetEntity(int id);
        //Task<T?> GetEntityWithDetails(int id);
        //void CreateEntity(T entity);
        //void UpdateEntity(T dbEntity, T entity);
        //void DeleteEntity(T entity);
        T Add(T entity);
        T Update(T entity);
        T Get(Guid id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
