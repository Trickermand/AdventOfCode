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

            inputs = new()
            {
                "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
            };


            foreach (var line in inputs)
            {
                string sample = line.Split(" | ")[0];
                SegmentDisplay sd = new SegmentDisplay(sample.Split(" ").ToList());
                result += sd.GetValue(line.Split(" | ")[1]);
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
