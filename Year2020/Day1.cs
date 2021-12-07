using System;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2020
{
    public static class Day1
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void Part1()
        {
            List<int> inputs = IO.ConvertStringListToIntList(IO.ReadInputAsLines(Day));

            int result = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    if (inputs[i] + inputs[j] == 2020)
                        result = inputs[i] * inputs[j];
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<int> inputs = IO.ConvertStringListToIntList(IO.ReadInputAsLines(Day));

            int result = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    for (int k = j + 1; k < inputs.Count; k++)
                    {
                        if (inputs[i] + inputs[j] + inputs[k] == 2020)
                            result = inputs[i] * inputs[j] * inputs[k];
                    }
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
