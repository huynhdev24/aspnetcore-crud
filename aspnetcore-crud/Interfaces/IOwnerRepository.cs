using aspnetcore_crud.Models;

namespace aspnetcore_crud.Interfaces
{
    public interface IOwnerRepository : IDisposable, IGenericRepository<Owner>
    {
        
    }
}
