using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer
{
    class Utils
    {
        /// <summary>
        ///  Returns filtered text depending on applied filters from UI
        /// </summary>
        /// <param name="filterByLeft"></param>
        /// <param name="filterByRight"></param>
        /// <param name="toFilter"></param>
        /// <returns></returns>
        public string FilterText(List<string> filterByLeft, List<string>filterByRight, string toFilter)
        {
            // No filters passed, return full text
            if (filterByLeft.Count == 0 && filterByRight.Count == 0)
                return toFilter;

            if (filterByRight.Count != 0 && filterByLeft.Count == 0)
            {
                return FilterOne(filterByRight, toFilter);
            }
            else if (filterByRight.Count == 0 && filterByLeft.Count != 0)
            {
                return FilterOne(filterByLeft, toFilter);
            }

            StringBuilder builder = new StringBuilder();
            foreach (string line in toFilter.Split('\n'))
            {
                if (filterByLeft.Any(s => line.Contains($" {s} ")) && filterByRight.Any(s => line.Contains($" {s} ")))
                {
                    builder.Append(line);
                }
            }
            return builder.ToString();
        }
        
        private string FilterOne(List<string> filterBy, string toFilter)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string line in toFilter.Split('\n'))
            {
                if (filterBy.Any(s => line.Contains($" {s} ")))
                {
                    builder.Append(line);
                }
            }
            return builder.ToString();

        }
    }
}
