using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Repositories;

namespace aspnetcore_crud.UnitOfWork
{
    public class UnitofWork: IUnitofWork
    {
        public IOwnerRepository ownerrepo { get; private set; }

        private readonly DataContext _repositoryContext;

        public UnitofWork(DataContext _repositoryContext)
        {
            this._repositoryContext = _repositoryContext;
            ownerrepo = new OwnerRepository(_repositoryContext);
        }

        public async Task CompleteAsync()
        {
            await this._repositoryContext.SaveChangesAsync();
        }
    }
}
