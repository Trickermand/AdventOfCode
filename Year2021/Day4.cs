using System;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2021
{
    public static class Day4
    {
        public static string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void Part1()
        {
            List<string> inputs = IO.ReadInput(Day);



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: ");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: ");
        }
    }
}
