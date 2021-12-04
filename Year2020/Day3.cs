using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using Utilities;

namespace Year2020
{
    public enum Path
    {
        Ground,
        Tree
    }
    public static class Day3
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void Part1()
        {
            List<string> inputs = IO.ReadInput(Day);
            Path[][] area = GetAreaFromInput(inputs);
            int hits = GoDownSlope(area, new Point(1, 3));

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {hits}");
        }

        private static Path[][] GetAreaFromInput(List<string> input)
        {
            Path[][] area = new Path[input.Count][];

            for (int i = 0; i < input.Count; i++)
            {
                area[i] = new Path[input[i].Length];
                for (int j = 0; j < input[i].Length; j++)
                {
                    area[i][j] = input[i][j] == '.' ? Path.Ground : Path.Tree;
                }
            }
            return area;
        }

        private static int GoDownSlope(Path[][] area, Point slope)
        {
            int hits = 0;
            Point pos = new(0, 0);
            for (int i = 0; i < area.Length; i++)
            {
                if (pos.X > area.Length)
                    return hits;

                int offset = pos.Y - area[pos.X].Length;
                if (offset >= 0)
                {
                    pos = new Point(pos.X, offset);
                }

                if (area[pos.X][pos.Y] == Path.Tree)
                    hits++;

                pos = new Point(pos.X + slope.X, pos.Y + slope.Y);
            }
            return hits;
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);
            
            Path[][] area = GetAreaFromInput(inputs);
            long hits = 1;
            List<Point> slopes = new()
            {
                new Point(1, 1),
                new Point(1, 3),
                new Point(1, 5),
                new Point(1, 7),
                new Point(2, 1),
            };
            for (int i = 0; i < slopes.Count; i++)
            {
                hits *= GoDownSlope(area, slopes[i]);
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {hits}");
        }
    }
}
