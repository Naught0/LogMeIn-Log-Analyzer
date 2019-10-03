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
            public List<string> items { get; set; }
            public List<int> counts { get; set; }

            public FilterList()
            {
                items = new List<string>();
                counts = new List<int>();
            }
        }
    }
}
