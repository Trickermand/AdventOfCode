using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2019
{
    public static class Day1
    {
        public static int Part1()
        {
            List<string> moduleMasses = Utilities.ReadInputAsListStrings(Path.Combine(Environment.CurrentDirectory, $"..\\..\\..\\Inputs\\Day1.txt"));

            int totalFuelNeeded = 0;

            foreach (var moduleMass in moduleMasses)
            {
                totalFuelNeeded += (int.Parse(moduleMass) / 3) - 2;
            }
            return totalFuelNeeded;
        }

        public static int Part2()
        {
            List<string> moduleMasses = Utilities.ReadInputAsListStrings(Path.Combine(Environment.CurrentDirectory, $"..\\..\\..\\Inputs\\Day1.txt"));

            int totalFuelNeeded = 0;

            foreach (var moduleMass in moduleMasses)
            {
                int totalModuleFuel = 0;
                int fuel = CalculateFuel(int.Parse(moduleMass));
                while (fuel > 0)
                {
                    totalModuleFuel += fuel;
                    fuel = CalculateFuel(fuel);
                }
                totalFuelNeeded += totalModuleFuel;
            }

            int CalculateFuel(int mass)
            {
                return mass / 3 - 2;
            }

            return totalFuelNeeded;
        }
    }
}
