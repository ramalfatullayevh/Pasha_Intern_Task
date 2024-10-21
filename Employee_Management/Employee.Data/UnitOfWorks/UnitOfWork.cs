using Employee.Core.Base;
using Employee.Data.Context;
using Employee.Data.Repositories.Abstraction;
using Employee.Data.Repositories.Concrete;

namespace Employee.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity, new()
        {
            return new Repository<T>(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
