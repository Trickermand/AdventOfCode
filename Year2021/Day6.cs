using System;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using Year2021.Day6Helper;

namespace Year2021
{
    public static class Day6
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
            int result = 0;
            int dayToRun = 80;

            List<Fish> initialFish = InitializeFish(inputs[0].Split(','));
            List<Fish> growingFish = initialFish;

            for (int i = 0; i < dayToRun; i++)
            {
                growingFish = ProgressDay(growingFish);
            }

            result = growingFish.Count;

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);
            ulong result = 0;

            int daysToRun = 256;
            ulong[] groups = InitFish(inputs[0].Split(','));
            ulong[] newGroups = new ulong[9];

            for (int i = 0; i < daysToRun; i++)
            {
                newGroups[0] = groups[1];
                newGroups[1] = groups[2];
                newGroups[2] = groups[3];
                newGroups[3] = groups[4];
                newGroups[4] = groups[5];
                newGroups[5] = groups[6];
                newGroups[6] = groups[7];
                newGroups[7] = groups[8];

                newGroups[6] += groups[0];
                newGroups[8] = groups[0];

                newGroups.CopyTo(groups, 0);
                result = groups[0] +
                        groups[1] +
                        groups[2] +
                        groups[3] +
                        groups[4] +
                        groups[5] +
                        groups[6] +
                        groups[7] +
                        groups[8];
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static ulong[] InitFish(string[] input)
        {
            ulong[] groups = new ulong[9];
            for (int i = 0; i < input.Length; i++)
            {
                int tmp = int.Parse(input[i]);
                groups[tmp]++;
            }
            return groups;
        }

        private static List<Fish> ProgressDay(List<Fish> allFish)
        {
            List<Fish> allFishAndNewborns = new();
            foreach (var fish in allFish)
            {
                if (fish.BirthCounter == 0)
                    allFishAndNewborns.Add(new Fish(8));

                fish.ProgressBirthCounter();
                allFishAndNewborns.Add(fish);
            }
            return allFishAndNewborns;
        }

        private static List<Fish> InitializeFish(string[] initialBirthCounters)
        {
            List<Fish> allFish = new();
            for (int i = 0; i < initialBirthCounters.Length; i++)
            {
                allFish.Add(new Fish(int.Parse(initialBirthCounters[i])));
            }
            return allFish;
        }

    }
}
