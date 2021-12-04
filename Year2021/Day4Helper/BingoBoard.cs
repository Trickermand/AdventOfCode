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

        public void SetCell()
        {
            throw new NotImplementedException();
        }

    }
}
