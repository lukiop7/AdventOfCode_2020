using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars
{
    public static class day4
    {
        public static void day()
        {

            string filePath = @"C:\Users\studia\source\repos\CodeWars\CodeWars\input.txt";

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath); ;
            List<String> inputString = new List<String>();
            String line = "";
            while (!file.EndOfStream)
            {
                var input = file.ReadLine();
                input.Replace('\n', ' ');
                if (!string.IsNullOrEmpty(input))
                {
                    line += input + " ";
                }
                else
                {
                    inputString.Add(line);
                    line = "";
                }
            }
            inputString.Add(line);
            int validPassports = 0;
            String[] items = new string[7] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            foreach (var lin in inputString)
            {
                var splitted = lin.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                if (containsWords(lin, items))
                {
                    bool valid = true;
                    foreach (var s in splitted)
                    {
                        var split = s.Split(':').ToList();
                        if (!validValues(split[0], split[1])) { valid = false; }
                    }
                    if (valid)
                        validPassports++;
                }

                //if (splitted.Count() == 8)
                //{
                //    validPassports++;
                //}
                //else if (splitted.Count() == 7)
                //{
                //    if (!splitted.Contains("cid"))
                //        validPassports++;
                //}
            }




            //char[,] board = new char[lines.Length, lines[0].Length];
            //InitBoard(board, lines);
            //long sum1 =GetTree(board,1,1);
            //long sum2 = GetTree(board,3,1);
            //long sum3 = GetTree(board,5,1);
            //long sum4 = GetTree(board,7,1);
            //long sum5 = GetTree(board,1,2);
            //long sum = sum1 * sum2 * sum3 * sum4 * sum5;
            file.Close();
        }

        public static bool containsWords(String inputString, String[] items)
        {
            bool found = true;
            foreach (String item in items)
            {
                if (!inputString.Contains(item))
                {
                    found = false;
                    break;
                }
            }
            return found;
        }
        public static bool containsWord(String inputString, String[] items)
        {
            bool found = false;
            foreach (String item in items)
            {
                if (inputString.Contains(item))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        public static bool validValues(string item, string value)
        {
            bool found = true;
            switch (item)
            {
                case "byr":
                    if (value.Length != 4)
                        found = false;
                    else
                        found = Regex.IsMatch(value, "^19[2-9][0-9]$|^200[0-2]$");
                    break;
                case "iyr":
                    if (value.Length != 4)
                        found = false;
                    else
                        found = Regex.IsMatch(value, "^201[0-9]$|^2020$");
                    break;
                case "eyr":
                    if (value.Length != 4)
                        found = false;
                    else
                        found = Regex.IsMatch(value, "^202[0-9]$|^2030$");
                    break;
                case "hgt":
                    if (value.Length > 5)
                        found = false;
                    else
                        found = Regex.IsMatch(value, "^(1[5-8][0-9]|19[0-3])(cm)$|^(59|6[0-9]|7[0-6])(in)$");
                    break;
                case "hcl":
                    if (value.Length != 7)
                        found = false;
                    else
                        found = Regex.IsMatch(value, "^#[0-9a-f]{6}$");
                    break;
                case "ecl":
                    if (value.Length != 3)
                        found = false;
                    else
                    {
                        string[] words = new string[7] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        found = containsWord(value, words);
                    }
                    break;
                case "pid":
                    if (value.Length != 9)
                        found = false;
                    else
                        found = Regex.IsMatch(value, "^[0-9]{9}$");
                    break;
            }
            return found;
        }

    }
}
