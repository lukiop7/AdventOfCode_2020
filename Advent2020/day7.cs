using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars
{
    class day7
    {
        public static void day()
        {

            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> rules = new List<String>();
            rules = file.ReadToEnd().Split("\r\n").ToList();
            List<Tuple<string, (string, int)>> rule = new List<Tuple<string, (string, int)>>();
            List<string> search = new List<string>() { "shiny gold" };
            foreach (var line in rules)
            {
                var colors = line.Split("contain").ToList();
                var key = colors[0].Remove(colors[0].Length - 6);
                colors.RemoveAt(0);
                if (colors[0].Contains("other"))
                {

                }
                else
                {
                    var valuesAll = colors[0].Split(',').ToList();
                    foreach (var val in valuesAll)
                    {
                        var b = val.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        rule.Add(new Tuple<string, (string, int)>(key, (b[1] + " " + b[2], Int32.Parse(b[0].Trim()))));
                    }
                }
            }
            var lookup = rule.ToLookup(x => x.Item1, x => x.Item2);
            var gold = lookup[search[0]].ToList(); ;
            List<string> color = new List<string>();
            List<int> result = new List<int>() { 0 };
            var res = bags(result, lookup, search[0], 1);
            var count = color.Distinct().ToList().Count;
            file.Close();
        }
        public static int bags(List<int> sum, ILookup<string, (string, int)> lookup, string input, int level)
        {
            int sumCurrent = 0;
            var resultToSearch = lookup[input];
            foreach (var line in resultToSearch)
            {
                var tmp = bags(sum, lookup, line.Item1, level + 1);
                sumCurrent += line.Item2 + tmp * line.Item2;
            }
            return sumCurrent;
        }
        //public static int bagsMy(List<int> sum, ILookup<string, string> lookup, List<string> input, int level)
        //{
        //    int sumCurrent = 0;
        //    foreach (var line in input)
        //    {
        //        if (line.Contains("other bags."))
        //        {

        //        }
        //        else
        //        {
        //            var splitted = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        //            var resultToSearch = lookup[splitted[0] + " " + splitted[1]].ToList();
        //            sumCurrent += Int32.Parse(splitted[2]);
        //            sumCurrent += bags(sum, lookup, resultToSearch, level + 1) * Int32.Parse(splitted[2]);
        //        }
        //    }
        //    //if(sumCurrent!=0)
        //    //sum[0] += sumCurrent*level;          
        //    return sumCurrent;
        //}
        public static void part1()
        {

            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> rules = new List<String>();
            rules = file.ReadToEnd().Split("\r\n").ToList();
            List<Tuple<string, string>> rule = new List<Tuple<string, string>>();
            List<string> search = new List<string>() { "shiny gold" };
            foreach (var line in rules)
            {
                var colors = line.Split("contain").ToList();
                var key = colors[0].Remove(colors[0].Length - 6);
                colors.RemoveAt(0);
                var valuesAll = colors[0].Split(',').ToList();
                foreach (var val in valuesAll)
                {
                    var b = val.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    rule.Add(new Tuple<string, string>(key, b[1] + " " + b[2].Trim()));
                }
            }
            var lookup = rule.ToLookup(x => x.Item1, x => x.Item2);
            List<string> color = new List<string>();
            reqCol(color, lookup, search);
            var count = color.Distinct().ToList().Count;
            file.Close();
        }
        public static void reqCol(List<string> colors, ILookup<string, string> lookup, List<string> input)
        {
            if (input.Count > 0)
            {
                foreach (var line in input)
                {
                    var resultToSearch = lookup.Where(x => x.Any(s => s.Contains(line))).Select(x => x.Key).ToList();
                    colors.AddRange(resultToSearch);
                    reqCol(colors, lookup, resultToSearch);
                }
            }
        }

    }
}
