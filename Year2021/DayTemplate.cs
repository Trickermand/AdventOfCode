using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Year2021
{
    public static class DayTemplate
    {
        public static string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void Part1()
        {
            List<string> inputs = Utilities.ReadInput(Day);



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: ");
        }

        public static void Part2()
        {
            List<string> inputs = Utilities.ReadInput(MethodBase.GetCurrentMethod().DeclaringType.Name);



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: ");
        }
    }
}
