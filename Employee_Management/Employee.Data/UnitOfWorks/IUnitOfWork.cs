using Employee.Core.Base;
using Employee.Data.Repositories.Abstraction;

namespace Employee.Data.UnitOfWorks
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        //Get Repository
        IRepository<T> GetRepository<T>() where T : BaseEntity, new();

        //Save
        Task<int> SaveAsync();

        int Save();
    }
}
