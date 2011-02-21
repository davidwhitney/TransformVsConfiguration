using System;
using System.Collections;
using Microsoft.Build.Framework;

namespace TransformVsConfiguration
{
    public class CommandLineBuildEngine : IBuildEngine
    {
        public void LogErrorEvent(BuildErrorEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void LogWarningEvent(BuildWarningEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void LogMessageEvent(BuildMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void LogCustomEvent(CustomBuildEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs)
        {
            return true;
        }

        public bool ContinueOnError { get; set; }
        public int LineNumberOfTaskNode { get; set; }
        public int ColumnNumberOfTaskNode { get; set; }
        public string ProjectFileOfTaskNode { get; set; }
    }
}