using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace Year2021
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
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    if (IsLowestAdjacent(inputs, i, j))
                        result += int.Parse(inputs[i][j].ToString()) + 1;
                }
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(MethodBase.GetCurrentMethod().DeclaringType.Name);
            int result = 0;



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static bool IsLowestAdjacent(List<string> input, int rowIndex, int columnIndex)
        {
            if (columnIndex > 0 && int.Parse(input[rowIndex][columnIndex].ToString()) > int.Parse(input[rowIndex][columnIndex - 1].ToString()))
                return false;
            
            if (columnIndex < input[rowIndex].Length - 1 && int.Parse(input[rowIndex][columnIndex].ToString()) > int.Parse(input[rowIndex][columnIndex + 1].ToString()))
                return false;

            if (rowIndex > 0 && int.Parse(input[rowIndex][columnIndex].ToString()) > int.Parse(input[rowIndex - 1][columnIndex].ToString()))
                return false;

            if (rowIndex < input.Count - 1 && int.Parse(input[rowIndex][columnIndex].ToString()) > int.Parse(input[rowIndex + 1][columnIndex].ToString()))
                return false;



            return true;
        }
    }
}
