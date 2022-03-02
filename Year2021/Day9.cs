using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;
using Year2021.Day9Helper;

namespace Year2021
{
    public static class Day9
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

            HeightMap map = new HeightMap(inputs);
            for (int i = 0; i < map.Area.Length; i++)
            {
                for (int j = 0; j < map.Area[i].Length; j++)
                {
                    if (map.IsLowestPoint(i, j))
                    {
                        result += int.Parse(map.Area[i][j].ToString()) + 1;
                    }
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(MethodBase.GetCurrentMethod().DeclaringType.Name);
            int result = 0;



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

    }
}
