using aspnetcore_crud.Data;
using aspnetcore_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_crud.Services
{
    public class OwnerRepository: IOwnerRepository, IDisposable
    {
        private readonly DataContext _repositoryContext;
        public OwnerRepository(DataContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public async Task<Owner?> GetOwner(int ownerId)
        {
            return await _repositoryContext.Owners.FindAsync(ownerId);
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            return await _repositoryContext.Owners.ToListAsync();
        }
        
        public async Task<Owner> GetOwnerWithDetails(int ownerId)
        {
            return await _repositoryContext.Owners
                .Include(owner => owner.Accounts)
                .FirstOrDefaultAsync(owner => owner.Id == ownerId);
        }

        public void CreateOwner(Owner owner)
        {
            _repositoryContext.Owners.Add(owner);
            _repositoryContext.SaveChanges();
        }

        public void UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            dbOwner.DateOfBirth = owner.DateOfBirth;

            _repositoryContext.Owners.Update(dbOwner);
            _repositoryContext.SaveChanges();
        }

        public void DeleteOwner(Owner owner)
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
    }
}
