using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2022
{
    public static class Day3
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

            foreach (var line in inputs)
            {
                int halfIndex = line.Length / 2;
                List<char> fst = line[..halfIndex].ToList();
                List<char> snd = line[halfIndex..].ToList();
                List<char> matches = new();
                foreach (var c in fst)
                {
                    if (snd.Contains(c) && !matches.Contains(c))
                    {
                        if (c > 90) // IsLower
                            result += c - 97 + 1;
                        else // IsUpper
                            result += c - 65 + 27;

                        matches.Add(c);
                    }
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            for (int i = 0; i < inputs.Count; i += 3)
            {
                List<char> intersections = inputs[i].Intersect(inputs[i + 1]).Intersect(inputs[i + 2]).ToList();
                if (intersections.Count == 1)
                {
                    char c = intersections.First();
                    if (c > 90) // IsLower
                        result += c - 97 + 1;
                    else // IsUpper
                        result += c - 65 + 27;
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
