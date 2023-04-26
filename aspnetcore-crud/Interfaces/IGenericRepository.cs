using aspnetcore_crud.Models;

namespace aspnetcore_crud.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetEntities();
        Task<T> GetEntity(int id);
        Task<T> GetEntityWithDetails(int id);
        void CreateEntity(T entity);
        void UpdateEntity(T dbEntity, T entity);
        void DeleteEntity(T entity);
    }
}
