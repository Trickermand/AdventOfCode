using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;
using Year2021.Day4Helper;

namespace Year2021
{
    public static class Day4
    {
        public static string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void Part1()
        {
            List<string> inputs = IO.ReadInput(Day);

            List<int> bingoNumbers = IO.ConvertStringListToIntList(inputs[0].Split(',').ToList());
            List<BingoBoard> boards = GetBingoBoards(inputs, 2);
            


            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: ");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: ");
        }

        private static List<BingoBoard> GetBingoBoards(List<string> inputs, int startIndex)
        {
            List<BingoBoard> boards = new List<BingoBoard>();
            List<string> currentBoardString = new List<string>();

            for (int i = startIndex; i < inputs.Count; i++)
            {
                if (inputs[i] == "")
                {
                    BingoBoard currentBoard = new BingoBoard(currentBoardString);
                    boards.Add(currentBoard);
                    currentBoardString.Clear();
                    continue;
                }
                currentBoardString.Add(inputs[i]);
            }
            return boards;
        }
    }
}
