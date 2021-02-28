using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars
{
    public static class day8
    {
        public static void day()
        {
            Stopwatch time10kOperations = Stopwatch.StartNew();
            time10kOperations.Start();
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> rules = new List<String>();
            rules = file.ReadToEnd().Split("\r\n").ToList();
            int counter, acumulator;
            bool found = false;
            counter = 0;
            while (!found)
            {
                Dictionary<int, bool> visitedClone = new Dictionary<int, bool>();
                for (int i = 0; i < rules.Count; i++)
                {
                    visitedClone.Add(i, false);
                }


                acumulator = 0;
                List<String> cloned = (List<string>)rules.Clone();
                var splitted = rules[counter].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (splitted[0].Contains("acc"))
                {
                    counter++;
                }
                else if (splitted[0].Contains("jmp"))
                {
                    cloned[counter] = cloned[counter].Replace("jmp", "nop");
                    found = CalcAcc(cloned, visitedClone, out acumulator);
                    if (!found)
                        counter++;
                }
                else
                {
                    cloned[counter] = cloned[counter].Replace("nop", "jmp");
                    found = CalcAcc(cloned, visitedClone, out acumulator);
                    if (!found)
                        counter++;
                }
            }
            time10kOperations.Stop();
            var a = time10kOperations.ElapsedMilliseconds;
            file.Close();
        }

        private static bool CalcAcc(List<string> rules, Dictionary<int, bool> visited, out int acumulator)
        {
            int counter = 0;
            acumulator = 0;
            while (!visited[counter])
            {
                visited[counter] = true;
                var splitted = rules[counter].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (splitted[0].Contains("acc"))
                {
                    if (splitted[1][0] == '+')
                    {
                        acumulator += Int32.Parse(splitted[1].Remove(0, 1));
                    }
                    else
                    {
                        acumulator -= Int32.Parse(splitted[1].Remove(0, 1));
                    }
                    counter++;
                }
                else if (splitted[0].Contains("jmp"))
                {
                    if (splitted[1][0] == '+')
                    {
                        counter += Int32.Parse(splitted[1].Remove(0, 1));
                    }
                    else
                    {
                        counter -= Int32.Parse(splitted[1].Remove(0, 1));
                    }
                }
                else
                {
                    counter++;
                }
                if (counter == rules.Count)
                    return true;

            }
            return false;
        }
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        public static void part1()
        {

            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> rules = new List<String>();
            rules = file.ReadToEnd().Split("\r\n").ToList();
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            for (int i = 0; i < rules.Count; i++)
            {
                visited.Add(i, false);
            }
            int counter = 0;
            int acumulator = 0;
            while (!visited[counter])
            {
                visited[counter] = true;
                var splitted = rules[counter].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (splitted[0].Contains("acc"))
                {
                    if (splitted[1][0] == '+')
                    {
                        acumulator += Int32.Parse(splitted[1].Remove(0, 1));
                    }
                    else
                    {
                        acumulator -= Int32.Parse(splitted[1].Remove(0, 1));
                    }
                    counter++;
                }
                else if (splitted[0].Contains("jmp"))
                {
                    if (splitted[1][0] == '+')
                    {
                        counter += Int32.Parse(splitted[1].Remove(0, 1));
                    }
                    else
                    {
                        counter -= Int32.Parse(splitted[1].Remove(0, 1));
                    }
                }
                else
                {
                    counter++;
                }
            }
            file.Close();
        }
    }
}
