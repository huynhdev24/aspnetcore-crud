using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_crud.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _repositoryContext;
        internal DbSet<T> DbSet { get; set; }
        public GenericRepository(DataContext _repositoryContext)
        {
            this._repositoryContext = _repositoryContext;
            this.DbSet = this._repositoryContext.Set<T>();
        }
        public virtual void CreateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateEntity(T dbEntity, T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T?> GetEntityWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
