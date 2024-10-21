using Employee.Core.Base;
using System.Linq.Expressions;

namespace Employee.Data.Repositories.Abstraction
{
    public interface IRepository<T> where T : BaseEntity, new() 
    {
        //Get All
        Task<ICollection<T>> GetAllAsync();


        //GetById
        T GetByIdAsync(int id);

        //Add
        Task AddAsync(T entity);

        //Delete
        Task DeleteAsync(int id);

        //Update
        Task<T> UpdateAsync(T entity);

    }
}
