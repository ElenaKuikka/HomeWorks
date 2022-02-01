using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Parser
{
    interface IDataAnalysis
    {
        double AverageWordCount(ref List<StringWithWordCount> str);
        int MaxWordCount(ref List<StringWithWordCount> str);
        int MinWordCount(ref List<StringWithWordCount> str);
    }

    public class StringAnalysis : IDataAnalysis
    {
        public double AverageWordCount(ref List<StringWithWordCount> str)
        {
            return str.Average(n => n.WordCount);
        }

        public int MaxWordCount(ref List<StringWithWordCount> str)
        {
            return str.Max(n => n.WordCount);
        }

        public int MinWordCount(ref List<StringWithWordCount> str)
        {
            return str.Min(n => n.WordCount);
        }
    }
}
