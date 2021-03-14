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
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();

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
