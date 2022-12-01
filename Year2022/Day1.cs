using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2022
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
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            List<int> elfCals = new();

            int index = 0;
            foreach (var line in inputs)
            {
                if (line.Length < 1)
                {
                    index++;
                    continue;
                }
                
                if (elfCals.Count < index + 1)
                    elfCals.Add(0);

                elfCals[index] += int.Parse(line);
            }

            result = elfCals.Max();

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(MethodBase.GetCurrentMethod().DeclaringType.Name);
            int result = 0;

            List<int> elfCals = new();

            int index = 0;
            foreach (var line in inputs)
            {
                if (line.Length < 1)
                {
                    index++;
                    continue;
                }

                if (elfCals.Count < index + 1)
                    elfCals.Add(0);

                elfCals[index] += int.Parse(line);
            }
            List<int> elfCalsOrdered = elfCals.OrderByDescending(x => x).ToList();

            result = elfCalsOrdered[0] + elfCalsOrdered[1] + elfCalsOrdered[2];

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
