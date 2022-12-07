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
        public uint Size { get; set; }
        public TreeFile(string name, uint size)
        {
            Name = name;
            Size = size;
        }
    }
}
