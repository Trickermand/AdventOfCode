﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2022
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
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            List<List<int>> forest = new();
            for (int i = 0; i < inputs.Count; i++)
            {
                List<int> line = new();
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    line.Add(int.Parse(inputs[i][j].ToString()));
                }
                forest.Add(line);
            }

            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[i].Count; j++)
                {
                    int tree = forest[i][j];
                    bool visible = true;
                    if (i == 0 || j == 0 || i == forest.Count - 1 || j == forest[i].Count - 1)
                    {
                        result++;
                        continue;
                    }

                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (tree <= forest[k][j])
                            visible = false;
                    }

                    if (visible)
                    {
                        result++;
                        continue;
                    }
                    visible = true;

                    for (int k = i + 1; k < forest.Count; k++)
                    {
                        if (tree <= forest[k][j])
                            visible = false;
                    }

                    if (visible)
                    {
                        result++;
                        continue;
                    }
                    visible = true;

                    for (int k = j + 1; k < forest[i].Count; k++)
                    {
                        if (tree <= forest[i][k])
                            visible = false;
                    }

                    if (visible)
                    {
                        result++;
                        continue;
                    }
                    visible = true;

                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (tree <= forest[i][k])
                            visible = false;
                    }

                    if (visible)
                    {
                        result++;
                        continue;
                    }
                }
            }


            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            List<List<int>> forest = new();
            for (int i = 0; i < inputs.Count; i++)
            {
                List<int> line = new();
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    line.Add(int.Parse(inputs[i][j].ToString()));
                }
                forest.Add(line);
            }

            int bestScore = 0;

            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[i].Count; j++)
                {
                    int treeCountN = 0;
                    int treeCountS = 0;
                    int treeCountE = 0;
                    int treeCountW = 0;
                    int tree = forest[i][j];
                    if (i == 0 || j == 0 || i == forest.Count - 1 || j == forest[i].Count - 1)
                        continue;

                    for (int k = i - 1; k >= 0; k--)
                    {
                        treeCountN++;
                        if (tree <= forest[k][j])
                            break;
                    }

                    for (int k = i + 1; k < forest.Count; k++)
                    {
                        treeCountS++;
                        if (tree <= forest[k][j])
                            break;
                    }

                    for (int k = j + 1; k < forest[i].Count; k++)
                    {
                        treeCountE++;
                        if (tree <= forest[i][k])
                            break;
                    }

                    for (int k = j - 1; k >= 0; k--)
                    {
                        treeCountW++;
                        if (tree <= forest[i][k])
                            break;
                    }

                    int score = treeCountN * treeCountS * treeCountE * treeCountW;
                    if (bestScore < score)
                        bestScore = score;
                }
            }

            result = bestScore;

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }
    }
}
