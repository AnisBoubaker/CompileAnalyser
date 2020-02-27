using System.Collections.Generic;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICourseService
    {
        ServiceCallResult ProcessCourseGroupAlias(string alias, int clientId);

        ServiceCallResult<IEnumerable<string>> GetCourseIds();
    }
}
