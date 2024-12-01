using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;

namespace Year2024
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
            int result = 0;

            List<int> firsts = new();
            List<int> seconds = new();

            foreach (var line  in inputs)
            {
                var segments = line.Split("   ");
                firsts.Add(int.Parse(segments[0]));
                seconds.Add(int.Parse(segments[1]));
            }

            firsts = firsts.Order().ToList();
            seconds = seconds.Order().ToList();

            for (int i = 0; i < firsts.Count; i++)
            {
                result += Math.Abs(firsts[i] - seconds[i]);
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

            List<int> firsts = new();
            List<int> seconds = new();

            foreach (var line in inputs)
            {
                var segments = line.Split("   ");
                firsts.Add(int.Parse(segments[0]));
                seconds.Add(int.Parse(segments[1]));
            }

            for (int i = 0;i < firsts.Count;i++)
            {
                int counts = 0;
                for (int j = 0; j < seconds.Count; j++)
                {
                    if (firsts[i] == seconds[j])
                        counts++;
                }
                result += counts * firsts[i];
            }

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
