using Services.Models;

namespace Services.Interfaces
{
    public interface IVSProjAnalyzerService
    {
        ServiceCallResult<int> Process(string projPath);
    }
}
