namespace Services.Interfaces
{
    using Microsoft.AspNetCore.Http;
    using Services.Models;

    public interface ICompilationService
    {
        ServiceCallResult<string> AddCompilation(IFormFile file);
    }
}
