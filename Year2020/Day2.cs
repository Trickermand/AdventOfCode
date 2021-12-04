using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace Year2020
{
    public static class Day2
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void Part1()
        {
            List<string> inputs = IO.ReadInput(Day);

            int result = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                string entry = inputs[i];
                int lowerbound = int.Parse(entry.Substring(0, entry.IndexOf('-')));
                int upperbound = int.Parse(entry.Substring(entry.IndexOf('-') + 1, entry.IndexOf(' ') - entry.IndexOf('-') - 1));
                char letter = entry[entry.IndexOf(' ') + 1];
                string password = entry.Substring(entry.IndexOf(':') + 2);

                int occurrences = password.Count(x => x == letter);

                if (occurrences <= upperbound && occurrences >= lowerbound)
                {
                    result++;
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);

            int result = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                string entry = inputs[i];
                int index_a = int.Parse(entry.Substring(0, entry.IndexOf('-')));
                int index_b = int.Parse(entry.Substring(entry.IndexOf('-') + 1, entry.IndexOf(' ') - entry.IndexOf('-') - 1));
                char letter = entry[entry.IndexOf(' ') + 1];
                string password = entry.Substring(entry.IndexOf(':') + 2);

                bool index_a_Satisfies = index_a - 1 < password.Length && password[index_a - 1] == letter;
                bool index_b_Satisfies = index_b - 1 < password.Length && password[index_b - 1] == letter;

                if ((index_a_Satisfies && !index_b_Satisfies)
                    || (!index_a_Satisfies && index_b_Satisfies))
                {
                    result++;
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
