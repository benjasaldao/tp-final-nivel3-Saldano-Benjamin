using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public static class ValidationUtilities
    {
        public static bool onlyNumbers(string text)
        {
            foreach (char caracter in text)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isProductCode(string code)
        {
            if (code.Length != 3)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if(i == 0 && char.IsNumber(code[0]))
                {
                    return false;
                } else
                {
                    if (!char.IsNumber(code[i]) && i != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool validEmail(string email)
        {
            Regex emailRegex = new Regex("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");

            Match match = emailRegex.Match(email);
            if (match.Success)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
