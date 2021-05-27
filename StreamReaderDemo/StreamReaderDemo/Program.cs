using System;
using System.Collections.Generic;
using System.IO;

namespace StreamReaderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                List<string> linesWithA = new List<string>();
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if(line.Contains('b',StringComparison.CurrentCultureIgnoreCase))
                    {
                        linesWithA.Add(line);
                    }
                }
                Console.WriteLine(linesWithA.Count + " lines with an 'a' in it.");
            }

        }
    }
}
