﻿using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Services.Base;

namespace LaunchTimeDB.Domain.Interfaces.Services
{
    public interface IRestaurantService : IServiceBase<Restaurant>
    {
        bool IsValid(long id, string name, bool isNew);

        long GetNextId();
    }
}
