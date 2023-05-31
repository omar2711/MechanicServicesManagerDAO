using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace mechanicDAO.Validations
{
    public class validations
    {
        public static bool IsOnlyLettersNumbers(string text)
        {
            bool containsSpecialChars = Regex.IsMatch(text, @"^[a-zA-Z0-9\s]+$");

            if (containsSpecialChars)
            {
                return false;
            }
            else return true;
        }

        public static bool IsOnlyLetters(string text)
        {
            bool containsNonLetters = Regex.IsMatch(text, @"[^a-zA-Z\s]");
            if (containsNonLetters)
            {
                return false;
            }
            else return true;

        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);

            

        }

        public static string EraseSpaces(string text)
        {
            string newText = text.TrimEnd();
            newText = newText.TrimStart();

            string cadenaConEspacios = newText;
            string cadenaSinEspaciosNoSpace = Regex.Replace(cadenaConEspacios, @"\s+", " ").Trim();


            return cadenaSinEspaciosNoSpace;
        }

        public static bool isOnlyPositiveNumbers(string text)
        {
            bool isPositiveNumber = Regex.IsMatch(text, @"^(?!-)\d+(\.\d+)?$");

            if (isPositiveNumber)
            {
                return true;
            }
            else return false;

        }

        public static bool isOnlyNumbers(string text)
        {
            bool isNumber = Regex.IsMatch(text, @"^[0-9]+$");
            if (isNumber)
            {
                return true;
            }
            else return false;
        }

        public static bool ContainsAtLeastOneLetter(string text)
        {
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
