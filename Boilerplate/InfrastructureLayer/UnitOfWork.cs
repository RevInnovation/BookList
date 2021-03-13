using Boilerplate.Helpers.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Boilerplate.InfrastructureLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _context;
        public DbContext Context => _context;

        public UnitOfWork(DatabaseEntities context)
        {
            this._context = context;
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }


        public void Rollback()
        {
            _context.Dispose();
        }
        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
