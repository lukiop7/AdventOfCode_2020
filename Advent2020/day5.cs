using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace CodeWars
{
    class day5
    {
        public static void day()
        {

            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> inputString = new List<String>();
            inputString = (file.ReadToEnd()).Split("\r\n").ToList();
            int rows = 127;
            int columns = 7;
            List<int> ids = new List<int>();
            foreach (var line in inputString)
            {
                var row = line.Substring(0, 7);
                var column = line.Substring(7, 3);
                ids.Add(getRow(row) * 8 + getCols(column));
            }
            var max = ids.OrderBy(x => x).ToList();
            var my = FindMissing(max);

            file.Close();
        }
        public static int getRow(string input)
        {
            List<int> rows = new List<int>();
            for (int i = 0; i < 128; i++)
                rows.Add(i);
            foreach (char a in input)
            {
                if (a == 'F')
                {
                    rows.RemoveRange(rows.Count / 2, rows.Count / 2);
                }
                else
                {
                    rows.RemoveRange(0, rows.Count / 2);
                }
            }
            return rows[0];
        }
        public static int getCols(string input)
        {
            List<int> rows = new List<int>();
            for (int i = 0; i < 8; i++)
                rows.Add(i);
            foreach (char a in input)
            {
                if (a == 'L')
                {
                    rows.RemoveRange(rows.Count / 2, rows.Count / 2);
                }
                else
                {
                    rows.RemoveRange(0, rows.Count / 2);
                }
            }
            return rows[0];
        }

        public static IEnumerable<int> FindMissing(List<int> values)
        {
            HashSet<int> myRange = new HashSet<int>(Enumerable.Range(values[0], values.Count));
            myRange.ExceptWith(values);
            return myRange;
        }
    }
}
