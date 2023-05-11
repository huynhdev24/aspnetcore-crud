using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Models;
using aspnetcore_crud.Repositories;
using Castle.Core.Resource;

namespace aspnetcore_crud.UnitOfWork
{
    public class UnitofWork: IUnitofWork
    {
        private DataContext context;
        private IGenericRepository<Owner> ownerRepository;

        public UnitofWork(DataContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Owner> OwnerRepository
        {
            get
            {
                if (ownerRepository == null)
                {
                    ownerRepository = new OwnerRepository(context);
                }

                return ownerRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
