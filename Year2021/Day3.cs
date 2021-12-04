using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Utilities;

namespace Year2021
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

            string oxygenRating = FindRating(inputs, true);
            string scrubRating = FindRating(inputs, false);

            int oxygenRatingDecimal = Convert.ToInt32(oxygenRating, 2);
            int scrubRatingDecimal = Convert.ToInt32(scrubRating, 2);
            int result = oxygenRatingDecimal * scrubRatingDecimal;

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static string FindRating(List<string> inputs, bool pickMostCommon)
        {
            int ones = 0;
            int zeroes = 0;
            List<string> options = new();
            options = inputs;
            int bitIndex = 0;

            while (options.Count > 1)
            {
                for (int j = 0; j < options.Count; j++)
                {
                    if (options[j][bitIndex] == '1')
                        ones++;
                    else
                        zeroes++;
                }

                if (pickMostCommon)
                {
                    if (ones >= zeroes)
                        options = options.Where(x => x.Substring(bitIndex, 1) == "1").ToList();
                    else
                        options = options.Where(x => x.Substring(bitIndex, 1) == "0").ToList();
                }
                else
                {
                    if (zeroes <= ones)
                        options = options.Where(x => x.Substring(bitIndex, 1) == "0").ToList();
                    else
                        options = options.Where(x => x.Substring(bitIndex, 1) == "1").ToList();
                }

                ones = 0;
                zeroes = 0;
                bitIndex = bitIndex + 1 > options[0].Length ? 0 : bitIndex + 1;
            }
            return options[0];
        }
    }
}
