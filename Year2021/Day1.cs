using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Year2021
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
            List<string> inputs = IO.ReadInput(Day);

            int depthIncreases = 0;
            int previousDepth = int.Parse(inputs[0]);

            for (int i = 1; i < inputs.Count; i++)
            {
                int currentDepth = int.Parse(inputs[i]);
                if (currentDepth > previousDepth)
                {
                    depthIncreases++;
                }
                previousDepth = int.Parse(inputs[i]);
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {depthIncreases}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(Day);

            int depthIncreases = 0;
            int previousDepth = int.Parse(inputs[0] + int.Parse(inputs[1]) + int.Parse(inputs[2]));

            for (int i = 1; i < inputs.Count - 2; i++)
            {
                int currentDepth = int.Parse(inputs[i]) + int.Parse(inputs[i + 1]) + int.Parse(inputs[i + 2]);
                if (currentDepth > previousDepth)
                {
                    depthIncreases++;
                }
                previousDepth = int.Parse(inputs[i]) + int.Parse(inputs[i + 1]) + int.Parse(inputs[i + 2]);
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {depthIncreases}");
        }
    }
}
