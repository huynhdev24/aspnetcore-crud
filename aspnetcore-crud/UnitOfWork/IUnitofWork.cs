using aspnetcore_crud.Interfaces;

namespace aspnetcore_crud.UnitOfWork
{
    public interface IUnitofWork
    {
        IOwnerRepository Ownerrepo { get; }

        Task CompleteAsync();
    }
}
