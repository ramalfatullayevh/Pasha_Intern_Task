using Employee.Core.Base;
using Employee.Data.Context;
using Employee.Data.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _obj;

            // Əlaqəli məlumatları daxil et
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            // Əgər predicate varsa, tətbiq edin
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _obj;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.SingleAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _obj.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _obj.Update(entity);
            return entity;
        }
    }
}
