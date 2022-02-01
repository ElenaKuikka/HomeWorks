using System;
using System.Text.RegularExpressions;

namespace Text_Parser
{
    public class StringWithWordCount
    {
        public string Data { get; set; }
        public int WordCount { get; }

        public StringWithWordCount() { WordCount = 0; }

        public StringWithWordCount(string data)
        {
            Data = data;
            if (data == null)
                WordCount = 0;
            else
                WordCount = CountNumberOfWords();
        }

        private string RemoveMultiplePaces()
        {
            var rx = @"\s+";
            var tg = " ";
            Regex regex = new Regex(rx);
            return regex.Replace(Data, tg);
        }

        private int CountNumberOfWords()
        {
            int count = 0;
            string tempStr = RemoveMultiplePaces();
            if (tempStr != "" && tempStr[0] != ' ')
                count = 1;
            foreach(var s in tempStr)
                if (s == ' ')
                    count++;
            return count;
        }
    }
}
