using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;
using System.Text;

namespace Year2024
{
    public static class Day4
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
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    result += Try(() => inputs[i][j] == 'X' && inputs[i][j + 1] == 'M' && inputs[i][j + 2] == 'A' && inputs[i][j + 3] == 'S') ? 1 : 0;
                    result += Try(() => inputs[i][j] == 'X' && inputs[i + 1][j + 1] == 'M' && inputs[i + 2][j + 2] == 'A' && inputs[i + 3][j + 3] == 'S') ? 1 : 0;
                    result += Try(() => inputs[i][j] == 'X' && inputs[i + 1][j] == 'M' && inputs[i + 2][j] == 'A' && inputs[i + 3][j] == 'S') ? 1 : 0;
                    result += Try(() => inputs[i][j] == 'X' && inputs[i + 1][j - 1] == 'M' && inputs[i + 2][j - 2] == 'A' && inputs[i + 3][j - 3] == 'S') ? 1 : 0;
                    result += Try(() => inputs[i][j] == 'X' && inputs[i][j - 1] == 'M' && inputs[i][j - 2] == 'A' && inputs[i][j - 3] == 'S') ? 1 : 0;
                    result += Try(() => inputs[i][j] == 'X' && inputs[i - 1][j - 1] == 'M' && inputs[i - 2][j - 2] == 'A' && inputs[i - 3][j - 3] == 'S') ? 1 : 0;
                    result += Try(() => inputs[i][j] == 'X' && inputs[i - 1][j] == 'M' && inputs[i - 2][j] == 'A' && inputs[i - 3][j] == 'S') ? 1 : 0;
                    result += Try(() => inputs[i][j] == 'X' && inputs[i - 1][j + 1] == 'M' && inputs[i - 2][j + 2] == 'A' && inputs[i - 3][j + 3] == 'S') ? 1 : 0;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }

        private static bool Try(Func<bool> function)
        {
            try
            {
                return function.Invoke();
            }
            catch
            {
                return false;
            }
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
