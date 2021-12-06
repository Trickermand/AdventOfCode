using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Day6Helper
{
    public class Fish
    {
        public int BirthCounter { get; set; }

        public Fish(int birthCounter)
        {
            BirthCounter = birthCounter;
        }

        public void ProgressBirthCounter()
        {
            if (BirthCounter == 0)
                BirthCounter = 6;
            else
                BirthCounter--;
        }

    }
}
