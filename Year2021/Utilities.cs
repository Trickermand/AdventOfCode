using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021
{
    public static class Utilities
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
