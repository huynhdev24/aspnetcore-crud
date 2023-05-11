using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace aspnetcore_crud.Repositories
{
    public class OwnerRepository: GenericRepository<Owner>
    {
        public OwnerRepository(DataContext context) : base(context)
        {
        }

        public Owner Add(Owner owner)
        {
            return base.Add(owner);
        }

        public List<Owner> Find(Expression<Func<Owner, bool>> predicate)
        {
            return base.Find(predicate).ToList();
        }

        public Owner Get(Guid id)
        {
            return base.Get(id);
        }

        public List<Owner> All()
        {
            return base.All().ToList();
        }

        public Owner Update(Owner owner)
        {
            return base.Update(owner);
        }

        public void Delete(Owner entity)
        {
            base.Delete(entity);
        }
    }
}
