using aspnetcore_crud.Models;

namespace aspnetcore_crud.Services
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetOwners();
        Task<Owner> GetOwner(int ownerId);
        Task<Owner> GetOwnerWithDetails(int ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner dbowner, Owner owner);
    }
}
