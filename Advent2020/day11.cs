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

    public static class Day11
    {


        public static void Solve()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            var inpu = File.ReadAllLines(filePath).ToList();
            List<char[]> input = new List<char[]>();
            List<char[]> newIteration = new List<char[]>();
            var newIteratio = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < inpu.Count; i++)
            {
                input.Add(inpu[i].ToCharArray());
                newIteration.Add(newIteratio[i].ToCharArray());
            }
            List<(int, int)> vector = new List<(int, int)>{
                (-1,0 ),
                (1,0 ),
                (0,-1 ),
                (0,1 ),
                (-1,-1),
                (-1,1 ),
                (1,-1),
                (1,1 )
            };
            int changes = 1;
            int occupiedTotal = 0;
            while (changes != 0)
            {
                changes = 0;
                occupiedTotal = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    for (int j = 0; j < input[0].Length; j++)
                    {
                        int occupied = 0;
                        foreach (var a in vector)
                        {
                            int x = i;
                            int y = j;
                            bool found = false;
                            while (!found)
                            {
                                x = x + a.Item1;
                                y = y + a.Item2;
                                if (checkBounds(x, y, input.Count, input[0].Length))
                                {
                                    if (input[x][y] == '#')
                                    {
                                        occupied++;
                                        found = true;
                                    }
                                    else if (input[x][y] == 'L')
                                        found = true;
                                }
                                else
                                {
                                    found = true;
                                }
                            }
                        }
                        if (input[i][j] == 'L' && occupied == 0)
                        {
                            newIteration[i][j] = '#';
                            changes++;
                            occupiedTotal++;
                        }
                        else if (input[i][j] == '#')
                        {
                            if (occupied >= 5)
                            {
                                newIteration[i][j] = 'L';
                                changes++;
                            }
                            else
                                occupiedTotal++;
                        }

                    }
                }
                input.Clear();
                input = DeepCopy(newIteration);
            }
            file.Close();
        }

        public static bool checkBounds(int x, int y, int line, int end)
        {
            if (x >= 0 && y >= 0 && x < line && y < end)
                return true;
            return false;
        }

        public static void part1()
        {
            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            var inpu = File.ReadAllLines(filePath).ToList();
            List<char[]> input = new List<char[]>();
            List<char[]> newIteration = new List<char[]>();
            var newIteratio = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < inpu.Count; i++)
            {
                input.Add(inpu[i].ToCharArray());
                newIteration.Add(newIteratio[i].ToCharArray());
            }
            List<(int, int)> vector = new List<(int, int)>{
                (-1,0 ),
                (1,0 ),
                (0,-1 ),
                (0,1 ),
                (-1,-1),
                (-1,1 ),
                (1,-1),
                (1,1 )
            };
            int changes = 1;
            int occupiedTotal = 0;
            while (changes != 0)
            {
                changes = 0;
                occupiedTotal = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    for (int j = 0; j < input[0].Length; j++)
                    {
                        int occupied = 0;
                        foreach (var a in vector)
                        {
                            int newX = i + a.Item1;
                            int newY = j + a.Item2;
                            if (checkBounds(newX, newY, input.Count, input[0].Length))
                            {
                                if (input[newX][newY] == '#')
                                    occupied++;
                            }
                        }
                        if (input[i][j] == 'L' && occupied == 0)
                        {
                            newIteration[i][j] = '#';
                            changes++;
                            occupiedTotal++;
                        }
                        else if (input[i][j] == '#')
                        {
                            if (occupied >= 4)
                            {
                                newIteration[i][j] = 'L';
                                changes++;
                            }
                            else
                                occupiedTotal++;
                        }
                    }
                }
                input.Clear();
                input = DeepCopy(newIteration);
            }
            file.Close();
        }

        public static T DeepCopy<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}

