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
            BingoBoard winningBingoBoard = new BingoBoard();

            foreach (var number in bingoNumbers)
            {
                foreach (var board in boards)
                {
                    board.SetCell(number);
                    if (board.IsBingo)
                    {
                        winningBingoBoard = board;
                        winningBingoBoard.winningNumber = number;
                        goto End;
                    }
                }
            }
            End:

            int result = CalculateBingoResult(winningBingoBoard);

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);

            List<int> bingoNumbers = IO.ConvertStringListToIntList(inputs[0].Split(',').ToList());
            List<BingoBoard> boards = GetBingoBoards(inputs, 2);
            List<BingoBoard> winningBoards = new List<BingoBoard>();
            int index = 0;
            int wonBoards = 0;

            foreach (var number in bingoNumbers)
            {
                foreach (var board in boards)
                {
                    board.SetCell(number);
                    if (board.winningNumberIndex == -1 && board.IsBingo)
                    {
                        board.winningNumberIndex = index;
                        board.winningNumber = number;
                        winningBoards.Add(board);
                        wonBoards++;
                        if (wonBoards == 99)
                            goto End;
                    }
                }
                index++;
            }
            End:
            BingoBoard winningBoard = winningBoards.OrderByDescending(x => x.winningNumberIndex).First();

            int result = CalculateBingoResult(winningBoard);

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static int CalculateBingoResult(BingoBoard board)
        {
            int unhitNumbers = 0;
            foreach (var column in board.Board)
            {
                foreach (var item in column)
                {
                    if (!item.IsHit)
                        unhitNumbers += item.Number;
                }
            }
            return unhitNumbers * board.winningNumber;
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
