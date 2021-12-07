using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Year2020.Day4Helper
{
    enum fieldType
    {
        byr,
        iyr,
        eyr,
        hgt,
        hcl,
        ecl,
        pid,
        cid
    }

    class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }

        public Passport(string input)
        {
            string singleLine = FormatPassportToLine(input);
            List<string> fields = singleLine.Split(' ').ToList();

            foreach (var field in fields)
            {
                SetProperties(field);
            }
        }

        private void SetProperties(string field)
        {
            List<string> fieldKeyValuePair = field.Split(':').ToList();
            switch (fieldKeyValuePair[0])
            {
                case "byr":
                    SetBirthYear(fieldKeyValuePair[1]);
                    break;
                case "iyr":
                    SetIssueYear(fieldKeyValuePair[1]);
                    break;
                case "eyr":
                    SetExpirationYear(fieldKeyValuePair[1]);
                    break;
                case "hgt":
                    Height = fieldKeyValuePair[1];
                    break;
                case "hcl":
                    HairColor = fieldKeyValuePair[1];
                    break;
                case "ecl":
                    EyeColor = fieldKeyValuePair[1];
                    break;
                case "pid":
                    PassportID = fieldKeyValuePair[1];
                    break;
                case "cid":
                    CountryID = fieldKeyValuePair[1];
                    break;
            }
        }

        private void SetHeight(string height)
        {

        }

        private void SetBirthYear(string year)
        {
            bool parsed = int.TryParse(year, out int yearInt);
            if (YearIsValid(yearInt, 1920, 2002) && parsed)
                BirthYear = year;
        }

        private void SetIssueYear(string year)
        {
            bool parsed = int.TryParse(year, out int yearInt);
            if (YearIsValid(yearInt, 2010, 2020) && parsed)
                BirthYear = year;
        }

        private void SetExpirationYear(string year)
        {
            bool parsed = int.TryParse(year, out int yearInt);
            if (YearIsValid(yearInt, 2020, 2030) && parsed)
                BirthYear = year;
        }

        private bool YearIsValid(int input, int lowerBound, int upperBound)
        {
            return input >= lowerBound && input <= upperBound;
        }

        private string FormatPassportToLine(string input)
        {
            StringBuilder sb = new StringBuilder();
            string[] inputs = input.Split("\r\n");
            foreach (var item in inputs)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
