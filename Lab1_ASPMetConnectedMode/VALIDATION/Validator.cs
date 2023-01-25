using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Lab1_ASPMetConnectedMode.VALIDATION
{
    //Only verification link to the input format never with the DB
    public static class Validator
    {
        // A method to validate StudentId (4-digit number)

        public static bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{4}$"))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidName(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if ((!Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i]))){
                    return false;
                }
            }
            return true;
        }
    }
}