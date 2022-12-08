using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using Year2022.Day7Helper;

namespace Year2022
{
    public static class Day7
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        // State Machine variables
        static int instPointer = 0;
        static List<string> memory = new();
        static TreeFolder currentFolder;
        static TreeFolder homeFolder = new("/", null);

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            memory = IO.ReadInputAsLines(Day);
            int result = 0;

            InitializeFolders();

            List<TreeFolder> allFolders = new();
            homeFolder.GetFolderAndSubFolders(allFolders);

            foreach (var folder in allFolders)
            {
                int size = folder.TotalSize;
                if (size <= 100000)
                    result += size;
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        private static void InitializeFolders()
        {
            int lastInstPointer = 0;
            while (instPointer < memory.Count)
            {
                lastInstPointer = instPointer;
                if (memory[instPointer].StartsWith('$'))
                    ExecuteNextCommand();

                if (lastInstPointer == instPointer)
                    throw new Exception("Program ran into an infinite loop.");
            }
        }

        private static void ExecuteNextCommand()
        {
            if (!memory[instPointer].StartsWith('$'))
                throw new Exception("ExecuteNextCommand called but next line was not an instruction declaration.");

            string command = memory[instPointer][2..];
            if (command.StartsWith("cd"))
            {
                string destination = command.Split(' ')[1];
                if (destination == "/")
                    GoHome();
                else if (destination == "..")
                    GoParentFolder();
                else
                    GoSubFolder(destination);

                instPointer++;
            }
            else if (command == "ls")
                InterpretResponse();
        }

        private static void InterpretResponse()
        {
            instPointer++;
            string line = memory[instPointer];
            while (!line.StartsWith("$"))
            {
                if (line.StartsWith("dir"))
                {
                    var folderInfo = line.Split(" ");
                    string name = folderInfo[1];
                    currentFolder.AddSubFolder(name);
                }
                else
                {
                    var fileInfo = line.Split(" ");
                    int size = int.Parse(fileInfo[0]);
                    string name = fileInfo[1];
                    currentFolder.AddFile(name, size);
                }
                instPointer++;
                if (instPointer >= memory.Count)
                    break;
                line = memory[instPointer];
            }
        }

        private static void GoHome()
        {
            currentFolder = homeFolder;
        }

        private static void GoParentFolder()
        {
            currentFolder = currentFolder.GetParentFolder();
        }

        private static void GoSubFolder(string name)
        {
            currentFolder = currentFolder.GetSubFolder(name);
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day, true);
            int result = 0;

            InitializeFolders();

            int totalSpace = 70000000;
            int spaceUsed = homeFolder.GetTotalSize();
            int freeSpace = totalSpace - spaceUsed;
            int spaceNeeded = 30000000;
            int spaceMissing = spaceNeeded - freeSpace;

            List<TreeFolder> allFolders = new();
            homeFolder.GetFolderAndSubFolders(allFolders);

            List<TreeFolder> folderCandidates = new();
            foreach (var folder in allFolders)
            {
                int size = folder.TotalSize;
                if (size > spaceMissing)
                    folderCandidates.Add(folder);
            }

            result = folderCandidates.OrderBy(x => x.TotalSize).ToList()[0].TotalSize;

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }
    }
}
