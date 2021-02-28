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

    public static class Day12
    {


        public static void Solve()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";
            Dictionary<char, int> coords = new Dictionary<char, int>();
            coords.Add('S', 0);
            coords.Add('W', 1);
            coords.Add('N', 2);
            coords.Add('E', 3);
            Dictionary<int, int> turns = new Dictionary<int, int>();
            turns.Add(0, 0);
            turns.Add(90, 1);
            turns.Add(180, 2);
            turns.Add(270, 3);
            List<int> values = new List<int> { 0, 0, 0, 0 };
            List<int> waypoint = new List<int> { 0, 0, 1, 10 };
            int direction = 3;
            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            var input = File.ReadAllLines(filePath).ToList();
            foreach (var cur in input)
            {
                int value;
                if (coords.ContainsKey(cur[0]))
                {
                    value = int.Parse(cur.Remove(0, 1));
                    waypoint[coords[cur[0]]] += value;
                }
                else
                {
                    if (cur[0] == 'F')
                    {
                        value = int.Parse(cur.Remove(0, 1));
                        for (int i = 0; i < 4; i++)
                        {
                            values[i] += waypoint[i] * value;
                        }
                    }
                    else if (cur[0] == 'R')
                    {
                        value = int.Parse(cur.Remove(0, 1));
                        int turn = turns[value];
                        int tmp;
                        for (int i = 0; i < turn; i++)
                        {
                            tmp = waypoint[waypoint.Count - 1];
                            for (int scan = waypoint.Count - 1; scan > 0; scan--)
                            {
                                waypoint[scan] = waypoint[scan - 1];
                            }
                            waypoint[0] = tmp;
                        }
                    }
                    else
                    {
                        value = int.Parse(cur.Remove(0, 1));
                        int turn = turns[value];
                        int tmp;
                        for (int i = 0; i < turn; i++)
                        {
                            tmp = waypoint[0];
                            for (int scan = 1; scan < waypoint.Count; scan++)
                            {
                                waypoint[scan - 1] = waypoint[scan];
                            }
                            waypoint[waypoint.Count - 1] = tmp;
                        }
                    }
                }
            }
            int ns = Math.Abs(values[2] - values[0]);
            int we = Math.Abs(values[3] - values[1]);
            int result = ns + we;
            file.Close();
        }
        public static void part1()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";
            Dictionary<char, int> coords = new Dictionary<char, int>();
            coords.Add('S', 0);
            coords.Add('W', 1);
            coords.Add('N', 2);
            coords.Add('E', 3);
            Dictionary<int, int> turns = new Dictionary<int, int>();
            turns.Add(0, 0);
            turns.Add(90, 1);
            turns.Add(180, 2);
            turns.Add(270, 3);
            List<int> values = new List<int> { 0, 0, 0, 0 };
            int direction = 3;
            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            var input = File.ReadAllLines(filePath).ToList();
            foreach (var cur in input)
            {
                int value;
                if (coords.ContainsKey(cur[0]))
                {
                    value = int.Parse(cur.Remove(0, 1));
                    values[coords[cur[0]]] += value;
                }
                else
                {
                    if (cur[0] == 'F')
                    {
                        value = int.Parse(cur.Remove(0, 1));
                        values[direction] += value;
                    }
                    else if (cur[0] == 'R')
                    {
                        value = int.Parse(cur.Remove(0, 1));
                        int turn = turns[value];
                        direction = (direction + turn) % 4;
                    }
                    else
                    {
                        value = int.Parse(cur.Remove(0, 1));
                        int turn = turns[value];
                        for (int i = 0; i < turn; i++)
                        {
                            direction -= 1;
                            if (direction < 0)
                                direction = 3;
                        }
                    }
                }
            }
            int ns = Math.Abs(values[2] - values[0]);
            int we = Math.Abs(values[3] - values[1]);
            int result = ns + we;
            file.Close();
        }

    }
}

