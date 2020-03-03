using Entity.DTO;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IErrorCategoryService
    {
        ServiceCallResult<IEnumerable<ErrorCategoryDto>> GetAll();

        ServiceCallResult Assign(string errorCodeId, int categoryId);

        ServiceCallResult<ErrorCategoryDto> Add(string name);

        ServiceCallResult Delete(int category);
    }
}
