using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Utilities
{
    public static class IO
    {
        public static List<string> ReadInputAsLines(string day)
        {
            string path = Path.Combine(Environment.CurrentDirectory, $"..\\..\\..\\Inputs\\{day}.txt");
            List<string> result = new();

            using (StreamReader reader = new(path))
            {
                while (!reader.EndOfStream)
                {
                    result.Add(reader.ReadLine());
                }
            }

            return result;
        }

        public static List<int> ConvertStringListToIntList(List<string> input)
        {
            List<int> result = new(input.Count);

            foreach (var item in input)
            {
                result.Add(int.Parse(item));
            }

            return result;
        }

        public static List<T> ReadInputDelimited<T>(string day, string delimiter) where T : IComparable
        {
            string firstLine = ReadInputAsLines(day)[0];
            string[] inputs = firstLine.Split(delimiter);
            List<T> ls = new();

            for (int i = 0; i < inputs.Length; i++)
            {
                ls.Add((T)Convert.ChangeType(inputs[i], typeof(T)));
            }

            return ls;
        }
    }

}
