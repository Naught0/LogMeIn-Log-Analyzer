using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAnalyzer.utils
{
    public static class Utils
    {
        /// <summary>
        ///  Returns filtered text depending on applied filters from UI
        /// </summary>
        /// <param name="filterByLeft"></param>
        /// <param name="filterByRight"></param>
        /// <param name="toFilter"></param>
        /// <returns></returns>
        public static string FilterText(List<string> filterByLeft, List<string>filterByRight, string toFilter)
        {
            // No filters passed, return full text
            if (filterByLeft.IsEmpty() && filterByRight.IsEmpty())
                return toFilter;

            if (! filterByRight.IsEmpty() && filterByLeft.IsEmpty())
            {
                return FilterOne(filterByRight, toFilter);
            }
            else if (filterByRight.IsEmpty() && ! filterByLeft.IsEmpty())
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
        
        /// <summary>
        /// A helper method to filter by a single term to reduce some repetitive code I had before
        /// </summary>
        /// <param name="filterBy"></param>
        /// <param name="toFilter"></param>
        /// <returns></returns>
        private static string FilterOne(List<string> filterBy, string toFilter)
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

        /// <summary>
        /// Extends List<T> to add and IsEmpty shortcut method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this List<T> l)
        {
            if (l.Count == 0 || l == null)
            {
                return true;
            }
            return false;
        }
    }
}
