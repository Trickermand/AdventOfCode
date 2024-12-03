using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;

namespace Year2024
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

            for (int i = 0; i < inputs.Count; i++)
            {
                List<int> segments = inputs[i].Split(" ").Select(x => int.Parse(x)).ToList();
                bool success = true;
                for (int j = 0; j < segments.Count - 1; j++)
                {
                    int digit = segments[j];
                    int nextDigit = segments[j + 1];
                    bool isOrdered = true;
                    for (int k = j; k < segments.Count - 1; k++)
                    {
                        if (!(segments[k] < segments[k + 1]))
                            isOrdered = false;
                    }
                    if (!isOrdered)
                    {
                        isOrdered = true;
                        for (int k = j; k < segments.Count - 1; k++)
                        {
                            if (!(segments[k] > segments[k + 1]))
                                isOrdered = false;
                        }
                    }

                    if (!(Math.Abs(digit - nextDigit) < 4 && isOrdered))
                    {
                        success = false; 
                        break;
                    }

                }
                if (success)
                    result++;
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



            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
