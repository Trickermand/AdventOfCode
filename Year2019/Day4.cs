using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2019
{
    public static class Day4
    {
        public static string Part1()
        {
            List<int> successDigits = new List<int>();
            for (int i = 347312; i < 805915; i++)
            {
                List<int> digits = SplitIntToDigits(i);
                if (CheckNumber(digits))
                {
                    successDigits.Add(i);
                }
            }

            return successDigits.Count.ToString();
        }

        public static string Part2()
        {
            List<int> successDigits = new List<int>();
            for (int i = 347312; i < 805915; i++)
            {
                List<int> digits = SplitIntToDigits(i);
                if (CheckNumberPart2(digits))
                {
                    successDigits.Add(i);
                }
            }

            return successDigits.Count.ToString();
        }

        private static bool CheckNumberPart2(List<int> digits)
        {
            bool b = CheckNumberHasPreciselyTwoConcurrentNumber(digits);
            if (CheckNumberIsAscending(digits) && CheckNumberHasPreciselyTwoConcurrentNumber(digits))
                return true;
            else
                return false;
        }

        private static bool CheckNumber(List<int> digits)
        {
            if (CheckNumberIsAscending(digits) && CheckNumberHasConcurrentNumbers(digits))
                return true;
            else
                return false;
        }

        private static bool CheckNumberHasPreciselyTwoConcurrentNumber(List<int> digits)
        {
            List<int> candidates = new List<int>();
            for (int i = 0; i < digits.Count - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                {
                    candidates.Add(digits[i]);
                }
            }

            for (int i = 0; i < candidates.Count; i++)
            {
                if (digits.Count(x => x == candidates[i]) == 2)
                {
                    return true;
                }
            }
            
            return false;
        }

        private static bool CheckNumberHasConcurrentNumbers(List<int> digits)
        {
            for (int i = 0; i < digits.Count - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckNumberIsAscending(List<int> digits)
        {
            int lastNum = digits[0];
            for (int i = 1; i < digits.Count; i++)
            {
                if (digits[i] < lastNum)
                {
                    return false;
                }
                lastNum = digits[i];
            }
            return true;
        }

        private static List<int> SplitIntToDigits(int num)
        {
            List<int> digits = new List<int>();
            int tmpNum = num;

            while (tmpNum % 10 > 0.9 || (tmpNum % 10 == 0 && tmpNum > 0))
            {
                if (tmpNum % 10 == 0)
                {
                    digits.Add(0);
                }
                else
                {
                    digits.Add(tmpNum % 10);
                }
                tmpNum /= 10;
            }
            digits.Reverse();
            return digits;
        }

    }
}
