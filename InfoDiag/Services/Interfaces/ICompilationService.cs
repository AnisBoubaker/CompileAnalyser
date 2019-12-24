using Microsoft.AspNetCore.Http;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICompilationService
    {
        ServiceCallResult<string> AddCompilation(IFormFile file);
    }
}
