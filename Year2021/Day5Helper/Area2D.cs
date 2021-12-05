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

        public void IncrementCellStraightLines(Point start, Point end)
        {
            if (start.X != end.X && start.Y != end.Y)
            {
                return;
            }
            else if (start.X != end.X)
            {
                int lowest = start.X < end.X ? start.X : end.X;
                int highest = start.X > end.X ? start.X : end.X;

                for (int i = lowest; i <= highest; i++)
                {
                    Area[start.Y][i]++; 
                }
            }
            else
            {
                int lowest = start.Y < end.Y ? start.Y : end.Y;
                int highest = start.Y > end.Y ? start.Y : end.Y;

                for (int i = lowest; i <= highest; i++)
                {
                    Area[i][start.X]++;
                }
            }


        }


    }
}
