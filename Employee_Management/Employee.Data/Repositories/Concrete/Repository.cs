using Employee.Core.Base;
using Employee.Data.Context;
using Employee.Data.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _obj;

        public Repository(AppDbContext context)
        {
            _context = context;
            _obj = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _obj.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _obj.FindAsync(id);
            if (entity != null)  _obj.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _obj.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _obj.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _obj.Update(entity));
            return entity;
        }
    }
}
