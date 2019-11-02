namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Services.Models;

    public interface ILogAnalyzerService
    {
        IEnumerable<LogLine> MapToLines(string logPath);
    }
}
