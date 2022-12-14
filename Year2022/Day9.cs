using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2022
{
    public static class Day9
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

            List<string> positions = new()
            {
                "0,0"
            };

            int tolerance = 1;

            int hVert = 0;
            int hHori = 0;

            int tVert = 0;
            int tHori = 0;

            foreach (var line in inputs)
            {
                string[] s = line.Split(' ');
                string direction = s[0];
                int distance = int.Parse(s[1]);

                if (direction == "U")
                {
                    int destionation = hVert + distance;
                    for (; hVert <= destionation; hVert++)
                    {
                        if (Math.Abs(hVert - tVert) > tolerance || Math.Abs(hHori - tHori) > tolerance)
                        {
                            tHori = hHori;
                            tVert++;
                            StorePosition(tVert, tHori, positions);
                        }
                    }
                    hVert--;
                }
                else if (direction == "D")
                {
                    int destionation = hVert - distance;
                    for (; hVert >= destionation; hVert--)
                    {
                        if (Math.Abs(hVert - tVert) > tolerance || Math.Abs(hHori - tHori) > tolerance)
                        {
                            tHori = hHori;
                            tVert--;
                            StorePosition(tVert, tHori, positions);
                        }
                    }
                    hVert++;
                }
                else if (direction == "R")
                {
                    int destionation = hHori + distance;
                    for (; hHori <= destionation; hHori++)
                    {
                        if (Math.Abs(hVert - tVert) > tolerance || Math.Abs(hHori - tHori) > tolerance)
                        {
                            tVert = hVert;
                            tHori++;
                            StorePosition(tVert, tHori, positions);
                        }
                    }
                    hHori--;
                }
                else if (direction == "L")
                {
                    int destionation = hHori - distance;
                    for (; hHori >= destionation; hHori--)
                    {
                        if (Math.Abs(hVert - tVert) > tolerance || Math.Abs(hHori - tHori) > tolerance)
                        {
                            tVert = hVert;
                            tHori--;
                            StorePosition(tVert, tHori, positions);
                        }
                    }
                    hHori++;
                }
            }

            result = positions.Count;

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        private static void StorePosition(int vert, int hori, List<string> positions)
        {
            string coord = $"{vert},{hori}";
            if (!positions.Contains(coord))
                positions.Add(coord);
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;



            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }
    }
}
