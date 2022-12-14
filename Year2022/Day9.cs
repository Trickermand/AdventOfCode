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
        
        private static int tolerance = 1;

        public static void Part1()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            List<string> positions = new()
            {
                "0,0"
            };
            int hVert = 0;
            int hHori = 0;
            int tVert = 0;
            int tHori = 0;

            foreach (var line in inputs)
            {
                string[] s = line.Split(' ');
                string direction = s[0];
                int distance = int.Parse(s[1]);
                MoveSegmentAndTail(direction, ref hVert, ref hHori, ref tVert, ref tHori, ref distance, positions, true);

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

        private static void MoveSegmentAndTail(string direction, ref int hVert, ref int hHori, ref int tVert, ref int tHori, ref int distance, List<string> positions, bool isEndTail)
        {

            if (direction == "U")
            {
                int destionation = hVert + distance;
                for (; hVert <= destionation; hVert++)
                {
                    if (Math.Abs(hVert - tVert) > tolerance || Math.Abs(hHori - tHori) > tolerance)
                    {
                        tHori = hHori;
                        tVert++;
                        if (isEndTail)
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
                        if (isEndTail)
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
                        if (isEndTail)
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
                        if (isEndTail)
                            StorePosition(tVert, tHori, positions);
                    }
                }
                hHori++;
            }
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day, true);
            int result = 0;
            List<int> verts = new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<int> horis = new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<string> positions = new()
            {
                "0,0"
            };

            foreach (var line in inputs)
            {
                string[] s = line.Split(' ');
                string direction = s[0];
                int distance = int.Parse(s[1]);
                for (int i = 0; i < 10; i += 2)
                {
                    if (i > 0 && (direction == "U" || direction == "D"))
                        distance = Math.Abs(verts[i] - verts[i - 1]) - 1;
                    else if (i > 0 && (direction == "R" || direction == "L"))
                        distance = Math.Abs(horis[i] - horis[i - 1]) - 1;

                    if (distance < 1)
                        break;
                    bool isEndTail = i == 8;
                    int hVert = verts[i];
                    int hHori = horis[i];
                    int tVert = verts[i + 1];
                    int tHori = horis[i + 1];

                    MoveSegmentAndTail(direction, ref hVert, ref hHori, ref tVert, ref tHori, ref distance, positions, isEndTail);
                    
                    verts[i] = hVert;
                    horis[i] = hHori;
                    verts[i + 1] = tVert;
                    horis[i + 1] = tHori;
                }

            }
            result = positions.Count;

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }
    }
}
