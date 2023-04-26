using aspnetcore_crud.Interfaces;

namespace aspnetcore_crud.UnitOfWork
{
    public interface IUnitofWork
    {
        IOwnerRepository ownerrepo { get; }

        Task CompleteAsync();
    }
}
