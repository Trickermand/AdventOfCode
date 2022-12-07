using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2022.Day7Helper
{
    internal class TreeFile
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public TreeFile(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
