using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_crud.Repositories
{
    public class OwnerRepository: GenericRepository<Owner>, IOwnerRepository, IDisposable
    {
        #region Implement IOwnerRepository
        private new readonly DataContext _repositoryContext;

        public OwnerRepository(DataContext _repositoryContext): base(_repositoryContext)
        {
            this._repositoryContext = _repositoryContext;
        }

        public async Task<Owner?> GetEntity(int ownerId)
        {
            return await _repositoryContext.Owners.FindAsync(ownerId);
        }

        public async Task<IEnumerable<Owner>> GetEntities()
        {
            return await _repositoryContext.Owners.ToListAsync();
        }
        
        public async Task<Owner?> GetEntityWithDetails(int ownerId)
        {
            return await _repositoryContext.Owners
                .Include(owner => owner.Accounts)
                .FirstOrDefaultAsync(owner => owner.Id == ownerId);
        }

        public void CreateEntity(Owner owner)
        {
            _repositoryContext.Owners.Add(owner);
            _repositoryContext.SaveChanges();
        }

        public void UpdateEntity(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            dbOwner.DateOfBirth = owner.DateOfBirth;

            _repositoryContext.Owners.Update(dbOwner);
            _repositoryContext.SaveChanges();
        }

        public void DeleteEntity(Owner owner)
        {
            _repositoryContext.Owners.Remove(owner);
            _repositoryContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    _repositoryContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
