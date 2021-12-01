using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2019
{
    public static class Day5
    {
        public static string Part1()
        {
            return "NOT IMPLEMENTED";
        }

        public static string Part2()
        {
            return "NOT IMPLEMENTED";
        }

        private static void IntcoodeComputer(int[] commands, int noun, int verb)
        {
            commands[1] = noun;
            commands[2] = verb;
            int inputConst = 1;
            for (int i = 0; i < commands.Length;)
            {
                int[] instruction = InterpretCommand(commands[i]);
                if (instruction[0] == 1)
                {
                    commands[commands[i + 3]] = commands[commands[i + 1]] + commands[commands[i + 2]];
                    i += 4;
                }
                else if (commands[i] == 2)
                {
                    commands[commands[i + 3]] = commands[commands[i + 1]] * commands[commands[i + 2]];
                    i += 4;
                }
                else if (commands[i] == 3)
                {
                    commands[commands[i] + 1] = inputConst;
                }
                else if (commands[i] == 4)
                {
                    Console.WriteLine(commands[commands[i] + 1]);
                }
                else if (commands[i] == 99)
                {
                    return;
                }
            }
        }

        private static int[] InterpretCommand(int command)
        {
            List<int> seperatedCommand = new List<int>();
            int tmpNum = command;

            seperatedCommand.Add(tmpNum % 100);
            tmpNum /= 100;
            for (int i = 2; i < 5; i++)
            {
                seperatedCommand.Add(tmpNum % 10);
            }

            while (tmpNum % 10 > 0.9 || (tmpNum % 10 == 0 && tmpNum > 0))
            {
                if (tmpNum % 10 == 0)
                {
                    seperatedCommand.Add(0);
                }
                else
                {
                    seperatedCommand.Add(tmpNum % 10);
                }
                tmpNum /= 10;
            }
            seperatedCommand.Reverse();
            return seperatedCommand.ToArray();
        }

        private static List<int> SplitIntToDigits(int num)
        {
            List<int> digits = new List<int>();
            int tmpNum = num;

            while (tmpNum % 10 > 0.9 || (tmpNum % 10 == 0 && tmpNum > 0))
            {
                if (tmpNum % 10 == 0)
                {
                    digits.Add(0);
                }
                else
                {
                    digits.Add(tmpNum % 10);
                }
                tmpNum /= 10;
            }
            digits.Reverse();
            return digits;
        }

        private static int[] ReadCommandSeparatedInputAsIntArray(string readPath)
        {
            int[] arr = new int[1000000];

            using (StreamReader reader = new StreamReader(readPath))
            {
                string[] s = reader.ReadToEnd().Split(',');

                for (int i = 0; i < s.Length; i++)
                {
                    arr[i] = int.Parse(s[i].ToString());
                }

            }
            return arr;
        }

    }
}
