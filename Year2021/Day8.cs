﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2021
{
    public static class Day8
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
                List<string> segments = line.Split("|")[1].Split(" ").Where(x => x != "").ToList();
                int count1 = 0, count4 = 0, count7 = 0, count8 = 0;
                for (int i = 0; i < segments.Count; i++)
                {
                    if (segments[i].Length == 2)
                        count1++;
                    if (segments[i].Length == 4)
                        count4++;
                    if (segments[i].Length == 3)
                        count7++;
                    if (segments[i].Length == 7)
                        count8++;
                }

                result += count1 + count4 + count7 + count8;
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