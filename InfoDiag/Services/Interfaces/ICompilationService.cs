using Microsoft.AspNetCore.Http;

namespace Services.Interfaces
{
    public interface ICompilationService
    {
        string AddCompilation(IFormFile file);
    }
}
