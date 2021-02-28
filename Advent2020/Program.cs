using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars
{

    public static class Kata
    {


        public static void Main()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath);
            var input = File.ReadAllLines(filePath).ToList();
            int stamp = int.Parse(input[0]);
            var bus = input[1].Split(",")
                      .Where(x=> x!="x").Select(x => Convert.ToInt32(x)).ToList();
            bool found = false;
            int time = stamp;
            int busId=-1;
            while (!found)
            {
                foreach(var v in bus)
                {
                    if (time % v==0)
                    {
                        found = true;
                        busId = v;
                    }
                }
                if(!found)
                time++;
            }
            int result = (time - stamp) * busId;
            file.Close();
        }
        public static void part1()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath);
            var input = File.ReadAllLines(filePath).ToList();
            int stamp = int.Parse(input[0]);
            var bus = input[1].Split(",")
                      .Where(x => x != "x").Select(x => Convert.ToInt32(x)).ToList();
            bool found = false;
            int time = stamp;
            int busId = -1;
            while (!found)
            {
                foreach (var v in bus)
                {
                    if (time % v == 0)
                    {
                        found = true;
                        busId = v;
                    }
                }
                if (!found)
                    time++;
            }
            int result = (time - stamp) * busId;
            file.Close();
        }

    }
}

