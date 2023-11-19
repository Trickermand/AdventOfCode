using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace Year2020.Day4Helper
{
    enum FieldType
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
        private int _birthYear = -1;
        private int _issueYear = -1;
        private int _expirationYear = -1;
        private string _height = null;
        private string _hairColor = null;
        private string _eyeColor = null;
        private string _passportId = null;
        private bool _isValid = false;
        public int BirthYear { get { return _birthYear; }
            set
            {
                _birthYear = value;
                BirthYearIsValid = YearIsValid(value, 1920, 2002);
            } }
        public bool BirthYearIsValid { get; private set; } = false;
        public int IssueYear
        {
            get { return _issueYear; }
            set
            {
                _issueYear = value;
                IssueYearIsValid = YearIsValid(value, 2010, 2020);
            }
        }
        public bool IssueYearIsValid { get; private set; } = false;
        public int ExpirationYear
        {
            get { return _expirationYear; }
            set
            {
                _expirationYear = value;
                ExpirationYearIsValid = YearIsValid(value, 2020, 2030);
            }
        }
        public bool ExpirationYearIsValid { get; private set; } = false;
        public string Height
        {
            get { return _height; }
            set
            {
                _height = value;
                HeightIsValid = ValidateHeight();
            }
        }
        public bool HeightIsValid { get; private set; } = false;
        public string HairColor
        {
            get { return _hairColor; }
            set
            {
                _hairColor = value;
                HairColorIsValid = ValidatedateHairColor();
            }
        }
        public bool HairColorIsValid { get; private set; } = false;
        public string EyeColor
        {
            get { return _eyeColor; }
            set
            {
                _eyeColor = value;
                EyeColorIsValid = ValidateEyeColor();
            }
        }
        public bool EyeColorIsValid { get; private set; } = false;
        public string PassportID
        {
            get { return _passportId; }
            set
            {
                _passportId = value;
                PassportIDIsValid = ValidatePassportId();
            }
        }
        public bool PassportIDIsValid { get; private set; } = false;
        public string CountryID { get; set; }
        public bool CountryIDIsValid { get; private set; } = false;

        public Passport(string input)
        {
            List<string> cleanPassport = input.Replace("\n", " ").Split(" ").ToList();

            foreach (var field in cleanPassport)
            {
                SetProperties(field);
            }
        }

        private void SetProperties(string field)
        {
            if (string.IsNullOrEmpty(field))
                return;

            List<string> fieldKeyValuePair = field.Split(':').ToList();
            FieldType fieldType = (FieldType)Enum.Parse(typeof(FieldType), fieldKeyValuePair[0]);
            switch (fieldType)
            {
                case FieldType.byr:
                    BirthYear = int.Parse(fieldKeyValuePair[1]);
                    break;
                case FieldType.iyr:
                    IssueYear = int.Parse(fieldKeyValuePair[1]);
                    break;
                case FieldType.eyr:
                    ExpirationYear = int.Parse(fieldKeyValuePair[1]);
                    break;
                case FieldType.hgt:
                    Height = fieldKeyValuePair[1];
                    break;
                case FieldType.hcl:
                    HairColor = fieldKeyValuePair[1];
                    break;
                case FieldType.ecl:
                    EyeColor = fieldKeyValuePair[1];
                    break;
                case FieldType.pid:
                    PassportID = fieldKeyValuePair[1];
                    break;
                case FieldType.cid:
                    CountryID = fieldKeyValuePair[1];
                    break;
            }
        }

        private bool YearIsValid(int input, int lowerBound, int upperBound)
        {
            return input >= lowerBound && input <= upperBound;
        }
        
        private bool ValidateHeight()
        {
            if (Height is null)
                return false;

            if (Height.Contains("in"))
            {
                int heightIn = int.Parse(Height.Replace("in", ""));
                return heightIn >= 59 && heightIn <= 76;
            }
            else if (Height.Contains("cm"))
            {
                int heightCm = int.Parse(Height.Replace("cm", ""));
                return heightCm >= 150 && heightCm <= 193;
            }
            return false;
        }

        private bool ValidatedateHairColor()
        {
            if (HairColor is null)
                return false;

            return Regex.IsMatch(HairColor, "#(([0-9]|[a-f]){6})$") && HairColor.Length == 7;
        }

        private bool ValidateEyeColor()
        {
            if (EyeColor is null)
                return false;

            return Regex.IsMatch(EyeColor, "((amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth))$") && EyeColor.Length == 3;
        }

        private bool ValidatePassportId()
        {
            if (PassportID is null)
                return false;

            return Regex.IsMatch(PassportID, @"^\d{9}$");
        }

        public bool IsValid()
        {
            bool isValid = BirthYearIsValid
                && IssueYearIsValid
                && ExpirationYearIsValid
                && HeightIsValid
                && HairColorIsValid
                && EyeColorIsValid
                && PassportIDIsValid;

            return isValid;
        }

    }
}
