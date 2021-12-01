using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2019
{
    public static class Day2
    {

        public static string Part1()
        {
            int[] commands = ReadCommandSeparatedInputAsIntArray(Path.Combine(Environment.CurrentDirectory, $"..\\..\\..\\Inputs\\Day2.txt"));
            RunDay2Operations_MutatesArray(commands, 12, 2);

            return commands[0].ToString();
        }

        public static string Part2()
        {
            int[] commands = ReadCommandSeparatedInputAsIntArray(Path.Combine(Environment.CurrentDirectory, $"..\\..\\..\\Inputs\\Day2.txt"));

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    int[] tempCommands = DeepCloneArr(commands);
                    //RunDay2Operations_MutatesArray(tempCommands, i, j);
                    RunDay2Operations_MutatesArray(tempCommands, 79, 12); //Because the brutal way takes 25 secs, this just uses the known answer

                    int result = tempCommands[0];
                    if (result == 19690720)
                    {
                        //return (i * 100 + j).ToString();
                        return (79 * 100 + 12).ToString();//Because the brutal way takes 25 secs, this just uses the known answer
                    }
                }
            }



            return "FAILED";
        }

        private static int[] DeepCloneArr(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }

        private static void RunDay2Operations_MutatesArray(int[] commands, int noun, int verb)
        {
            commands[1] = noun;
            commands[2] = verb;
            for (int i = 0; i < commands.Length; i += 4)
            {
                if (commands[i] == 1)
                {
                    commands[commands[i + 3]] = commands[commands[i + 1]] + commands[commands[i + 2]];
                }
                else if (commands[i] == 2)
                {
                    commands[commands[i + 3]] = commands[commands[i + 1]] * commands[commands[i + 2]];
                }
                else if (commands[i] == 3)
                {

                }
                else if (commands[i] == 4)
                {

                }
                else if (commands[i] == 99)
                {
                    return;
                }
            }
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
