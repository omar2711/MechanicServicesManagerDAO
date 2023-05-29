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
        public static bool IsOnlyLetters(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static string EraseSpaces(string text)
        {
            string newText = text.TrimEnd();
            newText = newText.TrimStart();

            string cadenaConEspacios = newText;
            string cadenaSinEspaciosNoSpace = Regex.Replace(cadenaConEspacios, @"\s+", " ").Trim();


            return cadenaSinEspaciosNoSpace;
        }

        //create a method to erase inner spaces from a text 

        public static bool isOnlyNumber(string text)
        {
            foreach(char c in text)
            {
                if (!char.IsLetter(c) && !char.IsSymbol(c))
                {
                    return true;
                }
            }
            return false;
        }




        public static bool IsOnlyDecimalNumbers(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsOnlyPositiveNumbers(string text)
        {
            double num = double.Parse(text);

            if ((num - double.Parse(text)) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool IsValidEmail(string text)
        {
            if (text.Contains("@") && text.Contains(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsvalidCi(string text)
        {
            foreach (char c in text)
            {
                foreach (char sc in specialCharactersCI)
                {
                    if (c == sc)
                    {
                        return false;
                    }
                }
            }
            return true;


        }
               


        public static bool IsOnlyPositiveIntNumbers(string text)
        {
            double num = double.Parse(text);
            if ((num - double.Parse(text)) == 0)
            {
                foreach (char c in text)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static char[] specialCharactersCI = { '!', '"', '#', '$', '%', '&', '/', '(', ')', '=', '?', '¡', '¿', '*', '+', '_', '^', '`', '{', '}', '[', ']', ';', ':', '.', ',', '<', '>', '|', '~', '@' };


        public static char[] specialCharacters = { '!', '"', '#', '$', '%', '&', '/', '(', ')', '=', '?', '¡', '¿', '*', '+', '-', '_', '^', '`', '{', '}', '[', ']', ';', ':', '.', ',', '<', '>', '|', '~', '@' };

        public static bool ContainsSpecialCharacters(string text)
        {
            foreach (char c in text)
            {
                foreach (char sc in specialCharacters)
                {
                    if (c == sc)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsOnlyLettersAndNumbers(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetterOrDigit(c) || !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
