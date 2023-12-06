using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Year2023
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
            Stopwatch stopwatch = Stopwatch.StartNew();
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> lines = IO.ReadInputAsLines(Day);
            int result = 0;

            List<Point> machineParts = new();
            List<string> machineNumbers = new();

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != '.' && !Regex.IsMatch(lines[i][j].ToString(), @"\d"))
                        machineParts.Add(new Point(i, j));
                }
            }

            foreach (var machinePart in machineParts)
            {
                for (int i = machinePart.X; i < machinePart.X + 3; i++)
                {
                    if (i < 0 || i >= lines.Count)
                        continue;

                    for (int j = machinePart.Y; j < machinePart.Y + 3; j++)
                    {
                        if (j < 0 || j >= lines[i].Length)
                            continue;
                        string number = lines[i][j].ToString();
                        if (Regex.IsMatch(number, @"\d") && !machineNumbers.Contains(number))
                            machineNumbers.Add(number);
                    }
                }
            }

            result = machineNumbers.Sum(x => int.Parse(x));

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }

        private static int GetNumber(List<string> lines, int i, int j)
        {
            return 0;
        }

        public static void Part2()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;



            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
