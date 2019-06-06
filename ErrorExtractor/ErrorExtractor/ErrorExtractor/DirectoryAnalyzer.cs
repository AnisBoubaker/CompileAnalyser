using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ErrorExtractor
{
    internal class DirectoryAnalyzer
    {
        private static Regex CodeRegex = new Regex("\\w{1,3}\\d{4}");

        internal static IEnumerable<Error> ProcessDirectory(string directory, string linkstart)
        {
            var files = Directory.EnumerateFiles(directory);
            var errors = new List<Error>();

            foreach (var file in files)
            {
                var error = ProcessFile(file, linkstart + "/" + file.Split('\\').Last());

                if (error != null)
                {
                    errors.Add(error);
                }
            }

            return errors;
        }

        private static Error ProcessFile(string file, string link)
        {
            var match = CodeRegex.Match(file);
            if (!match.Success)
            {
                return null;
            }

            var error = new Error
            {
                Code = match.Value.ToUpper(),
            };

            var lines = File.ReadAllLines(file);

            error.Name = lines[1].Split('\"')[1];

            if (error.Name.ToLower().Contains("through"))
            {
                return null;
            }

            error.Title = lines[9];

            error.Link = link;

            if (error.Link.ToLower().Contains("through"))
            {
                return null;
            }

            return error;
        }
    }
}