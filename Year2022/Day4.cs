using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Security.Cryptography;

namespace Year2022
{
    public static class Day4
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            foreach (var line in inputs)
            {
                var elfs = line.Split(',');
                var fstElf = elfs[0].Split('-');
                int fstElfStart = int.Parse(fstElf[0]);
                int fstElfEnd = int.Parse(fstElf[1]);
                
                var sndElf = elfs[1].Split('-');
                int sndElfStart = int.Parse(sndElf[0]);
                int sndElfEnd = int.Parse(sndElf[1]);

                if ((fstElfStart >= sndElfStart && fstElfStart <= sndElfEnd
                    && fstElfEnd <= sndElfEnd && fstElfEnd >= sndElfStart)
                    || (sndElfStart >= fstElfStart && sndElfStart <= fstElfEnd
                    && sndElfEnd <= fstElfEnd && sndElfEnd >= fstElfStart))
                {
                    result++;
                }
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            foreach (var line in inputs)
            {
                var elfs = line.Split(',');
                var fstElf = elfs[0].Split('-');
                int fstElfStart = int.Parse(fstElf[0]);
                int fstElfEnd = int.Parse(fstElf[1]);

                var sndElf = elfs[1].Split('-');
                int sndElfStart = int.Parse(sndElf[0]);
                int sndElfEnd = int.Parse(sndElf[1]);

                if ((fstElfStart >= sndElfStart && fstElfStart <= sndElfEnd
                    || fstElfEnd <= sndElfEnd && fstElfEnd >= sndElfStart)
                    || (sndElfStart >= fstElfStart && sndElfStart <= fstElfEnd
                    || sndElfEnd <= fstElfEnd && sndElfEnd >= fstElfStart))
                {
                    result++;
                }
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }
    }
}
