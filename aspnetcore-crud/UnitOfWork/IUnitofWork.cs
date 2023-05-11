using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Models;

namespace aspnetcore_crud.UnitOfWork
{
    public interface IUnitofWork
    {
        IGenericRepository<Owner> OwnerRepository { get; }

        void SaveChanges();
    }
}
