using Services.Interfaces;
using Services.Models;
using TalentMontreal.Entities;

namespace Services
{
    internal class ErrorCategoryService : BaseService, IErrorCategoryService
    {
        public ServiceCallResult<ErrorCategoryDto> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
