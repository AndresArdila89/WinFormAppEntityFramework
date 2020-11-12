using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormAppEntityFramework.VALIDATION
{
    public static class Validation
    {
        public static bool IsValidId(string input)
        {
            if (!(Regex.IsMatch(input, @"^\d{5}$")))
            {
                return false;
            }
            return true;
        }


        public static bool IsValidName(string input)
        {
            if(!Regex.IsMatch(input, "^[a-zA-Z]*$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string input)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            if (!Regex.IsMatch(input, pattern))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidPhone(string input)
        {
            string pattern = @"^\G\(\d{3}\)\s\d{3}-\d{4}$";

            if (!Regex.IsMatch(input, pattern))
            {
                return false;
            }
            return true;
        }


    }
}
