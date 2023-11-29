using System.Text.RegularExpressions;

namespace Year2023
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("===== Running Advent of Code 2023 =====");

            RunAll();

            Console.WriteLine("Complete ...");
        }

        static void RunAll()
        {
            string namespaceName = typeof(Program).Namespace;
            var classes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace == namespaceName && Regex.IsMatch(x.Name, @"Day(\d{1}|\d{2})"));

            foreach (var day in classes)
            {
                var parts = day.GetMethods().Where(x => Regex.IsMatch(x.Name, @"Part(\d{1})"));
                foreach (var part in parts)
                {
                    part.Invoke(null, null);
                }
            }
        }
    }
}