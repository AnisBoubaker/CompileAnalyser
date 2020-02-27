using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TalentMontreal.Entities;

namespace Services.Interfaces
{
    public interface IErrorCategoryService
    {
        ServiceCallResult<ErrorCategoryDto> GetAll();
    }
}
