using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer.utils
{
    public class Types
    {
        public class CheckListItem<T>
        {
            public T Data { get; set; }
            public string Display { get; set; }

            public CheckListItem(string displayValue, T dataValue)
            {
                Data = dataValue;
                Display = displayValue;
            }

            public override string ToString()
            {
                return Display;
            }
        }
    }
}
