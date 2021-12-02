using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021
{
    public enum Direction
    {
        forward,
        down,
        up
    }

    public static class Day2
    {
        public static void Part1()
        {
            List<string> inputs = Utilities.ReadInput("Day2");

            int horizontalPos = 0;
            int depth = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                string[] currentLine = inputs[i].Split(' ');
                Direction direction = currentLine[0] == "forward" ? Direction.forward : currentLine[0] == "down" ? Direction.down : Direction.up;
                int distance = int.Parse(currentLine[1]);

                switch (direction)
                {
                    case Direction.forward:
                        horizontalPos += distance;
                        break;
                    case Direction.down:
                        depth += distance;
                        break;
                    case Direction.up:
                        depth -= distance;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Day2 part 1 answer: {horizontalPos * depth}");
        }


        public static void Part2()
        {
            List<string> inputs = Utilities.ReadInput("Day2");

            int horizontalPos = 0;
            int depth = 0;
            int aim = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                string[] currentLine = inputs[i].Split(' ');
                Direction direction = currentLine[0] == "forward" ? Direction.forward : currentLine[0] == "down" ? Direction.down : Direction.up;
                int distance = int.Parse(currentLine[1]);

                switch (direction)
                {
                    case Direction.forward:
                        horizontalPos += distance;
                        depth += aim * distance;
                        break;
                    case Direction.down:
                        aim += distance;
                        break;
                    case Direction.up:
                        aim -= distance;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Day2 part 2 answer: {horizontalPos * depth}");
        }
    }
}
