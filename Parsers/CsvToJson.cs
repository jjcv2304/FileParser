using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Parser.FilesServices;
using File = Parser.FilesServices.File;

namespace Parser.Parsers
{
    public static class CsvToJson
    {
        internal static void Parse(string sourceFilename)
        {
            string destFilename = sourceFilename.Replace(ParseConstants.CsvExtension, ParseConstants.JsonExtension);
            var inputFilePath = "." + Path.DirectorySeparatorChar + sourceFilename;
            var outputFilePath = "." + Path.DirectorySeparatorChar + destFilename;
            var inputContent = File.LinesContentByName(inputFilePath);
            var outputContent = CsvContentToJsonContent(inputContent);

            var outputContentAsText = outputContent.ToList();
            JsonFiles.WriteToJsonFile(outputFilePath, outputContentAsText);
        }
        private static IEnumerable<JObject> CsvContentToJsonContent(IEnumerable<string?> csvLines)
        {
            var csvLinesList = csvLines.ToList();

            var header = csvLinesList[0]?.Split(',');
            for (var i = 1; i < csvLinesList.Count; i++)
            {
                var thisLineSplit = csvLinesList[i]?.Split(',');
                var pairedWithHeader = header?.Zip(thisLineSplit ?? Array.Empty<string>(), (h, v) => new KeyValuePair<string, string>(h, v));

                yield return new JObject((pairedWithHeader ?? Array.Empty<KeyValuePair<string, string>>()).Select(j => new JProperty(j.Key, j.Value)));
            }
        }
    }
}