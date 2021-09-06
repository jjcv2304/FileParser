using System.Collections.Generic;
using System.IO;

namespace Parser.FilesServices
{
    public static class File
    {
        internal static IEnumerable<string?> LinesContentByName(string fileName)
        {
            using var reader = new StreamReader(fileName);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

    }
}