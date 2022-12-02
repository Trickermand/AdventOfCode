using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2022
{
    public static class Day2
    {
        public enum choice
        {
            none = 0,
            rock = 1,
            paper = 2,
            scissors = 3
        }

        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            foreach (var line in inputs)
            {
                var match = ParseInputToRps(line);
                var points = CalculateMatchPoints(match.opponent, match.me);

                result += points.mePoints;
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(MethodBase.GetCurrentMethod().DeclaringType.Name);
            int result = 0;

            foreach (var line in inputs)
            {
                var match = ParseInputToRps(line);
                var points = CalculateMatchPointsPart2(match.opponent, match.me);

                result += points.mePoints;
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static (int oppnentPoints, int mePoints) CalculateMatchPoints(choice opponent, choice me)
        {
            int opponentPoints = (int)opponent;
            int mePoints = (int)me;

            if (opponent == me)
            {
                opponentPoints += 3;
                mePoints += 3;
                return (opponentPoints, mePoints);
            }

            if (opponent == choice.rock)
            {
                if (me == choice.scissors)
                    opponentPoints += 6;
                else if (me == choice.paper)
                    mePoints += 6;
            }
            else if (opponent == choice.paper)
            {
                if (me == choice.rock)
                    opponentPoints += 6;
                else if (me == choice.scissors)
                    mePoints += 6;
            }
            else if (opponent == choice.scissors)
            {
                if (me == choice.paper)
                    opponentPoints += 6;
                else if (me == choice.rock)
                    mePoints += 6;
            }

            return (opponentPoints, mePoints);
        }

        private static (choice opponent, choice me) ParseInputToRps(string input)
        {
            string[] chars = input.Split(' ');

            return (parseRsp(chars[0]), parseRsp(chars[1]));

            choice parseRsp(string inp)
            {
                switch (inp)
                {
                    case "A":
                    case "X":
                        return choice.rock;
                    case "B":
                    case "Y":
                        return choice.paper;
                    case "C":
                    case "Z":
                        return choice.scissors;
                    default:
                        return choice.none;
                }
            }
        }

        private static (int oppnentPoints, int mePoints) CalculateMatchPointsPart2(choice opponent, choice me)
        {
            if (opponent == choice.rock)
            {
                if (me == choice.rock)
                    me = choice.scissors;
                else if (me == choice.paper)
                    me = choice.rock;
                else if (me == choice.scissors)
                    me = choice.paper;
            }
            else if (opponent == choice.paper)
            {

            }
            else if (opponent == choice.scissors)
            {
                if (me == choice.rock)
                    me = choice.paper;
                else if (me == choice.paper)
                    me = choice.scissors;
                else if (me == choice.scissors)
                    me = choice.rock;
            }

            return CalculateMatchPoints(opponent, me);
        }
    }
}
