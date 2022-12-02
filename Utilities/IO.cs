using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Utilities
{
    public static class IO
    {
        private enum IOType
        {
            input,
            output
        }

        public static List<string> ReadInputAsLines(string day)
        {
            string path = GetPath(day, "Real");
            List<string> result = new();

            using (StreamReader reader = new(path))
            {
                while (!reader.EndOfStream)
                {
                    result.Add(reader.ReadLine());
                }
            }

            return result;
        }

        public static string ReadAllText(string day)
        {
            string path = GetPath(day, "Real");
            return File.ReadAllText(path);
        }

        public static List<int> ConvertStringListToIntList(List<string> input)
        {
            List<int> result = new(input.Count);

            foreach (var item in input)
            {
                result.Add(int.Parse(item));
            }

            return result;
        }

        public static List<T> ReadInputDelimited<T>(string day, string delimiter) where T : IComparable
        {
            string firstLine = ReadInputAsLines(day)[0];
            string[] inputs = firstLine.Split(delimiter);
            List<T> ls = new();

            for (int i = 0; i < inputs.Length; i++)
            {
                ls.Add((T)Convert.ChangeType(inputs[i], typeof(T)));
            }

            return ls;
        }

        private static string GetPath(string day, string puzzle)
        {
            var year = System.Reflection.Assembly.GetEntryAssembly().GetName().Name[^4..];

            var path = Path.Combine(Environment.CurrentDirectory, $"../../../Inputs/{day}_{puzzle}.txt");
            if (!File.Exists(path))
            {
                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create($"https://adventofcode.com/{year}/day/{day.Substring(3)}/input");
                rq.UserAgent = "https://github.com/Trickermand/AdventOfCode/tree/master/Utilities by patrickhansen2500@hotmail.com";
                rq.CookieContainer = new CookieContainer();
                Cookie cookie = new("session", File.ReadAllText("../../../../Utilities/sessionId.txt"))
                {
                    Domain = ".adventofcode.com",
                    Path = "/",
                    Expired = false,
                    HttpOnly = true
                };
                rq.CookieContainer.Add(cookie);
                HttpWebResponse resp = (HttpWebResponse)rq.GetResponse();
                using FileStream fs = new(path, FileMode.CreateNew);
                resp.GetResponseStream().CopyTo(fs);
            }
            return path;
        }
    }

}
