using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Year2023
{
    public static class Day1
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


            int result = inputs.Sum(x => int.Parse(Regex.Matches(x, @"(\d)").First().Value + Regex.Matches(x, @"(\d)").Last().Value));

            //foreach (var line in inputs)
            //{

            //    var match = Regex.Matches(line, @"(\d)");
            //    string s = match.First().Value;
            //    s += match.Last().Value;
            //    result += int.Parse(s);

            //}

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

                var match = Regex.Matches(line, @"(?=(\d|one|two|three|four|five|six|seven|eight|nine))");

                string s = "";
                switch (match.First().Groups[1].Value)
                {
                    case "one":
                        s += 1;
                        break;
                    case "two":
                        s += 2;
                        break;
                    case "three":
                        s += 3;
                        break;
                    case "four":
                        s += 4;
                        break;
                    case "five":
                        s += 5;
                        break;
                    case "six":
                        s += 6;
                        break;
                    case "seven":
                        s += 7;
                        break;
                    case "eight":
                        s += 8;
                        break;
                    case "nine":
                        s += 9;
                        break;
                    default:
                        s += match.First().Groups[1].Value;
                        break;
                }

                switch (match.Last().Groups[1].Value)
                {
                    case "one":
                        s += 1;
                        break;
                    case "two":
                        s += 2;
                        break;
                    case "three":
                        s += 3;
                        break;
                    case "four":
                        s += 4;
                        break;
                    case "five":
                        s += 5;
                        break;
                    case "six":
                        s += 6;
                        break;
                    case "seven":
                        s += 7;
                        break;
                    case "eight":
                        s += 8;
                        break;
                    case "nine":
                        s += 9;
                        break;
                    default:
                        s += match.Last().Groups[1].Value;
                        break;
                }
                result += int.Parse(s);

            }

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
