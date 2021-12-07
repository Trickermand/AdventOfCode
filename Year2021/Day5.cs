using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Utilities;
using Year2021.Day5Helper;

namespace Year2021
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
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            Area2D area = new Area2D(1000, 1000);

            for (int i = 0; i < inputs.Count; i++)
            {
                (Point start, Point end) line = DecipherInputLine(inputs[i]);
                area.IncrementCellLines(line.start, line.end, true);
            }

            result = EvaluateArea(area);

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(MethodBase.GetCurrentMethod().DeclaringType.Name);
            int result = 0;

            Area2D area = new Area2D(1000, 1000);

            for (int i = 0; i < inputs.Count; i++)
            {
                (Point start, Point end) line = DecipherInputLine(inputs[i]);
                area.IncrementCellLines(line.start, line.end, false);
            }

            result = EvaluateArea(area);

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static int EvaluateArea(Area2D area)
        {
            int result = 0;
            for (int i = 0; i < area.Area.Length; i++)
            {
                for (int j = 0; j < area.Area[i].Length; j++)
                {
                    if (area.Area[i][j] > 1)
                        result++;
                }
            }
            return result;
        }

        private static (Point start, Point end) DecipherInputLine(string input)
        {
            string[] inputSides= input.Split(" -> ");
            string[] startInput = inputSides[0].Split(',');
            string[] endInput = inputSides[1].Split(',');

            Point start = new Point(int.Parse(startInput[0]), int.Parse(startInput[1]));
            Point end = new Point(int.Parse(endInput[0]), int.Parse(endInput[1]));

            return (start, end);
        }
    }
}
