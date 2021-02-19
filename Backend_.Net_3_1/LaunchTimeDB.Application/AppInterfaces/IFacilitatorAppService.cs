using LaunchTimeDB.Application.InputModels.Facilitators;
using LaunchTimeDB.Application.ViewModels.Facilitators;
using System;

namespace LaunchTimeDB.Application.AppInterfaces
{
    public interface IFacilitatorAppService
    {
        FacilitatorDetailViewModel GetById(int id);

        FacilitatorListViewModel GetAll();

        FacilitatorDetailViewModel Insert(FacilitatorInputModel inputModel);

        FacilitatorDetailViewModel Update(FacilitatorInputModel inputModel);

        void Delete(int id);
    }
}
