using System;
using System.Collections.Generic;
using System.IO;

namespace Utilities
{
    public static class IO
    {
        public static List<string> ReadInput(string day)
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
    }
}
