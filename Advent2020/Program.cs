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
            string filePath = @"G:\STUDIA\AdventOfCode\Advent2020\input.txt";
            string a= "mem[49377]";
            int  numericPhone = int.Parse(a.Where(Char.IsDigit).ToArray());
            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath);
            var input = File.ReadAllLines(filePath).ToList();
            Dictionary<long, long> memory = new Dictionary<long, long>();
            Dictionary<int, string> mask = new Dictionary<int, string>();
            foreach (var line in input)
            {
                if (line.Contains("mask"))
                {
                    var li = line.Split(" = ").ToList();
                    string newMask = li[1];
                    mask.Clear();
                    for(int i = 0; i< newMask.Count();i++)
                    {
                        if (newMask[i] != 'X')
                            mask.Add(i, newMask[i].ToString());
                    }
                }
                else
                {
                    var li = line.Split(" = ").ToList();
                    long address = int.Parse(li[0].Where(Char.IsDigit).ToArray());
                    long value = long.Parse(li[1]);
                    string valueString = BinaryExt.ToBinary(value);
                   foreach(var el in mask)
                    {
                        valueString = valueString.Remove(el.Key,1).Insert(el.Key, el.Value);
                    }
                     long value2 = Convert.ToInt64(valueString, 2);


                    if (memory.ContainsKey(address))
                        memory[address] = value2;
                    else
                        memory.Add(address, value2);
                }
            }
            var sum = memory.Sum(x=>x.Value);
            long sum2 = memory.Values.Sum();
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
    public static class BinaryExt
    {
        public static string ToBinary(this long number, int bitsLength = 36)
        {
            return NumberToBinary(number, bitsLength);
        }

        public static string NumberToBinary(long number, int bitsLength = 36)
        {
            string result = Convert.ToString(number, 2).PadLeft(bitsLength, '0');

            return result;
        }

        public static int FromBinaryToInt(this string binary)
        {
            return BinaryToInt(binary);
        }

        public static int BinaryToInt(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }
    }
}

