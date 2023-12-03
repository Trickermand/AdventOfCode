using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;

namespace Year2023
{
    public static class Day2
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            foreach (var line in inputs)
            {
                int reds = 0;
                int blues = 0;
                int greens = 0;
                bool legal = true;
                var game = line.Split(":");
                int id = int.Parse(game[0].Replace("Game ", ""));

                var colorSegment = game[1].Split(";");
                foreach (var colors in colorSegment)
                {
                    reds = 0;
                    blues = 0;
                    greens = 0;
                    var color = colors.Split(',');
                    foreach (var c in color)
                    {
                        if (c.Contains("red"))
                            reds += int.Parse(c.Replace(" red", ""));
                        if (c.Contains("blue"))
                            blues += int.Parse(c.Replace(" blue", ""));
                        if (c.Contains("green"))
                            greens += int.Parse(c.Replace(" green", ""));
                    }
                    if (!(reds <= 12 && greens <= 13 && blues <= 14))
                        legal = false;
                }
                if (legal)
                    result += id;
            }

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }

        public static void Part2()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            foreach (var line in inputs)
            {
                int reds = 0;
                int blues = 0;
                int greens = 0;
                int highestRed = 0;
                int highestBlue = 0;
                int highestGreen = 0;

                var game = line.Split(":");
                int id = int.Parse(game[0].Replace("Game ", ""));

                var colorSegment = game[1].Split(";");
                foreach (var colors in colorSegment)
                {
                    reds = 0;
                    blues = 0;
                    greens = 0;
                    var color = colors.Split(',');
                    foreach (var c in color)
                    {
                        if (c.Contains("red"))
                        {
                            int val = int.Parse(c.Replace(" red", ""));
                            if (val > highestRed)
                                highestRed = val;
                            reds += val;
                        }
                        if (c.Contains("blue"))
                        {
                            int val = int.Parse(c.Replace(" blue", ""));
                            if (val > highestBlue)
                                highestBlue = val;
                            blues += val;
                        }
                        if (c.Contains("green"))
                        {
                            int val = int.Parse(c.Replace(" green", ""));
                            if (val > highestGreen)
                                highestGreen = val;
                            greens += val;
                        }
                    }
                }
                
                result += highestRed * highestGreen * highestBlue;
            }

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
