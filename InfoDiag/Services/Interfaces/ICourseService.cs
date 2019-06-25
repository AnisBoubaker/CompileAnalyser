using Services.Models;

namespace Services.Interfaces
{
    public interface ICourseService
    {
        ServiceCallResult ProcessCourseGroupAlias(string alias, int clientId);
    }
}
