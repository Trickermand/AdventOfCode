using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2021
{
    public static class Day7
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            List<int> inputs = IO.ReadInputDelimited<int>(Day, ",");
            int result = 100000000;

            
            for (int i = 0; i < 1000; i++)
            {
                int tmp = 0;
                for (int j = 0; j < inputs.Count; j++)
                {
                    tmp += Math.Abs(inputs[j] - i);
                }
                if (tmp < result)
                    result = tmp;
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<int> inputs = IO.ReadInputDelimited<int>(Day, ",");
            int result = 100000000;


            for (int i = 0; i < 1000; i++)
            {
                int tmp = 0;
                for (int j = 0; j < inputs.Count; j++)
                {
                    int movementCost = 0;
                    int distance = Math.Abs(inputs[j] - i);
                    for (int k = 1; k <= distance; k++)
                    {
                        movementCost += k;
                    }
                    tmp += movementCost;
                }
                if (tmp < result)
                    result = tmp;
            }


            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
