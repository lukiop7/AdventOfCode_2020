using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars
{
    class day6
    {
        public static void part2()
        {

            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> inputString = new List<String>();
            string group = "";
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    group += line + ";";
                }
                else
                {
                    inputString.Add(group);
                    group = "";
                }
            }
            inputString.Add(group);
            List<int> values = new List<int>();
            foreach (var line in inputString)
            {
                var splitted = line.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
                var result = splitted.Aggregate(splitted[0].AsEnumerable(),
                    (a, words) => a.Intersect(words)).ToList();
                values.Add(result.Count);
            }
            var sum = values.Sum();
            file.Close();
        }

        public static void part1()
        {

            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> inputString = new List<String>();
            string group = "";
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    group += line;
                }
                else
                {
                    inputString.Add(group);
                    group = "";
                }
            }
            inputString.Add(group);
            List<int> values = new List<int>();
            foreach (var line in inputString)
            {
                var dist = line.Distinct().ToArray();
                values.Add(dist.Length);
            }
            var sum = values.Sum();
            file.Close();
        }
    }
}
