using Employee.Core.Base;
using System.Linq.Expressions;

namespace Employee.Data.Repositories.Abstraction
{
    public interface IRepository<T> where T : BaseEntity, new() 
    {
        //Get All
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);


        //GetById
        Task<T> GetByIdAsync(int id);

        //Get
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);


        //Add
        Task AddAsync(T entity);

        //Delete
        Task DeleteAsync(int id);

        //Update
        Task<T> UpdateAsync(T entity);

    }
}
