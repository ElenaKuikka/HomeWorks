using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<StringWithWordCount> text = new List<StringWithWordCount>();

                using (var strReader = new StringWithWordCountReader(@"Text.txt"))
                {
                    foreach (var c in strReader.ReadAll())
                        text.Add(c);
                }

                IDataAnalysis inf = new StringAnalysis();

                Console.WriteLine($"Среднее количество слов в строке: {inf.AverageWordCount(ref text)}");
                Console.WriteLine($"Максимальное количество слов в строке: {inf.MaxWordCount(ref text)}");
                Console.WriteLine($"Минимальное количество слов в строке: {inf.MinWordCount(ref text)}");

                Console.WriteLine($"\nКоличество строк: {text.Count}\n");
                
                foreach (var s in text)
                    Console.WriteLine(s.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
