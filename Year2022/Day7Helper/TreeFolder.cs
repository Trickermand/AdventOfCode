using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2022.Day7Helper
{
    internal class TreeFolder
    {
        public string Root { get; private set; }
        public string Name { get; set; }
        public List<TreeFile> Files { get; set; } = new();

        public TreeFolder(string name)
        {
            Name = name;
        }

        public void AddFile(string name, uint size)
        {
            if (!FileExists(name))
                Files.Add(new TreeFile(name, size));
        }

        public bool FileExists(string name)
        {
            return Files.Select(x => x.Name).Contains(name);
        }
    }
}
