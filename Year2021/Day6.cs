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
            int result = 0;

            int dayToRun = 256;

            int[] initialFish = InitializeFishArrayOptimized(inputs[0].Split(','));
            int[] growingFish = initialFish;

            int rollingIndex = 300;

            for (int i = 0; i < dayToRun; i++)
            {
                ProgressDayArrayOptimized(ref growingFish, ref rollingIndex);
            }


            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static void ProgressDayArrayOptimized(ref int[] allFish, ref int rollingIndex)
        {
            int initialLength = rollingIndex;
            for (int i = 0; i < initialLength; i++)
            {
                if (allFish[i] == 0)
                {
                    allFish[i + 1] = 8;
                    allFish[i] = 6;
                    i++;
                }
                else
                    allFish[i]--;
            }
        }

        private static void ProgressDayOptimized(ref List<int> allFish)
        {
            int initialLength = allFish.Count;
            for (int i = 0; i < initialLength; i++)
            {
                if (allFish[i] == 0)
                    allFish.Add(8);

                if (allFish[i] == 0)
                    allFish[i] = 6;
                else
                    allFish[i]--;
            }
        }

        private static List<Fish> ProgressDay(List<Fish> allFish)
        {
            List<Fish> allFishAndNewborns = new();
            foreach (var fish in allFish)
            {
                if (fish.BirthCounter == 0)
                    allFishAndNewborns.Add(new Fish(8));

                fish.ProgressBithCounter();
                allFishAndNewborns.Add(fish);
            }
            return allFishAndNewborns;
        }

        private static int[] InitializeFishArrayOptimized(string[] initialBirthCounters)
        {
            int[] allFish = new int[4000000000];
            for (int i = 0; i < initialBirthCounters.Length; i++)
            {
                allFish[i] = int.Parse(initialBirthCounters[i]);
            }
            return allFish;
        }

        private static List<int> InitializeFishOptimized(string[] initialBirthCounters)
        {
            List<int> allFish = new();
            for (int i = 0; i < initialBirthCounters.Length; i++)
            {
                allFish.Add(int.Parse(initialBirthCounters[i]));
            }
            return allFish;
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
