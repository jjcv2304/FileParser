using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Parser.FilesServices;
using Parser.Parsers;

namespace Parser
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string operation = args[0];
            string sourceFilename = args[1];
            ValidatedInputParameters(operation, sourceFilename);

            switch (operation.ToLower())
            {
                case ParseConstants.CsvToJson:
                    CsvToJson.Parse(sourceFilename);
                    break;

                case ParseConstants.JsonToCsv:
                    throw new NotImplementedException();
                    break;

                default:
                    throw new InvalidOperationException("The operation type must be a valid value");
                    break;
            }
        }

        private static void ValidatedInputParameters(string operation, string sourceFilename)
        {
            if (string.IsNullOrEmpty(operation))
            {
                throw new InvalidOperationException("The operation type must be a valid value");
            }

            if (string.IsNullOrEmpty(sourceFilename))
            {
                throw new InvalidDataException("The source filename must be a valid value");
            }
        }

    
    }
}