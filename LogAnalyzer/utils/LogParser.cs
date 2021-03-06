﻿using System.Collections.Generic;
using System.Linq;
using LogAnalyzer.Properties;
using Newtonsoft.Json;
using System.Text;

namespace LogAnalyzer.utils
{
    using DictInfoFormat = Dictionary<string, Dictionary<string, string>>;
    public abstract class LogParser
    {
        public abstract string ParseLine(string line);
    }

    public class ParserLMI : LogParser
    {
        public readonly DictInfoFormat lmiErrorInfo = 
            JsonConvert.DeserializeObject<DictInfoFormat>(Resources.errorInfo);
        public readonly DictInfoFormat socketErrorInfo = 
            JsonConvert.DeserializeObject<DictInfoFormat>(Resources.winSockErrorInfo);

        const string STR_NO_MATCH = @"¯\_( ͠° ͟ʖ °͠ )_/¯";

        // PATCH MANAGEMENT
        // https://www.catalog.update.microsoft.com/ScopedViewGeneric.aspx?updateid={}
        // WOW *********************************************************************
        public override string ParseLine(string line)
        {
            StringBuilder builder = new StringBuilder();
            // First check the line for a relevant entry in the LMI log information
            // Pulled from the L2 wiki and a few tidbits added by me
            if (lmiErrorInfo["LogMeIn"].Keys.Any(s => line.Contains($" {s} ")))
            {
                foreach (string desc in lmiErrorInfo["LogMeIn"].Keys)
                {
                    if (line.Contains(desc))
                    {
                        
                        builder.AppendLine($"{desc}\n{lmiErrorInfo["LogMeIn"][desc]}\n");
                    }
                }
                // Ugly detection for specific cases
                // builder.AppendLine(
                if (line.Contains(" LogMeIn AV "))
                {
                    // Iterates all Installer errors and checks for them
                    foreach (string code in lmiErrorInfo["AV Install"].Keys)
                    {
                        if (line.Contains($": {code}"))
                        {
                            builder.AppendLine($"\nError {code} info: \n{lmiErrorInfo["AV Install"][code]}\n");
                        }
                    }
                    // iterates update erors and checks for them
                    foreach (string code in lmiErrorInfo["AV Updates"].Keys)
                    {
                        if (line.Contains($": {code})") && line.Contains("update"))
                        {
                            builder.AppendLine($"\nUpdate Error {code} info:\n{lmiErrorInfo["AV Updates"][code]}\n");
                        }
                    }
                }
                // More of the same ugly
                if (line.Contains(" Socket "))
                {
                    foreach (string code in socketErrorInfo.Keys)
                    {
                        if (line.Contains($"({code})"))
                        {
                            builder.AppendLine($"\nError {code} info: \n{socketErrorInfo[code]["Description"]}\n");
                        }
                    }
                }
            }
            // No matches
            else
            {
                builder.AppendLine(STR_NO_MATCH);
            }
            return builder.ToString();
        }
    }
}
