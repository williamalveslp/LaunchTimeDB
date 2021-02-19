using System.Collections.Generic;

namespace LaunchTimeDB.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        T Insert(T entity);

        T Update(T entity);

        T GetById(long entityId);

        IList<T> GetAll();

        void DeleteById(long entityId);
    }
}
