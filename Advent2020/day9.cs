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

    public static class Day9
    {


        public static void Solve()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<long> input = new List<long>();
            input = File.ReadAllLines(filePath)
           .Select(x => Convert.ToInt64(x)).ToList();
            var find = part1();
            bool found = false;
            long res;
            int cnt = 0;
            long answer;
            while (!found)
            {
                long sum = 0;

                var a = input.GetRange(cnt, input.Count - cnt);
                int i = 0;
                for (; i < a.Count; i++)
                {
                    if (sum >= find)
                    {
                        break;
                    }
                    sum += a[i];
                }
                if (sum == find)
                {

                    found = true;
                    var b = input.GetRange(cnt, i);
                    sum = b.Sum();
                    res = b.Min() + b.Max();
                }
                cnt++;
            }


            file.Close();
        }

        public static long part1()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<long> input = new List<long>();
            input = File.ReadAllLines(filePath)
           .Select(x => Convert.ToInt64(x)).ToList();
            bool fail = false;
            long res = 0;
            int cnt = 25;
            while (!fail)
            {
                var a = input.GetRange(cnt - 25, 25);
                fail = !a.Any(x => a.Contains(input[cnt] - x));
                res = input[cnt++];
            }


            file.Close();
            return res;
        }


    }
}

