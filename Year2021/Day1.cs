using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021
{
    public static class Day1
    {
        private static List<string> ReadInput(string day)
        {
            string path = Path.Combine(Environment.CurrentDirectory, $"..\\..\\..\\Inputs\\{day}.txt");
            List<string> result = new();

            using (StreamReader reader = new(path))
            {
                while (!reader.EndOfStream)
                {
                    result.Add(reader.ReadLine());
                }
            }

            return result;
        }

        public static void Part1()
        {
            List<string> inputs = ReadInput("Day1");

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

            Console.WriteLine($"Day1 part 1 answer: {depthIncreases}");
        }

        public static void Part2()
        {
            List<string> inputs = ReadInput("Day1");

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

            Console.WriteLine($"Day1 part 2 answer: {depthIncreases}");
        }
    }
}
