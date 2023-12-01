using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;

namespace Year2022
{
    public static class DayTemplate
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
