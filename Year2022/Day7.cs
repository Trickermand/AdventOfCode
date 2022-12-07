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
        static string currentRoot = "";

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            memory = IO.ReadInputAsLines(Day, true);
            int result = 0;

            while (instPointer < memory.Count)
            {
                if (memory[instPointer].StartsWith('$'))
                    ExecuteNextCommand();


                instPointer++;
            }

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }


        private static void ExecuteNextCommand()
        {
            if (!memory[instPointer].StartsWith('$'))
                throw new Exception("ExecuteNextCommand called but next line was not an instruction declaration.");

            string command = memory[instPointer][2..];
            if (command == "cd")
            {
                string destination = command.Split(' ')[1];
                if (destination == "/")
                    GoHome();
                else if (destination == "..")
                    GoParentFolder();
                else
                    GoSubFolder(destination);
            }
            else if (command == "ls")
            {

            }
        }

        private static void GoHome()
        {
            throw new NotImplementedException();
            currentRoot = "/";
        }

        private static void GoParentFolder()
        {
            throw new NotImplementedException();
            currentRoot = currentRoot[0..currentRoot.LastIndexOf("/")];
        }

        private static void GoSubFolder(string name)
        {
            TreeFolder folder = new(name);

        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day, true);
            int result = 0;



            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }
    }
}
