using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer.utils
{
    public class CustomTypes
    {
        public class FilterList
        {
            public List<string> Items { get; set; }
            public List<int> Counts { get; set; }

            public FilterList()
            {
                Items = new List<string>();
                Counts = new List<int>();
            }
        }
    }
}
