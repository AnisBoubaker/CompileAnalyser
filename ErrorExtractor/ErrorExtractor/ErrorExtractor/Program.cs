using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ErrorExtractor
{
    class Program
    {
        private const string linkstart = "https://github.com/MicrosoftDocs/cpp-docs/blob/master/docs/error-messages/";

        static void Main(string[] args)
        {
            var mainFiles = Directory.EnumerateDirectories(args[0]);

            List<Error> errors = new List<Error>();

            foreach (var directory in mainFiles)
            {
                errors.AddRange(DirectoryAnalyzer.ProcessDirectory(directory, linkstart + directory.Split('\\').Last()));
            }

            var json = JsonConvert.SerializeObject(errors, Formatting.Indented);

            var outputpath = Directory.GetCurrentDirectory() + "\\error.json";

            File.WriteAllText(outputpath, json);

            Console.WriteLine("The errors are in " + outputpath);
        }
    }
}
