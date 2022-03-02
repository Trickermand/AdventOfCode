using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Day9Helper
{
    class HeightMap
    {
        public string[] Area { get; set; }

        public HeightMap(List<string> input)
        {
            Area = new string[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                Area[i] = input[i];
            }
        }

        public bool IsLowestPoint(int i, int j)
        {
            return IsLowerThanAbove(i, j) && IsLowerThanBelow(i, j) && IsLowerThanLeft(i, j) && IsLowerThanRight(i, j);
        }

        public bool IsLowerThanAbove(int i, int j)
        {
            if (i < 1) return true;
            if (Area[i][j] < Area[i - 1][j]) return true;
            return false;
        }

        public bool IsLowerThanBelow(int i, int j)
        {
            if (i + 1 >= Area.Length) return true;
            if (Area[i][j] < Area[i + 1][j]) return true;
            return false;
        }

        public bool IsLowerThanLeft(int i, int j)
        {
            if (j < 1) return true;
            if (Area[i][j] < Area[i][j - 1]) return true;
            return false;
        }

        public bool IsLowerThanRight(int i, int j)
        {
            if (j + 1 >= Area[i].Length) return true;
            if (Area[i][j] < Area[i][j + 1]) return true;
            return false;
        }

    }
}
