using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Day8Helper
{
    class SegmentDisplay
    {
        public char Top_VeryImportant = ' ';
        public char TopLeft = ' ';
        public char TopRight = ' ';
        public char Middle = ' ';
        public char BottomLeft = ' ';
        public char BottomRight = ' ';
        public char Bottom = ' ';

        public SegmentDisplay(List<string> input)
        {
            string possibleOne = input.Where(x => x.Length == 2).ToList()[0];
            string possibleFour = input.Where(x => x.Length == 4).ToList()[0];
            string possibleSeven = input.Where(x => x.Length == 3).ToList()[0];
            string possibleEigth = input.Where(x => x.Length == 7).ToList()[0];
            List<char> possibleMid_TopLeft_Useless = possibleFour.Except(possibleOne).ToList();

            // Valuable!
            Top_VeryImportant = possibleSeven.Except(possibleOne).ToList()[0];

            List<string> segmentsWithSix = input.Where(x => x.Length == 6).ToList();
            List<string> segmentsWithFive = input.Where(x => x.Length == 5).ToList();

            List<string> FindBottomLeft = NewListWithExtraElement(segmentsWithSix, possibleFour);
            BottomLeft = GetLeastOccurringLetter(GetAllCharsFromStringLists(FindBottomLeft));

            List<string> findMiddle = NewListWithExtraElement(segmentsWithSix, possibleOne);
            Middle = GetLeastOccurringLetter(GetAllCharsFromStringLists(findMiddle), new List<char>() { BottomLeft });

            List<string> findTopRight = NewListWithExtraElement(segmentsWithSix, null);
            TopRight = GetLeastOccurringLetter(GetAllCharsFromStringLists(findTopRight), new List<char>() { BottomLeft, Middle });

            BottomRight = possibleOne.Except(new List<char>() { TopRight }).ToList()[0];

            TopLeft = GetLeastOccurringLetter(GetAllCharsFromStringLists(segmentsWithFive), new List<char>() { TopRight, Middle, BottomLeft, BottomRight });

            Bottom = GetLeastOccurringLetter(possibleEigth, new List<char>() { Top_VeryImportant, TopRight, Middle, BottomLeft, BottomRight, TopLeft });
        }

        public int GetValue(string input)
        {


            return 0;
        }

        private List<string> NewListWithExtraElement(List<string> list, string element)
        {
            string[] newArray = new string[list.Count];
            list.CopyTo(newArray);
            List<string> newList = newArray.ToList();
            if (element is not null)
                newList.Add(element);

            return newList;
        }


        private string GetAllCharsFromStringLists(List<string> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        private char GetLeastOccurringLetter(string input, List<char> presets = null)
        {
            Dictionary<char, int> options = new Dictionary<char, int>();
            if (presets is not null)
            {
                for (int i = 0; i < presets.Count; i++)
                {
                    if (options.ContainsKey(presets[i]))
                        options[presets[i]]++;
                    else
                        options.Add(presets[i], 50);
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (options.ContainsKey(input[i]))
                    options[input[i]]++;
                else
                    options.Add(input[i], 0);
            }
            return options.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
        }
    }
}
