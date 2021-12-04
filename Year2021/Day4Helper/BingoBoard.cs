using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Day4Helper
{
    public class BingoBoard
    {
        public BingoCell[][] Board { get; set; }
        public bool IsBingo{ get; private set; }
        public BingoBoard(List<string> inputBoard)
        {
            BingoCell[][] tmp = new BingoCell[5][];

            for (int i = 0; i < inputBoard.Count; i++)
            {
                List<string> inputLine = inputBoard[i].Split(' ').Where(x => x != "").ToList();
                tmp[i] = new BingoCell[5];

                for (int j = 0; j < inputLine.Count; j++)
                {
                    int num = int.Parse(inputLine[j]);
                    tmp[i][j] = new BingoCell(num);
                }
            }

            Board = tmp;
        }

        public void SetCell(int num)
        {
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < Board[i].Length; j++)
                {
                    if (Board[i][j].Number == num)
                    {
                        Board[i][j].IsHit = true;
                        IsBingo = CheckIfBingo(i, j);
                    }
                }
            }
        }

        private bool CheckIfBingo(int columnNum, int rowNum)
        {
            return CheckIfColumnBingo(columnNum) || CheckIfRowBingo(rowNum);
        }

        private bool CheckIfColumnBingo(int colNum)
        {
            for (int i = 0; i < Board[colNum].Length; i++)
            {
                if (!Board[colNum][i].IsHit)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckIfRowBingo(int rowNum)
        {
            for (int i = 0; i < Board.Length; i++)
            {
                if (!Board[i][rowNum].IsHit)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
