using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogAnalyzer.utils
{
    class SysInfoParser
    {
        /// <summary>
        /// Ok so this is absolutely hideous
        /// But I don't know that parsing text is ever not hideous
        /// But here we are
        /// 
        /// The Monitor parsing doesn't work *yet*, and I'm trying to modularize this at some point
        /// </summary>
        private static class ParseBy
        {
            public static string OS = "Main - Runtime OS version";
            public static string LMI = "Main - LogMeIn version";
            public static string Display = "MonitorInfo - Monitor found";
            public static string AV = "AVDetection - Found new anti-virus";
        }
        private string logFile = string.Empty;

        public SysInfoParser(string passedLog)
        {
            logFile = passedLog;
        }
        public string GetSysInfo()
        {
            var splitLog = logFile.Split('\n').ToList();
            var _l = new List<string>();
            StringBuilder builder = new StringBuilder();

            Action NewLine = () => builder.AppendLine("\n");
            // Add OS information
            builder.AppendLine("OS info:");
            foreach (string line in splitLog)
            {
                if (line.Contains(ParseBy.OS))
                {
                    _l.Add(line);
                }
            }
            if (! _l.IsEmpty())
                // Maybe parse this better one day
                builder.AppendLine(_l.Last().Split('(').Last());
            else
                builder.AppendLine("No data available.");
            
            _l.Clear();
            NewLine();

            // Add LogMeIn Info
            builder.AppendLine("LogMeIn Info:");
            foreach (string line in splitLog)
            {
                if (line.Contains(ParseBy.LMI))
                {
                    _l.Add(line);
                }
            }
            if (! _l.IsEmpty())
                builder.AppendLine(_l.Last().Split(new string[] { "version:" }, StringSplitOptions.None)[1]);
            else
                builder.AppendLine("No data available.");

            _l.Clear();
            NewLine();

            // Add AV information
            builder.AppendLine("Anti-virus Info:");
            foreach (string line in splitLog)
            {
                if (line.Contains(ParseBy.AV))
                {
                    _l.Add(line);
                }
            }
            if (! _l.IsEmpty())
                builder.AppendLine(_l.Last().Split(new string[] { ParseBy.AV }, StringSplitOptions.None)[1]);
            else
                builder.AppendLine("No data available.");

            _l.Clear();
            NewLine();

            builder.AppendLine("Display Info:");
            List<string> displayMatches = GetMatches(ParseBy.Display, splitLog);
            HashSet<string> filteredMatches = GetDisplayList(displayMatches);
            foreach (string match in filteredMatches)
            {
                List<string> parsedList = ParseDisplayString(match);
                string _ = $"Adapater: {parsedList[0]}\nResolution: {parsedList[1]}";
                _l.Add(_);
                builder.AppendLine(_);
            }
            if (_l.IsEmpty())
                builder.AppendLine("No data available.");

            return builder.ToString();
        }
        
        /// <summary>
        /// Finds and returns all matching strings
        /// </summary>
        /// <param name="matchString"></param>
        /// <param name="logLines"></param>
        /// <returns></returns>
        private List<string> GetMatches(String matchString, List<string> logLines)
        {
            // Create list of matching queries
            List<string> matchList = new List<string>();

            foreach (string line in logLines)
            {
                if (line.Contains(matchString))
                {
                    matchList.Add(line);
                }
            }

            return matchList;
        }

        private HashSet<string> GetDisplayList(List<string> matchList)
        {
            List<string> l = new List<string>();
            foreach (string item in matchList)
            {
                l.Add(item.Split(new string[] { "Monitor found" }, StringSplitOptions.None)[1]);
            }
            
            // returns only unique monitor strings
            return new HashSet<string>(l);
        }

        private List<string> ParseDisplayString(string line)
        {
            //var regRemove = new Regex(@"\((.)\)");
            var reg = new Regex(@"\(([^)]*)\)");
            var newLine = Regex.Replace(line, @"\((.)\)", string.Empty);
            var matches = reg.Matches(newLine);
            try
            {
                return new List<string> { matches[0].Value, matches[2].Value };
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}
