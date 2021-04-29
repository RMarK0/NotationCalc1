using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static NotationCalc.MainWindow;

namespace NotationCalc
{
    class ViewModel
    {
        public static void Calculate(char[] firstElement, char[] secondElement, int sourceNotation1,
            int sourceNotation2, int targetNotation, int actionID)
        {
            double First = Model.ConvertToDecimal(sourceNotation1, firstElement);
            double Second = Model.ConvertToDecimal(sourceNotation2, secondElement);

            double result10 = Model.DoAction(actionID, First, Second);
            AnswerBlock10.Text = "В 10-чной системе - " + result10;
            if (Math.Abs(First % Second) > 0 && actionID == 2)
            {
                AnswerBlock.Text = "Не удается получить ответ от дробного числа";
            }
            else
            {


                char[] resultArray = result10.ToString().ToCharArray();

                int result = Model.ConvertFromDecimal(targetNotation, resultArray);
                AnswerBlock.Text = $"В {targetNotation}-чной системе - " + result;
            }
        }
    }
}
