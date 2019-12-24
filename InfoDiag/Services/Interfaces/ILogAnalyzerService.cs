using System.Collections.Generic;
using Services.Models;

namespace Services.Interfaces
{
    public interface ILogAnalyzerService
    {
        IEnumerable<LogLine> MapToLines(string logPath);
    }
}
