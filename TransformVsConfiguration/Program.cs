using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Build.Utilities;
using Microsoft.Web.Publishing.Tasks;
using NDesk.Options;

namespace TransformVsConfiguration
{
    class Program
    {
        private static bool _showHelp;
        private static string _sourcePathAndFilename;
        private static string _destinationPathAndFilename;
        private static string _transformPathAndFilename;

        static void Main(string[] args)
        {
            var optionSet = LoadCommandLineArguments(args);

            if(UserNeedsHelp())
            {
                WriteHelpToConsole(optionSet);
                return;
            }

            var task = new TransformXml
                           {
                               Source = new TaskItem(_sourcePathAndFilename),
                               Destination = new TaskItem(_destinationPathAndFilename),
                               Transform = new TaskItem(_transformPathAndFilename),
                               StackTrace = false,
                               BuildEngine = new CommandLineBuildEngine(),
                           };

            task.Execute();
        }

        private static OptionSet LoadCommandLineArguments(IEnumerable<string> args)
        {
            var optionSet = new OptionSet
                                {
                                    {"h|?|help|man", "Display help message", param => _showHelp = param != null },
                                    {"source=", "Source path and file name of .config file", param => _sourcePathAndFilename = param },
                                    {"destination=", "Output path and filename", param => _destinationPathAndFilename = param},
                                    {"transform", "VS2010 transformation file", param => _transformPathAndFilename = param },
                                };
            optionSet.Parse(args);
            return optionSet;
        }

        private static bool UserNeedsHelp()
        {
            return _showHelp
                   || string.IsNullOrWhiteSpace(_sourcePathAndFilename)
                   || string.IsNullOrWhiteSpace(_destinationPathAndFilename)
                   || string.IsNullOrWhiteSpace(_transformPathAndFilename);
        }


        private static void WriteHelpToConsole(OptionSet optionSet)
        {
            var sb = new StringBuilder();
            optionSet.WriteOptionDescriptions(new StringWriter(sb));
            Console.Write(sb.ToString());
        }
    }
}
