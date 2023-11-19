using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Data.Common;

namespace Year2020
{
    public static class Day5
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
            List<string> lines = IO.ReadInputAsLines(Day);
            int result = 0;


            foreach (var line in lines)
            {
                int id = GetSeatId(line);
                if (id > result)
                    result = id;
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> lines = IO.ReadInputAsLines(Day);
            int result = 0;

            int row = -1;
            int column = -1;

            List<int> ids = new();

            foreach (var line in lines)
            {
                ids.Add(GetSeatId(line));
            }

            List<int> orderedIds = ids.OrderBy(x => x).ToList();

            for (int i = 0; i < orderedIds.Count - 1; i++)
            {
                if (orderedIds[i] + 2 == orderedIds[i + 1])
                {
                    result = orderedIds[i] + 1;
                    break;
                }
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        private static int GetSeatId(string line)
        {
            int row = -1;
            int column = -1;

            int currentRowMin = 0;
            int currentRowMax = 127;
            int currentColumnMin = 0;
            int currentColumnMax = 7;
            foreach (var letter in line)
            {
                switch (letter)
                {
                    case 'F':
                        currentRowMax -= (currentRowMax - currentRowMin) / 2 + 1;
                        if (currentRowMax == currentRowMin)
                            row = currentRowMax;
                        break;
                    case 'B':
                        currentRowMin += (currentRowMax - currentRowMin) / 2 + 1;
                        if (currentRowMax == currentRowMin)
                            row = currentRowMax;
                        break;
                    case 'R':
                        currentColumnMin += (currentColumnMax - currentColumnMin) / 2 + 1;
                        if (currentColumnMax == currentColumnMin)
                            column = currentColumnMax;
                        break;
                    case 'L':
                        currentColumnMax -= (currentColumnMax - currentColumnMin) / 2 + 1;
                        if (currentColumnMax == currentColumnMin)
                            column = currentColumnMax;
                        break;
                    default:
                        break;
                }
            }
            return row * 8 + column;
        }
    }
}
