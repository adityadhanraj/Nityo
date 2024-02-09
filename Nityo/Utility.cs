using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nityo
{
    internal class Utility
    {
        public static string IsStringValidDate(string? input)
        {
            if(input == null)
            {
                return "Not a valid date";
            }
            // Define the regular expression pattern
            string pattern = @"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$";

            // Check if the input matches the regular expression
            if (!Regex.IsMatch(input, pattern))
            {
                // If the input string does not match the pattern, it's not a valid date format
                return "Not a valid date";
            }

            // Parse the input string to a DateTime object
            if (!DateTime.TryParse(input, out _))
            {
                // If parsing fails, the input string is not a valid date
                return "Not a valid date";
            }
            DateTime dateOfBirth = DateTime.ParseExact(input, "yyyy-MM-dd", null);
            if(dateOfBirth > DateTime.Now)
            {
                return "Not a valid date";
            }
            var newDate = GetNextBirthday(input);
            

            // If the input string matches the pattern and can be parsed as a DateTime,
            // it is considered a valid date
            return newDate.ToString("yyyy-MM-dd");
        }
        public static DateTime GetNextBirthday(string birthdate)
        {
            // Parse the birthdate string into a DateTime object
            DateTime dateOfBirth = DateTime.ParseExact(birthdate, "yyyy-MM-dd", null);

            // Get today's date
            DateTime today = DateTime.Today;

            // Check if the birthday has already occurred this year
            DateTime currentYearBirthday = new DateTime(today.Year, dateOfBirth.Month, dateOfBirth.Day);
            if (currentYearBirthday < today)
            {
                // If the birthday has already occurred this year, add 1 year to get the next birthday
                currentYearBirthday = currentYearBirthday.AddYears(1);
            }

            return currentYearBirthday;
        }
    }
}
