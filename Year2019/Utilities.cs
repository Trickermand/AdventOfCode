using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2019
{
    class Utilities
    {
        public static List<string> ReadInputAsListStrings(string readPath)
        {
            List<string> ls = new List<string>();

            using (StreamReader reader = new StreamReader(readPath))
            {
                while (!reader.EndOfStream)
                {
                    ls.Add(reader.ReadLine());
                }
            }
            return ls;
        }
    }
}
