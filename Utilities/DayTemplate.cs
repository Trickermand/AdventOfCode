using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

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
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;



            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;



            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }
    }
}
