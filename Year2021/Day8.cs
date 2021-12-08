using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using Year2021.Day8Helper;

namespace Year2021
{
    public static class Day8
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;
            
            foreach (var line in inputs)
            {
                List<string> segments = line.Split("|")[1].Split(" ").Where(x => x != "").ToList();
                for (int i = 0; i < segments.Count; i++)
                {
                    if (segments[i].Length == 2
                        || segments[i].Length == 3
                        || segments[i].Length == 4
                        || segments[i].Length == 7)
                        result++;
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(MethodBase.GetCurrentMethod().DeclaringType.Name);
            int result = 0;

            foreach (var line in inputs)
            {
                string sample = line.Split(" | ")[0];
                SegmentDisplay sd = new SegmentDisplay(sample.Split(" ").ToList());
                //result += sd.GetValue(line.Split(" | ")[1]);

                string input = line.Split(" | ")[1];
                List<string> numbers = input.Split(" ").ToList();
                string finalNumber = "";

                foreach (var number in numbers)
                {
                    finalNumber += DecipherNumber(number, sd);
                }
                result += int.Parse(finalNumber);
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
        private static string DecipherNumber(string input, SegmentDisplay sd)
        {
            if (input.Length == 2)
                return "1";
            else if (input.Length == 5 
                && input.Contains(sd.Top_VeryImportant)
                && input.Contains(sd.TopRight)
                && input.Contains(sd.Middle)
                && input.Contains(sd.BottomLeft)
                && input.Contains(sd.Bottom))
                return "2";
            else if (input.Length == 5
                && input.Contains(sd.Top_VeryImportant)
                && input.Contains(sd.TopRight)
                && input.Contains(sd.Middle)
                && input.Contains(sd.BottomRight)
                && input.Contains(sd.Bottom))
                return "3";
            else if (input.Length == 4)
                return "4";
            else if (input.Length == 5
                && input.Contains(sd.Top_VeryImportant)
                && input.Contains(sd.TopLeft)
                && input.Contains(sd.Middle)
                && input.Contains(sd.BottomRight)
                && input.Contains(sd.Bottom))
                return "5";
            else if (input.Length == 6
                && input.Contains(sd.Top_VeryImportant)
                && input.Contains(sd.TopLeft)
                && input.Contains(sd.Middle)
                && input.Contains(sd.BottomLeft)
                && input.Contains(sd.BottomRight)
                && input.Contains(sd.Bottom))
                return "6";
            else if (input.Length == 3)
                return "7";
            else if (input.Length == 7)
                return "8";
            else if (input.Length == 6
                && input.Contains(sd.Top_VeryImportant)
                && input.Contains(sd.TopLeft)
                && input.Contains(sd.TopRight)
                && input.Contains(sd.Middle)
                && input.Contains(sd.BottomRight)
                && input.Contains(sd.Bottom))
                return "9";
            else
                return "0";
        }
    }
}
