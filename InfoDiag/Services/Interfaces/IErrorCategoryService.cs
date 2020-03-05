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

        ServiceCallResult Assign(int categoryId, params string[] errorCodeIds);

        ServiceCallResult Unassign(params string[] errorCodeIds);

        ServiceCallResult<ErrorCategoryDto> Add(string name);

        ServiceCallResult Delete(int category);
    }
}
