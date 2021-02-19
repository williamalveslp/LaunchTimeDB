using System.Collections.Generic;

namespace LaunchTimeDB.Domain.Interfaces.Services.Base
{
    public interface IServiceBase<T> where T : class
    {
        /// <summary>
        /// Insert the entity on database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Insert(T entity);

        /// <summary>
        /// Update the registers.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Get the entity by Id.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        T GetById(long entityId);

        /// <summary>
        /// Get all register.
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Delete the register by Id.
        /// </summary>
        /// <param name="entityId"></param>
        void DeleteById(long entityId);
    }
}
