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

    public static class Day10
    {


        public static void Solve()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<int> input;
            input = File.ReadAllLines(filePath)
           .Select(x => Convert.ToInt32(x)).OrderBy(x => x).ToList();
            int device = input.Max() + 3;
            input.Add(device);
            input.Add(0);
            input.Sort();
            List<int> answer = new List<int>();
            Dictionary<int, long> range = new Dictionary<int, long>();
            range.Add(device, 1);

            for (int i = input.Count - 2; i >= 0; i--)
            {
                long ans = 0;
                for (int j = 1; j <= 3; j++)
                {
                    if (range.ContainsKey(input[i] + j))
                    {
                        ans += range[input[i] + j];
                    }
                }
                if (ans > 0)
                {
                    range[input[i]] = ans;
                }
            }
            long answe = range[input[0]];
            file.Close();
        }

        public static void part1()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<int> input;
            input = File.ReadAllLines(filePath)
           .Select(x => Convert.ToInt32(x)).OrderBy(x => x).ToList();
            int device = input.Max() + 3;
            input.Add(device);
            List<int> answer = new List<int>();
            answer.Add(0);
            int one = 0;
            int three = 0;
            while (answer.Count != input.Count + 1)
            {
                int cnt = answer.Count - 1;
                int choice = input.Skip(cnt).Take(3).Min();
                if (choice - answer[cnt] == 1)
                    one++;
                else if (choice - answer[cnt] == 3)
                    three++;
                answer.Add(choice);
            }
            var a = one * three;
            file.Close();
        }


    }
}

