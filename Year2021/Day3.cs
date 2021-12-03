using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace Year2021
{
    public static class Day3
    {
        public static string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void Part1()
        {
            List<string> inputs = IO.ReadInput(Day);

            int ones = 0;
            int zeroes = 0;
            List<bool> gamma = new();
            List<bool> epsilon = new();

            for (int i = 0; i < inputs[0].Length; i++)
            {
                for (int j = 0; j < inputs.Count; j++)
                {
                    if (inputs[j][i] == '1')
                        ones++;
                    else
                        zeroes++;
                }

                if (ones > zeroes)
                    gamma.Add(true);
                else
                    gamma.Add(false);

                ones = 0;
                zeroes = 0;
            }

            epsilon = gamma.Select(x => !x).ToList();

            string gammaBinary = ConvertBoolListToBinaryString(gamma);
            string epsilonBinary = ConvertBoolListToBinaryString(epsilon);

            int result = Convert.ToInt32(gammaBinary, 2) * Convert.ToInt32(epsilonBinary, 2);

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static string ConvertBoolListToBinaryString(List<bool> input)
        {
            string output = "";

            foreach (var item in input)
            {
                output += item == true ? "1" : "0";
            }

            return output;
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);

            int ones = 0;
            int zeroes = 0;
            List<string> options = new();
            List<bool> gamma = new();
            List<bool> epsilon = new();


            //Scrapped
            for (int i = 0; i < inputs[0].Length; i++)
            {
                options = inputs;
                for (int j = 0; j < options.Count; j++)
                {
                    if (inputs[j][i] == '1')
                        ones++;
                    else
                        zeroes++;
                }

                if (ones >= zeroes)
                {
                    options = options.Where(x => x.Substring(i, 1) == "1").ToList();
                }
                else
                {
                    options = options.Where(x => x.Substring(i, 1) == "0").ToList();
                }

                ones = 0;
                zeroes = 0;
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: ");
        }
    }
}
