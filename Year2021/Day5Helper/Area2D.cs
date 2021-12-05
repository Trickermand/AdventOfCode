using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Day5Helper
{
    public class Area2D
    {
        public int[][] Area { get; set; }

        public Area2D(int height, int width)
        {
            Area = new int[height][];
            for (int i = 0; i < height; i++)
            {
                Area[i] = new int[width];
            }
        }

        public void IncrementCellLines(Point start, Point end, bool avoidDiagonals)
        {
            if (start.X != end.X && start.Y != end.Y)
            {
                if (avoidDiagonals)
                    return;

                int count = Math.Abs(start.X - end.X);
                bool xPositive = start.X <= end.X;
                bool yPositive = start.Y <= end.Y;

                for (int i = 0; i <= count; i++)
                {
                    int newX = start.X + (xPositive ? i : i * -1);
                    int newY = start.Y + (yPositive ? i : i * -1);
                    Area[newY][newX]++;
                }
            }
            else if (start.X != end.X)
            {
                int count = Math.Abs(start.X - end.X);
                bool xPositive = start.X <= end.X;

                for (int i = 0; i <= count; i++)
                {
                    int newX = start.X + (xPositive ? i : i * -1);
                    Area[start.Y][newX]++; 
                }
            }
            else
            {
                int count = Math.Abs(start.Y - end.Y);
                bool yPositive = start.Y <= end.Y;

                for (int i = 0; i <= count; i++)
                {
                    int newY = start.Y + (yPositive ? i : i * -1);
                    Area[newY][start.X]++;
                }
            }
        }


    }
}
