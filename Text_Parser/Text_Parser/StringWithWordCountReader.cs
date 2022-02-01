using System;
using System.Collections.Generic;

namespace Text_Parser
{
    public class StringWithWordCountReader : BaseModelReader
    {
        public StringWithWordCountReader(string filename) : base(filename)
        {
        }

        public IEnumerable<StringWithWordCount> ReadAll()
        {
            if (IsOpened) Close();
            StringWithWordCount c;
            while ((c = ReadNext()) != null)
                yield return c;
        }

        public StringWithWordCount ReadNext()
        {
            if (!IsOpened) Open();
            string s = ReadLine();
            if (s == null)
                return null;
            return new StringWithWordCount(s);
        }
    }
}
