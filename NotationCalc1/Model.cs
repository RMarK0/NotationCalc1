using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotationCalc
{
    class Model
    {
        public static double ConvertToDecimal(int sourceNotation, char[] element)
        {
            double result = 0;

            int i2 = 0;
            for (int i = element.Length - 1; i > -1; i--)
            {
                double a = Char.GetNumericValue(element[i2]);

                a *= Math.Pow(sourceNotation, i);
                result += a;
                i2++;
            }

            return result;
        }

        public static int ConvertFromDecimal(int targetNotation, char[] element)
        {
            int el = Convert.ToInt32(new string(element));
            int main = el;
            List<string> array = new List<string>();

            while (main > 0)
            {
                var lastRemainder = main % targetNotation;
                main /= targetNotation;
                array.Add(Convert.ToString(lastRemainder));
            }

            array.Reverse();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string item in array)
            {
                stringBuilder.Append(item);
            }

            if (stringBuilder.ToString() == "")
            {
                return 0;
            }
            return Convert.ToInt32(stringBuilder.ToString());
        }

        internal static double DoAction(int actionID, double first, double second)
        {
            switch (actionID)
            {
                case 0:
                    return first + second;
                case 1:
                    return first - second;
                case 2:
                    return first / second;
                case 3:
                    return first * second;
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
