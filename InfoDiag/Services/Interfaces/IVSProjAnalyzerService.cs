namespace Services.Interfaces
{
    using Services.Models;

    public interface IVSProjAnalyzerService
    {
        ServiceCallResult<int> Process(string projPath);
    }
}
