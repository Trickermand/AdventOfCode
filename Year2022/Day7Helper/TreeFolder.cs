using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2022.Day7Helper
{
    internal class TreeFolder
    {
        public string Root { get; private set; } = "";
        public string Name { get; private set; }
        public Dictionary<string, TreeFile> Files { get; set; } = new();
        public Dictionary<string, TreeFolder> SubFolders { get; private set; } = new();
        public TreeFolder ParentFolder;
        private int _totalSize = -1;
        public int TotalSize { 
            get
            {
                if (_totalSize < 0)
                {
                    _totalSize = GetTotalSize();
                }
                return _totalSize;
            }
            private set
            {

            }
        }

        public TreeFolder(string name, TreeFolder parentFolder)
        {
            Name = name;
            ParentFolder = parentFolder;
            if (ParentFolder != null)
                Root = parentFolder.Root += $"{(parentFolder.Root.EndsWith("/") ? "" : "/")}{name}";
            else
                Root = name;
        }

        public void GetFolderAndSubFolders(List<TreeFolder> folderDestionation)
        {
            folderDestionation.Add(this);
            foreach (var subFolder in SubFolders)
            {
                subFolder.Value.GetFolderAndSubFolders(folderDestionation);
            }
        }

        public void AddFile(string name, int size)
        {
            if (!FileExists(name))
                Files.Add(name, new TreeFile(name, size));
        }

        public bool FileExists(string name)
        {
            return Files.ContainsKey(name);
        }

        public TreeFolder GetSubFolder(string name)
        {
            return SubFolders[name];
        }

        public TreeFolder GetParentFolder()
        {
            return ParentFolder;
        }

        public void AddSubFolder(string name)
        {
            if (SubFolders.ContainsKey(name))
                return;

            SubFolders.Add(name, new TreeFolder(name, this));
        }

        public int GetTotalSize()
        {
            int result = GetCurrentFolderFilesSize();
            foreach (var subFolder in SubFolders)
            {
                result += subFolder.Value.GetTotalSize();
            }
            return result;
        }

        public int GetCurrentFolderFilesSize()
        {
            int result = 0;
            foreach (var file in Files)
            {
                result += file.Value.Size;
            }
            return result;
        }

    }
}
