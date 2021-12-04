using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Day4Helper
{
    public class BingoCell
    {
        public int Number { get; set; }
        public bool IsHit { get; set; }

        public BingoCell(int num)
        {
            Number = num;
            IsHit = false;
        }

    }
}
