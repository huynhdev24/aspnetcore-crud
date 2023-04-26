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
        public virtual Task<bool> AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return this.DbSet.ToListAsync();
        }

        public virtual Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
