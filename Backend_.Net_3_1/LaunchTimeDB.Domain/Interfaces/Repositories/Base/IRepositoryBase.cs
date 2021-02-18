﻿using System.Collections.Generic;

namespace LaunchTimeDB.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        T Insert(T entity);

        T Update(T entity);

        T GetById(int entityId);

        IList<T> GetAll();

        void DeleteById(int entityId);

        void Dispose();
    }
}
