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

                int lowestX = start.X < end.X ? start.X : end.X;
                int lowestY = start.Y < end.Y ? start.Y : end.Y;
                int highestX = start.X > end.X ? start.X : end.X;
                int highestY = start.Y > end.Y ? start.Y : end.Y;
                int offset = 0;

                for (int i = lowestX; i <= highestX; i++)
                {
                    Area[lowestY + offset][lowestX + offset]++;
                    offset++;
                }
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
