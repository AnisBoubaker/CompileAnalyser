namespace Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Services.Interfaces;
    using Services.Models;

    internal class LogAnalyzerService : BaseService, ILogAnalyzerService
    {
        private const int FileNameGroup = 1;
        private const int LineGroup = 2;
        private const int ErrorCodeGroup = 4;
        private const int CriticityGroup = 3;
        private const int ErrorMessageGroup = 5;
        private readonly Regex logLineRegex = new Regex(".+\\\\(\\w+.\\w)\\((\\d+)\\): (\\w+) *(\\w{1,2}\\d{4})?: (.+)");

        public IEnumerable<LogLine> MapToLines(string logPath)
        {
            var lines = File.ReadAllLines(logPath);

            var logLines = new List<LogLine>();

            foreach (var line in lines)
            {
                var match = logLineRegex.Match(line);
                if (match.Success)
                {
                    logLines.Add(new LogLine
                    {
                        FileName = match.Groups[FileNameGroup].Value,
                        Line = int.Parse(match.Groups[LineGroup].Value),
                        Code = match.Groups[ErrorCodeGroup].Value,
                        Message = match.Groups[ErrorMessageGroup].Value,
                        Criticity = match.Groups[CriticityGroup].Value,
                    });
                }
            }

            return logLines;
        }
    }
}
