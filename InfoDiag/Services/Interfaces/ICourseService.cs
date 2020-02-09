namespace Services.Interfaces
{
    using Services.Models;

    public interface ICourseService
    {
        ServiceCallResult ProcessCourseGroupAlias(string alias, int clientId);
    }
}
