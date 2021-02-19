using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Services.Base;
using System;

namespace LaunchTimeDB.Domain.Interfaces.Services
{
    public interface IFacilitatorService : IServiceBase<Facilitator>
    {
        bool IsValid(long id, long restaurantId, DateTime launchDate, bool isNew);

        long GetNextId();
    }
}
