using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ILogAnalyzerService
    {
        IEnumerable<LogLine> MapToLines(string logPath);
    }
}
