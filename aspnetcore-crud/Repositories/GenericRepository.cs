using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace aspnetcore_crud.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext context;

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }

        public T Add(T entity)
        {
            return context
                .Add(entity)
                .Entity;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return context.Find<T>(id);
        }

        public IEnumerable<T> All()
        {
            return context.Set<T>()
                .ToList();
        }

        public T Update(T entity)
        {
            return context.Update(entity)
                .Entity;
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
