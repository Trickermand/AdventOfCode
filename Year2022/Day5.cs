using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Text.RegularExpressions;

namespace Year2022
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
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            string result = "";

            List<string> instructions = new();
            int separationIndex = inputs.IndexOf("");
            instructions = inputs.Skip(separationIndex + 1).ToList();

            List<string> stackData = inputs.SkipLast(inputs.Count - separationIndex).ToList();
            Dictionary<int, List<char>> stack = LoadStack(stackData);

            foreach (var instruction in instructions)
            {
                Move(instruction, stack);
            }

            foreach (var item in stack)
            {
                result += item.Value.Last();
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        private static void Move(string instruction, Dictionary<int, List<char>> stack)
        {
            Regex reg = new("(\\d+)");
            MatchCollection matches = reg.Matches(instruction);

            int amount = int.Parse(matches[0].Value);
            int source = int.Parse(matches[1].Value);
            int destination = int.Parse(matches[2].Value);

            for (int i = 1; i <= amount; i++)
            {
                char element = stack[source].Last();
                stack[source].RemoveAt(stack[source].Count - 1);
                stack[destination].Add(element);
            }
        }

        private static Dictionary<int, List<char>> LoadStack(List<string> input)
        {
            Dictionary<int, List<char>> stacks = new();
            
            for (int i = 0; i < input.Last().Length; i += 4)
            {
                for (int j = input.Count - 1; j >= 0 ; j--)
                {
                    int stackNum = int.Parse(input.Last().Substring(i, 3));
                    if (!stacks.ContainsKey(stackNum))
                    {
                        stacks.Add(stackNum, new List<char>());
                    }
                    else
                    {
                        string text = input[j].Substring(i, 3).Trim('[').Trim(']').Trim();
                        if (text.Length < 1)
                            continue;

                        char c = char.Parse(input[j].Substring(i, 3).Trim('[').Trim(']'));
                        stacks[stackNum].Add(c);
                    }
                }
            }

            return stacks;
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            string result = "";

            List<string> instructions = new();
            int separationIndex = inputs.IndexOf("");
            instructions = inputs.Skip(separationIndex + 1).ToList();

            List<string> stackData = inputs.SkipLast(inputs.Count - separationIndex).ToList();
            Dictionary<int, List<char>> stack = LoadStack(stackData);

            foreach (var instruction in instructions)
            {
                MoveCrane9001(instruction, stack);
            }

            foreach (var item in stack)
            {
                result += item.Value.Last();
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        private static void MoveCrane9001(string instruction, Dictionary<int, List<char>> stack)
        {
            Regex reg = new("(\\d+)");
            MatchCollection matches = reg.Matches(instruction);

            int amount = int.Parse(matches[0].Value);
            int source = int.Parse(matches[1].Value);
            int destination = int.Parse(matches[2].Value);

            List<char> elements = stack[source].TakeLast(amount).ToList();
            stack[source].RemoveRange(stack[source].Count - amount, amount);
            stack[destination].AddRange(elements);
        }
    }
}
